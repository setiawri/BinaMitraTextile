using System;
using System.Linq;
using System.Collections.Generic;
using System.Web.Mvc;
using BinaMitraTextileWebApp.Models;
using LIBUtil;
using LIBWebMVC;
using System.Reflection;

namespace BinaMitraTextileWebApp.Controllers
{
    public class FinancialReportsController : Controller
    {
        private readonly DBContext db = new DBContext();

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (!UsersController.getUserAccess(Session).FinancialReports_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (UtilWebMVC.hasNoFilter(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo))
            {
                FILTER_chkDateFrom = true;
                FILTER_DateFrom = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime().AddMonths(-1));
                FILTER_chkDateTo = true;
                FILTER_DateTo = Util.getLastDayOfSelectedMonth((DateTime)FILTER_DateFrom);
                setViewBag(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            }

            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                List<FinancialReportsModel> models = get(null, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
                return View(models);
            }
        }

        [HttpPost]
        public ActionResult Index(bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            setViewBag(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            List<FinancialReportsModel> models = get(null, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(models);
        }

        /* PROFT LOSS STATEMENTS ******************************************************************************************************************************/

        public ActionResult ProfitLossStatements(int? rss, bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (!UsersController.getUserAccess(Session).FinancialReports_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (UtilWebMVC.hasNoFilter(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo))
            {
                FILTER_chkDateFrom = true;
                FILTER_DateFrom = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime().AddMonths(-1));
                FILTER_chkDateTo = true;
                FILTER_DateTo = Util.getLastDayOfSelectedMonth((DateTime)FILTER_DateFrom);
                setViewBag(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            }

            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                List<FinancialReportsModel> models = get(null, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
                return View(models);
            }
        }

        [HttpPost]
        public ActionResult ProfitLossStatements(bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            setViewBag(FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            List<FinancialReportsModel> models = get(null, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo);
            return View(models);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            ViewBag.FILTER_chkDateFrom = FILTER_chkDateFrom;
            ViewBag.FILTER_DateFrom = FILTER_DateFrom;
            ViewBag.FILTER_chkDateTo = FILTER_chkDateTo;
            ViewBag.FILTER_DateTo = FILTER_DateTo;
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public static FinancialReportsModel get(bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo) { return get(null, FILTER_chkDateFrom, FILTER_DateFrom, FILTER_chkDateTo, FILTER_DateTo).FirstOrDefault(); }
        public static List<FinancialReportsModel> get(Guid? Id, 
            bool? FILTER_chkDateFrom, DateTime? FILTER_DateFrom, bool? FILTER_chkDateTo, DateTime? FILTER_DateTo)
        {
            if (FILTER_chkDateFrom == null || !(bool)FILTER_chkDateFrom)
                FILTER_DateFrom = null;

            if (FILTER_chkDateTo == null || !(bool)FILTER_chkDateTo)
                FILTER_DateTo = null;

            return new DBContext().Database.SqlQuery<FinancialReportsModel>(getSQL(),
                    DBConnection.getSqlParameter(FinancialReportsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_DateFrom", FILTER_DateFrom),
                    DBConnection.getSqlParameter("FILTER_DateTo", Util.getAsEndDate(FILTER_DateTo))
                ).ToList();
        }

        public static string getSQL()
        {
            string statements = "";
            string variables = initializeSql();

            sql_PettyCash(ref statements, ref variables);
            sql_SalesNetProfit(ref statements, ref variables);
            sql_Receivables(ref statements, ref variables);
            sql_StockIncrease(ref statements, ref variables);
            sql_NetPurchasedInventory(ref statements, ref variables);
            sql_VendorInvoices(ref statements, ref variables);
            sql_PayableVendorInvoices(ref statements, ref variables);
            sql_PersonalNetProfit(ref statements, ref variables);

            return finalizeSql(statements, variables);
        }

        public static string initializeSql()
        {
            return @"
                    NEWID() AS Id,
                    @PeriodStart AS [Period]           
                ";
        }

        public static string finalizeSql(string statements, string variables)
        {
            string sql = string.Format(@"

                    DECLARE @PeriodStart datetime = @FILTER_DateFrom
                    DECLARE @PeriodEnd datetime = @FILTER_DateFrom

                    WHILE @PeriodEnd < @FILTER_DateTo
                    BEGIN
                        SET @PeriodStart = @PeriodEnd
                        SET @PeriodEnd = DATEADD(day, 1, EOMONTH(@PeriodEnd))

                        {0}

                        -- COMPILE RESULTS ----------------------------------------------------------------------------------------------------------------

		                IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NULL
                        BEGIN
                            SELECT {1} INTO #TEMP_RESULT 
                        END
		                ELSE 
                        BEGIN
                            INSERT INTO #TEMP_RESULT SELECT {1} 
                        END
		
                    END

                    SELECT * FROM #TEMP_RESULT
						
	                -- clean up
	                IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NOT NULL
		                DROP TABLE #TEMP_RESULT
				", statements, variables);

            return sql;
        }

        /* SALES **********************************************************************************************************************************************/

        public static void sql_SalesNetProfit(ref string statements, ref string variables)
        {
            sql_RevenuesAndExpenses(ref statements, ref variables); 
            sql_SalesGrossProfit(ref statements, ref variables);
            sql_SalesShippingCost(ref statements, ref variables);

            statements += @"
                    DECLARE @SalesNetProfit decimal(15,2) = NULL
                    SET @SalesNetProfit = @SalesGrossProfit + @SalesShippingCost - @SalesShippingExpense - @Expenses + @CompanyTotalRevenuesAndExpenses;
                ";

            variables = Util.append(variables, @"
                    @SalesNetProfit AS SalesNetProfit
                ", ",");
        }

        public static void sql_SalesGrossProfit(ref string statements, ref string variables)
        {
            sql_Sales(ref statements, ref variables);

            statements += @"
                    DECLARE @SalesGrossProfit decimal(15,2) = @SalesSellValue - @SalesBuyValue;
                ";

            variables = Util.append(variables, @"
                    @SalesGrossProfit AS SalesGrossProfit
                ", ",");
        }

        public static void sql_Sales(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesSellValue decimal(15,2) = NULL
                    DECLARE @SalesBuyValue decimal(15,2) = NULL
                    DECLARE @SalesQty decimal(15,2) = NULL
                    SET @SalesSellValue = 0;
                    SELECT @SalesSellValue = SUM(InventoryItems.item_length * (SaleItems.sell_price+SaleItems.adjustment)),
                        @SalesBuyValue = SUM(InventoryItems.item_length * (Inventory.buy_price)),
                        @SalesQty = SUM(InventoryItems.item_length)
                    FROM SaleItems
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id
                        LEFT JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                    WHERE 1=1
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND SaleItems.return_id IS NULL
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesQty AS SalesQty,
                    @SalesSellValue AS SalesSellValue,
                    @SalesBuyValue AS SalesBuyValue
                ", ",");
        }

        public static void sql_SalesShippingCost(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesShippingCost decimal(15,2) = NULL
                    DECLARE @SalesShippingExpense decimal(15,2) = NULL
                    SELECT @SalesShippingCost = SUM(COALESCE(Sales.shipping_cost,0)),
                        @SalesShippingExpense = SUM(COALESCE(Sales.ShippingExpense,0))
                    FROM Sales
                    WHERE 1=1
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesShippingCost AS SalesShippingCost,
                    @SalesShippingExpense AS SalesShippingExpense
                ", ",");
        }

        /* SALES PAYMENTS *************************************************************************************************************************************/

        public static void sql_Receivables(ref string statements, ref string variables)
        {
            //Need sql_SalesNetProfit for @SalesSellValue and @SalesShippingCost 
            sql_SalesPayments_Cash(ref statements, ref variables);
            sql_SalesPayments_EDC(ref statements, ref variables);
            sql_SalesPayments_Transfer(ref statements, ref variables);
            sql_SalesPayments_Credit(ref statements, ref variables);
            sql_SalesPayments_Giro(ref statements, ref variables);
            sql_SalesPayments_Others(ref statements, ref variables);

            statements += @"
                    DECLARE @Receivables decimal(15,2) = 
                        @SalesSellValue 
                        + @SalesShippingCost
                        - @SalesPayments_Cash 
                        - @SalesPayments_EDC 
                        - @SalesPayments_Transfer
                        - @SalesPayments_Credit
                        - @SalesPayments_Giro
                        - @SalesPayments_Others    

                    -- ALTERNATIVE CALCULATION
                    --        SELECT @Receivables = SUM(CompiledSales.Amount + Sales.shipping_cost - SalePayments.Amount)
                    --        FROM (
                    --                SELECT SaleItems.sale_id, SUM((InventoryItems.item_length * (SaleItems.sell_price+SaleItems.adjustment))) AS Amount
                    --                FROM SaleItems
                    --                    LEFT JOIN Sales ON Sales.id = SaleItems.sale_id
                    --                    LEFT JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
                    --                    LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                    --                WHERE Sales.time_stamp < @PeriodEnd
                    --                    AND Sales.Vendors_Id IS NULL
                    --                GROUP BY SaleItems.sale_id
                    --            ) CompiledSales
                    --            LEFT JOIN Sales ON Sales.id = CompiledSales.sale_id
                    --            LEFT JOIN (
                    --                SELECT Payments.ReferenceId, SUM(Payments.Amount) AS Amount
                    --                FROM Payments
                    --                WHERE Payments.Timestamp < @PeriodEnd
                    --                GROUP BY Payments.ReferenceId
                    --            ) SalePayments ON SalePayments.ReferenceId = Sales.id
                    --        WHERE Sales.time_stamp < @PeriodEnd
                      
                ";

            variables = Util.append(variables, @"
                    @Receivables AS Receivables
                ", ",");
        }

        public static void sql_SalesPayments_Cash(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Cash decimal(15,2) = NULL
                    SELECT @SalesPayments_Cash = SUM(COALESCE(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 0
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_Cash AS SalesPayments_Cash
                ", ",");
        }

        public static void sql_SalesPayments_EDC(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_EDC decimal(15,2) = 0
                    SELECT @SalesPayments_EDC = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 1
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_EDC AS SalesPayments_EDC
                ", ",");
        }

        public static void sql_SalesPayments_Transfer(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Transfer decimal(15,2) = 0
                    SELECT @SalesPayments_Transfer = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 2
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_Transfer AS SalesPayments_Transfer
                ", ",");
        }

        public static void sql_SalesPayments_Credit(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Credit decimal(15,2) = 0
                    SELECT @SalesPayments_Credit = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 3
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_Credit AS SalesPayments_Credit
                ", ",");
        }

        public static void sql_SalesPayments_Giro(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Giro decimal(15,2) = 0
                    SELECT @SalesPayments_Giro = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 4
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_Giro AS SalesPayments_Giro
                ", ",");
        }

        public static void sql_SalesPayments_Others(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Others decimal(15,2) = 0
                    SELECT @SalesPayments_Others = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 6
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = Util.append(variables, @"
                    @SalesPayments_Others AS SalesPayments_Others
                ", ",");
        }

        /* INVENTORY ******************************************************************************************************************************************/

        public static void sql_StockIncrease(ref string statements, ref string variables)
        {
            sql_BeginningStock(ref statements, ref variables);
            sql_EndingStock(ref statements, ref variables);

            statements += @"
                    DECLARE @StockIncreaseValue decimal(15,2) = @EndingStockValue - @BeginningStockValue;
                    DECLARE @StockIncreaseQty decimal(15,2) = @EndingStockQty - @BeginningStockQty;                                         
                ";

            variables = Util.append(variables, @"
                    @StockIncreaseValue AS StockIncreaseValue,
                    @StockIncreaseQty AS StockIncreaseQty
                ", ",");
        }

        public static void sql_BeginningStock(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @BeginningStockValue decimal(15,2) = NULL
                    DECLARE @BeginningStockQty decimal(15,2) = NULL
                    SELECT @BeginningStockValue = SUM(InventoryItems.item_length * Inventory.buy_price),
                        @BeginningStockQty = SUM(InventoryItems.item_length)
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp <= @PeriodStart
                    WHERE Sales.id IS NULL
                        AND Inventory.receive_date <= @PeriodStart
                ";

            variables = Util.append(variables, @"
                    @BeginningStockValue AS BeginningStockValue,
                    @BeginningStockQty AS BeginningStockQty
                ", ",");
        }

        public static void sql_EndingStock(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @EndingStockValue decimal(15,2) = NULL
                    DECLARE @EndingStockQty decimal(15,2) = NULL
                    SELECT @EndingStockValue = SUM(InventoryItems.item_length * Inventory.buy_price),
                        @EndingStockQty = SUM(InventoryItems.item_length)
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp < @PeriodEnd
                    WHERE Sales.id IS NULL
                        AND Inventory.receive_date < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @EndingStockValue AS EndingStockValue,
                    @EndingStockQty AS EndingStockQty
                ", ",");
        }

        public static void sql_NetPurchasedInventory(ref string statements, ref string variables)
        {
            sql_ReceivedInventory(ref statements, ref variables);
            sql_ReturnedToVendorInventory(ref statements, ref variables);

            statements += @"
                    DECLARE @NetPurchasedInventoryQty decimal(15,2) = @ReceivedInventoryQty - @ReturnedToVendorInventoryQty
                    DECLARE @NetPurchasedInventoryValue decimal(15,2) = @ReceivedInventoryValue - @ReturnedToVendorInventoryValue
                ";

            variables = Util.append(variables, @"
                    @NetPurchasedInventoryValue AS NetPurchasedInventoryValue,
                    @NetPurchasedInventoryQty AS NetPurchasedInventoryQty
                ", ",");
        }

        public static void sql_ReceivedInventory(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedInventoryQty decimal(15,2) = NULL
                    DECLARE @ReceivedInventoryValue decimal(15,2) = NULL
                    SELECT @ReceivedInventoryQty = SUM(InventoryItems.item_length),
                        @ReceivedInventoryValue = SUM(InventoryItems.item_length * Inventory.buy_price)
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                    WHERE 1=1
                        AND Inventory.receive_date >= @PeriodStart
                        AND Inventory.receive_date < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @ReceivedInventoryValue AS ReceivedInventoryValue,
                    @ReceivedInventoryQty AS ReceivedInventoryQty
                ", ",");
        }

        public static void sql_ReturnedToVendorInventory(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReturnedToVendorInventoryQty decimal(15,2) = NULL
                    DECLARE @ReturnedToVendorInventoryValue decimal(15,2) = NULL
                    SELECT @ReturnedToVendorInventoryQty = SUM(InventoryItems.item_length),
                        @ReturnedToVendorInventoryValue = SUM(InventoryItems.item_length * Inventory.buy_price)
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp >= @PeriodStart AND Sales.time_stamp < @PeriodEnd
                    WHERE 1=1
                        AND Sales.Vendors_Id IS NOT NULL           
                ";

            variables = Util.append(variables, @"
                    @ReturnedToVendorInventoryValue AS ReturnedToVendorInventoryValue,
                    @ReturnedToVendorInventoryQty AS ReturnedToVendorInventoryQty
                ", ",");
        }

        /* PETTY CASH *****************************************************************************************************************************************/

        public static void sql_PettyCash(ref string statements, ref string variables)
        {
            sql_PettyCashBalance(ref statements, ref variables);
            sql_ReceivedCashFromSales(ref statements, ref variables);
            sql_ReceivedCashFromOthers(ref statements, ref variables);
            sql_BankCashDeposits(ref statements, ref variables);
            sql_Expenses(ref statements, ref variables);
        }

        public static void sql_PettyCashBalance(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @BeginningPettyCashBalance decimal(15,2) = NULL		
                    DECLARE @EndingPettyCashBalance decimal(15,2) = NULL
	                SELECT @BeginningPettyCashBalance = LastEntry.InitialBalance,
		                @EndingPettyCashBalance = LastEntry.Balance
	                FROM (
			                SELECT TOP 1 * FROM (
				                SELECT MoneyAccountItems.*,
					                InitialBalance.Amount + (SUM(MoneyAccountItems.Amount) OVER(ORDER BY MoneyAccountItems.Timestamp ASC)) AS Balance,
					                InitialBalance.Amount AS InitialBalance
				                FROM MoneyAccountItems
					                LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
					                LEFT JOIN (
							                SELECT 1 AS Id, ISNULL(SUM(MoneyAccountItems.Amount),0) AS Amount
							                FROM MoneyAccountItems
								                LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
							                WHERE 1=1
                				                AND MoneyAccounts.[Default] = 1
								                AND MoneyAccountItems.Timestamp < @PeriodStart
						                ) InitialBalance ON InitialBalance.Id = 1
				                WHERE 1=1
					                AND MoneyAccounts.[Default] = 1
					                AND MoneyAccountItems.Timestamp > @PeriodStart
					                AND MoneyAccountItems.Timestamp < @PeriodEnd
			                ) ResultTable
			                ORDER BY ResultTable.Timestamp DESC
		                ) LastEntry




                ";

            variables = Util.append(variables, @"
                    @BeginningPettyCashBalance AS BeginningPettyCashBalance,
                    @EndingPettyCashBalance AS EndingPettyCashBalance
                ", ",");
        }

        public static void sql_ReceivedCashFromSales(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedCashFromSales decimal(15,2) = NULL
                    SELECT @ReceivedCashFromSales = SUM(COALESCE(Payments.Amount,0))
                    FROM Payments
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 0
                        AND Payments.Timestamp >= @PeriodStart 
                        AND Payments.Timestamp < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @ReceivedCashFromSales AS ReceivedCashFromSales
                ", ",");
        }

        public static void sql_ReceivedCashFromOthers(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedCashFromOthers decimal(15,2) = NULL
                    SELECT @ReceivedCashFromOthers = ISNULL(SUM(COALESCE(MoneyAccountItems.Amount,0)),0)
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.ReceivedCash = 1
                ";

            variables = Util.append(variables, @"
                    @ReceivedCashFromOthers AS ReceivedCashFromOthers
                ", ",");
        }

        public static void sql_BankCashDeposits(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @BankCashDeposits decimal(15,2) = NULL
                    SELECT @BankCashDeposits = SUM(MoneyAccountItems.Amount * -1)
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.BankCashDeposit = 1
                ";

            variables = Util.append(variables, @"
                    @BankCashDeposits AS BankCashDeposits
                ", ",");
        }

        public static void sql_Expenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @Expenses decimal(15,2) = NULL
                    SELECT @Expenses = SUM(MoneyAccountItems.Amount * -1)
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.Expense = 1
                ";

            variables = Util.append(variables, @"
                    @Expenses AS Expenses
                ", ",");
        }

        /******************************************************************************************************************************************************/

        public static void sql_RevenuesAndExpenses(ref string statements, ref string variables)
        {
            sql_TotalRevenuesAndExpenses(ref statements, ref variables);
            sql_CompanyTotalRevenuesAndExpenses(ref statements, ref variables);
            sql_PersonalTotalRevenuesAndExpenses(ref statements, ref variables);
        }

        public static void sql_TotalRevenuesAndExpenses(ref string statements, ref string variables)
        {
            statements += @"
                    -- REVENUES AND EXPENSES ----------------------------------------------------------------------------------------------------------
                    DECLARE @TotalRevenuesAndExpenses decimal(15,2) = NULL
                    SELECT @TotalRevenuesAndExpenses = ISNULL(SUM(COALESCE(RevenuesAndExpenses.Amount,0)),0)
                    FROM RevenuesAndExpenses
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @TotalRevenuesAndExpenses AS TotalRevenuesAndExpenses
                ", ",");
        }

        public static void sql_CompanyTotalRevenuesAndExpenses(ref string statements, ref string variables)
        {
            sql_CompanyRevenues(ref statements, ref variables);
            sql_CompanyExpenses(ref statements, ref variables);

            statements += @"
                    DECLARE @CompanyTotalRevenuesAndExpenses decimal(15,2) = @CompanyRevenues - @CompanyExpenses
                ";

            variables = Util.append(variables, @"
                    @CompanyTotalRevenuesAndExpenses AS CompanyTotalRevenuesAndExpenses
                ", ",");
        }

        public static void sql_CompanyRevenues(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @CompanyRevenues decimal(15,2) = NULL
                    SELECT @CompanyRevenues = ISNULL(SUM(COALESCE(RevenuesAndExpenses.Amount,0)),0)
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Company = 1
                        AND Revenue = 1
                ";

            variables = Util.append(variables, @"
                    @CompanyRevenues AS CompanyRevenues
                ", ",");
        }

        public static void sql_CompanyExpenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @CompanyExpenses decimal(15,2) = NULL
                    SELECT @CompanyExpenses = ISNULL(SUM(COALESCE(RevenuesAndExpenses.Amount,0)),0)
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Company = 1
                        AND Expense = 1
                ";

            variables = Util.append(variables, @"
                    @CompanyExpenses AS CompanyExpenses
                ", ",");
        }

        public static void sql_PersonalTotalRevenuesAndExpenses(ref string statements, ref string variables)
        {
            sql_PersonalRevenues(ref statements, ref variables);
            sql_PersonalExpenses(ref statements, ref variables);

            statements += @"
                    DECLARE @PersonalTotalRevenuesAndExpenses decimal(15,2) = @PersonalRevenues - @PersonalExpenses
                ";

            variables = Util.append(variables, @"
                    @PersonalTotalRevenuesAndExpenses AS PersonalTotalRevenuesAndExpenses
                ", ",");
        }

        public static void sql_PersonalRevenues(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PersonalRevenues decimal(15,2) = NULL
                    SELECT @PersonalRevenues = ISNULL(SUM(COALESCE(RevenuesAndExpenses.Amount,0)),0)
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Personal = 1
                        AND Revenue = 1
                ";

            variables = Util.append(variables, @"
                    @PersonalRevenues AS PersonalRevenues
                ", ",");
        }

        public static void sql_PersonalExpenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PersonalExpenses decimal(15,2) = NULL
                    SELECT @PersonalExpenses = ISNULL(SUM(COALESCE(RevenuesAndExpenses.Amount,0)),0)
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Personal = 1
                        AND Expense = 1
                ";

            variables = Util.append(variables, @"
                    @PersonalExpenses AS PersonalExpenses
                ", ",");
        }

        /* PERSONAL NET PROFIT ********************************************************************************************************************************/

        public static void sql_PersonalNetProfit(ref string statements, ref string variables)
        {
            statements += @"
                    -- INVOICES -----------------------------------------------------------------------------------------------------------------------
                    DECLARE @PersonalNetProfit decimal(15,2) = @SalesNetProfit + @PersonalTotalRevenuesAndExpenses
                ";

            variables = Util.append(variables, @"
                    @PersonalNetProfit AS PersonalNetProfit
                ", ",");
        }

        /******************************************************************************************************************************************************/

        public static void sql_VendorInvoices(ref string statements, ref string variables)
        {
            statements += @"
                    -- INVOICES -----------------------------------------------------------------------------------------------------------------------
                    DECLARE @TotalVendorInvoices decimal(15,2) = NULL
                    SELECT @TotalVendorInvoices = SUM(VendorInvoices.Amount)
                    FROM VendorInvoices
                    WHERE VendorInvoices.timestamp >= @PeriodStart
                        AND VendorInvoices.timestamp < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @TotalVendorInvoices AS TotalVendorInvoices
                ", ",");
        }

        public static void sql_PayableVendorInvoices(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PayableVendorInvoices decimal(15,2) = NULL
                    SELECT @PayableVendorInvoices = SUM(TotaledVendorInvoicePaymentItems.Amount - VendorInvoices.Amount)
                    FROM VendorInvoices
                        LEFT JOIN (
                            SELECT VendorInvoicePaymentItems.VendorInvoices_Id, SUM(VendorInvoicePaymentItems.Amount) AS Amount
                            FROM VendorInvoicePaymentItems
                            GROUP BY VendorInvoicePaymentItems.VendorInvoices_Id
                        ) TotaledVendorInvoicePaymentItems ON TotaledVendorInvoicePaymentItems.VendorInvoices_Id =  VendorInvoices.id
                    WHERE VendorInvoices.timestamp < @PeriodEnd
                ";

            variables = Util.append(variables, @"
                    @PayableVendorInvoices AS PayableVendorInvoices
                ", ",");
        }

        /******************************************************************************************************************************************************/

        public static void sql_(ref string statements, ref string variables)
        {
            statements += @"
                ";

            variables = Util.append(variables, @"
                ", ",");
        }

        /******************************************************************************************************************************************************/
    }
}