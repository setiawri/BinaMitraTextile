

--------------------------------------------------------------------------
-- EXECUTED 24/8/2019
--------------------------------------------------------------------------


ALTER TABLE InventoryItems ADD SaleOrderItems_Id uniqueidentifier NULL


CREATE TABLE [dbo].[SaleOrders] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [Timestamp]    DATETIME         NOT NULL,
    [Customers_Id] UNIQUEIDENTIFIER NOT NULL,
    [CustomerInfo] VARCHAR(MAX) NULL, 
    [TargetDate]   DATE             NULL,
    [CustomerPONo] VARCHAR (MAX)    NULL,
    [Notes]        VARCHAR (MAX)    NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO 

CREATE TABLE [dbo].[SaleOrderItems] (
    [Id]                      UNIQUEIDENTIFIER NOT NULL,
    [SaleOrders_Id]                   UNIQUEIDENTIFIER NOT NULL,
    [Ref_Inventory_Id] UNIQUEIDENTIFIER NULL,
    [PricePerUnit]          DECIMAL (11, 2)   NOT NULL DEFAULT 0,
    [ProductDescription]     VARCHAR (MAX)    NOT NULL,
    [Qty]                     DECIMAL (8, 2)   NOT NULL,
    [UnitName]               VARCHAR (MAX)     NOT NULL,
    [LineNo]                 TINYINT          NOT NULL,
    [Status_enum_id]          TINYINT          DEFAULT ((0)) NOT NULL,
    [PriorityNo]              SMALLINT         NULL,
    [ExpectedDeliveryDate]    DATETIME         NULL,
    [Notes]                   VARCHAR (MAX)     NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);
GO

CREATE PROCEDURE [dbo].[SaleOrders_add]

	@Id uniqueidentifier,
	@Customers_Id uniqueidentifier, 
	@CustomerInfo varchar(MAX),
	@Notes varchar(MAX) = NULL, 
	@TargetDate datetime,
	@CustomerPONo varchar(MAX)

AS

BEGIN

	INSERT INTO SaleOrders(Id,Timestamp,Customers_Id,CustomerInfo,Notes,TargetDate,CustomerPONo) 
					VALUES(@Id,CURRENT_TIMESTAMP,@Customers_Id,@CustomerInfo,@Notes,@TargetDate,@CustomerPONo)

END
GO

CREATE PROCEDURE [dbo].[SaleOrders_get]
	
	@Id uniqueidentifier = NULL,
	@Customers_Id uniqueidentifier = NULL,
	@CustomerPONo varchar(MAX) = NULL,
	@FILTER_DateStart datetime = NULL,
	@FILTER_DateEnd datetime = NULL,
	@FILTER_StatusCompleted tinyint = 0,
	@FILTER_StatusCancelled tinyint = 0,
	@FILTER_ShowIncompleteOnly bit 
	
AS

BEGIN

	SELECT SaleOrders.*,
		calculation.Amount AS Amount,
		Customers.customer_name AS Customers_customer_name
	FROM SaleOrders 
		LEFT OUTER JOIN Customers ON Customers.id = SaleOrders.Customers_Id
		LEFT OUTER JOIN (SELECT SaleOrderItems.SaleOrders_Id, 
								SUM(COALESCE(SaleOrderItems.Qty,0) * COALESCE(SaleOrderItems.PricePerUnit,0)) AS Amount
							FROM SaleOrderItems GROUP BY SaleOrderItems.SaleOrders_Id) calculation 
		ON calculation.SaleOrders_Id = SaleOrders.Id
	WHERE 1=1
		AND (@Id IS NULL OR SaleOrders.Id = @Id)
		AND (@Customers_Id IS NULL OR SaleOrders.Customers_Id = @Customers_Id)
		AND (@CustomerPONo IS NULL OR SaleOrders.CustomerPONo LIKE '%' + @CustomerPONo + '%')
		AND (@FILTER_DateStart IS NULL OR SaleOrders.Timestamp > @FILTER_DateStart)
		AND (@FILTER_DateEnd IS NULL OR SaleOrders.Timestamp < @FILTER_DateEnd)
		AND (@FILTER_ShowIncompleteOnly = 0 
			OR (SaleOrders.Id IN (
						SELECT DISTINCT(SaleOrderItems.SaleOrders_Id) 
						FROM SaleOrderItems 
						WHERE SaleOrderItems.status_enum_id <> @FILTER_StatusCompleted 
							AND SaleOrderItems.status_enum_id <> @FILTER_StatusCancelled
					)
				)
			)
	ORDER BY SaleOrders.Timestamp DESC

END
GO

CREATE PROCEDURE [dbo].[SaleOrderItems_add]

	@Id uniqueidentifier, 
	@SaleOrders_Id uniqueidentifier,  
	@Ref_Inventory_Id uniqueidentifier = NULL,
	@PricePerUnit decimal(11,2),
	@ProductDescription varchar(MAX),
	@Qty decimal(8,2),
	@UnitName varchar(MAX),
	@LineNo tinyint,
	@Status_enum_id tinyint,
	@Notes varchar(MAX) NULL

AS

BEGIN

	INSERT INTO SaleOrderItems(Id,SaleOrders_Id,Ref_Inventory_Id,PricePerUnit,ProductDescription,Qty,UnitName,[LineNo],Status_enum_id,Notes) 
					VALUES(@Id,@SaleOrders_Id,@Ref_Inventory_Id,@PricePerUnit,@ProductDescription,@Qty,@UnitName,@LineNo,@Status_enum_id,@Notes)

END
GO

CREATE PROCEDURE [dbo].[SaleOrderItems_get]

	@Id uniqueidentifier NULL,
	@SaleOrders_Id uniqueidentifier NULL,
	@FILTER_Customers_Id uniqueidentifier NULL,
	@FILTER_StatusCompleted tinyint,
	@FILTER_StatusCancelled tinyint,
	@FILTER_ShowIncompleteOnly bit

AS

BEGIN

	SELECT SaleOrderItems.*,
		SaleOrders.Timestamp AS Timestamp,
		SaleOrders.Customers_Id AS Customers_Id,
		SaleOrders.CustomerPONo AS CustomerPONo,
		Customers.customer_name AS CustomerName,
		COALESCE(Qty,0) * COALESCE(PricePerUnit,0) AS subtotal,
		DATEDIFF(DAY, SaleOrders.Timestamp, CURRENT_TIMESTAMP) AS Age,
		Qty - COALESCE(ShippedInventoryItems.TotalQty,0) - COALESCE(BookedInventoryItems.TotalQty,0) AS RemainingQty,
		COALESCE(ShippedInventoryItems.TotalQty,0) AS ShippedQty,
		COALESCE(BookedInventoryItems.TotalQty,0) AS BookedQty,
		'' AS StatusName
	FROM SaleOrderItems 
		LEFT OUTER JOIN SaleOrders ON SaleOrders.id = SaleOrderItems.SaleOrders_Id
		LEFT OUTER JOIN Customers ON Customers.id = SaleOrders.Customers_Id
		LEFT OUTER JOIN (
				SELECT InventoryItems.SaleOrderItems_Id, SUM(InventoryItems.item_length) AS TotalQty
				FROM InventoryItems
					LEFT OUTER JOIN (
							SELECT inventory_item_id, isSold=1 
							FROM SaleItems 
							WHERE return_id IS NULL
						) SoldItems ON SoldItems.inventory_item_id = InventoryItems.id
				WHERE SaleOrderItems_Id IS NOT NULL AND SoldItems.isSold IS NULL
				GROUP BY InventoryItems.SaleOrderItems_Id
			) BookedInventoryItems ON BookedInventoryItems.SaleOrderItems_Id = SaleOrderItems.Id
		LEFT OUTER JOIN (
				SELECT InventoryItems.SaleOrderItems_Id, SUM(InventoryItems.item_length) AS TotalQty
				FROM InventoryItems
					LEFT OUTER JOIN (
							SELECT inventory_item_id, isSold=1 
							FROM SaleItems 
							WHERE return_id IS NULL
						) SoldItems ON SoldItems.inventory_item_id = InventoryItems.id
				WHERE SaleOrderItems_Id IS NOT NULL AND SoldItems.isSold IS NOT NULL
				GROUP BY InventoryItems.SaleOrderItems_Id
			) ShippedInventoryItems ON ShippedInventoryItems.SaleOrderItems_Id = SaleOrderItems.Id
	WHERE 1=1
		AND (@Id IS NULL OR SaleOrders.Id = @Id)
		AND (@SaleOrders_Id IS NULL OR SaleOrderItems.SaleOrders_Id = @SaleOrders_Id)
		AND (@FILTER_Customers_Id IS NULL OR SaleOrders.Customers_Id = @FILTER_Customers_Id)
		AND (@FILTER_ShowIncompleteOnly = 0 
			OR (SaleOrderItems.status_enum_id <> @FILTER_StatusCompleted 
					AND SaleOrderItems.status_enum_id <> @FILTER_StatusCancelled
				)
			)
	ORDER BY [LineNo] ASC

END
GO

CREATE PROCEDURE [dbo].[SaleOrderItems_update_Status_enum_id]

	@Id uniqueidentifier, 
	@Status_enum_id tinyint

AS

BEGIN

	UPDATE SaleOrderItems SET Status_enum_id = @Status_enum_id WHERE Id=@Id

END
GO

CREATE PROCEDURE [dbo].[InventoryItems_update_SaleOrderItems_Id]

	@id uniqueidentifier,
	@SaleOrderItems_Id uniqueidentifier

AS

BEGIN

	UPDATE InventoryItems SET SaleOrderItems_Id = @SaleOrderItems_Id WHERE id=@id

END
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
			LastOpnames.last_opname,
			(CASE WHEN InventoryItems.SaleOrderItems_Id IS NOT NULL 
             THEN SaleOrders.CustomerPONo + ' Line ' + CONVERT(varchar(10),SaleOrderItems.[LineNo])
             ELSE ''
	        END) AS SaleOrderItemDescription,
			Customers.customer_name AS SaleOrderItemCustomerName,
			Customers.id AS SaleOrders_Customers_Id
	FROM InventoryItems 
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Inventory.product_id = Products.id
		LEFT OUTER JOIN Colors ON Colors.id = InventoryItems.color_id
		LEFT OUTER JOIN Colors InventoryColors ON InventoryColors.id = Inventory.color_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN ProductPrices ProductPrices1 ON ProductPrices1.inventory_id = Inventory.id
		LEFT OUTER JOIN SaleOrderItems ON SaleOrderItems.Id = InventoryItems.SaleOrderItems_Id
		LEFT OUTER JOIN SaleOrders ON SaleOrders.Id = SaleOrderItems.SaleOrders_Id
		LEFT OUTER JOIN Customers ON Customers.id = SaleOrders.Customers_Id
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
			SoldItems.isSold AS isSold, 
			Grades.id AS Grades_Id,
			Grades.grade_name AS grade_name, 
			InventoryItemColors.color_name AS inventoryitem_color_name, 
			InventoryColors.color_name AS inventory_color_name,
			1 AS qty,
			ISNULL(AdjustmentWithColor.adjustment_per_unit, COALESCE(AdjustmentWithoutColor.adjustment_per_unit,0)) AS adjustment,
			--0.0 AS adjustment,
			0.0 AS adjusted_price,
			0.0 AS subtotal,
			@isManualAdjustment AS isManualAdjustment,
			(CASE WHEN InventoryItems.SaleOrderItems_Id IS NOT NULL 
             THEN SaleOrders.CustomerPONo + ' Line ' + CONVERT(varchar(10),SaleOrderItems.[LineNo])
             ELSE ''
	        END) AS SaleOrderItemDescription,
			Customers.customer_name AS SaleOrderItemCustomerName,
			Customers.id AS SaleOrders_Customers_Id
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
		LEFT OUTER JOIN SaleOrderItems ON SaleOrderItems.Id = InventoryItems.SaleOrderItems_Id
		LEFT OUTER JOIN SaleOrders ON SaleOrders.Id = SaleOrderItems.SaleOrders_Id
		LEFT OUTER JOIN Customers ON Customers.id = SaleOrders.Customers_Id
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
			1 AS qty,			
			InventoryItems.SaleOrderItems_Id,
			(CASE WHEN InventoryItems.SaleOrderItems_Id IS NOT NULL 
             THEN SaleOrders.CustomerPONo + ' Line ' + CONVERT(varchar(10),SaleOrderItems.[LineNo])
             ELSE ''
	        END) AS SaleOrderItemDescription
	FROM SaleItems
		LEFT OUTER JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
		LEFT OUTER JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
		LEFT OUTER JOIN Products ON Products.id = Inventory.product_id
		LEFT OUTER JOIN ProductStoreNames ON ProductStoreNames.id = Products.store_name_id
		LEFT OUTER JOIN LengthUnits ON LengthUnits.id = Inventory.length_unit_id
		LEFT OUTER JOIN Grades ON Grades.id = Inventory.grade_id
		LEFT OUTER JOIN ProductWidths ON ProductWidths.id = Inventory.product_width_id
		LEFT OUTER JOIN Colors ON Colors.id = Inventory.color_id
		LEFT OUTER JOIN SaleOrderItems ON SaleOrderItems.Id = InventoryItems.SaleOrderItems_Id
		LEFT OUTER JOIN SaleOrders ON SaleOrders.Id = SaleOrderItems.SaleOrders_Id
	WHERE sale_id = @sale_id
	ORDER BY InventoryItems.item_length ASC

END
GO


