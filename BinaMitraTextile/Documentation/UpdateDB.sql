USE [BinaMitraTextile]
GO
/****** Object:  StoredProcedure [dbo].[activity_log_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitemcheck_cleanup]

AS

BEGIN
	
	DELETE InventoryChecks WHERE InventoryChecks.id IN (
			SELECT InventoryChecks.id
			FROM InventoryChecks
				LEFT OUTER JOIN SaleItems ON SaleItems.inventory_item_id = InventoryChecks.inventory_item_id
			WHERE SaleItems.id IS NOT NULL AND SaleItems.return_id IS NULL
		)

END
GO

ALTER PROCEDURE [dbo].[CustomerTerms_update_Checked]

	@id uniqueidentifier,
	@Checked bit

AS

BEGIN

	UPDATE CustomerTerms SET Checked = @Checked WHERE id=@id

END
GO

alter PROCEDURE [dbo].[CustomerTerms_add]

	@Id uniqueidentifier,
	@Customers_Id uniqueidentifier,
	@DebtLimit decimal,
	@TermDays int,
	@Notes varchar(MAX)

AS

BEGIN

	INSERT INTO CustomerTerms(Id,Customers_Id,DebtLimit,TermDays,Notes) 
	VALUES(@Id,@Customers_Id,@DebtLimit,@TermDays,@Notes)

END
GO


alter PROCEDURE [dbo].[CustomerTerms_update]

	@Id uniqueidentifier,
	@DebtLimit decimal,
	@TermDays int,
	@Notes varchar(MAX)

AS

BEGIN

	Update CustomerTerms SET
		DebtLimit = @DebtLimit,
		TermDays = @TermDays,
		Notes = @Notes
	WHERE Id = @Id

END
GO


alter PROCEDURE [dbo].[CustomerTerms_get]

	@Id uniqueidentifier = NULL,
	@Customers_Id uniqueidentifier = NULL,
	@include_inactive bit = 0,
	@FILTER_OnlyNotChecked bit = 0

AS

BEGIN

	SELECT CustomerTerms.*,
		Customers.customer_name AS Customers_Name
	FROM CustomerTerms
		LEFT OUTER JOIN Customers ON Customers.id = CustomerTerms.Customers_Id
	WHERE 1=1
		AND (@Id IS NULL OR CustomerTerms.Id = @Id)
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND CustomerTerms.Active = 1))
		AND (@Customers_Id IS NULL OR CustomerTerms.Customers_Id = @Customers_Id)
		AND (@FILTER_OnlyNotChecked = 0 OR CustomerTerms.Checked = 0)

END
GO


alter PROCEDURE [dbo].[CustomerTerms_update_Active]

	@Id uniqueidentifier,
	@Active bit

AS

BEGIN

	UPDATE CustomerTerms SET Active = @Active WHERE Id=@Id

END
GO

alter PROCEDURE [dbo].[CustomerTerms_isExist_Customers_Id]

	@Id uniqueidentifier = NULL,
	@Customers_Id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM CustomerTerms WHERE Customers_Id = @Customers_Id AND (@Id IS NULL OR Id != @Id))
		RETURN 1
	ELSE
		RETURN 0

END
GO

ALTER PROCEDURE [dbo].[sale_getall]
	
	@date_start datetime = NULL, 
	@date_end datetime = NULL,
	@inventory_item_id uniqueidentifier = NULL, 
	@customer_id uniqueidentifier = NULL,
	@sale_id uniqueidentifier = NULL,
	@only_has_receivable bit,
	@only_loss_profit bit,
	@include_special_user_only bit,
	@returned_to_supplier bit,
	@salesman_id uniqueidentifier = NULL,	
	@productstorename_id_list AS Array READONLY,
	@color_id_list AS Array READONLY,
	@FILTER_OnlyNotCompleted bit = 0,
	@FILTER_Inventory_Code varchar(MAX) = NULL,
	@FILTER_OnlyManualAdjustment bit = 0

AS

BEGIN
 
	SELECT Sales.*, RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), Sales.barcode), 1),5) AS hexbarcode,
			Customers.customer_name AS customer_name,
			CustomerTerms.DebtLimit AS CustomerTerms_DebtLimit,
			CustomerTerms.TermDays AS CustomerTerms_TermDays,
			CustomerTerms.TermDays - DATEDIFF(day, time_stamp, CURRENT_TIMESTAMP) AS RemainingTermDays,
			Transports.name AS transport_name,
			SaleItems.sale_amount AS sale_amount,
			SaleItems.sale_qty AS sale_qty,
			SaleItems.sale_length AS sale_length,
			COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0) AS profit,
			IIF(COALESCE(SaleItems.buy_amount,0) = 0,1,(COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0)) / COALESCE(SaleItems.buy_amount,0)) * 100 AS profit_percent,
			COALESCE(CompiledPayments.payment_amount,0) AS payment_amount,
			IIF(Sales.returned_to_supplier=1,0,COALESCE(SaleItems.sale_amount,0) - COALESCE(CompiledPayments.payment_amount,0) + COALESCE(Sales.shipping_cost, 0)) AS receivable_amount,
			DATEDIFF(day, time_stamp, CURRENT_TIMESTAMP) AS days_elapsed,
			Salesman.id AS salesman_id,
			Salesman.username AS salesman_name,
			COALESCE(ReturnedItems.amount,0) AS returned_amount,
			(CASE WHEN AdjustedSaleItems.sale_id IS NOT NULL THEN 1 ELSE 0 END) AS isManualAdjustment
	FROM Sales 
		LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
		LEFT OUTER JOIN CustomerTerms ON CustomerTerms.Customers_Id = Customers.id
		LEFT OUTER JOIN Users Salesman ON Salesman.id = Customers.sales_user_id
		LEFT OUTER JOIN Transports ON Transports.id = Sales.transport_id
		LEFT OUTER JOIN (
			SELECT SaleItems.sale_id,
					SUM(Inventory.buy_price * InventoryItems.item_length) AS buy_amount,
					SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS sale_amount,
					COUNT(InventoryItems.item_length) AS sale_qty,
					SUM(InventoryItems.item_length) AS sale_length
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
				LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			GROUP BY SaleItems.sale_id
			) SaleItems ON SaleItems.sale_id = Sales.id
		LEFT OUTER JOIN (
			SELECT DISTINCT(SaleItems.sale_id)
			FROM SaleItems
			WHERE SaleItems.isManualAdjustment = 1
			) AdjustedSaleItems ON AdjustedSaleItems.sale_id = Sales.id
		LEFT OUTER JOIN (
			SELECT SaleItems.sale_id,
					SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS amount,
					COUNT(InventoryItems.item_length) AS qty,
					SUM(InventoryItems.item_length) AS length
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
				LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			WHERE SaleItems.return_id IS NOT NULL
			GROUP BY SaleItems.sale_id
			) ReturnedItems ON ReturnedItems.sale_id = Sales.id
		LEFT OUTER JOIN (SELECT Payments.ReferenceId, 
								SUM(Payments.Amount) AS payment_amount 
							FROM Payments GROUP BY Payments.ReferenceId) CompiledPayments 
		ON CompiledPayments.ReferenceId = Sales.id
	WHERE 1=1
		AND (@date_start IS NULL OR time_stamp > @date_start)
		AND (@date_end IS NULL OR time_stamp < @date_end)
		AND (@inventory_item_id IS NULL OR Sales.id IN (SELECT sale_id FROM SaleItems WHERE inventory_item_id = @inventory_item_id))
		AND (@customer_id IS NULL OR customer_id = @customer_id)
		AND (@sale_id IS NULL OR Sales.id = @sale_id)
		AND (@only_has_receivable = 0 OR (COALESCE(SaleItems.sale_amount,0) + COALESCE(Sales.shipping_cost, 0) - COALESCE(CompiledPayments.payment_amount,0) > 0 AND returned_to_supplier = 0))
		AND (@only_loss_profit = 0 OR (COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0) <= 0 AND returned_to_supplier = 0))
		AND (@include_special_user_only = 1 OR (@include_special_user_only = 0 AND special_user_only = 0))
		AND (@FILTER_OnlyNotCompleted = 0 OR Sales.completed = 0)
		AND (@FILTER_OnlyManualAdjustment = 0 OR AdjustedSaleItems.sale_id IS NOT NULL)
		AND (@FILTER_Inventory_Code IS NULL OR Sales.id IN (
					SELECT DISTINCT(SaleItems.sale_id)
					FROM SaleItems
					WHERE SaleItems.inventory_item_id IN (
							SELECT InventoryItems.id
							FROM InventoryItems 
								LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
							WHERE Inventory.code = CONVERT(INT, @FILTER_Inventory_Code)
						)
				)
			)
		AND (@returned_to_supplier = 0  OR returned_to_supplier = @returned_to_supplier)
		AND (@salesman_id IS NULL OR Customers.sales_user_id = @salesman_id)
		AND ((SELECT COUNT(value_str) FROM @productstorename_id_list) = 0 
				OR Sales.id in (
					SELECT DISTINCT(SaleItems.sale_id) 
					FROM SaleItems 
						LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
						LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
						LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
						LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
					WHERE ProductStoreNames.id IN (SELECT value_str FROM @productstorename_id_list)
						AND (@date_start IS NULL OR time_stamp > @date_start)
						AND (@date_end IS NULL OR time_stamp < @date_end)
				))
		AND ((SELECT COUNT(value_str) FROM @color_id_list) = 0 
				OR Sales.id in (
					SELECT DISTINCT(SaleItems.sale_id) 
					FROM SaleItems 
						LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
						LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
					WHERE Inventory.color_id IN (SELECT value_str FROM @color_id_list)
						AND (@date_start IS NULL OR time_stamp > @date_start)
						AND (@date_end IS NULL OR time_stamp < @date_end)
				))
END
GO








/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[activity_log_new]

	@id uniqueidentifier,
	@time_stamp datetime,
	@associated_id uniqueidentifier,
	@description varchar(MAX),
	@userID uniqueidentifier,
	@notify_role_enum_id smallint = NULL

AS

BEGIN

	INSERT INTO ActivityLog(id,time_stamp,associated_id,description,userID,notify_role_enum_id) VALUES(@id,@time_stamp,@associated_id,@description,@userID,@notify_role_enum_id)

END

GO
/****** Object:  StoredProcedure [dbo].[activitylog_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[activitylog_getall]

	@associated_id uniqueidentifier

AS

BEGIN

	SELECT ActivityLog.id, ActivityLog.time_stamp, ActivityLog.description, 
			Users.username AS username, notify_role_enum_id
	FROM ActivityLog 
			LEFT OUTER JOIN Users ON Users.id = ActivityLog.userID
	WHERE associated_id = @associated_id
	ORDER BY time_stamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[city_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Cities.id,city_name,Cities.active,Cities.state_id,
			States.state_name AS state_name, 
			city_name + ', ' + state_name AS city_and_state 
	FROM Cities 
			LEFT OUTER JOIN States ON States.id = Cities.state_id
	WHERE Cities.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[city_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_get_byFilter]

	@include_inactive bit, 
	@city_name varchar(50) = NULL,
	@state_id uniqueidentifier = NULL

AS

BEGIN

	SELECT Cities.id,city_name,Cities.active,Cities.state_id,
			States.state_name AS state_name,
			city_name + ', ' + state_name AS city_and_state 
	FROM Cities 
			LEFT OUTER JOIN States ON States.id = Cities.state_id
	WHERE 1=1
		AND (@city_name IS NULL OR Cities.city_name LIKE '%' + @city_name + '%')
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Cities.active = 1)) 
		AND (@state_id IS NULL OR Cities.state_id = @state_id)
	ORDER BY city_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[city_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_isNameExist]

	@city_name varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Cities WHERE city_name = @city_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[city_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_new]

	@id uniqueidentifier,
	@city_name varchar(50),
	@state_id uniqueidentifier

AS

BEGIN

	INSERT INTO Cities(id,city_name,state_id) VALUES(@id,@city_name,@state_id)

END

GO
/****** Object:  StoredProcedure [dbo].[city_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_update]

	@id uniqueidentifier,
	@city_name varchar(50),
	@state_id uniqueidentifier

AS

BEGIN

	UPDATE Cities SET city_name = @city_name, state_id = @state_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[city_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[city_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Cities SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[color_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Colors.* FROM Colors WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[color_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_get_byFilter]

	@include_inactive bit,  
	@color_name varchar(50) = NULL

AS

BEGIN

	SELECT Colors.* 
	FROM Colors 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Colors.active = 1)) 
		AND (@color_name IS NULL OR Colors.color_name LIKE '%' + @color_name + '%')
	ORDER BY color_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[color_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_isNameExist]

	@color_name varchar(20),
	@id uniqueidentifier = NULL, 
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Colors WHERE color_name = @color_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[color_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_new]

	@id uniqueidentifier,
	@color_name varchar(20)

AS

BEGIN

	INSERT INTO Colors(id,color_name) VALUES(@id,@color_name)

END

GO
/****** Object:  StoredProcedure [dbo].[color_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_update]

	@id uniqueidentifier,
	@color_name varchar(20)

AS

BEGIN

	UPDATE Colors SET color_name = @color_name WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[color_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Colors SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[color_update_allow2ndcolor]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_update_allow2ndcolor]

	@id uniqueidentifier,
	@new_value bit

AS

BEGIN

	UPDATE Colors SET allow_2nd_color = @new_value WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[color_update_default]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[color_update_default]

	@id uniqueidentifier

AS

BEGIN

	UPDATE Colors SET default_row = 0
	UPDATE Colors SET default_row = 1 WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[customer_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Customers.*,
		Cities.city_name AS city_name,
		States.state_name AS state_name,
		Transports.name AS default_transport_name,
		Users.username AS sales_user_name
	FROM Customers 
		LEFT OUTER JOIN Cities ON Cities.id = Customers.city_id
		LEFT OUTER JOIN States ON States.id = Cities.id
		LEFT OUTER JOIN Transports ON Transports.id = Customers.default_transport_id
		LEFT OUTER JOIN Users ON Users.id = Customers.sales_user_id
	WHERE Customers.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[customer_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_get_byFilter]

	@include_inactive bit, 
	@customer_name varchar(50) = NULL,
	@city_id uniqueidentifier = NULL,
	@default_transport_id uniqueidentifier = NULL

AS

BEGIN

	SELECT Customers.*,
		Cities.city_name AS city_name,
		States.state_name AS state_name,
		Transports.name AS default_transport_name,
		Users.username AS sales_user_name
	FROM Customers 
		LEFT OUTER JOIN Cities ON Cities.id = Customers.city_id
		LEFT OUTER JOIN States ON States.id = Cities.id
		LEFT OUTER JOIN Transports ON Transports.id = Customers.default_transport_id
		LEFT OUTER JOIN Users ON Users.id = Customers.sales_user_id
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Customers.active = 1))
		AND (@customer_name IS NULL OR Customers.customer_name LIKE '%' + @customer_name + '%')
		AND (@city_id IS NULL OR Customers.city_id = @city_id)
		AND (@default_transport_id IS NULL OR Customers.default_transport_id = @default_transport_id)
	ORDER BY customer_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[customer_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_isNameExist]

	@customer_name varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Customers WHERE customer_name = @customer_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[customer_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_new]

	@id uniqueidentifier,
	@customer_name varchar(50),
	@address varchar(100),
	@city_id uniqueidentifier,
	@default_transport_id uniqueidentifier = NULL,
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(MAX),
	@sales_user_id uniqueidentifier

AS

BEGIN

	INSERT INTO Customers(id,customer_name,address,city_id, default_transport_id,phone1,phone2,notes,sales_user_id) VALUES(@id,@customer_name,@address,@city_id,@default_transport_id,@phone1,@phone2,@notes,@sales_user_id)

END

GO
/****** Object:  StoredProcedure [dbo].[customer_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_update]

	@id uniqueidentifier,
	@customer_name varchar(50),
	@address varchar(MAX),
	@city_id uniqueidentifier,
	@default_transport_id uniqueidentifier = NULL,
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(MAX),
	@sales_user_id uniqueidentifier

AS

BEGIN

	UPDATE Customers SET customer_name = @customer_name, address = @address, city_id = @city_id, default_transport_id=@default_transport_id, phone1 = @phone1, phone2 = @phone2, notes = @notes, sales_user_id=@sales_user_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[customer_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customer_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Customers SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[customercredit_get_balance]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customercredit_get_balance]

	@customer_id uniqueidentifier 

AS

BEGIN

	SELECT COALESCE(CustomerCreditSummary.balance,0)
	FROM (	SELECT CustomerCredits.customer_id, 
					SUM(CustomerCredits.amount) AS balance 
			FROM CustomerCredits
			WHERE CustomerCredits.customer_id = @customer_id
			GROUP BY CustomerCredits.customer_id) CustomerCreditSummary
		LEFT OUTER JOIN Customers ON Customers.id = CustomerCreditSummary.customer_id

END

GO
/****** Object:  StoredProcedure [dbo].[customercredit_get_by_customer_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customercredit_get_by_customer_id]

	@customer_id uniqueidentifier,
	@hex_length tinyint

AS

BEGIN

	SELECT CustomerCredits.*,
		RIGHT(CONVERT(VARCHAR(8),CONVERT(VARBINARY(8),Sales.barcode),2),@hex_length) AS sale_barcode, 
		Sales.id AS sale_id,
		ISNULL(CustomerCredits.method_enumid, Payments.PaymentMethod_enumid) AS payment_method_enumid,
		'' AS payment_method_name,
		0 AS balance
	FROM (CustomerCredits 
		LEFT OUTER JOIN Payments ON Payments.id = CustomerCredits.sale_payment_id
		) LEFT OUTER JOIN Sales ON Sales.id = Payments.ReferenceId
	WHERE CustomerCredits.customer_id = @customer_id
	ORDER BY CustomerCredits.time_stamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[customercredit_get_summary]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customercredit_get_summary]

	@FILTER_onlyHasActivityLast3Months bit

AS

BEGIN

	SELECT CustomerCreditSummary.customer_id, CustomerCreditSummary.balance, 
		Customers.customer_name
	FROM (	SELECT CustomerCredits.customer_id, 
					SUM(CustomerCredits.amount) AS balance 
			FROM CustomerCredits
			WHERE 1=1
				AND (@FILTER_onlyHasActivityLast3Months = 0 OR CustomerCredits.customer_id IN (
						SELECT DISTINCT(CustomerCredits.customer_id) FROM CustomerCredits WHERE DATEDIFF(DAY,CustomerCredits.time_stamp, CURRENT_TIMESTAMP) < 180 )
					)
			GROUP BY CustomerCredits.customer_id) CustomerCreditSummary
		LEFT OUTER JOIN Customers ON Customers.id = CustomerCreditSummary.customer_id
	ORDER BY Customers.customer_name ASC
END

GO
/****** Object:  StoredProcedure [dbo].[customercredit_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customercredit_new]

	@id uniqueidentifier,
	@customer_id uniqueidentifier, 
	@amount decimal(11,2),
	@notes varchar(MAX),
	@user_id uniqueidentifier,
	@sale_payment_id uniqueidentifier,
	@method_enumid tinyint

AS

BEGIN

	INSERT INTO CustomerCredits(id,customer_id,time_stamp,amount,notes,user_id,sale_payment_id,method_enumid) 
	VALUES(@id,@customer_id,CURRENT_TIMESTAMP,@amount,@notes,@user_id,@sale_payment_id,@method_enumid)

END

GO
/****** Object:  StoredProcedure [dbo].[customercredit_update_Confirmed]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customercredit_update_Confirmed]

	@id uniqueidentifier,
	@Confirmed bit

AS

BEGIN

	UPDATE CustomerCredits SET Confirmed = @Confirmed WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_add]

	@customer_id uniqueidentifier,
	@id uniqueidentifier,
	@product_store_name_id uniqueidentifier,
	@grade_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier = NULL,
	@adjustment_per_unit decimal,
	@notes varchar(MAX) = NULL

AS

BEGIN

	INSERT INTO CustomerSaleAdjustments(id,customer_id,product_store_name_id,grade_id,product_width_id,length_unit_id,color_id,adjustment_per_unit,notes) 
	VALUES(@id,@customer_id,@product_store_name_id,@grade_id,@product_width_id,@length_unit_id,@color_id,@adjustment_per_unit,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_delete]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_delete]

	@id uniqueidentifier

AS

BEGIN

	DELETE FROM CustomerSaleAdjustments WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_get]

	@id uniqueidentifier

AS

BEGIN
 
	SELECT CustomerSaleAdjustments.*,
			Customers.customer_name AS customer_name,
			ProductStoreNames.id AS store_name_id,
			ProductStoreNames.name AS store_name,
			ProductWidths.product_width_name AS width_name,
			LengthUnits.length_unit_name AS length_unit_name, 
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name
	FROM CustomerSaleAdjustments
		LEFT OUTER JOIN Customers ON Customers.id = CustomerSaleAdjustments.customer_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = CustomerSaleAdjustments.product_store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = CustomerSaleAdjustments.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = CustomerSaleAdjustments.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = CustomerSaleAdjustments.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = CustomerSaleAdjustments.color_id
	WHERE CustomerSaleAdjustments.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_get_by_combination]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_get_by_combination]

	@customer_id uniqueidentifier = NULL,
	@product_store_name_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@return_value uniqueidentifier = NULL OUTPUT

AS

BEGIN

		SET @return_value = (SELECT MAX(id) 
				FROM CustomerSaleAdjustments 
				WHERE customer_id = @customer_id
					AND product_store_name_id = @product_store_name_id
					AND grade_id = @grade_id
					AND product_width_id = @product_width_id
					AND length_unit_id = @length_unit_id
					AND color_id = @color_id
				)

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_get_byFilter]

	@customer_id uniqueidentifier = NULL,
	@product_store_name_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@FILTER_OnlyNotChecked bit = 0

AS

BEGIN

	SELECT CustomerSaleAdjustments.*,
			Customers.customer_name AS customer_name,
			ProductStoreNames.id AS store_name_id,
			ProductStoreNames.name AS store_name,
			ProductWidths.product_width_name AS width_name,
			LengthUnits.length_unit_name AS length_unit_name, 
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name
	FROM CustomerSaleAdjustments
		LEFT OUTER JOIN Customers ON Customers.id = CustomerSaleAdjustments.customer_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = CustomerSaleAdjustments.product_store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = CustomerSaleAdjustments.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = CustomerSaleAdjustments.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = CustomerSaleAdjustments.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = CustomerSaleAdjustments.color_id
	WHERE 1=1
		AND (@customer_id IS NULL OR CustomerSaleAdjustments.customer_id = @customer_id)
		AND (@product_store_name_id IS NULL OR CustomerSaleAdjustments.product_store_name_id = @product_store_name_id)
		AND (@grade_id IS NULL OR CustomerSaleAdjustments.grade_id = @grade_id)
		AND (@product_width_id IS NULL OR CustomerSaleAdjustments.product_width_id = @product_width_id)
		AND (@length_unit_id IS NULL OR CustomerSaleAdjustments.length_unit_id = @length_unit_id)
		AND (@color_id IS NULL OR CustomerSaleAdjustments.color_id = @color_id)
		AND (@FILTER_OnlyNotChecked = 0 OR CustomerSaleAdjustments.Checked = 0)
	ORDER BY ProductStoreNames.name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_isCombinationExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_isCombinationExist]

	@id uniqueidentifier = NULL,
	@customer_id uniqueidentifier,
	@product_store_name_id uniqueidentifier = NULL, 
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@return_value uniqueidentifier = NULL OUTPUT

AS

BEGIN

	IF EXISTS	(SELECT id 
				FROM CustomerSaleAdjustments 
				WHERE (@id IS NULL OR id <> @id)
					AND customer_id = @customer_id
					AND product_store_name_id = @product_store_name_id
					AND grade_id = @grade_id
					AND product_width_id = @product_width_id
					AND length_unit_id = @length_unit_id
					AND color_id = @color_id
				)
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
/********************************************************************************************************************************************************/
ALTER PROCEDURE [dbo].[customersaleadjustment_update]

	@id uniqueidentifier,
	@customer_id uniqueidentifier,
	@product_store_name_id uniqueidentifier,
	@grade_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier = NULL,
	@adjustment_per_unit decimal,
	@notes varchar(MAX) = NULL

AS

BEGIN

	UPDATE CustomerSaleAdjustments SET
		customer_id = @customer_id,
		product_store_name_id = @product_store_name_id,
		grade_id=@grade_id,
		product_width_id=@product_width_id,
		length_unit_id=@length_unit_id,
		color_id=@color_id,
		adjustment_per_unit=@adjustment_per_unit,
		Checked=0,
		notes=@notes
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[customersaleadjustment_update_Checked]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[customersaleadjustment_update_Checked]

	@id uniqueidentifier,
	@Checked bit

AS

BEGIN

	UPDATE CustomerSaleAdjustments SET Checked = @Checked WHERE id=@id

END
GO
/****** Object:  StoredProcedure [dbo].[financial_get_overview]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[financial_get_overview] 

AS

BEGIN

	SELECT InventoryInfo.buy_value AS inventory_buy_value, 
			ReceivableInfo.amount AS receivable_amount
	FROM (
			SELECT 1 AS info_id, 
					SUM((COALESCE(items_count.item_length,0) - COALESCE(solditems_count.item_length,0)) * Inventory.buy_price) AS buy_value
			FROM Inventory
				LEFT OUTER JOIN (SELECT InventoryItems.inventory_id,
										SUM(InventoryItems.item_length) AS item_length 
								 FROM InventoryItems GROUP BY InventoryItems.inventory_id) items_count 
				ON Inventory.id = items_count.inventory_id
				LEFT OUTER JOIN (SELECT sold_inventory_items.inventory_id, 
										SUM(sold_inventory_items.item_length) AS item_length 
								 FROM SaleItems
									 LEFT OUTER JOIN InventoryItems sold_inventory_items ON sold_inventory_items.id = SaleItems.inventory_item_id
								 WHERE SaleItems.return_id IS null
								 GROUP BY sold_inventory_items.inventory_id) solditems_count 
				ON Inventory.id = solditems_count.inventory_id
			WHERE isConsignment = 0
		) InventoryInfo
		LEFT OUTER JOIN (
			SELECT 1 AS info_id, 
					SUM(IIF(Sales.returned_to_supplier=1,0,COALESCE(SaleAmount.sale_amount,0) - COALESCE(CompiledPayments.payment_amount,0) + COALESCE(Sales.shipping_cost, 0))) AS amount
			FROM (Sales 
				LEFT OUTER JOIN 
					(SELECT SaleItems.sale_id,
							SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS sale_amount,
							COUNT(InventoryItems.item_length) AS sale_qty,
							SUM(InventoryItems.item_length) AS sale_length
					FROM SaleItems
						LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
					GROUP BY SaleItems.sale_id
					) SaleAmount ON SaleAmount.sale_id = Sales.id
				) LEFT OUTER JOIN (SELECT Payments.ReferenceId, 
										SUM(Payments.Amount) AS payment_amount 
									FROM Payments GROUP BY Payments.ReferenceId) CompiledPayments 
				ON CompiledPayments.ReferenceId = Sales.id
		) ReceivableInfo ON ReceivableInfo.info_id = InventoryInfo.info_id

END


GO
/****** Object:  StoredProcedure [dbo].[gordenitem_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenitem_add]

	@id uniqueidentifier,
	@name varchar(MAX),
	@vendor_id uniqueidentifier,
	@productwidth_id uniqueidentifier,
	@category_enumid tinyint,
	@retail_lengthunit_id uniqueidentifier,
	@bulk_lengthunit_id uniqueidentifier,
	@buy_retail_priceperunit decimal(9,2) = NULL,
	@buy_bulk_priceperunit decimal(9,2) = NULL,
	@sell_retail_priceperunit decimal(9,2) = NULL,
	@sell_bulk_priceperunit decimal(9,2) = NULL,
	@notes varchar(MAX)

AS

BEGIN

	INSERT INTO GordenItems(id,name,vendor_id,productwidth_id,category_enumid,retail_lengthunit_id,bulk_lengthunit_id,buy_retail_priceperunit,buy_bulk_priceperunit,sell_retail_priceperunit,sell_bulk_priceperunit,notes) 
	VALUES(@id,@name,@vendor_id,@productwidth_id,@category_enumid,@retail_lengthunit_id,@bulk_lengthunit_id,@buy_retail_priceperunit,@buy_bulk_priceperunit,@sell_retail_priceperunit,@sell_bulk_priceperunit,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[gordenitem_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[gordenitem_get]

	@id uniqueidentifier = NULL,
	@category_enumid_list AS Array READONLY,
	@include_inactive bit,
	@name varchar(MAX) = NULL,
	@vendor_id uniqueidentifier = NULL,
	@retail_lengthunit_id uniqueidentifier = NULL,
	@bulk_lengthunit_id uniqueidentifier = NULL,
	@productwidth_id uniqueidentifier = NULL,
	@category_enumid tinyint = NULL

AS

BEGIN

	SELECT GordenItems.*,
		'' AS category_name,
		Vendors.vendor_name AS vendor_name,
		RetailLengthUnits.length_unit_name AS retail_lengthunit_name,
		BulkLengthUnits.length_unit_name AS bulk_lengthunit_name,
		ProductWidths.product_width_name AS productwidth_name,
		CAST(ProductWidths.product_width_name AS decimal(11,2))/100 AS productwidth_inmeter
	FROM GordenItems 
		LEFT OUTER JOIN Vendors ON Vendors.id = GordenItems.vendor_id
		LEFT OUTER JOIN LengthUnits RetailLengthUnits ON RetailLengthUnits.id = GordenItems.retail_lengthunit_id
		LEFT OUTER JOIN LengthUnits BulkLengthUnits ON BulkLengthUnits.id = GordenItems.bulk_lengthunit_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = GordenItems.productwidth_id
	WHERE 1=1
		AND (@id IS NULL OR GordenItems.id = @id)
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND GordenItems.active = 1)) 
		AND ((SELECT COUNT(value_int) FROM @category_enumid_list) = 0 OR GordenItems.category_enumid IN (SELECT value_int FROM @category_enumid_list))
		AND (@name IS NULL OR GordenItems.name LIKE '%' + @name + '%')
		AND (@vendor_id IS NULL OR GordenItems.vendor_id = @vendor_id)
		AND (@retail_lengthunit_id IS NULL OR GordenItems.retail_lengthunit_id = @retail_lengthunit_id)
		AND (@bulk_lengthunit_id IS NULL OR GordenItems.bulk_lengthunit_id = @bulk_lengthunit_id)
		AND (@productwidth_id IS NULL OR GordenItems.productwidth_id = @productwidth_id)
		AND (@category_enumid IS NULL OR GordenItems.category_enumid = @category_enumid)
	ORDER BY GordenItems.name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[gordenitem_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenitem_isNameExist]

	@name varchar(MAX),
	@id uniqueidentifier = NULL, 
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM GordenItems WHERE name = @name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[gordenitem_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenitem_update]

	@id uniqueidentifier,
	@name varchar(MAX),
	@vendor_id uniqueidentifier,
	@productwidth_id uniqueidentifier,
	@category_enumid tinyint,
	@retail_lengthunit_id uniqueidentifier,
	@bulk_lengthunit_id uniqueidentifier,
	@buy_retail_priceperunit decimal(9,2) = NULL,
	@buy_bulk_priceperunit decimal(9,2) = NULL,
	@sell_retail_priceperunit decimal(9,2) = NULL,
	@sell_bulk_priceperunit decimal(9,2) = NULL,
	@notes varchar(MAX)

AS

BEGIN


	UPDATE GordenItems SET 
		name=@name,
		vendor_id=@vendor_id,
		productwidth_id=@productwidth_id,
		category_enumid=@category_enumid,
		retail_lengthunit_id=@retail_lengthunit_id,
		bulk_lengthunit_id=@bulk_lengthunit_id,
		buy_retail_priceperunit=@buy_retail_priceperunit,
		buy_bulk_priceperunit=@buy_bulk_priceperunit,
		sell_retail_priceperunit=@sell_retail_priceperunit,
		sell_bulk_priceperunit=@sell_bulk_priceperunit,
		notes=@notes
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[gordenitem_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenitem_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE GordenItems SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorder_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorder_add]

	@id uniqueidentifier,
	@customer_id uniqueidentifier,
	@customer_info varchar(MAX),
	@discount_amount decimal(11,2),
	@other_charges decimal(11,2),
	@notes varchar(MAX),
	@return_value int OUTPUT

AS

BEGIN
	
	IF (SELECT COUNT(no) FROM GordenOrders) = 0
		SET @return_value = 1;
	ELSE
		SET @return_value = (SELECT MAX(no)+1 FROM GordenOrders);

	INSERT INTO GordenOrders(id,timestamp,no,customer_id,customer_info,discount_amount,other_charges,notes) 
	VALUES(@id,CURRENT_TIMESTAMP,@return_value,@customer_id,@customer_info,@discount_amount,@other_charges,@notes);

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorder_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorder_get]

	@id uniqueidentifier = NULL,
	@no int = NULL,
	@customer_id uniqueidentifier = NULL,
	@notes varchar(MAX) = NULL

AS

BEGIN

	SELECT GordenOrders.*,
		REPLACE(STR(RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), GordenOrders.no), 1),5), 5), SPACE(1), '0') AS no_hex,
		Customers.customer_name AS customer_name,
		COALESCE(GordenOrderItemGroup.amount,0) AS order_amount
	FROM GordenOrders 
		LEFT OUTER JOIN Customers ON Customers.id = GordenOrders.customer_id
		LEFT OUTER JOIN (
			SELECT GordenOrderItems.gordenorder_id, SUM(GordenOrderItems.qty * GordenOrderItems.sell_amount_perunit) AS amount
			FROM GordenOrderItems
			GROUP BY GordenOrderItems.gordenorder_id
			) GordenOrderItemGroup ON GordenOrderItemGroup.gordenorder_id = GordenOrders.id
	WHERE 1=1
		AND (@id IS NULL OR GordenOrders.id = @id)
		AND (@no IS NULL OR GordenOrders.no = @no)
		AND (@customer_id IS NULL OR GordenOrders.customer_id = @customer_id)
	ORDER BY GordenOrders.timestamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorderitem_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorderitem_add]

	@id uniqueidentifier,
	@gordenorder_id uniqueidentifier,
	@line_no tinyint,
	@description varchar(MAX),
	@sell_amount_perunit decimal(11,2),
	@qty int,
	@notes varchar(MAX)

AS

BEGIN

	INSERT INTO GordenOrderItems(id,gordenorder_id,line_no,description,sell_amount_perunit,qty,notes) 
	VALUES(@id,@gordenorder_id,@line_no,@description,@sell_amount_perunit,@qty,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorderitem_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorderitem_get]

	@is_emptytable bit = 0,
	@id uniqueidentifier = NULL,
	@gordenorder_id uniqueidentifier = NULL,
	@description varchar(MAX) = NULL,
	@notes varchar(MAX) = NULL

AS

BEGIN

	SELECT GordenOrderItems.*,
		COALESCE(GordenOrderItems.qty,0) * COALESCE(GordenOrderItems.sell_amount_perunit,0) AS subtotal
	FROM GordenOrderItems 
	WHERE 1=1
		AND (@is_emptytable = 0 OR 1=2)
		AND (@id IS NULL OR GordenOrderItems.id = @id)
		AND (@gordenorder_id IS NULL OR GordenOrderItems.gordenorder_id = @gordenorder_id)
		AND (@description IS NULL OR GordenOrderItems.description LIKE '%' + @description + '%')
		AND (@notes IS NULL OR GordenOrderItems.notes LIKE '%' + @notes + '%')
	ORDER BY GordenOrderItems.line_no ASC

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorderitemmaterial_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorderitemmaterial_add]

	@id uniqueidentifier,
	@gordenorderitem_id uniqueidentifier,
	@gordenitem_id uniqueidentifier,
	@description varchar(MAX),
	@buy_amount_perunit decimal(11,2),
	@qty int,
	@notes varchar(MAX)

AS

BEGIN

	INSERT INTO GordenOrderItemMaterials(id,gordenorderitem_id,gordenitem_id,description,buy_amount_perunit,qty,notes) 
	VALUES(@id,@gordenorderitem_id,@gordenitem_id,@description,@buy_amount_perunit,@qty,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[gordenorderitemmaterial_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[gordenorderitemmaterial_get]

	@id uniqueidentifier = NULL,
	@notes varchar(MAX) = NULL

AS

BEGIN

	SELECT GordenOrderItemMaterials.*
	FROM GordenOrderItemMaterials 
	WHERE 1=1
		AND (@id IS NULL OR GordenOrderItemMaterials.id = @id)

END

GO
/****** Object:  StoredProcedure [dbo].[grade_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,grade_name,active,default_row FROM Grades WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[grade_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_get_byFilter]

	@include_inactive bit,  
	@grade_name varchar(50) = NULL

AS

BEGIN

	SELECT id,grade_name,active,default_row 
	FROM Grades 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Grades.active = 1)) 
		AND (@grade_name IS NULL OR Grades.grade_name LIKE '%' + @grade_name + '%')
	ORDER BY grade_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[grade_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_isNameExist]

	@grade_name varchar(20), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Grades WHERE grade_name = @grade_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[grade_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_new]

	@id uniqueidentifier,
	@grade_name varchar(20)

AS

BEGIN

	INSERT INTO Grades(id,grade_name) VALUES(@id,@grade_name)

END

GO
/****** Object:  StoredProcedure [dbo].[grade_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_update]

	@id uniqueidentifier,
	@grade_name varchar(20)

AS

BEGIN

	UPDATE Grades SET grade_name = @grade_name WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[grade_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Grades SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[grade_update_default]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[grade_update_default]

	@id uniqueidentifier

AS

BEGIN

	UPDATE Grades SET default_row = 0
	UPDATE Grades SET default_row = 1 WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[inventory_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_get]

	@id uniqueidentifier 

AS

BEGIN

	SELECT Inventory.*,
			POs.po_no AS po_no,
			POItems.product_description AS po_item_description,
			ProductStoreNames.name + ': ' + Products.name_vendor AS product_name_full,
			Products.name_vendor AS product_name_vendor,
			ProductStoreNames.id AS product_store_name_id,
			ProductStoreNames.name AS product_store_name,
			Products.name_vendor AS product_name_vendor,
			Grades.id AS grade_id,
			Grades.grade_name AS grade_name,
			LengthUnits.length_unit_name AS length_unit_name,
			ProductWidths.product_width_name AS product_width_name,
			Colors.color_name AS color_name,
			Vendors.id AS vendor_id,
			VendorInvoices.invoice_no AS vendorinvoice_no,
			COALESCE(items_count.qty,0) AS qty,
			COALESCE(items_count.item_length,0) AS item_length
	FROM Inventory 
			LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
			LEFT OUTER JOIN POItems ON POItems.id = Inventory.po_item_id
			LEFT OUTER JOIN POs ON POs.id = POItems.po_id
			LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
			LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
			LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
			LEFT OUTER JOIN LengthUnits ON Inventory.length_unit_id = LengthUnits.id
			LEFT OUTER JOIN ProductWidths ON Inventory.product_width_id = ProductWidths.id
			LEFT OUTER JOIN Colors ON Inventory.color_id = Colors.id
			LEFT OUTER JOIN VendorInvoices ON VendorInvoices.id = Inventory.vendorinvoice_id
			LEFT OUTER JOIN (SELECT InventoryItems.inventory_id, 
									COUNT(InventoryItems.item_length) AS qty,
									SUM(InventoryItems.item_length) AS item_length 
								FROM InventoryItems GROUP BY InventoryItems.inventory_id) items_count 
				ON Inventory.id = items_count.inventory_id
	WHERE Inventory.id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[inventory_get_info]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_get_info]

	@grade_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@color_id uniqueidentifier,
	@product_id uniqueidentifier,
	@vendorinvoice_id uniqueidentifier = NULL

AS

BEGIN

	SELECT grade_name,
			length_unit_name,
			product_width_name,
			color_name,
			product_store_name,
			product_store_name_id,
			vendorinvoice_no
	FROM (select grade_name, 1 as info_id from Grades where id=@grade_id) GradeInfo
		LEFT OUTER JOIN (select length_unit_name, 1 as info_id from LengthUnits where id=@length_unit_id) LengthUnitInfo ON LengthUnitInfo.info_id = GradeInfo.info_id
		LEFT OUTER JOIN (select product_width_name, 1 as info_id from ProductWidths where id=@product_width_id) ProductWidthInfo ON ProductWidthInfo.info_id = GradeInfo.info_id
		LEFT OUTER JOIN (select color_name, 1 as info_id from Colors where id=@color_id) ColorInfo ON ColorInfo.info_id = GradeInfo.info_id
		LEFT OUTER JOIN (select ProductStoreNames.id AS product_store_name_id, ProductStoreNames.name AS product_store_name, 1 as info_id from Products LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id WHERE Products.id=@product_id) ProductStoreNameInfo ON ProductStoreNameInfo.info_id = GradeInfo.info_id
		LEFT OUTER JOIN (select VendorInvoices.invoice_no AS vendorinvoice_no, 1 as info_id from VendorInvoices where VendorInvoices.id = @vendorinvoice_id) VendorInvoiceInfo ON VendorInvoiceInfo.info_id = GradeInfo.info_id
END

GO
/****** Object:  StoredProcedure [dbo].[inventory_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[inventory_getall]

	@include_inactive bit, 
	@last3Months bit = 0,
	@code smallint = NULL,  
	@vendor_id uniqueidentifier = NULL,
	@vendorinvoice_id uniqueidentifier = NULL,
	@grade_id_list AS Array READONLY,
	@productstorename_id_list AS Array READONLY,
	@productwidth_id_list AS Array READONLY,
	@lengthunit_id_list AS Array READONLY,
	@color_id_list AS Array READONLY

AS

BEGIN

	SELECT 
			Inventory.*,
			POs.po_no AS po_no,
			Inventory.id AS inventory_id,
			POItems.product_description AS po_item_description,
			ProductStoreNames.name + ': ' + Products.name_vendor AS product_name_full,
			Products.name_vendor AS product_name_vendor,
			ProductStoreNames.id AS product_store_name_id,
			ProductStoreNames.name AS product_store_name,
			Products.name_vendor AS product_name_vendor,
			ISNULL(ProductPrices1.sell_price,ISNULL(ProductPrices2.sell_price, COALESCE(ProductPrices3.sell_price,0))) AS sell_price,
			Grades.id AS grade_id,
			Grades.grade_name AS grade_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,
			Colors.color_name AS color_name,
			Vendors.id AS vendor_id,
			VendorInvoices.id AS vendorinvoice_id,
			VendorInvoices.invoice_no AS vendorinvoice_no,
			COALESCE(items_count.qty,0) AS qty,
			COALESCE(items_count.item_length,0) AS item_length,
			COALESCE(solditems_count.qty,0) AS sold_qty,
			COALESCE(solditems_count.item_length,0) AS sold_item_length,
			COALESCE(items_count.qty,0) - COALESCE(solditems_count.qty,0) AS available_qty,
			COALESCE(items_count.item_length,0) - COALESCE(solditems_count.item_length,0) AS available_item_length
	FROM Inventory 
		LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
		LEFT OUTER JOIN POItems ON POItems.id = Inventory.po_item_id
		LEFT OUTER JOIN POs ON POs.id = POItems.po_id
		LEFT OUTER JOIN VendorInvoices ON VendorInvoices.id = Inventory.vendorinvoice_id
		LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN ProductPrices ProductPrices1 ON ProductPrices1.inventory_id = Inventory.id
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NOT NULL
			) ProductPrices2 ON (ProductPrices2.product_store_name_id = Products.store_name_id
								AND ProductPrices2.grade_id = Inventory.grade_id
								AND ProductPrices2.product_width_id = Inventory.product_width_id
								AND ProductPrices2.length_unit_id = Inventory.length_unit_id
								AND ProductPrices2.color_id = Inventory.color_id)
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NULL
			) ProductPrices3 ON (ProductPrices3.product_store_name_id = Products.store_name_id
								AND ProductPrices3.grade_id = Inventory.grade_id
								AND ProductPrices3.product_width_id = Inventory.product_width_id
								AND ProductPrices3.length_unit_id = Inventory.length_unit_id)
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN LengthUnits ON Inventory.length_unit_id = LengthUnits.id
		LEFT OUTER JOIN ProductWidths ON Inventory.product_width_id = ProductWidths.id
		LEFT OUTER JOIN Colors ON Inventory.color_id = Colors.id
		LEFT OUTER JOIN (SELECT InventoryItems.inventory_id, 
								COUNT(InventoryItems.item_length) AS qty,
								SUM(InventoryItems.item_length) AS item_length 
							FROM InventoryItems GROUP BY InventoryItems.inventory_id) items_count 
		ON Inventory.id = items_count.inventory_id
		LEFT OUTER JOIN (SELECT sold_inventory_items.inventory_id, 
								COUNT(sold_inventory_items.item_length) AS qty,
								SUM(sold_inventory_items.item_length) AS item_length 
							FROM SaleItems
								LEFT OUTER JOIN InventoryItems sold_inventory_items ON sold_inventory_items.id = SaleItems.inventory_item_id
							WHERE SaleItems.return_id IS null
							GROUP BY sold_inventory_items.inventory_id) solditems_count 
		ON Inventory.id = solditems_count.inventory_id
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Inventory.active = 1)) 
		AND (@last3Months = 0 OR Inventory.receive_date > DATEADD(month, -3, GETDATE()))
		AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
		AND ((SELECT COUNT(value_str) FROM @productstorename_id_list) = 0 OR ProductStoreNames.id IN (SELECT value_str FROM @productstorename_id_list))
		AND ((SELECT COUNT(value_str) FROM @productwidth_id_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @productwidth_id_list))
		AND ((SELECT COUNT(value_str) FROM @lengthunit_id_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @lengthunit_id_list))
		AND ((SELECT COUNT(value_str) FROM @color_id_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @color_id_list))
		AND (@code IS NULL OR Inventory.code = @code)
		AND (@vendor_id IS NULL OR Vendors.id = @vendor_id)
		AND (@vendorinvoice_id IS NULL OR Inventory.vendorinvoice_id = @vendorinvoice_id)
	ORDER BY code DESC

END


GO
/****** Object:  StoredProcedure [dbo].[inventory_isCodeExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_isCodeExist]

	@code smallint, 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Inventory WHERE code = @code AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[inventory_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_new]

	@id uniqueidentifier,
	@buy_price decimal(10,2),
	@grade_id uniqueidentifier,
	@product_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier,
	@notes varchar(1000),
	@po_item_id uniqueidentifier = NULL,
	@packinglist_no varchar(50),
	@vendorinvoice_id uniqueidentifier = NULL

AS

BEGIN

	IF @buy_price = 0
	BEGIN
		SELECT TOP(1) @buy_price = Inventory.buy_price
		FROM Inventory 
		WHERE Inventory.color_id = @color_id
			AND Inventory.grade_id = @grade_id
			AND Inventory.product_id = @product_id
			AND Inventory.product_width_id = @product_width_id
			AND Inventory.length_unit_id = @length_unit_id
		ORDER BY Inventory.receive_date DESC
	END

	INSERT INTO Inventory(id,code,buy_price,grade_id,product_id,product_width_id,length_unit_id,color_id,notes,receive_date,po_item_id,packinglist_no,vendorinvoice_id) 
					VALUES(@id,(SELECT MAX(code) FROM Inventory) + 1,@buy_price,@grade_id,@product_id,@product_width_id,@length_unit_id,@color_id,@notes,CURRENT_TIMESTAMP,@po_item_id,@packinglist_no,@vendorinvoice_id)

END

GO
/****** Object:  StoredProcedure [dbo].[inventory_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_update]

	@id uniqueidentifier, 
	@code smallint,
	@buy_price decimal(10,2),
	@grade_id uniqueidentifier,
	@product_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier,
	@notes varchar(1000),
	@po_item_id uniqueidentifier = NULL,
	@packinglist_no varchar(50),
	@vendorinvoice_id uniqueidentifier = NULL

AS

BEGIN

	UPDATE Inventory 
	SET code = @code, 
		buy_price = @buy_price, 
		grade_id = @grade_id, 
		product_id = @product_id, 
		product_width_id = @product_width_id, 
		length_unit_id = @length_unit_id, 
		color_id = @color_id, 
		notes = @notes,
		po_item_id = @po_item_id,
		packinglist_no = @packinglist_no,
		vendorinvoice_id = @vendorinvoice_id 
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[inventory_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventory_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Inventory SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[Inventory_update_isConsignment]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[Inventory_update_isConsignment]

	@id uniqueidentifier,
	@isConsignment bit

AS

BEGIN

	UPDATE Inventory SET isConsignment = @isConsignment WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[Inventory_update_OpnameMarker]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Inventory_update_OpnameMarker]

	@id uniqueidentifier,
	@OpnameMarker bit

AS

BEGIN

	UPDATE Inventory SET OpnameMarker = @OpnameMarker WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[Inventory_update_BuyPrice]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[Inventory_update_BuyPrice]

	@id uniqueidentifier,
	@buy_price decimal(12,2)

AS

BEGIN

	UPDATE Inventory SET buy_price = @buy_price WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitem_get]

	@id uniqueidentifier,
	@customer_id uniqueidentifier = NULL

AS  

BEGIN

	DECLARE @isManualAdjustment bit = 0

	SELECT InventoryItems.*,
			Inventory.code AS inventory_code,
			Inventory.OpnameMarker AS OpnameMarker,
			ProductWidths.product_width_name AS product_width_name, 
			ProductStoreNames.name AS product_store_name,
			ISNULL(ProductPrices1.sell_price,ISNULL(ProductPrices2.sell_price, COALESCE(ProductPrices3.sell_price,0))) AS sell_price,
			LengthUnits.length_unit_name AS length_unit_name,
			Grades.id AS Grades_Id,
			Grades.grade_name AS grade_name, 
			InventoryItemColors.color_name AS inventoryitem_color_name, 
			InventoryColors.color_name AS inventory_color_name,
			1 AS qty,
			ISNULL(AdjustmentWithColor.adjustment_per_unit, COALESCE(AdjustmentWithoutColor.adjustment_per_unit,0)) AS adjustment,
			--0.0 AS adjustment,
			0.0 AS adjusted_price,
			0.0 AS subtotal,
			@isManualAdjustment AS isManualAdjustment
	FROM InventoryItems 
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN Colors InventoryItemColors ON InventoryItemColors.id = InventoryItems.color_id
		LEFT OUTER JOIN Colors InventoryColors ON InventoryColors.id = Inventory.color_id
		LEFT OUTER JOIN ProductPrices ProductPrices1 ON ProductPrices1.inventory_id = Inventory.id
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NOT NULL
			) ProductPrices2 ON (ProductPrices2.product_store_name_id = Products.store_name_id
								AND ProductPrices2.grade_id = Inventory.grade_id
								AND ProductPrices2.product_width_id = Inventory.product_width_id
								AND ProductPrices2.length_unit_id = Inventory.length_unit_id
								AND ProductPrices2.color_id = Inventory.color_id)
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NULL
			) ProductPrices3 ON (ProductPrices3.product_store_name_id = Products.store_name_id
								AND ProductPrices3.grade_id = Inventory.grade_id
								AND ProductPrices3.product_width_id = Inventory.product_width_id
								AND ProductPrices3.length_unit_id = Inventory.length_unit_id)
		LEFT OUTER JOIN CustomerSaleAdjustments AdjustmentWithColor
			ON AdjustmentWithColor.customer_id = @customer_id
			AND AdjustmentWithColor.product_store_name_id = Products.store_name_id
			AND AdjustmentWithColor.grade_id = Inventory.grade_id
			AND AdjustmentWithColor.product_width_id = Inventory.product_width_id
			AND AdjustmentWithColor.length_unit_id = Inventory.length_unit_id
			AND AdjustmentWithColor.color_id = Inventory.color_id
		LEFT OUTER JOIN CustomerSaleAdjustments AdjustmentWithoutColor
			ON AdjustmentWithoutColor.customer_id = @customer_id
			AND AdjustmentWithoutColor.product_store_name_id = Products.store_name_id
			AND AdjustmentWithoutColor.grade_id = Inventory.grade_id
			AND AdjustmentWithoutColor.product_width_id = Inventory.product_width_id
			AND AdjustmentWithoutColor.length_unit_id = Inventory.length_unit_id
			AND AdjustmentWithoutColor.color_id IS NULL

	WHERE InventoryItems.id = @id

END



GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_get_by_inventory_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitem_get_by_inventory_id]

	@inventory_id uniqueidentifier

AS

BEGIN

	SELECT InventoryItems.*, 
			Inventory.code AS inventory_code,
			Colors.color_name AS inventoryitem_color_name,
			InventoryColors.color_name AS color_name, 
			ISNULL(ProductPrices1.sell_price,ISNULL(ProductPrices2.sell_price, COALESCE(ProductPrices3.sell_price,0))) AS sell_price,
			LengthUnits.length_unit_name AS length_unit_name, 
			SoldItems.isSold AS isSold, 
			LastOpnames.last_opname
	FROM InventoryItems 
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
		LEFT OUTER JOIN Colors ON Colors.id = InventoryItems.color_id
		LEFT OUTER JOIN Colors InventoryColors ON InventoryColors.id = Inventory.color_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN ProductPrices ProductPrices1 ON ProductPrices1.inventory_id = Inventory.id
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NOT NULL
			) ProductPrices2 ON (ProductPrices2.product_store_name_id = Products.store_name_id
								AND ProductPrices2.grade_id = Inventory.grade_id
								AND ProductPrices2.product_width_id = Inventory.product_width_id
								AND ProductPrices2.length_unit_id = Inventory.length_unit_id
								AND ProductPrices2.color_id = Inventory.color_id)
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NULL
			) ProductPrices3 ON (ProductPrices3.product_store_name_id = Products.store_name_id
								AND ProductPrices3.grade_id = Inventory.grade_id
								AND ProductPrices3.product_width_id = Inventory.product_width_id
								AND ProductPrices3.length_unit_id = Inventory.length_unit_id)
		LEFT OUTER JOIN (SELECT inventory_item_id, isSold=1 FROM SaleItems WHERE return_id IS NULL) SoldItems ON SoldItems.inventory_item_id = InventoryItems.id
		LEFT OUTER JOIN (
				SELECT InventoryChecks.inventory_item_id, MAX(InventoryChecks.time_stamp) AS last_opname
				FROM InventoryChecks 
				WHERE InventoryChecks.IgnoreSold=0
				GROUP BY InventoryChecks.inventory_item_id
			) LastOpnames ON LastOpnames.inventory_item_id = InventoryItems.id
	WHERE InventoryItems.inventory_id = @inventory_id
	ORDER BY InventoryItems.barcode ASC

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_get_forBarcodeReprint]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_get_forBarcodeReprint]
	
	@receive_start_date datetime = NULL, 
	@receive_end_date datetime = NULL

AS

BEGIN

	SELECT	InventoryItems.barcode AS barcode
	FROM InventoryItems 
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
	WHERE (@receive_start_date IS NULL OR Inventory.receive_date > @receive_start_date) 
		AND (@receive_end_date IS NULL OR Inventory.receive_date < @receive_end_date)
		AND InventoryItems.id NOT IN (SELECT SaleItems.inventory_item_id FROM SaleItems WHERE SaleItems.return_id IS NULL)
	ORDER BY InventoryItems.barcode ASC

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_get_id_by_barcode]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_get_id_by_barcode]

	@barcode varchar(10)

AS

BEGIN

	SELECT MAX(id) 
	FROM InventoryItems 
	WHERE InventoryItems.barcode = @barcode

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_get_nextsplitbarcode]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitem_get_nextsplitbarcode]

	@barcode varchar(MAX),
	@nextsplitbarcode int OUTPUT

AS

BEGIN

	SELECT @nextsplitbarcode = (ISNULL(COUNT(barcode),0)+1) FROM InventoryItems WHERE barcode LIKE @barcode + '.%'

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_isBarcodeExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_isBarcodeExist]

	@barcode varchar(10),
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM InventoryItems WHERE barcode = @barcode)
		RETURN 1
	ELSE
		RETURN 0

END

GO

/****** Object:  StoredProcedure [dbo].[inventoryitem_isBarcodeValidForSale]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_isBarcodeValidForSale]

	@barcode varchar(10), 
	@return_value bit = 0 OUTPUT

AS

BEGIN

	-- not for sale if item is in SaleItems table and the Sale was not voided
	IF EXISTS (	SELECT SaleItems.id 
				FROM SaleItems 
					LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id
				WHERE SaleItems.inventory_item_id = (SELECT MAX(InventoryItems.id) FROM InventoryItems WHERE InventoryItems.barcode = @barcode) 
					AND Sales.voided = 0 AND SaleItems.return_id IS NULL
				)
		RETURN 0
	ELSE
		RETURN 1

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_isIDExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_isIDExist]

	@id uniqueidentifier,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM InventoryItems WHERE id = @id)
		RETURN 1
	ELSE
		RETURN 0

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_new]

	@id uniqueidentifier,
	@inventory_id uniqueidentifier,
	@item_length decimal(5,2), 
	@barcode varchar(10),
	@color_id uniqueidentifier = NULL,
	@notes varchar(1000)

AS

BEGIN

	INSERT INTO InventoryItems(id,inventory_id,item_length,barcode,color_id,notes) VALUES(@id,@inventory_id,@item_length,@barcode,@color_id,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitem_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitem_update]

	@id uniqueidentifier, 
	@inventory_id uniqueidentifier,
	@item_length decimal(5,2),
	@barcode varchar(10),
	@color_id uniqueidentifier = NULL,
	@notes varchar(1000)

AS

BEGIN

	UPDATE InventoryItems SET inventory_id = @inventory_id, item_length=@item_length, barcode = @barcode, color_id = @color_id, notes = @notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_deleteIgnoreSold]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[inventoryitemcheck_deleteIgnoreSold]

AS

BEGIN

	DELETE InventoryChecks WHERE InventoryChecks.IgnoreSold = 1

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_deletetodaydata]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitemcheck_deletetodaydata]

AS

BEGIN

	DELETE InventoryChecks WHERE InventoryChecks.time_stamp >  dateadd(DAY, datediff(DAY, 0, getdate()),0)

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_get_summary]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitemcheck_get_summary]

	@date_start datetime = NULL,
	@date_end datetime = NULL,
	@Users_Id uniqueidentifier = NULL

AS

BEGIN

	SELECT Items.*,
			Inventory.*,
			ProductStoreNames.name AS product_store_name,
			Products.name_vendor AS product_name_vendor,
			Grades.grade_name AS grade_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,
			Colors.color_name AS color_name
	FROM (
			SELECT Inventory.code AS scanned_item_inventory_code,
					SUM(InventoryItems.item_length) AS total_item_length,
					COUNT(InventoryItems.barcode) AS total_item_qty
			FROM InventoryChecks 
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = InventoryChecks.inventory_item_id
				LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			WHERE 1=1
				AND (@Users_Id IS NULL OR InventoryChecks.user_id = @Users_Id)
				AND (@date_start IS NULL OR InventoryChecks.time_stamp > @date_start)
				AND (@date_end IS NULL OR InventoryChecks.time_stamp < @date_end)
			GROUP BY Inventory.code
		) Items
		LEFT OUTER JOIN Inventory ON Inventory.code = Items.scanned_item_inventory_code
		LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
		LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN LengthUnits ON Inventory.length_unit_id = LengthUnits.id
		LEFT OUTER JOIN ProductWidths ON Inventory.product_width_id = ProductWidths.id
		LEFT OUTER JOIN Colors ON Inventory.color_id = Colors.id
	ORDER BY Inventory.code ASC

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[inventoryitemcheck_getall]
	
	@date_start datetime = NULL,
	@date_end datetime = NULL,
	@Users_Id uniqueidentifier = NULL,
	@IncludeIgnoreSold bit = 0

AS

BEGIN

	SELECT	InventoryChecks.id, InventoryChecks.time_stamp,manual_input,
			Users.username AS username,
			InventoryItems.barcode AS barcode,
			InventoryItems.item_length AS item_length,
			Inventory.id AS inventory_id,
			Inventory.code AS inventory_code,
			Inventory.OpnameMarker AS OpnameMarker,
			ISNULL(ProductPrices1.sell_price,ISNULL(ProductPrices2.sell_price, COALESCE(ProductPrices3.sell_price,0))) AS sell_price,
			ProductWidths.product_width_name AS product_width_name, 
			ProductStoreNames.name AS product_store_name,
			LengthUnits.length_unit_name AS length_unit_name,
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name,
			1 AS qty,
			0 AS subtotal,
			COALESCE(items_count.qty,0) - COALESCE(solditems_count.qty,0) AS available_qty,
			COALESCE(items_count.item_length,0) - COALESCE(solditems_count.item_length,0) AS available_item_length,
			0 AS diff_qty,
			0 AS diff_length
	FROM InventoryChecks 
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = InventoryChecks.inventory_item_id
		LEFT OUTER JOIN Users ON Users.id = InventoryChecks.user_id
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id 
		LEFT OUTER JOIN ProductPrices ProductPrices1 ON ProductPrices1.inventory_id = Inventory.id
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NOT NULL
			) ProductPrices2 ON (ProductPrices2.product_store_name_id = Products.store_name_id
								AND ProductPrices2.grade_id = Inventory.grade_id
								AND ProductPrices2.product_width_id = Inventory.product_width_id
								AND ProductPrices2.length_unit_id = Inventory.length_unit_id
								AND ProductPrices2.color_id = Inventory.color_id)
		LEFT OUTER JOIN (
				SELECT ProductPrices.* FROM ProductPrices WHERE ProductPrices.color_id IS NULL
			) ProductPrices3 ON (ProductPrices3.product_store_name_id = Products.store_name_id
								AND ProductPrices3.grade_id = Inventory.grade_id
								AND ProductPrices3.product_width_id = Inventory.product_width_id
								AND ProductPrices3.length_unit_id = Inventory.length_unit_id)
		LEFT OUTER JOIN (SELECT InventoryItems.inventory_id, 
								COUNT(InventoryItems.item_length) AS qty,
								SUM(InventoryItems.item_length) AS item_length 
							FROM InventoryItems GROUP BY InventoryItems.inventory_id) items_count 
		ON Inventory.id = items_count.inventory_id
		LEFT OUTER JOIN (SELECT sold_inventory_items.inventory_id, 
								COUNT(sold_inventory_items.item_length) AS qty,
								SUM(sold_inventory_items.item_length) AS item_length 
							FROM SaleItems
								LEFT OUTER JOIN InventoryItems sold_inventory_items ON sold_inventory_items.id = SaleItems.inventory_item_id
							WHERE SaleItems.return_id IS null
							GROUP BY sold_inventory_items.inventory_id) solditems_count 
		ON Inventory.id = solditems_count.inventory_id
		LEFT OUTER JOIN (SELECT inventory_item_id, isSold=1 FROM SaleItems WHERE return_id IS NULL) SoldItems ON SoldItems.inventory_item_id = InventoryItems.id
	WHERE 1=1
		AND (@IncludeIgnoreSold = 1 OR SoldItems.isSold IS NULL)
		AND (@Users_Id IS NULL OR InventoryChecks.user_id = @Users_Id)
		AND InventoryChecks.time_stamp IN (
				SELECT FilteredInventoryChecks.time_stamp 
				FROM (	SELECT MAX(InventoryChecks.time_stamp) AS time_stamp 
						FROM InventoryChecks 
						WHERE 1=1 
								AND (@date_start IS NULL OR InventoryChecks.time_stamp > @date_start)
								AND (@date_end IS NULL OR InventoryChecks.time_stamp < @date_end)
						GROUP BY inventory_item_id) FilteredInventoryChecks)
		AND (@date_start IS NULL OR InventoryChecks.time_stamp > @date_start)
		AND (@date_end IS NULL OR InventoryChecks.time_stamp < @date_end)
	ORDER BY InventoryChecks.time_stamp DESC

END


GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_isExistToday]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventoryitemcheck_isExistToday]

	@barcode varchar(10),
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT InventoryChecks.id 
				FROM InventoryChecks 
					LEFT OUTER JOIN InventoryItems ON InventoryItems.id = InventoryChecks.inventory_item_id
				WHERE InventoryItems.barcode = @barcode 
					AND CAST(InventoryChecks.time_stamp AS DATE)  = CAST(CURRENT_TIMESTAMP AS DATE) )
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[inventoryitemcheck_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventoryitemcheck_new]

	@id uniqueidentifier,
	@BarcodeWithoutPrefix varchar(MAX),
	@user_id uniqueidentifier,
	@manual_input bit,
	@IgnoreSold bit,
	@InventoryItems_id uniqueidentifier = NULL OUTPUT,
	@opnameMarker bit = 0 OUTPUT,
	@inventory_code varchar(MAX) = '' OUTPUT,
	@item_length int = -1 OUTPUT,
	@errorcode int = 0 OUTPUT

AS

BEGIN

	SET @errorcode = 0
	DECLARE @return_value bit = 1
	
	EXECUTE @return_value = inventoryitem_isBarcodeExist @BarcodeWithoutPrefix, @return_value
	IF @return_value = 0
		SET @errorcode = 1
	IF @errorcode <> 0
		RETURN
		
	EXECUTE @return_value = inventoryitemcheck_isExistToday @BarcodeWithoutPrefix, @return_value
	IF @return_value = 1
		SET @errorcode = 2
	IF @errorcode <> 0
		RETURN
	
	EXECUTE @return_value = inventoryitem_isBarcodeValidForSale @BarcodeWithoutPrefix, @return_value
	IF @return_value = 0
		SET @errorcode = 3
	IF @errorcode <> 0
		RETURN

	SELECT 
		@InventoryItems_id = InventoryItems.id, 
		@item_length = InventoryItems.item_length,
		@opnameMarker = Inventory.OpnameMarker, 
		@inventory_code = Inventory.code
	FROM InventoryItems 
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
	WHERE InventoryItems.barcode=@BarcodeWithoutPrefix

	INSERT INTO InventoryChecks(id,inventory_item_id,time_stamp,user_id,manual_input,IgnoreSold) 
	VALUES(@id,@InventoryItems_id,CURRENT_TIMESTAMP,@user_id,@manual_input,@IgnoreSold)

END
GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventorystocklevel_add]

	@id uniqueidentifier,
	@product_id uniqueidentifier,
	@grade_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier,
	@order_lot_qty int = 0,
	@qty int = 0,
	@po_notes varchar(MAX) = NULL,
	@notes varchar(MAX) = NULL

AS

BEGIN

	INSERT INTO InventoryStockLevels(id,product_id,grade_id,product_width_id,length_unit_id,color_id,order_lot_qty,qty,po_notes,notes) 
	VALUES(@id,@product_id,@grade_id,@product_width_id,@length_unit_id,@color_id,@order_lot_qty,@qty,@po_notes,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_delete]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventorystocklevel_delete]

	@id uniqueidentifier

AS

BEGIN

	DELETE FROM InventoryStockLevels WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventorystocklevel_get]

	@id uniqueidentifier

AS

BEGIN
 
	SELECT InventoryStockLevels.*,
		ProductStoreNames.id AS store_name_id,
		ProductStoreNames.name AS store_name,
		ProductWidths.product_width_name AS width_name,
		LengthUnits.length_unit_name AS length_unit_name, 
		Grades.grade_name AS grade_name,
		Colors.color_name AS color_name,
		Vendors.vendor_name AS vendor_name,
		Vendors.id AS vendor_id
	FROM InventoryStockLevels 
		LEFT OUTER JOIN Products ON Products.id = InventoryStockLevels.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = InventoryStockLevels.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = InventoryStockLevels.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = InventoryStockLevels.grade_id
		LEFT OUTER JOIN Colors ON Grades.id = InventoryStockLevels.color_id
	WHERE InventoryStockLevels.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_get_by_combination]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventorystocklevel_get_by_combination]

	@product_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@return_value uniqueidentifier = NULL OUTPUT

AS

BEGIN

		SET @return_value = (SELECT MAX(id) 
				FROM InventoryStockLevels 
				WHERE product_id = @product_id
					AND grade_id = @grade_id
					AND product_width_id = @product_width_id
					AND length_unit_id = @length_unit_id
					AND color_id = @color_id
				)

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[inventorystocklevel_get_byFilter]

	@product_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@vendor_id uniqueidentifier = NULL,
	@status_completed tinyint,
	@status_cancelled tinyint,
	@has_neworderqty_only bit = 0

AS

BEGIN

	SELECT InventoryStockLevels.*,
			ProductStoreNames.id AS store_name_id,
			ProductStoreNames.name AS store_name,
			ProductWidths.product_width_name AS width_name,
			LengthUnits.length_unit_name AS length_unit_name, 
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name,
			Vendors.vendor_name AS vendor_name,
			LastOrdered.id AS last_order_inventory_id,
			LastOrdered.receive_date AS last_order_timestamp,
			CONVERT(INT, COALESCE(InventoryCount.total_length, 0) - COALESCE(InventorySold.total_length, 0)) AS remainingstock_qty,
			CONVERT(INT, COALESCE(Orders.pendingdelivery_length, 0)) AS pendingdelivery_qty,
			IIF(InventoryStockLevels.order_lot_qty = 0 OR InventoryStockLevels.qty - (COALESCE(InventoryCount.total_length, 0) - COALESCE(InventorySold.total_length, 0)) - COALESCE(Orders.pendingdelivery_length, 0) < 0, 0,
			CEILING((InventoryStockLevels.qty - (COALESCE(InventoryCount.total_length, 0) - COALESCE(InventorySold.total_length, 0)) - COALESCE(Orders.pendingdelivery_length, 0))/InventoryStockLevels.order_lot_qty) * InventoryStockLevels.order_lot_qty) AS new_order_qty
	FROM InventoryStockLevels
		LEFT OUTER JOIN Products ON Products.id = InventoryStockLevels.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = InventoryStockLevels.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = InventoryStockLevels.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = InventoryStockLevels.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = InventoryStockLevels.color_id
		LEFT OUTER JOIN (
				SELECT Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id,
					SUM(InventoryItems.item_length) AS total_length
				FROM InventoryItems
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id			
				WHERE InventoryItems.id NOT IN (SELECT SaleItems.inventory_item_id FROM SaleItems LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id WHERE Sales.returned_to_supplier = 1)
				GROUP BY Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id
			) InventoryCount ON InventoryCount.product_id = InventoryStockLevels.product_id
								AND  InventoryCount.product_width_id = InventoryStockLevels.product_width_id
								AND  InventoryCount.length_unit_id = InventoryStockLevels.length_unit_id
								AND  InventoryCount.color_id = InventoryStockLevels.color_id
								AND  InventoryCount.grade_id = InventoryStockLevels.grade_id
		LEFT OUTER JOIN (
				SELECT Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id,
					SUM(InventoryItems.item_length) AS total_length
				FROM SaleItems
					LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
				WHERE SaleItems.return_id is null
					AND SaleItems.inventory_item_id NOT IN (SELECT SaleItems.inventory_item_id 
															FROM SaleItems LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id 
															WHERE Sales.returned_to_supplier = 1)
				GROUP BY Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id
			) InventorySold ON InventorySold.product_id = InventoryStockLevels.product_id
								AND  InventorySold.product_width_id = InventoryStockLevels.product_width_id
								AND  InventorySold.length_unit_id = InventoryStockLevels.length_unit_id
								AND  InventorySold.color_id = InventoryStockLevels.color_id
								AND  InventorySold.grade_id = InventoryStockLevels.grade_id
		LEFT OUTER JOIN (
				SELECT Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id,
					SUM(COALESCE(POItems.qty,0) - COALESCE(ReceivedQty.total_length,0)) AS pendingdelivery_length
				FROM POItems
					LEFT OUTER JOIN Inventory ON Inventory.id = POItems.referenced_inventory_id
					LEFT OUTER JOIN (
							SELECT Inventory.po_item_id, SUM(InventoryItems.item_length) AS total_length
							FROM Inventory
								LEFT OUTER JOIN InventoryItems ON InventoryItems.inventory_id = Inventory.id
							WHERE Inventory.po_item_id IS NOT NULL
							GROUP BY Inventory.po_item_id
						) ReceivedQty ON ReceivedQty.po_item_id = POItems.id
				WHERE POItems.status_enum_id <> @status_cancelled AND POItems.status_enum_id <> @status_completed
				GROUP BY Inventory.product_id, Inventory.product_width_id, Inventory.length_unit_id, Inventory.color_id, Inventory.grade_id
			) Orders ON Orders.product_id = InventoryStockLevels.product_id
								AND  Orders.product_width_id = InventoryStockLevels.product_width_id
								AND  Orders.length_unit_id = InventoryStockLevels.length_unit_id
								AND  Orders.color_id = InventoryStockLevels.color_id
								AND  Orders.grade_id = InventoryStockLevels.grade_id
		LEFT OUTER JOIN (
				SELECT Inventory.*
				FROM Inventory 
				WHERE Inventory.receive_date IN (
						SELECT MAX(Inventory.receive_date)
						FROM Inventory
						GROUP BY product_id, product_width_id, length_unit_id, color_id, grade_id
					)
			) LastOrdered ON LastOrdered.product_id = InventoryStockLevels.product_id
								AND  LastOrdered.product_width_id = InventoryStockLevels.product_width_id
								AND  LastOrdered.length_unit_id = InventoryStockLevels.length_unit_id
								AND  LastOrdered.color_id = InventoryStockLevels.color_id
								AND  LastOrdered.grade_id = InventoryStockLevels.grade_id
	WHERE 1=1
		AND (@product_id IS NULL OR InventoryStockLevels.product_id = @product_id)
		AND (@grade_id IS NULL OR InventoryStockLevels.grade_id = @grade_id)
		AND (@product_width_id IS NULL OR InventoryStockLevels.product_width_id = @product_width_id)
		AND (@length_unit_id IS NULL OR InventoryStockLevels.length_unit_id = @length_unit_id)
		AND (@color_id IS NULL OR InventoryStockLevels.color_id = @color_id)
		AND (@vendor_id IS NULL OR Vendors.id = @vendor_id)
		AND (@has_neworderqty_only = 0 OR (@has_neworderqty_only = 1 AND 
			0 < IIF(InventoryStockLevels.qty - (COALESCE(InventoryCount.total_length, 0) - COALESCE(InventorySold.total_length, 0)) - COALESCE(Orders.pendingdelivery_length, 0) < 0, 0,
			CEILING((InventoryStockLevels.qty - (COALESCE(InventoryCount.total_length, 0) - COALESCE(InventorySold.total_length, 0)) - COALESCE(Orders.pendingdelivery_length, 0))/InventoryStockLevels.order_lot_qty) * InventoryStockLevels.order_lot_qty)))
	ORDER BY Vendors.vendor_name ASC, ProductStoreNames.name ASC, Grades.grade_name ASC, ProductWidths.product_width_name ASC, LengthUnits.length_unit_name ASC, Colors.color_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_isCombinationExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventorystocklevel_isCombinationExist]

	@id uniqueidentifier = NULL,
	@product_id uniqueidentifier = NULL, 
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@return_value uniqueidentifier = NULL OUTPUT

AS

BEGIN

	IF EXISTS	(SELECT id 
				FROM InventoryStockLevels 
				WHERE (@id IS NULL OR id <> @id)
					AND product_id = @product_id
					AND grade_id = @grade_id
					AND product_width_id = @product_width_id
					AND length_unit_id = @length_unit_id
					AND color_id = @color_id
				)
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[inventorystocklevel_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[inventorystocklevel_update]

	@id uniqueidentifier,
	@product_id uniqueidentifier,
	@grade_id uniqueidentifier,
	@product_width_id uniqueidentifier,
	@length_unit_id uniqueidentifier,
	@color_id uniqueidentifier,
	@order_lot_qty int = 0,
	@qty int = 0,
	@po_notes varchar(MAX) = NULL,
	@notes varchar(MAX) = NULL

AS

BEGIN

	UPDATE InventoryStockLevels SET
		product_id = @product_id,
		grade_id=@grade_id,
		product_width_id=@product_width_id,
		length_unit_id=@length_unit_id,
		color_id=@color_id,
		order_lot_qty=@order_lot_qty,
		qty=@qty,
		po_notes = @po_notes,
		notes=@notes
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[lengthunit_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,length_unit_name,active,default_row FROM LengthUnits WHERE id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[lengthunit_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_get_byFilter]

	@include_inactive bit,  
	@length_unit_name varchar(50) = NULL

AS

BEGIN

	SELECT id,length_unit_name,active,default_row 
	FROM LengthUnits 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND LengthUnits.active = 1)) 
		AND (@length_unit_name IS NULL OR LengthUnits.length_unit_name LIKE '%' + @length_unit_name + '%')
	ORDER BY length_unit_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[lengthunit_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_isNameExist]

	@length_unit_name varchar(50),
	@id uniqueidentifier = NULL, 
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM LengthUnits WHERE length_unit_name = @length_unit_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[lengthunit_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_new]

	@id uniqueidentifier,
	@length_unit_name varchar(20)

AS

BEGIN

	INSERT INTO LengthUnits(id,length_unit_name) VALUES(@id,@length_unit_name)

END


GO
/****** Object:  StoredProcedure [dbo].[lengthunit_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_update]

	@id uniqueidentifier,
	@length_unit_name varchar(20)

AS

BEGIN

	UPDATE LengthUnits SET length_unit_name = @length_unit_name WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[lengthunit_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE LengthUnits SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[lengthunit_update_default]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[lengthunit_update_default]

	@id uniqueidentifier

AS

BEGIN

	UPDATE LengthUnits SET default_row = 0
	UPDATE LengthUnits SET default_row = 1 WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[Payments_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Payments_add]

	@Id uniqueidentifier, 
	@ReferenceId uniqueidentifier,
	@Amount decimal(12,2) = 0,
	@PaymentMethod_enumid tinyint,
	@Notes varchar(MAX) = NULL
AS

BEGIN

	INSERT INTO Payments(Id,Timestamp,ReferenceId,Amount,PaymentMethod_enumid,Notes) 
					VALUES(@Id,CURRENT_TIMESTAMP,@ReferenceId,@Amount,@PaymentMethod_enumid,@Notes)

END

GO
/****** Object:  StoredProcedure [dbo].[Payments_getby_ReferenceId]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Payments_getby_ReferenceId]

	@ReferenceId uniqueidentifier

AS

BEGIN

	SELECT Payments.*,
		0.00 AS balance
	FROM Payments 
	WHERE ReferenceId = @ReferenceId
	ORDER BY Payments.Timestamp ASC

END

GO
/****** Object:  StoredProcedure [dbo].[Payments_update_Checked]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Payments_update_Checked]

	@id uniqueidentifier,
	@Checked bit

AS

BEGIN

	UPDATE Payments SET Checked = @Checked WHERE id=@id

	DECLARE @Sales_Id uniqueidentifier
	SELECT @Sales_Id = Payments.ReferenceId FROM Payments WHERE Payments.Id = @id;

	DECLARE @Sales_Amount decimal(11,2) = 0
	SELECT @Sales_Amount = SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length)
	FROM SaleItems 
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
	WHERE SaleItems.sale_id = @Sales_Id AND SaleItems.return_id IS NULL

	DECLARE @Shipping_Amount decimal(8,0) = 0
	SELECT @Shipping_Amount = Sales.shipping_cost
	FROM Sales
	WHERE Sales.id = @Sales_Id

	DECLARE @TotalSales decimal(11,2) = 0
	SET @TotalSales = @Shipping_Amount + @Sales_Amount

	DECLARE @TotalCheckedPaymentAmount decimal(11,2) = 0
	SELECT @TotalCheckedPaymentAmount = SUM(Payments.Amount) FROM Payments WHERE Payments.ReferenceId = @Sales_Id AND Checked=1

	IF @TotalCheckedPaymentAmount = @TotalSales
		UPDATE Sales SET Sales.completed = 1 WHERE Sales.id = @Sales_Id
	ELSE
		UPDATE Sales SET Sales.completed = 0 WHERE Sales.id = @Sales_Id

END


GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecords_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PettyCashRecords_add]

	@Id uniqueidentifier,
	@PettyCashRecordsCategories_Id uniqueidentifier,
	@Amount decimal(11,2),
	@Notes varchar(MAX)

AS

BEGIN

	-- increment last no
	DECLARE @HexLength int = 6;
	DECLARE @NewNo nvarchar(10) = RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), ISNULL(CONVERT(INT, CONVERT(VARBINARY, (SELECT MAX(No) FROM PettyCashRecords), 2)),0) + 1), 1),@HexLength)

	INSERT INTO PettyCashRecords(Id,Timestamp,PettyCashRecordsCategories_Id,Amount,Notes,No) VALUES(@Id,CURRENT_TIMESTAMP,@PettyCashRecordsCategories_Id,@Amount,@Notes,@NewNo)

END


GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecords_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecords_get]

	@Id uniqueidentifier = NULL,
	@Timestamp_Start datetime,
	@Timestamp_End datetime = NULL,
	@PettyCashRecordsCategories_Id uniqueidentifier = NULL,
	@Notes varchar(MAX),
	@FILTER_OnlyNotChecked bit = 0,
	@return_value decimal = 0 OUTPUT

AS

BEGIN

	SELECT @return_value = COALESCE(SUM(PettyCashRecords.amount),0)
	FROM PettyCashRecords
	WHERE PettyCashRecords.Timestamp < @Timestamp_Start

	SELECT PettyCashRecords.*,
		PettyCashRecordsCategories.Name AS PettyCashRecordsCategories_Name,
		0 AS Balance
	FROM PettyCashRecords 
		LEFT OUTER JOIN PettyCashRecordsCategories ON PettyCashRecordsCategories.id = PettyCashRecords.PettyCashRecordsCategories_Id
	WHERE 1=1
		AND (@Id IS NULL OR PettyCashRecords.Id = @Id)
		AND (@Timestamp_Start IS NULL OR PettyCashRecords.Timestamp > @Timestamp_Start)
		AND (@Timestamp_End IS NULL OR PettyCashRecords.Timestamp < @Timestamp_End)
		AND (@PettyCashRecordsCategories_Id IS NULL OR PettyCashRecords.PettyCashRecordsCategories_Id = @PettyCashRecordsCategories_Id)
		AND (@Notes IS NULL OR PettyCashRecords.Notes LIKE '%' + @Notes + '%')
		AND (@FILTER_OnlyNotChecked = 0 OR PettyCashRecords.IsChecked = 0)
	ORDER BY PettyCashRecords.No DESC

END


GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecords_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[PettyCashRecords_update]

	@Id uniqueidentifier,
	@PettyCashRecordsCategories_Id uniqueidentifier,
	@Amount decimal(11,2),
	@Notes varchar(MAX)

AS

BEGIN

	UPDATE PettyCashRecords 
	SET PettyCashRecordsCategories_Id = @PettyCashRecordsCategories_Id,
		Amount = @Amount,
		Notes = @Notes 
	WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecords_update_IsChecked]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecords_update_IsChecked]

	@Id uniqueidentifier,
	@IsChecked bit

AS

BEGIN

	UPDATE PettyCashRecords SET IsChecked = @IsChecked WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_add]

	@Id uniqueidentifier,
	@Name varchar(50),
	@Notes varchar(MAX)

AS

BEGIN

	INSERT INTO PettyCashRecordsCategories(Id,Name,Notes) VALUES(@Id,@Name,@Notes)

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_get]

	@Include_Inactive bit, 
	@Id uniqueidentifier,
	@Name varchar(50)

AS

BEGIN

	SELECT PettyCashRecordsCategories.* 
	FROM PettyCashRecordsCategories 
	WHERE 1=1
		AND (@Include_Inactive = 1 OR (@Include_Inactive = 0 AND PettyCashRecordsCategories.Active = 1)) 
		AND (@Id IS NULL OR Id = @Id)
		AND (@Name IS NULL OR Name = @Name)
	ORDER BY Name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_isNameExist]

	@name varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM PettyCashRecordsCategories WHERE name = @name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_update]

	@Id uniqueidentifier,
	@Name varchar(50),
	@Notes varchar(MAX)

AS

BEGIN

	UPDATE PettyCashRecordsCategories SET Name = @Name, Notes = @Notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_update_active]

	@Id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE PettyCashRecordsCategories SET Active = @new_active WHERE Id=@Id

END

GO
/****** Object:  StoredProcedure [dbo].[PettyCashRecordsCategories_update_default]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[PettyCashRecordsCategories_update_default]

	@id uniqueidentifier

AS

BEGIN

	UPDATE PettyCashRecordsCategories SET default_row = 0
	UPDATE PettyCashRecordsCategories SET default_row = 1 WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[po_add_notes]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[po_add_notes]

	@id uniqueidentifier, 
	@notes varchar(1000)

AS

BEGIN

	DECLARE @new_notes varchar(1000)

	IF NOT (SELECT NULLIF(notes, '') FROM POs WHERE id=@id) IS NULL
		BEGIN
			SET @new_notes = @notes + char(13)
		END
	ELSE
		BEGIN
			SET @new_notes = @notes
		END

	UPDATE POs SET notes = @new_notes + notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[po_get_by_filter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[po_get_by_filter]
	
	@id uniqueidentifier = NULL,
	@po_no varchar(10) = NULL,
	@vendor_id uniqueidentifier = NULL,
	@date_start datetime = NULL,
	@date_end datetime = NULL,
	@productstorename_id uniqueidentifier = NULL, 
	@vendorinvoice_no varchar(50) = NULL, 
	@packinglist_no varchar(50) = NULL,
	@po_status_completed tinyint,
	@po_status_cancelled tinyint,
	@show_incomplete_only bit = 0
	
AS

BEGIN

	SELECT POs.id, POs.time_stamp, POs.vendor_id, POs.notes, POs.target_date, POs.po_no, POs.vendor_info, POs.user_id,
		calculation.total_amount AS amount,
		'' AS status_name,
		Vendors.vendor_name AS vendor_name
	FROM POs 
		LEFT OUTER JOIN Vendors ON Vendors.id = POs.vendor_id
		LEFT OUTER JOIN (SELECT POItems.po_id, 
								SUM(COALESCE(POItems.qty,0) * COALESCE(POItems.price_per_unit,0)) AS total_amount
							FROM POItems GROUP BY POItems.po_id) calculation 
		ON calculation.po_id = POs.id
	WHERE 1=1
		AND (@id IS NULL OR POs.id = @id)
		AND (@po_no IS NULL OR POs.po_no LIKE '%' + @po_no + '%')
		AND (@vendor_id IS NULL OR POs.vendor_id = @vendor_id)
		AND (@date_start IS NULL OR POs.time_stamp > @date_start)
		AND (@date_end IS NULL OR POs.time_stamp < @date_end)
		AND (@productstorename_id IS NULL OR POs.id IN (SELECT DISTINCT(POItems.po_id) FROM POItems WHERE POItems.product_description LIKE '%' + (SELECT ProductStoreNames.name FROM ProductStoreNames WHERE ProductStoreNames.id = @productstorename_id) + '%'))
		AND (@vendorinvoice_no IS NULL OR POs.id IN (SELECT DISTINCT(POItems.po_id) FROM POItems WHERE POItems.id IN ((SELECT DISTINCT(Inventory.po_item_id) FROM Inventory WHERE Inventory.vendorinvoice_id IN (SELECT DISTINCT(VendorInvoices.id) FROM VendorInvoices WHERE VendorInvoices.invoice_no LIKE '%' + @vendorinvoice_no + '%')))))
		AND (@packinglist_no IS NULL OR POs.id IN (SELECT DISTINCT(POItems.po_id) FROM POItems WHERE POItems.id IN ((SELECT DISTINCT(Inventory.po_item_id) FROM Inventory WHERE Inventory.packinglist_no LIKE '%' + @packinglist_no + '%'))))
		AND (@show_incomplete_only = 0 OR (POs.id IN (SELECT DISTINCT(POItems.po_id) FROM POItems WHERE POItems.status_enum_id <> @po_status_completed AND POItems.status_enum_id <> @po_status_cancelled)))
	ORDER BY POs.time_stamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[po_get_nextpono]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[po_get_nextpono]
	
	@return_value varchar(10) = '' OUTPUT 

AS

BEGIN

	SELECT @return_value = ISNULL(MAX(POs.po_no), FORMAT(CURRENT_TIMESTAMP, 'yyMMdd') + '00') +1 FROM POs WHERE po_no LIKE FORMAT(CURRENT_TIMESTAMP, 'yyMMdd') + '%';

	RETURN @return_value

END

GO
/****** Object:  StoredProcedure [dbo].[po_isPONoExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[po_isPONoExist]

	@po_no varchar(10),
	@return_value bit = 0 OUTPUT 

AS

BEGIN

	IF EXISTS (SELECT id FROM POs WHERE po_no = @po_no)
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[po_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[po_new]

	@id uniqueidentifier,
	@vendor_id uniqueidentifier, 
	@vendor_info varchar(1000),
	@user_id uniqueidentifier,
	@notes varchar(1000) = NULL, 
	@target_date date,
	@po_no varchar(10)

AS

BEGIN

	INSERT INTO POs(id,time_stamp,vendor_id,vendor_info,user_id,notes,target_date,po_no) 
					VALUES(@id,CURRENT_TIMESTAMP,@vendor_id,@vendor_info,@user_id,@notes,@target_date,@po_no)

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_get_by_poid]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[poitem_get_by_poid]

	@po_id uniqueidentifier, 
	@status_completed tinyint,
	@status_cancelled tinyint  

AS

BEGIN

	SELECT POItems.*,
		POs.time_stamp AS timestamp,
		COALESCE(qty,0) * COALESCE(price_per_unit,0) AS subtotal,
		COALESCE(ReceivedInventory.total_length,0) AS received_qty,
		DATEDIFF(DAY, POs.time_stamp, CURRENT_TIMESTAMP) AS Age,
		0 AS pendingqtyvalue
	FROM POItems 
		LEFT OUTER JOIN (
				SELECT Inventory.po_item_id, SUM(InventoryItems.item_length) AS total_length
				FROM Inventory
					LEFT OUTER JOIN InventoryItems ON InventoryItems.inventory_id = Inventory.id
				WHERE Inventory.po_item_id IS NOT NULL
					AND InventoryItems.id NOT IN (SELECT inventory_item_id FROM SaleItems LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id WHERE Sales.returned_to_supplier = 1)
				GROUP BY Inventory.po_item_id
			) 
			ReceivedInventory ON ReceivedInventory.po_item_id = POItems.id
		LEFT OUTER JOIN POs ON POs.id = POItems.po_id
	WHERE po_id = @po_id 
	ORDER BY line_no ASC

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_get_byID]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[poitem_get_byID]

	@id uniqueidentifier

AS

BEGIN

	SELECT POItems.*, 
		POs.po_no AS po_no,
		POs.time_stamp AS timestamp,
		COALESCE(qty,0) * COALESCE(price_per_unit,0) AS subtotal,
		DATEDIFF(DAY, POs.time_stamp, CURRENT_TIMESTAMP) AS Age,
		0 AS pendingqty,
		0 AS pendingqtyvalue,
		NULL AS ExpectedDeliveryDayCount

	FROM POItems 
		LEFT OUTER JOIN POs ON POs.id = POItems.po_id
	WHERE POItems.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_get_incomplete]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[poitem_get_incomplete]

	@status_completed tinyint,
	@status_cancelled tinyint  

AS

BEGIN

	SELECT POItems.*,
		POs.po_no AS po_no,
		POs.time_stamp AS timestamp,
		COALESCE(qty,0) * COALESCE(price_per_unit,0) AS subtotal,
		COALESCE(ReceivedInventory.total_length,0) AS received_qty,
		DATEDIFF(DAY, POs.time_stamp, CURRENT_TIMESTAMP) AS Age,
		POItems.price_per_unit * IIF(COALESCE(qty,0) - COALESCE(ReceivedInventory.total_length,0) < 0, 0, COALESCE(qty,0) - COALESCE(ReceivedInventory.total_length,0)) AS pendingqtyvalue,
		IIF(COALESCE(qty,0) - COALESCE(ReceivedInventory.total_length,0) < 0, 0, COALESCE(qty,0) - COALESCE(ReceivedInventory.total_length,0)) AS pendingqty,
		IIF(ExpectedDeliveryDate IS NULL, NULL, DATEDIFF(day, CURRENT_TIMESTAMP, ExpectedDeliveryDate)) AS ExpectedDeliveryDayCount
	FROM POItems 
		LEFT OUTER JOIN (
				SELECT Inventory.po_item_id, SUM(InventoryItems.item_length) AS total_length
				FROM InventoryItems
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
				WHERE Inventory.po_item_id IS NOT NULL 
					AND InventoryItems.id NOT IN (SELECT inventory_item_id FROM SaleItems LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id WHERE Sales.returned_to_supplier = 1)
				GROUP BY Inventory.po_item_id
			) 
			ReceivedInventory ON ReceivedInventory.po_item_id = POItems.id
		LEFT OUTER JOIN POs ON POs.id = POItems.po_id
	WHERE POItems.status_enum_id <> @status_completed AND POItems.status_enum_id <> @status_cancelled
	ORDER BY POs.time_stamp ASC

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[poitem_new]

	@id uniqueidentifier, 
	@po_id uniqueidentifier,  
	@notes varchar(50) NULL,
	@price_per_unit decimal(7,2),
	@product_description varchar(100),
	@line_no tinyint,
	@qty decimal(8,2),
	@unit_name varchar(10),
	@referenced_inventory_id uniqueidentifier = NULL,
	@status_enum_id tinyint

AS

BEGIN

	INSERT INTO POItems(id,po_id,notes,price_per_unit,product_description,line_no,qty,unit_name,referenced_inventory_id,status_enum_id) 
					VALUES(@id,@po_id,@notes,@price_per_unit,@product_description,@line_no,@qty,@unit_name,@referenced_inventory_id,@status_enum_id)

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
			ALTER PROCEDURE [dbo].[poitem_update]

	@id uniqueidentifier, 
	@PriorityNo smallint = NULL,
	@PriorityQty int = NULL,
	@ExpectedDeliveryDate date = NULL

AS

BEGIN

	IF EXISTS(SELECT POItems.id FROM POItems WHERE POItems.id = @id AND PriorityNo <> @PriorityNo)
	BEGIN
		IF EXISTS(SELECT POItems.Id FROM POItems WHERE PriorityNo=@PriorityNo AND status_enum_id <> 4)
			UPDATE POItems SET PriorityNo = PriorityNo+1 WHERE PriorityNo < 999 AND PriorityNo >= @PriorityNo AND status_enum_id <> 4
	END
	
	UPDATE POItems SET PriorityNo = @PriorityNo, PriorityQty = @PriorityQty, ExpectedDeliveryDate=@ExpectedDeliveryDate WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[poitem_update_status]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[poitem_update_status]

	@id uniqueidentifier, 
	@status_enum_id tinyint

AS

BEGIN

	UPDATE POItems SET status_enum_id = @status_enum_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[Procedure]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Procedure]
	@param1 int = 0,
	@param2 int
AS
	SELECT @param1, @param2
RETURN 0

GO
/****** Object:  StoredProcedure [dbo].[product_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Products.id,name_vendor,vendor_id,Products.active,Products.notes,store_name_id, 
			ProductStoreNames.name + ': ' + Products.name_vendor AS name_full,
			Vendors.vendor_name AS vendor_name,
			ProductStoreNames.name AS store_name
	FROM Products 
			LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id
			LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
	WHERE Products.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[product_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_get_byFilter]

	@include_inactive bit, 
	@name_vendor varchar(20) = NULL,
	@vendor_id uniqueidentifier = NULL,
	@store_name_id uniqueidentifier = NULL

AS

BEGIN

	SELECT Products.id,name_vendor,vendor_id,Products.active,Products.notes,store_name_id, 
			ProductStoreNames.name + ': ' + Products.name_vendor AS name_full,
			Vendors.vendor_name AS vendor_name,
			ProductStoreNames.name AS store_name
	FROM Products 
			LEFT OUTER JOIN Vendors ON Vendors.id = Products.vendor_id 
			LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Products.active = 1))
		AND (@name_vendor IS NULL OR Products.name_vendor LIKE '%' + @name_vendor + '%')
		AND (@vendor_id IS NULL OR Products.vendor_id = @vendor_id)
		AND (@store_name_id IS NULL OR Products.store_name_id = @store_name_id)
	ORDER BY ProductStoreNames.name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[product_isNameCombinationExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_isNameCombinationExist]

	@store_name_id uniqueidentifier, 
	@name_vendor varchar(20), 
	@vendor_id uniqueidentifier,
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (	SELECT id 
				FROM Products 
				WHERE (@id IS NULL OR id <> @id)
					AND store_name_id = @store_name_id 
					AND name_vendor = @name_vendor
					AND vendor_id = @vendor_id
				)
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[product_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_new]

	@id uniqueidentifier,
	@name_vendor varchar(20),
	@vendor_id uniqueidentifier,
	@notes varchar(1000),
	@store_name_id uniqueidentifier

AS

BEGIN

	INSERT INTO Products(id,name_vendor,vendor_id,notes,store_name_id) VALUES(@id,@name_vendor,@vendor_id,@notes,@store_name_id)

END

GO
/****** Object:  StoredProcedure [dbo].[product_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_update]

	@id uniqueidentifier,
	@name_vendor varchar(20),
	@vendor_id uniqueidentifier,
	@notes varchar(1000),
	@store_name_id uniqueidentifier

AS

BEGIN

	UPDATE Products SET name_vendor = @name_vendor, vendor_id = @vendor_id, notes = @notes, store_name_id = @store_name_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[product_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[product_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Products SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[productprice_delete]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_delete]

	@id uniqueidentifier

AS

BEGIN

	DELETE FROM ProductPrices WHERE id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[productprice_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[productprice_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT ProductPrices.*,
		ProductStoreNames1.id AS product_store_name_id, 
		ISNULL(ProductStoreNames1.name, ProductStoreNames2.name) AS product_store_name,
		ProductWidths.product_width_name AS width_name,
		LengthUnits.length_unit_name AS length_unit_name, 
		Grades.id AS grade_id, 
		Grades.grade_name AS grade_name,
		Inventory.code AS inventory_code,
		Colors.color_name AS color_name 
	FROM ProductPrices 
		LEFT OUTER JOIN ProductStoreNames ProductStoreNames1 ON ProductStoreNames1.id = ProductPrices.product_store_name_id
		LEFT OUTER JOIN ProductStoreNames ProductStoreNames2 ON ProductStoreNames2.id = (SELECT Products.store_name_id FROM Products WHERE Products.id = (SELECT Inventory.product_id FROM Inventory WHERE Inventory.id = ProductPrices.inventory_id))
		LEFT OUTER JOIN Inventory ON Inventory.id = ProductPrices.inventory_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = ProductPrices.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = ProductPrices.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = ProductPrices.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = ProductPrices.color_id
	WHERE ProductPrices.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_get_by_combination]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_get_by_combination]

	@inventory_id uniqueidentifier = NULL,
	@product_store_name_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@return_value uniqueidentifier = NULL OUTPUT

AS

BEGIN

	IF @inventory_id IS NOT NULL
		SET @return_value = (SELECT id
					FROM ProductPrices
					WHERE inventory_id = @inventory_id
					)

	IF (@return_value IS NULL AND @product_store_name_id IS NOT NULL AND @grade_id IS NOT NULL AND @product_width_id IS NOT NULL AND @length_unit_id IS NOT NULL)
		SET @return_value = (SELECT id 
				FROM ProductPrices 
				WHERE product_store_name_id = @product_store_name_id
					AND grade_id = @grade_id
					AND product_width_id = @product_width_id
					AND length_unit_id = @length_unit_id
					AND color_id = @color_id
				)

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_getall]

	@FILTER_OnlyNotChecked bit = 0

AS

BEGIN

	SELECT ProductPrices.*,
		ProductStoreNames1.id AS product_store_name_id, 
		ISNULL(ProductStoreNames1.name, ProductStoreNames2.name) AS product_store_name,
		ProductWidths.product_width_name AS width_name,
		LengthUnits.length_unit_name AS length_unit_name, 
		Grades.grade_name AS grade_name,
		Inventory.code AS inventory_code,
		Colors.color_name AS color_name
	FROM ProductPrices 
		LEFT OUTER JOIN ProductStoreNames ProductStoreNames1 ON ProductStoreNames1.id = ProductPrices.product_store_name_id
		LEFT OUTER JOIN ProductStoreNames ProductStoreNames2 ON ProductStoreNames2.id = (SELECT Products.store_name_id FROM Products WHERE Products.id = (SELECT Inventory.product_id FROM Inventory WHERE Inventory.id = ProductPrices.inventory_id))
		LEFT OUTER JOIN Inventory ON Inventory.id = ProductPrices.inventory_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = ProductPrices.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = ProductPrices.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = ProductPrices.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = ProductPrices.color_id
	WHERE 1=1
		AND (@FILTER_OnlyNotChecked = 0 OR Checked = 0)
	ORDER BY ISNULL(ProductStoreNames1.name, ProductStoreNames2.name) ASC, Grades.grade_name ASC, ProductWidths.product_width_name ASC, LengthUnits.length_unit_name ASC, Colors.color_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_isCombinationExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_isCombinationExist]

	@inventory_id uniqueidentifier = NULL,
	@product_store_name_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL, 
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF @inventory_id IS NOT NULL
		BEGIN
			IF EXISTS (SELECT id
						FROM ProductPrices
						WHERE inventory_id = @inventory_id
							AND (@id IS NULL OR id=@id)
						)
				RETURN 1
			ELSE
				RETURN 0
		END
	ELSE
		BEGIN
			IF EXISTS	(
						SELECT id 
						FROM ProductPrices 
						WHERE product_store_name_id = @product_store_name_id
							AND grade_id = @grade_id
							AND product_width_id = @product_width_id
							AND length_unit_id = @length_unit_id
							AND ((@color_id IS NULL AND color_id IS NULL) OR (@color_id IS NOT NULL AND color_id = @color_id))
							AND (@id IS NULL OR id=@id)
						)
				RETURN 1
			ELSE
				RETURN 0
		END
END

GO
/****** Object:  StoredProcedure [dbo].[productprice_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[productprice_new]

	@id uniqueidentifier,
	@product_store_name_id uniqueidentifier,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@sell_price decimal(10,2),
	@notes varchar(MAX) = NULL,
	@inventory_id uniqueidentifier = NULL

AS

BEGIN

	INSERT INTO ProductPrices(id,product_store_name_id,grade_id,product_width_id,length_unit_id,sell_price,notes,inventory_id,color_id) 
	VALUES(@id,@product_store_name_id,@grade_id,@product_width_id,@length_unit_id,@sell_price,@notes,@inventory_id,@color_id)

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_update]

	@id uniqueidentifier,
	@product_store_name_id uniqueidentifier = NULL,
	@grade_id uniqueidentifier = NULL,
	@product_width_id uniqueidentifier = NULL,
	@length_unit_id uniqueidentifier = NULL,
	@inventory_id uniqueidentifier = NULL,
	@color_id uniqueidentifier = NULL,
	@sell_price decimal(10,2),
	@notes varchar(1000)

AS

BEGIN

	UPDATE ProductPrices 
	SET product_store_name_id = @product_store_name_id,
		grade_id = @grade_id,
		product_width_id = @product_width_id,
		length_unit_id = @length_unit_id,
		inventory_id = @inventory_id,
		color_id = @color_id,
		sell_price = @sell_price,
		notes = @notes,
		Checked=0
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_update_Checked]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_update_Checked]

	@id uniqueidentifier,
	@Checked bit

AS

BEGIN

	UPDATE ProductPrices 
	SET Checked = @Checked
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[productprice_update_sell_price]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productprice_update_sell_price]

	@ARRAY_ProductPrices_Id AS Array READONLY,
	@sell_price decimal(10,2)

AS

BEGIN

	UPDATE ProductPrices 
	SET sell_price = @sell_price, Checked=0
	WHERE ((SELECT TOP(1)value_str FROM @ARRAY_ProductPrices_Id) = '00000000-0000-0000-0000-000000000000' OR ProductPrices.id IN (SELECT value_str FROM @ARRAY_ProductPrices_Id))

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,name,notes,active FROM ProductStoreNames WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_get_byFilter]

	@include_inactive bit,  
	@name varchar(50) = NULL

AS

BEGIN

	SELECT id,name,notes,active 
	FROM ProductStoreNames 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND ProductStoreNames.active = 1)) 
		AND (@name IS NULL OR ProductStoreNames.name LIKE '%' + @name + '%')
	ORDER BY name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_isNameExist]

	@name varchar(20), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM ProductStoreNames WHERE name = @name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_new]

	@id uniqueidentifier,
	@name varchar(20),
	@notes varchar(1000)

AS

BEGIN

	INSERT INTO ProductStoreNames(id,name,notes) VALUES(@id,@name,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_update]

	@id uniqueidentifier,
	@name varchar(20),
	@notes varchar(1000)

AS

BEGIN

	UPDATE ProductStoreNames SET name = @name, notes = @notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[productstorename_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productstorename_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE ProductStoreNames SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[productwidth_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,product_width_name,active,default_row FROM ProductWidths WHERE id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[productwidth_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_get_byFilter]

	@include_inactive bit,  
	@product_width_name varchar(50) = NULL

AS

BEGIN

	SELECT id,product_width_name,active,default_row 
	FROM ProductWidths 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND ProductWidths.active = 1)) 
		AND (@product_width_name IS NULL OR ProductWidths.product_width_name LIKE '%' + @product_width_name + '%')
	ORDER BY product_width_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[productwidth_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_isNameExist]

	@product_width_name varchar(20),
	@id uniqueidentifier = NULL, 
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM ProductWidths WHERE product_width_name = @product_width_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[productwidth_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_new]

	@id uniqueidentifier,
	@product_width_name varchar(20)

AS

BEGIN

	INSERT INTO ProductWidths(id,product_width_name) VALUES(@id,@product_width_name)

END


GO
/****** Object:  StoredProcedure [dbo].[productwidth_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_update]

	@id uniqueidentifier,
	@product_width_name varchar(20)

AS

BEGIN

	UPDATE ProductWidths SET product_width_name = @product_width_name WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[productwidth_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE ProductWidths SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[productwidth_update_default]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[productwidth_update_default]

	@id uniqueidentifier

AS

BEGIN

	UPDATE ProductWidths SET default_row = 0
	UPDATE ProductWidths SET default_row = 1 WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[sale_add_notes]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_add_notes]

	@id uniqueidentifier,
	@timestamp AS varchar(MAX), 
	@username AS varchar(MAX),
	@notes varchar(MAX)

AS

BEGIN

	DECLARE @new_notes varchar(MAX)

	IF NOT (SELECT NULLIF(notes, '') FROM Sales WHERE id=@id) IS NULL
		BEGIN
			SET @new_notes = @notes + char(13)
		END
	ELSE
		BEGIN
			SET @new_notes = @notes
		END

	UPDATE Sales SET notes = @timestamp + ' ' + @username + ': ' + @new_notes + ISNULL(notes, '') WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_charting]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_charting]

	@date_start datetime = NULL,
	@date_end datetime = NULL, 
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS 

BEGIN

	SELECT summarytable.sale_year_month as sale_year_month,
			SUM(summarytable.sale_qty) AS sale_qty,
			SUM(summarytable.sale_total) AS sale_total, 
			SUM(summarytable.profit) AS profit,
			COALESCE(SUM(summarytable.profit) / NULLIF(SUM(summarytable.sale_total) - SUM(summarytable.profit),0),0) * 100 AS sale_profit_percent
	FROM (
		SELECT Sales.time_stamp,
			CAST(YEAR(Sales.time_stamp) AS VARCHAR(4)) + '-' + (SELECT RIGHT('00' + CAST(MONTH(Sales.time_stamp) AS VARCHAR(2)),2)) AS sale_year_month,
			SaleItems.sell_price, SaleItems.adjustment,
			InventoryItems.item_length AS sale_qty,
			(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0)) * COALESCE(InventoryItems.item_length,0) AS sale_total,
			COALESCE(Inventory.buy_price,0) AS buy_price,
			(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0) - COALESCE(Inventory.buy_price,0)) * COALESCE(InventoryItems.item_length,0) AS profit
		FROM SaleItems 
			left outer join Sales ON Sales.id = SaleItems.sale_id
			left outer join InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
			LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		WHERE return_id IS NULL AND Sales.returned_to_supplier = 0
			AND (@date_start IS NULL OR time_stamp > @date_start)
			AND (@date_end IS NULL OR time_stamp < @date_end)
			AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
			AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
			AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
			AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
			AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
			AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
			AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
			AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
	) summarytable
	GROUP BY summarytable.sale_year_month
	ORDER BY summarytable.sale_year_month ASC

END

GO
/****** Object:  StoredProcedure [dbo].[sale_charting_bycustomers]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sale_charting_bycustomers]

	@date_start datetime = NULL,
	@date_end datetime = NULL, 
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS 

BEGIN

	-- drop table if already exists
	IF(SELECT object_id('TempDB..#TEMP_SALEITEMS')) IS NOT NULL
		DROP TABLE #TEMP_SALEITEMS
		
	SELECT * INTO #TEMP_SALEITEMS FROM (
		SELECT 
			summarytable.customer_id AS customer_id,
			SUM(summarytable.sale_qty) AS sale_length,
			SUM(summarytable.sale_total) AS sale_amount, 
			SUM(summarytable.profit) AS profit_amount,
			(SUM(summarytable.profit) / NULLIF(SUM(summarytable.sale_total) - SUM(summarytable.profit),0) * 100) AS profit_percent
		FROM (
				SELECT Sales.time_stamp,
					Sales.customer_id,
					SaleItems.sell_price, SaleItems.adjustment,
					InventoryItems.item_length AS sale_qty,
					(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0)) * COALESCE(InventoryItems.item_length,0) AS sale_total,
					COALESCE(Inventory.buy_price,0) AS buy_price,
					(COALESCE(SaleItems.sell_price,0) + COALESCE(SaleItems.adjustment,0) - COALESCE(Inventory.buy_price,0)) * COALESCE(InventoryItems.item_length,0) AS profit
				FROM SaleItems 
					left outer join Sales ON Sales.id = SaleItems.sale_id
					left outer join InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
					LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
				WHERE return_id IS NULL AND Sales.returned_to_supplier = 0
					AND (@date_start IS NULL OR time_stamp > @date_start)
					AND (@date_end IS NULL OR time_stamp < @date_end)
					AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
					AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
					AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
					AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
					AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
					AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
					AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
					AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
			) summarytable
		GROUP BY summarytable.customer_id
	) AS x
	
	SELECT #TEMP_SALEITEMS.*,
		Customers.customer_name AS customer_name
	FROM #TEMP_SALEITEMS
		LEFT OUTER JOIN Customers ON Customers.id = #TEMP_SALEITEMS.customer_id
	ORDER BY Customers.customer_name ASC
	
	-- clean up
	DROP TABLE #TEMP_SALEITEMS	
END


GO
/****** Object:  StoredProcedure [dbo].[sale_charting_detail]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_charting_detail]

	@date_start datetime = NULL, 
	@date_end datetime = NULL,
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS

BEGIN
 
	SELECT Sales.id AS sale_id, Sales.time_stamp, RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), Sales.barcode), 1),5) AS barcode,
			Customers.customer_name AS customer_name,
			SaleItems.sale_amount AS sale_amount,
			SaleItems.sale_pcs AS sale_pcs,
			SaleItems.sale_length AS sale_length,
			COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0) AS profit,
			IIF(COALESCE(SaleItems.buy_amount,0) = 0,1,(COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0)) / COALESCE(SaleItems.buy_amount,0)) * 100 AS profit_percent
	FROM Sales 
		LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
		LEFT OUTER JOIN Transports ON Transports.id = Sales.transport_id
		LEFT OUTER JOIN (
			SELECT SaleItems.sale_id,
					SUM(Inventory.buy_price * InventoryItems.item_length) AS buy_amount,
					SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS sale_amount,
					COUNT(InventoryItems.item_length) AS sale_pcs,
					SUM(InventoryItems.item_length) AS sale_length
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
				LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
				LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
			WHERE return_id IS NULL 
				AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
				AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
				AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
				AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
				AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
			GROUP BY SaleItems.sale_id
			) SaleItems ON SaleItems.sale_id = Sales.id
	WHERE 1=1
		AND Sales.returned_to_supplier = 0
		AND (@date_start IS NULL OR Sales.time_stamp > @date_start)
		AND (@date_end IS NULL OR Sales.time_stamp < @date_end)
		AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
		AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
		AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
		AND Sales.id IN (
				SELECT DISTINCT(SaleItems.sale_id)
				FROM SaleItems
					LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
					LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
				WHERE return_id IS NULL 
					AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
					AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
					AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
					AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
					AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
			)
	ORDER BY Sales.time_stamp ASC

END

GO
/****** Object:  StoredProcedure [dbo].[sale_charting_detailbycustomers]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sale_charting_detailbycustomers]

	@date_start datetime = NULL, 
	@date_end datetime = NULL,
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS

BEGIN
 
	-- drop table if already exists
	IF(SELECT object_id('TempDB..#TEMP_SALEITEMS')) IS NOT NULL
		DROP TABLE #TEMP_SALEITEMS
	IF(SELECT object_id('TempDB..#TEMP_GROUPEDSALEITEMS')) IS NOT NULL
		DROP TABLE #TEMP_GROUPEDSALEITEMS
		
	SELECT * INTO #TEMP_SALEITEMS FROM (
		SELECT SaleItems.*,
			Sales.customer_id AS customer_id,
			Inventory.product_id AS product_id,
			Inventory.grade_id AS grade_id,
			Inventory.buy_price AS buy_price,
			InventoryItems.item_length AS item_length
		FROM SaleItems
			LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id	
			LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
			LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
			LEFT OUTER JOIN ProductStoreNames ON Products.id = Products.store_name_id
		WHERE 1=1
			AND Sales.returned_to_supplier = 0
			AND (@date_start IS NULL OR Sales.time_stamp > @date_start)
			AND (@date_end IS NULL OR Sales.time_stamp < @date_end)
			AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
			AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
			AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
			AND SaleItems.return_id IS NULL 
			AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
			AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
			AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
			AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
			AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
	) AS x

	SELECT * INTO #TEMP_GROUPEDSALEITEMS FROM (
		SELECT 
			#TEMP_SALEITEMS.customer_id AS customer_id,
			SUM(#TEMP_SALEITEMS.buy_price * #TEMP_SALEITEMS.item_length) AS buy_amount,
			SUM((#TEMP_SALEITEMS.sell_price + #TEMP_SALEITEMS.adjustment) * #TEMP_SALEITEMS.item_length) AS sale_amount,
			COUNT(#TEMP_SALEITEMS.item_length) AS sale_pcs,
			SUM(#TEMP_SALEITEMS.item_length) AS sale_length
		FROM #TEMP_SALEITEMS
		GROUP BY #TEMP_SALEITEMS.customer_id
	) AS x

	SELECT #TEMP_GROUPEDSALEITEMS.*,
		Customers.id AS customer_id,
		Customers.customer_name AS customer_name,
		COALESCE(#TEMP_GROUPEDSALEITEMS.sale_amount,0) - COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0) AS profit_amount,
		IIF(COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0) = 0,1,(COALESCE(#TEMP_GROUPEDSALEITEMS.sale_amount,0) - COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0)) / COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0)) * 100 AS profit_percent
	FROM #TEMP_GROUPEDSALEITEMS
		LEFT OUTER JOIN Customers ON Customers.id = #TEMP_GROUPEDSALEITEMS.customer_id
	ORDER BY Customers.customer_name ASC

	-- clean up
	DROP TABLE #TEMP_SALEITEMS	
	DROP TABLE #TEMP_GROUPEDSALEITEMS
END


GO
/****** Object:  StoredProcedure [dbo].[sale_charting_detailbyproducts]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


ALTER PROCEDURE [dbo].[sale_charting_detailbyproducts]

	@date_start datetime = NULL, 
	@date_end datetime = NULL,
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS

BEGIN
 
	-- drop table if already exists
	IF(SELECT object_id('TempDB..#TEMP_SALEITEMS')) IS NOT NULL
		DROP TABLE #TEMP_SALEITEMS
	IF(SELECT object_id('TempDB..#TEMP_GROUPEDSALEITEMS')) IS NOT NULL
		DROP TABLE #TEMP_GROUPEDSALEITEMS
		
	SELECT * INTO #TEMP_SALEITEMS FROM (
		SELECT SaleItems.*,
			Inventory.product_id AS product_id,
			Inventory.grade_id AS grade_id,
			Inventory.buy_price AS buy_price,
			InventoryItems.item_length AS item_length
		FROM SaleItems
			LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id	
			LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
			LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
			LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
			LEFT OUTER JOIN ProductStoreNames ON Products.id = Products.store_name_id
		WHERE 1=1
			AND Sales.returned_to_supplier = 0
			AND (@date_start IS NULL OR Sales.time_stamp > @date_start)
			AND (@date_end IS NULL OR Sales.time_stamp < @date_end)
			AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
			AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
			AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
			AND SaleItems.return_id IS NULL 
			AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
			AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
			AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
			AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
			AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
	) AS x

	SELECT * INTO #TEMP_GROUPEDSALEITEMS FROM (
		SELECT #TEMP_SALEITEMS.product_id AS product_id, #TEMP_SALEITEMS.grade_id AS grade_id,
			SUM(#TEMP_SALEITEMS.buy_price * #TEMP_SALEITEMS.item_length) AS buy_amount,
			SUM((#TEMP_SALEITEMS.sell_price + #TEMP_SALEITEMS.adjustment) * #TEMP_SALEITEMS.item_length) AS sale_amount,
			COUNT(#TEMP_SALEITEMS.item_length) AS sale_pcs,
			SUM(#TEMP_SALEITEMS.item_length) AS sale_length
		FROM #TEMP_SALEITEMS
		GROUP BY #TEMP_SALEITEMS.product_id, #TEMP_SALEITEMS.grade_id
	) AS x

	SELECT #TEMP_GROUPEDSALEITEMS.*,
		ProductStoreNames.name AS product_name,
		Grades.grade_name AS grade_name,
		COALESCE(#TEMP_GROUPEDSALEITEMS.sale_amount,0) - COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0) AS profit_amount,
		IIF(COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0) = 0,1,(COALESCE(#TEMP_GROUPEDSALEITEMS.sale_amount,0) - COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0)) / COALESCE(#TEMP_GROUPEDSALEITEMS.buy_amount,0)) * 100 AS profit_percent
	FROM #TEMP_GROUPEDSALEITEMS
		LEFT OUTER JOIN Products ON Products.id = #TEMP_GROUPEDSALEITEMS.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN Grades ON Grades.id = #TEMP_GROUPEDSALEITEMS.grade_id
	ORDER BY ProductStoreNames.name ASC

	-- clean up
	DROP TABLE #TEMP_SALEITEMS	
	DROP TABLE #TEMP_GROUPEDSALEITEMS
END


GO
/****** Object:  StoredProcedure [dbo].[sale_charting_detailbysales]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_charting_detailbysales]

	@date_start datetime = NULL, 
	@date_end datetime = NULL,
	@exclude_customer_id uniqueidentifier = NULL,
	@customer_id_list AS Array READONLY,
	@length_unitid_list AS Array READONLY,
	@colorid_list AS Array READONLY,
	@grade_id_list AS Array READONLY,
	@product_storenameid_list AS Array READONLY,
	@product_widthid_list AS Array READONLY,
	@is_reported_only AS bit = 0

AS

BEGIN
 
	SELECT Sales.id AS sale_id, Sales.time_stamp, RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), Sales.barcode), 1),5) AS barcode,
			Customers.customer_name AS customer_name,
			SaleItems.sale_amount AS sale_amount,
			SaleItems.sale_pcs AS sale_pcs,
			SaleItems.sale_length AS sale_length,
			COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0) AS profit,
			IIF(COALESCE(SaleItems.buy_amount,0) = 0,1,(COALESCE(SaleItems.sale_amount,0) - COALESCE(SaleItems.buy_amount,0)) / COALESCE(SaleItems.buy_amount,0)) * 100 AS profit_percent
	FROM Sales 
		LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
		LEFT OUTER JOIN Transports ON Transports.id = Sales.transport_id
		LEFT OUTER JOIN (
			SELECT SaleItems.sale_id,
					SUM(Inventory.buy_price * InventoryItems.item_length) AS buy_amount,
					SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS sale_amount,
					COUNT(InventoryItems.item_length) AS sale_pcs,
					SUM(InventoryItems.item_length) AS sale_length
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
				LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
				LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
			WHERE return_id IS NULL 
				AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
				AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
				AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
				AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
				AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
			GROUP BY SaleItems.sale_id
			) SaleItems ON SaleItems.sale_id = Sales.id
	WHERE 1=1
		AND Sales.returned_to_supplier = 0
		AND (@date_start IS NULL OR Sales.time_stamp > @date_start)
		AND (@date_end IS NULL OR Sales.time_stamp < @date_end)
		AND ((SELECT COUNT(value_str) FROM @customer_id_list) = 0 OR Sales.customer_id IN (SELECT value_str FROM @customer_id_list))
		AND (@exclude_customer_id IS NULL OR Sales.customer_id <> @exclude_customer_id)
		AND (@is_reported_only = 0 OR (@is_reported_only = 1 AND Sales.is_reported = 1))
		AND Sales.id IN (
				SELECT DISTINCT(SaleItems.sale_id)
				FROM SaleItems
					LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
					LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
					LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
				WHERE return_id IS NULL 
					AND ((SELECT COUNT(value_str) FROM @length_unitid_list) = 0 OR Inventory.length_unit_id IN (SELECT value_str FROM @length_unitid_list))
					AND ((SELECT COUNT(value_str) FROM @colorid_list) = 0 OR Inventory.color_id IN (SELECT value_str FROM @colorid_list))
					AND ((SELECT COUNT(value_str) FROM @product_widthid_list) = 0 OR Inventory.product_width_id IN (SELECT value_str FROM @product_widthid_list))
					AND ((SELECT COUNT(value_str) FROM @grade_id_list) = 0 OR Inventory.grade_id IN (SELECT value_str FROM @grade_id_list))
					AND ((SELECT COUNT(value_str) FROM @product_storenameid_list) = 0 OR Products.store_name_id IN (SELECT value_str FROM @product_storenameid_list))
			)
	ORDER BY Sales.time_stamp ASC

END


GO
/****** Object:  StoredProcedure [dbo].[sale_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Sales.*,
		Transports.name AS transport_name
	FROM Sales 
		LEFT OUTER JOIN Transports ON Transports.id = Sales.transport_id
	WHERE Sales.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_get_id_by_barcode]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_get_id_by_barcode]

	@barcode int

AS

BEGIN

	SELECT MAX(id) FROM Sales WHERE Sales.barcode = @barcode

END

GO

/****** Object:  StoredProcedure [dbo].[sale_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_new]

	@id uniqueidentifier, 
	@time_stamp datetime,
	@voided bit,
	@customer_id uniqueidentifier,
	@customer_info varchar(1000),
	@user_id uniqueidentifier,
	@notes varchar(MAX) = NULL,
	@transport_id uniqueidentifier = NULL,
	@shipping_cost decimal, 
	@return_value int OUTPUT
AS

BEGIN

	INSERT INTO Sales(id,time_stamp,voided,customer_id,customer_info,user_id,notes,transport_id, shipping_cost) 
					VALUES(@id,@time_stamp,@voided,@customer_id,@customer_info,@user_id,@notes,@transport_id, @shipping_cost)
    SET @return_value=SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[sale_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update]

	@id uniqueidentifier,
	@notes varchar(MAX),
	@transport_id uniqueidentifier,
	@shipping_cost decimal(10,2)

AS

BEGIN

	UPDATE Sales SET notes=@notes, transport_id=@transport_id, shipping_cost=@shipping_cost WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_update_completed]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update_completed]

	@id uniqueidentifier,
	@completed bit

AS

BEGIN

	UPDATE Sales SET completed = @completed WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_update_isreported]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update_isreported]

	@id uniqueidentifier,
	@is_reported bit

AS

BEGIN

	UPDATE Sales SET is_reported = @is_reported WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_update_returnedtosupplier_by_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update_returnedtosupplier_by_id]

	@id uniqueidentifier,
	@returned_to_supplier bit

AS

BEGIN

	UPDATE Sales SET returned_to_supplier = @returned_to_supplier WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_update_specialuseronly_by_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update_specialuseronly_by_id]

	@id uniqueidentifier,
	@special_user_only bit

AS

BEGIN

	UPDATE Sales SET special_user_only = @special_user_only WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sale_update_taxno]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sale_update_taxno]

	@id uniqueidentifier,
	@tax_no varchar(50)

AS

BEGIN

	UPDATE Sales SET tax_no = @tax_no WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_by_inventory_item_barcode]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_get_by_inventory_item_barcode]

	@inventory_item_barcode varchar(10),
	@is_for_return bit = 0

AS

BEGIN

	SELECT SaleItems.id, sale_id, inventory_item_id, sell_price,
			Inventory.id AS inventory_id, 
			Inventory.code AS inventory_code, 
			Customers.id AS customer_id,
			Customers.customer_name AS customer_name,
			ProductStoreNames.name AS product_store_name,
			LengthUnits.length_unit_name AS length_unit_name,			
			Grades.grade_name AS grade_name,
			InventoryItems.id AS inventory_item_id,
			InventoryItems.item_length AS item_length,
			InventoryItems.barcode AS barcode,
			Colors.color_name AS color_name, Colors.color_name AS inventory_color_name, 
			SaleItems.adjustment AS adjustment,
			InventoryItems.barcode AS barcode,
			(InventoryItems.item_length * (SaleItems.sell_price + SaleItems.adjustment)) AS subtotal
	FROM SaleItems
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id
		LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
	WHERE InventoryItems.barcode = @inventory_item_barcode 
		AND (@is_for_return = 0 OR return_id IS NULL)
	ORDER BY SaleItems.sale_id ASC

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_by_sale_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_get_by_sale_id]

	@sale_id uniqueidentifier

AS

BEGIN

	SELECT SaleItems.id, sale_id, inventory_item_id, sell_price,
			Inventory.id AS inventory_id, 
			Inventory.code AS inventory_code,
			ProductStoreNames.name AS product_store_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,			
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name, Colors.color_name AS inventory_color_name, 
			InventoryItems.item_length AS item_length,
			SaleItems.adjustment AS adjustment,
			InventoryItems.barcode AS barcode,
			COALESCE(sell_price + adjustment, 0) AS adjusted_price,
			COALESCE(Inventory.buy_price, 0) AS buy_price,
			COALESCE(sell_price + adjustment, 0) - COALESCE(Inventory.buy_price, 0) * InventoryItems.item_length AS profit,
			IIF(COALESCE(Inventory.buy_price,0) = 0,0, ((COALESCE(sell_price + adjustment, 0) - COALESCE(Inventory.buy_price, 0)) / (COALESCE(Inventory.buy_price, 0)))) * 100 AS profit_percent,
			(InventoryItems.item_length * (SaleItems.sell_price + SaleItems.adjustment)) AS subtotal,
			1 AS qty
	FROM SaleItems
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
	WHERE sale_id = @sale_id
	ORDER BY InventoryItems.item_length ASC

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_by_salereturn_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_get_by_salereturn_id]

	@salereturn_id uniqueidentifier

AS

BEGIN

	SELECT SaleItems.id, sale_id, inventory_item_id, sell_price,
			Inventory.id AS inventory_id, 
			Inventory.code AS inventory_code,
			ProductStoreNames.name AS product_store_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,			
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name, Colors.color_name AS inventory_color_name, 
			InventoryItems.item_length AS item_length,
			SaleItems.adjustment AS adjustment,
			InventoryItems.barcode AS barcode,
			COALESCE(sell_price + adjustment, 0) AS adjusted_price,
			(InventoryItems.item_length * (SaleItems.sell_price + SaleItems.adjustment)) AS subtotal,
			1 AS qty
	FROM SaleItems
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
	WHERE SaleItems.return_id = @salereturn_id
	ORDER BY InventoryItems.item_length ASC

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_sold]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_get_sold]

	@date_start datetime = NULL,
	@date_end datetime = NULL

AS

BEGIN

	SELECT SaleItems.id, SaleItems.inventory_item_id
	FROM SaleItems
		LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id
	WHERE SaleItems.return_id IS NULL
		AND (@date_start IS NULL OR Sales.time_stamp > @date_start)
		AND (@date_end IS NULL OR Sales.time_stamp < @date_end)

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_summary_by_sale_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[saleitem_get_summary_by_sale_id]

	@sale_id uniqueidentifier 

AS

BEGIN

	SELECT Inventory.id, 
			Inventory.code AS inventory_code,
			ProductStoreNames.name AS product_store_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name, Colors.color_name AS inventory_color_name, 
			CalculatedSaleItems.qty AS qty,
			CalculatedSaleItems.item_length AS item_length,
			COALESCE(CalculatedSaleItems.subtotal / CalculatedSaleItems.item_length, 0) AS adjusted_price,
			COALESCE(Inventory.buy_price, 0) AS buy_price,
			COALESCE(CalculatedSaleItems.subtotal, 0) - COALESCE(Inventory.buy_price * CalculatedSaleItems.item_length, 0) AS profit,
			IIF(COALESCE(CalculatedSaleItems.item_length,0) = 0, 0, IIF(COALESCE(Inventory.buy_price,0) = 0,1, (COALESCE(CalculatedSaleItems.subtotal / CalculatedSaleItems.item_length, 0) - COALESCE(Inventory.buy_price, 0)) / (COALESCE(Inventory.buy_price, 0)))) * 100 AS profit_percent,
			CalculatedSaleItems.subtotal AS subtotal,
			(CASE WHEN AdjustedSaleItems.inventory_id IS NOT NULL THEN 1 ELSE 0 END) AS isManualAdjustment
	FROM Inventory 
		LEFT OUTER JOIN 
			(SELECT InventoryItems.inventory_id AS inventory_id,
					COUNT(InventoryItems.item_length) AS qty,
					SUM(InventoryItems.item_length) AS item_length,
					SUM(InventoryItems.item_length * (sell_price + adjustment)) AS subtotal
			FROM (SELECT * FROM SaleItems WHERE SaleItems.sale_id = @sale_id) FilteredSaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = FilteredSaleItems.inventory_item_id
			GROUP BY InventoryItems.inventory_id 
			) CalculatedSaleItems ON CalculatedSaleItems.inventory_id = Inventory.id
		LEFT OUTER JOIN (
			SELECT DISTINCT(InventoryItems.inventory_id)
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
			WHERE SaleItems.sale_id = @sale_id 
				AND SaleItems.isManualAdjustment = 1
			) AdjustedSaleItems ON AdjustedSaleItems.inventory_id = Inventory.id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
	WHERE Inventory.id IN (SELECT DISTINCT(inventory_id) 
							FROM InventoryItems 
							WHERE InventoryItems.id IN (SELECT inventory_item_id 
														FROM SaleItems 
														WHERE SaleItems.sale_id = @sale_id
														)
							)

		

END


GO
/****** Object:  StoredProcedure [dbo].[saleitem_get_summary_by_salereturn_id]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_get_summary_by_salereturn_id]

	@salereturn_id uniqueidentifier

AS

BEGIN

	SELECT Inventory.id, 
			Inventory.code AS inventory_code,
			ProductStoreNames.name AS product_store_name,
			ProductWidths.product_width_name AS product_width_name,
			LengthUnits.length_unit_name AS length_unit_name,
			Grades.grade_name AS grade_name,
			Colors.color_name AS color_name, Colors.color_name AS inventory_color_name, 
			CalculatedSaleItems.qty AS qty,
			CalculatedSaleItems.item_length AS item_length,
			CalculatedSaleItems.price_per_unit AS price_per_unit,
			CalculatedSaleItems.subtotal AS subtotal
	FROM Inventory 
		LEFT OUTER JOIN 
			(SELECT InventoryItems.inventory_id AS inventory_id,
					COUNT(InventoryItems.item_length) AS qty,
					SUM(InventoryItems.item_length) AS item_length,
					SUM(InventoryItems.item_length * (sell_price + adjustment)) / SUM(InventoryItems.item_length) AS price_per_unit,
					SUM(InventoryItems.item_length * (sell_price + adjustment)) AS subtotal
			FROM (SELECT * FROM SaleItems WHERE SaleItems.return_id = @salereturn_id) FilteredSaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = FilteredSaleItems.inventory_item_id
			GROUP BY InventoryItems.inventory_id 
			) CalculatedSaleItems ON CalculatedSaleItems.inventory_id = Inventory.id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
	WHERE Inventory.id IN (SELECT DISTINCT(inventory_id) 
							FROM InventoryItems 
							WHERE InventoryItems.id IN (SELECT inventory_item_id 
														FROM SaleItems 
														WHERE SaleItems.return_id = @salereturn_id
														)
							)

		

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_getall]

	@sale_id uniqueidentifier

AS

BEGIN

	SELECT id,sale_id,inventory_item_id,sell_price,adjustment FROM SaleItems WHERE sale_id = @sale_id ORDER BY id ASC

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[saleitem_new]

	@id uniqueidentifier,
	@sale_id uniqueidentifier,
	@inventory_item_id uniqueidentifier,
	@sell_price decimal(12,2),
	@adjustment decimal(12,2),
	@isManualAdjustment bit

AS

BEGIN

	INSERT INTO SaleItems(id,sale_id,inventory_item_id,sell_price,adjustment,isManualAdjustment) 
					VALUES(@id,@sale_id,@inventory_item_id,@sell_price,@adjustment,@isManualAdjustment)

END


GO
/****** Object:  StoredProcedure [dbo].[saleitem_return]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_return]

	@id uniqueidentifier,
	@return_id uniqueidentifier

AS

BEGIN

	UPDATE SaleItems SET return_id = @return_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[saleitem_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[saleitem_update]

	@id uniqueidentifier,
	@adjustment decimal(12,2)

AS

BEGIN

	UPDATE SaleItems SET adjustment = @adjustment WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[salereturn_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[salereturn_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT SaleReturns.id,SaleReturns.time_stamp,SaleReturns.voided,SaleReturns.user_id,SaleReturns.notes,
		RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), SaleReturns.barcode), 1),5) AS barcode,
		Sales.customer_id AS customer_id,
		Sales.customer_info AS customer_info,
		Customers.customer_name AS customer_name 
	FROM ((SaleReturns 
		LEFT OUTER JOIN SaleItems ON SaleItems.return_id = SaleReturns.id
		) LEFT OUTER JOIN Sales ON Sales.id = SaleItems.sale_id
		) LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
	WHERE SaleReturns.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[salereturn_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[salereturn_getall]
	
	@date_start datetime = NULL,
	@date_end datetime = NULL,
	@inventory_item_id uniqueidentifier = NULL,
	@customer_id uniqueidentifier = NULL,
	@salereturn_id uniqueidentifier = NULL,
	@salesman_id uniqueidentifier = NULL

AS

BEGIN

	SELECT SaleReturns.*,
			SaleReturns.barcode,RIGHT(CONVERT(NVARCHAR(10), CONVERT(VARBINARY(8), SaleReturns.barcode), 1),5) AS hexbarcode,
			Customers.customer_name AS customer_name,
			Sales.customer_info AS customer_info,
			SaleAmount.sale_amount AS sale_amount,
			SaleAmount.sale_qty AS sale_qty,
			SaleAmount.sale_length AS sale_length
	FROM (((SaleReturns 
		LEFT OUTER JOIN (SELECT * FROM SaleItems WHERE SaleItems.id IN (SELECT MAX(id) FROM SaleItems WHERE return_id IS NOT NULL GROUP BY return_id)) FilteredSaleItems ON FilteredSaleItems.return_id = SaleReturns.id
		) LEFT OUTER JOIN Sales ON Sales.id = FilteredSaleItems.sale_id
		) LEFT OUTER JOIN Customers ON Customers.id = Sales.customer_id
		) LEFT OUTER JOIN 
			(SELECT SaleItems.return_id,
					SUM((SaleItems.sell_price + SaleItems.adjustment) * InventoryItems.item_length) AS sale_amount,
					COUNT(InventoryItems.item_length) AS sale_qty,
					SUM(InventoryItems.item_length) AS sale_length
			FROM SaleItems
				LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
			WHERE SaleItems.return_id IS NOT NULL
			GROUP BY SaleItems.return_id
			) SaleAmount ON SaleAmount.return_id = SaleReturns.id
	WHERE 1=1
		AND (@date_start IS NULL OR SaleReturns.time_stamp > @date_start)
		AND (@date_end IS NULL OR SaleReturns.time_stamp < @date_end)
		AND (@inventory_item_id IS NULL OR Sales.id IN (SELECT sale_id FROM SaleItems WHERE inventory_item_id = @inventory_item_id))
		AND (@customer_id IS NULL OR customer_id = @customer_id)
		AND (@salereturn_id IS NULL OR Sales.id = @salereturn_id)
		AND (@salesman_id IS NULL OR Customers.sales_user_id = @salesman_id)
	ORDER BY SaleReturns.time_stamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[salereturn_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[salereturn_new]

	@id uniqueidentifier,
	@time_stamp datetime,
	@user_id uniqueidentifier,
	@notes varchar(1000),
	@return_value int OUTPUT
AS

BEGIN

	INSERT INTO SaleReturns(id,time_stamp,user_id,notes) 
					VALUES(@id,@time_stamp,@user_id,@notes)
    SET @return_value=SCOPE_IDENTITY()
END

GO
/****** Object:  StoredProcedure [dbo].[SaleReturns_update_Checked]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SaleReturns_update_Checked]

	@id uniqueidentifier,
	@Checked bit

AS

BEGIN

	UPDATE SaleReturns SET Checked = @Checked WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[sample_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sample_add]

	@id uniqueidentifier,
	@storage_name varchar(MAX),
	@vendor_name varchar(MAX),
	@vendor_info varchar(MAX),
	@description varchar(MAX),
	@price_date date = NULL,
	@price_per_unit decimal = NULL,
	@discontinue_date date = NULL,
	@notes varchar(MAX) = NULL,
	@sell_price_per_unit decimal = NULL,
	@lengthunit_id uniqueidentifier = NULL,
	@return_value int = NULL OUTPUT

AS

BEGIN

	IF (SELECT MAX(sample_no) FROM Samples) IS NULL
		SET @return_value = 1
	ELSE
		SET @return_value = (SELECT MAX(sample_no) + 1 FROM Samples)

	INSERT INTO Samples(id,sample_no,storage_name,vendor_name,vendor_info,description,price_date,price_per_unit,discontinue_date,notes,sell_price_per_unit,lengthunit_id) 
	VALUES(@id,@return_value,@storage_name,@vendor_name,@vendor_info,@description,@price_date,@price_per_unit,@discontinue_date,@notes,@sell_price_per_unit,@lengthunit_id)

END

GO
/****** Object:  StoredProcedure [dbo].[sample_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[sample_get]

	@id uniqueidentifier

AS

BEGIN
 
	SELECT Samples.*,
		LengthUnits.length_unit_name AS lengthunit_name
	FROM Samples
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Samples.lengthunit_id
	WHERE Samples.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[sample_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sample_get_byFilter]

	@storage_name varchar(MAX) = NULL,
	@vendor_name varchar(MAX) = NULL,
	@vendor_info varchar(MAX) = NULL,
	@description varchar(MAX) = NULL

AS

BEGIN

	SELECT Samples.*,
		LengthUnits.length_unit_name AS lengthunit_name
	FROM Samples
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Samples.lengthunit_id
	WHERE 1=1
		AND (@storage_name IS NULL OR Samples.storage_name LIKE '%' + @storage_name + '%')
		AND (@vendor_name IS NULL OR Samples.vendor_name LIKE '%' + @vendor_name + '%')
		AND (@vendor_info IS NULL OR Samples.vendor_info LIKE '%' + @vendor_info + '%')
		AND (@description IS NULL OR Samples.description LIKE '%' + @description + '%')
	ORDER BY Samples.sample_no DESC

END

GO
/****** Object:  StoredProcedure [dbo].[sample_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sample_update]

	@id uniqueidentifier,
	@storage_name varchar(MAX),
	@vendor_name varchar(MAX),
	@vendor_info varchar(MAX),
	@description varchar(MAX),
	@price_date date = NULL,
	@price_per_unit decimal = NULL,
	@discontinue_date date = NULL,
	@notes varchar(MAX) = NULL,
	@sell_price_per_unit decimal = NULL,
	@lengthunit_id uniqueidentifier = NULL

AS

BEGIN

	UPDATE Samples SET
		storage_name = @storage_name,
		vendor_name = @vendor_name,
		vendor_info=@vendor_info,
		description=@description,
		price_date=@price_date,
		price_per_unit=@price_per_unit,
		discontinue_date=@discontinue_date,
		notes=@notes,
		sell_price_per_unit = @sell_price_per_unit,
		lengthunit_id = @lengthunit_id
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[server_get_timestamp]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[server_get_timestamp]

	@timestamp datetime OUTPUT

AS

BEGIN

	SELECT @timestamp = CURRENT_TIMESTAMP

END

GO
/****** Object:  StoredProcedure [dbo].[Settings_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Settings_get]

	@Id uniqueidentifier

AS

BEGIN

	SELECT Settings.*
	FROM Settings
	WHERE Id = @Id

END

GO
/****** Object:  StoredProcedure [dbo].[Settings_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Settings_update]

	@Id uniqueidentifier,
	@Value_Int int = NULL,
	@Value_String nvarchar(MAX) = NULL

AS

BEGIN

	IF((SELECT Id FROM Settings WHERE Id=@Id) IS NULL)
		INSERT INTO Settings(Id,Value_Int,Value_String) VALUES(@Id,@Value_Int,@Value_String)
	ELSE
		BEGIN
		IF @Value_Int IS NOT NULL
			UPDATE Settings SET Value_Int = @Value_Int WHERE Id = @Id

		IF @Value_String IS NOT NULL
			UPDATE Settings SET Value_String = @Value_String WHERE Id = @Id
		END
END

GO
/****** Object:  StoredProcedure [dbo].[state_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,state_name,active FROM States WHERE id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[state_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_get_byFilter]

	@include_inactive bit, 
	@state_name varchar(50) = NULL

AS

BEGIN

	SELECT id,state_name,active 
	FROM States 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND active = 1))
		AND (@state_name IS NULL OR States.state_name LIKE '%' + @state_name + '%')
	ORDER BY state_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[state_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_isNameExist]

	@state_name varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM States WHERE state_name = @state_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[state_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_new]

	@id uniqueidentifier,
	@state_name varchar(50)

AS

BEGIN

	INSERT INTO States(id,state_name) VALUES(@id,@state_name)

END

GO
/****** Object:  StoredProcedure [dbo].[state_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_update]

	@id uniqueidentifier,
	@state_name varchar(50)

AS

BEGIN

	UPDATE States SET state_name = @state_name WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[state_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[state_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE States SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[todo_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[todo_add]

	@id uniqueidentifier,
	@description varchar(MAX),
	@customer_id uniqueidentifier = NULL,
	@vendor_id uniqueidentifier = NULL

AS

BEGIN

	INSERT INTO ToDos(id,timestamp,description,customer_id,vendor_id) 
	VALUES(@id,CURRENT_TIMESTAMP,@description,@customer_id,@vendor_id)

END

GO
/****** Object:  StoredProcedure [dbo].[todo_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[todo_get]

	@id uniqueidentifier

AS

BEGIN
 
	SELECT ToDos.*,
		Customers.customer_name AS customer_name,
		Vendors.vendor_name AS vendor_name
	FROM ToDos
		LEFT OUTER JOIN Customers ON Customers.id = ToDos.customer_id
		LEFT OUTER JOIN Vendors ON Vendors.id = Todos.vendor_id
	WHERE ToDos.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[todo_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[todo_get_byFilter]

	@id uniqueidentifier = NULL,
	@description varchar(MAX) = NULL,
	@customer_id uniqueidentifier = NULL,
	@vendor_id uniqueidentifier = NULL,
	@FILTER_ExcludeCompletedStatusEnumId tinyint = NULL

AS

BEGIN

	SELECT ToDos.*,
		Customers.customer_name AS customer_name,
		Vendors.vendor_name AS vendor_name
	FROM ToDos
		LEFT OUTER JOIN Customers ON Customers.id = ToDos.customer_id
		LEFT OUTER JOIN Vendors ON Vendors.id = Todos.vendor_id
	WHERE 1=1
		AND (@description IS NULL OR ToDos.description LIKE '%' + @description + '%')
		AND (@customer_id IS NULL OR ToDos.customer_id = @customer_id)
		AND (@vendor_id IS NULL OR ToDos.vendor_id = @vendor_id)
		AND (@FILTER_ExcludeCompletedStatusEnumId IS NULL OR ToDos.status_enum_id <> @FILTER_ExcludeCompletedStatusEnumId)
	ORDER BY ToDos.timestamp ASC

END

GO
/****** Object:  StoredProcedure [dbo].[todo_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[todo_update]

	@id uniqueidentifier,
	@description varchar(MAX),
	@customer_id uniqueidentifier = NULL,
	@vendor_id uniqueidentifier = NULL

AS

BEGIN

	UPDATE ToDos SET
		description = @description,
		customer_id = @customer_id,
		vendor_id = @vendor_id
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[todo_update_status]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[todo_update_status]

	@id uniqueidentifier, 
	@status_enum_id tinyint

AS

BEGIN

	UPDATE ToDos SET status_enum_id = @status_enum_id WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[transport_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT Transports.*
	FROM Transports 
	WHERE Transports.id = @id

END

GO
/****** Object:  StoredProcedure [dbo].[transport_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_get_byFilter]

	@include_inactive bit, 
	@name varchar(50) = NULL,
	@city_id uniqueidentifier = NULL

AS

BEGIN

	SELECT Transports.*		
	FROM Transports 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND Transports.active = 1))
		AND (@name IS NULL OR Transports.name LIKE '%' + @name + '%')
	ORDER BY Transports.name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[transport_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_isNameExist]

	@name varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Transports WHERE name = @name AND (@id IS NULL OR id <> @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[transport_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_new]

	@id uniqueidentifier,
	@name varchar(50),
	@address varchar(100),
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(MAX)

AS

BEGIN

	INSERT INTO Transports(id,name,address,phone1,phone2,notes) VALUES(@id,@name,@address,@phone1,@phone2,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[transport_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_update]

	@id uniqueidentifier,
	@name varchar(50),
	@address varchar(100),
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(MAX)

AS

BEGIN

	UPDATE Transports SET name = @name, address = @address, phone1 = @phone1, phone2 = @phone2, notes = @notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[transport_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[transport_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Transports SET active = @new_active WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[users_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,username,hashed_password,role,notes,active FROM Users WHERE id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[users_getall]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_getall]

	@include_inactive bit

AS

BEGIN

	SELECT id,username,hashed_password,role,notes,active 
	FROM Users 
	WHERE @include_inactive = 1 OR (@include_inactive = 0 AND active = 1) 
	ORDER BY username ASC

END



GO
/****** Object:  StoredProcedure [dbo].[users_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_isNameExist]

	@username varchar(30), 
	@return_value bit = 0 OUTPUT 

AS

BEGIN

	IF EXISTS (SELECT id FROM Users WHERE username = @username)
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[users_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_new]

	@id uniqueidentifier,
	@username varchar(30),
	@hashed_password varchar(50),
	@role smallint,
	@notes varchar(1000)

AS

BEGIN

	INSERT INTO Users(id,username,hashed_password,role,notes) VALUES(@id,@username,@hashed_password,@role,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[users_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_update]

	@id uniqueidentifier,
	@username varchar(30),
	@hashed_password varchar(50),
	@role smallint,
	@notes varchar(1000)

AS

BEGIN

IF @hashed_password IS NULL
	BEGIN
	
		UPDATE Users 
		SET username = @username, 
			role = @role,
			notes = @notes
		WHERE id=@id

	END
ELSE
	BEGIN
	
		UPDATE Users 
		SET username = @username, 
			hashed_password = @hashed_password,
			role = @role,
			notes = @notes
		WHERE id=@id

	END

END

GO
/****** Object:  StoredProcedure [dbo].[users_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[users_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Users SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[vendor_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_get]

	@id uniqueidentifier

AS

BEGIN

	SELECT id,vendor_name,address,phone1,phone2,active,notes FROM Vendors WHERE id = @id

END


GO
/****** Object:  StoredProcedure [dbo].[vendor_get_byFilter]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_get_byFilter]

	@include_inactive bit,
	@vendor_name varchar(50) = NULL

AS

BEGIN

	SELECT id,vendor_name,address,phone1,phone2,active,notes 
	FROM Vendors 
	WHERE 1=1
		AND (@include_inactive = 1 OR (@include_inactive = 0 AND active = 1))
		AND (@vendor_name IS NULL OR Vendors.vendor_name LIKE '%' + @vendor_name + '%')
	ORDER BY vendor_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[vendor_isNameExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_isNameExist]

	@vendor_name varchar(50),
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM Vendors WHERE vendor_name = @vendor_name AND (@id IS NULL OR id != @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[vendor_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_new]

	@id uniqueidentifier,
	@vendor_name varchar(50),
	@address varchar(100),
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(1000)

AS

BEGIN

	INSERT INTO Vendors(id,vendor_name,address,phone1,phone2,notes) VALUES(@id,@vendor_name,@address,@phone1,@phone2,@notes)

END

GO
/****** Object:  StoredProcedure [dbo].[vendor_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_update]

	@id uniqueidentifier,
	@vendor_name varchar(50),
	@address varchar(100),
	@phone1 varchar(20),
	@phone2 varchar(20),
	@notes varchar(1000)

AS

BEGIN

	UPDATE Vendors SET vendor_name = @vendor_name, address = @address, phone1 = @phone1, phone2 = @phone2, notes = @notes WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[vendor_update_active]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendor_update_active]

	@id uniqueidentifier,
	@new_active bit

AS

BEGIN

	UPDATE Vendors SET active = @new_active WHERE id=@id

END


GO
/****** Object:  StoredProcedure [dbo].[VendorDebits_add]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VendorDebits_add]

	@Id uniqueidentifier,
	@Vendors_Id uniqueidentifier, 
	@Amount decimal(11,2),
	@Notes varchar(MAX),
	@sale_payment_id uniqueidentifier,
	@Type_enumid tinyint

AS

BEGIN

	INSERT INTO VendorDebits(Id,Vendors_Id,Timestamp,Amount,Notes,sale_payment_id,Type_enumid) 
	VALUES(@Id,@Vendors_Id,CURRENT_TIMESTAMP,@Amount,@Notes,@sale_payment_id,@Type_enumid)

END

GO
/****** Object:  StoredProcedure [dbo].[VendorDebits_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VendorDebits_get]

	@Vendors_Id uniqueidentifier

AS

BEGIN

	SELECT VendorDebits.*, 
		Vendors.vendor_name AS Vendors_Name,
		ISNULL(VendorDebits.Type_enumid, Payments.PaymentMethod_enumid) AS PaymentType_enumid,
		'' AS PaymentType_name,
		0 AS balance
	FROM VendorDebits 
		LEFT OUTER JOIN Payments ON Payments.id = VendorDebits.sale_payment_id
		LEFT OUTER JOIN Vendors ON Vendors.id = VendorDebits.Vendors_Id
	WHERE VendorDebits.Vendors_Id = @Vendors_Id
	ORDER BY VendorDebits.Timestamp ASC

END

GO
/****** Object:  StoredProcedure [dbo].[VendorDebits_get_balance]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VendorDebits_get_balance]

	@Vendors_Id uniqueidentifier 

AS

BEGIN

	SELECT COALESCE(VendorDebitSummary.balance,0)
	FROM (	SELECT VendorDebits.Vendors_Id, 
					SUM(VendorDebits.amount) AS balance 
			FROM VendorDebits
			WHERE VendorDebits.Vendors_Id = @Vendors_Id
			GROUP BY VendorDebits.Vendors_Id) VendorDebitSummary
		LEFT OUTER JOIN Vendors ON Vendors.id = VendorDebitSummary.Vendors_Id

END

GO
/****** Object:  StoredProcedure [dbo].[VendorDebits_get_summary]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[VendorDebits_get_summary]

AS

BEGIN

	SELECT VendorDebitSummary.Vendors_Id, VendorDebitSummary.balance, 
		Vendors.vendor_name AS Vendors_Name
	FROM (	SELECT VendorDebits.Vendors_Id, 
					SUM(VendorDebits.amount) AS balance 
			FROM VendorDebits
			GROUP BY VendorDebits.Vendors_Id) VendorDebitSummary
		LEFT OUTER JOIN Vendors ON Vendors.id = VendorDebitSummary.Vendors_Id
	ORDER BY Vendors.vendor_name ASC

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_get]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_get]
	
	@id uniqueidentifier = NULL, 
	@invoice_no varchar(50) = NULL,
	@include_completed bit = 1,
	@status_completed tinyint,
	@status_cancelled tinyint  
	
AS

BEGIN

	SELECT VendorInvoices.*,
		Vendors.vendor_name AS VendorName,
		VendorInvoices.tax_dpp * 1.1 AS total_dpp_ppn,
		CompiledInventory.total_buy_value AS total_actual_value,
		DATEADD(day, 3 + VendorInvoices.[TOP], timestamp) AS pastdue,
		CAST(CASE WHEN DATEADD(day, 3 + VendorInvoices.[TOP], timestamp) < CURRENT_TIMESTAMP THEN 1 ELSE 0 END AS BIT) AS is_due,
		0 AS PayableAmount
	FROM VendorInvoices
		LEFT OUTER JOIN (
				SELECT Inventory.vendorinvoice_id, MAX(Inventory.id) AS inventoryid
				FROM Inventory
				GROUP BY Inventory.vendorinvoice_id
			) InvoiceInventory ON InvoiceInventory.vendorinvoice_id = VendorInvoices.id
		LEFT OUTER JOIN Inventory ON Inventory.id = InvoiceInventory.inventoryid
		LEFT OUTER JOIN POItems ON POItems.id = Inventory.po_item_id
		LEFT OUTER JOIN POs ON POs.id = POItems.po_id
		LEFT OUTER JOIN Vendors ON Vendors.id = POs.vendor_id
		LEFT OUTER JOIN (		
				SELECT Inventory.vendorinvoice_id, SUM(CompiledInventoryBuyValue.total_buy_value) AS total_buy_value
				FROM (
						SELECT CompiledInventoryItems.inventory_id, CompiledInventoryItems.total_length * Inventory.buy_price AS total_buy_value
						FROM (
								SELECT InventoryItems.inventory_id, SUM(InventoryItems.item_length) AS total_length
								FROM InventoryItems
									LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
									LEFT OUTER JOIN VendorInvoices ON VendorInvoices.id = Inventory.vendorinvoice_id
								WHERE 1=1
									AND (@id IS NULL OR Inventory.vendorinvoice_id = @id)
									AND (@invoice_no IS NULL OR VendorInvoices.invoice_no LIKE '%' + @invoice_no + '%')
								GROUP BY InventoryItems.inventory_id
							) CompiledInventoryItems
							LEFT OUTER JOIN Inventory ON Inventory.id = CompiledInventoryItems.inventory_id
					) CompiledInventoryBuyValue
					LEFT OUTER JOIN Inventory ON Inventory.id = CompiledInventoryBuyValue.inventory_id
				GROUP BY Inventory.vendorinvoice_id
			) CompiledInventory ON CompiledInventory.vendorinvoice_id = VendorInvoices.id
	WHERE 1=1
		AND (@id IS NULL OR VendorInvoices.id = @id)
		AND (@invoice_no IS NULL OR VendorInvoices.invoice_no LIKE '%' + @invoice_no + '%')
		AND (@include_completed = 1 OR (@include_completed = 0 AND VendorInvoices.status_enum_id <> @status_cancelled AND VendorInvoices.status_enum_id <> @status_completed))
	ORDER BY VendorInvoices.timestamp DESC

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_get_by_invoiceNo]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_get_by_invoiceNo]

	@invoice_no varchar(50), 
	@id uniqueidentifier OUTPUT
	
AS

BEGIN

	SELECT @id = MAX(VendorInvoices.id) FROM VendorInvoices WHERE VendorInvoices.invoice_no = @invoice_no

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_isInvoiceNoExist]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_isInvoiceNoExist]

	@invoice_no varchar(50), 
	@id uniqueidentifier = NULL,
	@return_value bit = 0 OUTPUT

AS

BEGIN

	IF EXISTS (SELECT id FROM VendorInvoices WHERE invoice_no = @invoice_no AND (@id IS NULL OR id <> @id))
		RETURN 1
	ELSE
		RETURN 0

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_new]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_new]

	@id uniqueidentifier, 
	@invoice_no varchar(50),
	@status_enum_id tinyint,
	@notes varchar(1000) = NULL

AS

BEGIN

	INSERT INTO VendorInvoices(id,invoice_no,notes,status_enum_id,timestamp) 
	VALUES(@id,@invoice_no,@notes,@status_enum_id,CURRENT_TIMESTAMP)

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_update]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_update]

	@id uniqueidentifier, 
	@invoice_no varchar(50),
	@tax_no varchar(50),
	@tax_dpp decimal(12,2),
	@TOP int,
	@SetorTunai bit,
	@notes varchar(MAX)

AS

BEGIN

	UPDATE VendorInvoices SET 
		invoice_no = @invoice_no,
		tax_no = @tax_no,
		tax_dpp = @tax_dpp,
		[TOP] = @TOP,
		SetorTunai = @SetorTunai,
		notes = @notes
	WHERE id=@id

END

GO
/****** Object:  StoredProcedure [dbo].[vendorinvoice_update_status]    Script Date: 03/05/2019 2:58:21 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[vendorinvoice_update_status]

	@id uniqueidentifier, 
	@status_enum_id tinyint

AS

BEGIN

	UPDATE VendorInvoices SET status_enum_id = @status_enum_id WHERE id=@id

END

GO
