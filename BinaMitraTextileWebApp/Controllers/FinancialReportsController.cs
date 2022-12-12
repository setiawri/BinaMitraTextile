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

        private const string Guid_SalesNetProfitUpToDate = "2C1356F9-079E-4FAB-931F-4AF501ED76F2";
        private const string Guid_PersonalAssets = "63B78400-4A9E-41E1-B4E9-30FF85C6FBBE";

        /* INDEX **********************************************************************************************************************************************/

        public ActionResult Index(int? rss, DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            if (!UsersController.getUserAccess(Session).FinancialReports_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (UtilWebMVC.hasNoFilter(FILTER_DatePeriodStart, FILTER_DatePeriodEnd))
            {
                FILTER_DatePeriodStart = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime().AddMonths(-1));
                FILTER_DatePeriodEnd = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime());
                setViewBag(FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            }

            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                List<FinancialReportsModel> models = get(null, FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
                return View(models);
            }
        }

        [HttpPost]
        public ActionResult Index(DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            setViewBag(FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            List<FinancialReportsModel> models = get(null, FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            return View(models);
        }

        /* PROFT LOSS STATEMENTS ******************************************************************************************************************************/

        public ActionResult ProfitLossStatements(int? rss, DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            if (!UsersController.getUserAccess(Session).FinancialReports_View)
                return RedirectToAction(nameof(HomeController.Index), "Home");

            if (UtilWebMVC.hasNoFilter(FILTER_DatePeriodStart, FILTER_DatePeriodEnd))
            {
                FILTER_DatePeriodStart = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime().AddMonths(-1));
                FILTER_DatePeriodEnd = Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime());
                setViewBag(FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            }

            if (rss != null)
            {
                ViewBag.RemoveDatatablesStateSave = rss;
                return View();
            }
            else
            {
                List<FinancialReportsModel> models = get(null, FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
                return View(models);
            }
        }

        [HttpPost]
        public ActionResult ProfitLossStatements(DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            setViewBag(FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            List<FinancialReportsModel> models = get(null, FILTER_DatePeriodStart, FILTER_DatePeriodEnd);
            return View(models);
        }

        /* METHODS ********************************************************************************************************************************************/

        public void setViewBag(DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            ViewBag.FILTER_DatePeriodStart = FILTER_DatePeriodStart ?? Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime());
            ViewBag.FILTER_DatePeriodEnd = FILTER_DatePeriodEnd ?? Util.getFirstDayOfSelectedMonth(Helper.getCurrentDateTime());
        }

        /* DATABASE METHODS ***********************************************************************************************************************************/

        public static FinancialReportsModel get(DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd) { return get(null, FILTER_DatePeriodStart, FILTER_DatePeriodEnd).FirstOrDefault(); }
        public static List<FinancialReportsModel> get(Guid? Id, 
            DateTime? FILTER_DatePeriodStart, DateTime? FILTER_DatePeriodEnd)
        {
            DBContext dbContext = new DBContext(180);
            return dbContext.Database.SqlQuery<FinancialReportsModel>(getSQL(),
                    DBConnection.getSqlParameter(FinancialReportsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_DatePeriodStart", FILTER_DatePeriodStart),
                    DBConnection.getSqlParameter("FILTER_DatePeriodEnd", Util.getAsEndDate(FILTER_DatePeriodEnd))
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

                    DECLARE @PeriodStart datetime = @FILTER_DatePeriodStart
                    DECLARE @PeriodEnd datetime = @FILTER_DatePeriodStart

                    WHILE @PeriodEnd <= @FILTER_DatePeriodEnd
                    BEGIN
                        SET @PeriodStart = @PeriodEnd
                        SET @PeriodEnd = DATEADD(month, 1, @PeriodEnd)

                        -- SQL STATEMENTS TO POPULATE VARIABLES -------------------------------------------------------------------------------------------
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

        public static string appendVariable(string variables, string field)
        {
            return Util.append(variables, string.Format("ISNULL(@{0},0) AS {0}", field), ",");
        }

        /* SALES **********************************************************************************************************************************************/

        public static void sql_SalesNetProfit(ref string statements, ref string variables)
        {
            sql_RevenuesAndExpenses(ref statements, ref variables); 
            sql_SalesGrossProfit(ref statements, ref variables);
            sql_SalesShippingCost(ref statements, ref variables);

            statements += string.Format(@"
                    DECLARE @SalesNetProfit decimal(15,2) = 0
                    SET @SalesNetProfit = ISNULL(@SalesGrossProfit,0) + ISNULL(@SalesShippingCost,0) - ISNULL(@SalesShippingExpense,0) - ISNULL(@Expenses,0) + ISNULL(@CompanyTotalRevenuesAndExpenses,0);


                    DECLARE @SalesNetProfitUpToDate decimal(15,2) = 0
                    SELECT TOP 1 @SalesNetProfitUpToDate = ISNULL(ReportBalances.Amount,0)
                    FROM ReportBalances
                    WHERE ReportBalances.[Period] = DATEADD(month, -1, @PeriodStart) AND ReportBalances.TypeId = '{0}'
                    SET @SalesNetProfitUpToDate = ISNULL(@SalesNetProfitUpToDate,0) + ISNULL(@SalesNetProfit,0)
                    DELETE ReportBalances WHERE ReportBalances.[Period] = @PeriodStart AND ReportBalances.TypeId = '{0}'                     
                    INSERT INTO ReportBalances(Id,Period,Amount,TypeId) VALUES(NEWID(),@PeriodStart,@SalesNetProfitUpToDate,'{0}')
                ", Guid_SalesNetProfitUpToDate);

            variables = appendVariable(variables, "SalesNetProfit");
            variables = appendVariable(variables, "SalesNetProfitUpToDate");
        }

        public static void sql_SalesGrossProfit(ref string statements, ref string variables)
        {
            sql_Sales(ref statements, ref variables);

            statements += @"
                    DECLARE @SalesGrossProfit decimal(15,2) = ISNULL(@SalesSellValue,0) - ISNULL(@SalesBuyValue,0);
                ";

            variables = appendVariable(variables, "SalesGrossProfit");
        }

        public static void sql_Sales(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesSellValue decimal(15,2) = 0
                    DECLARE @SalesBuyValue decimal(15,2) = 0
                    DECLARE @SalesQty decimal(15,2) = 0
                    SET @SalesSellValue = 0;
                    SELECT @SalesSellValue = SUM(ISNULL(InventoryItems.item_length,0) * (ISNULL(SaleItems.sell_price,0) + ISNULL(SaleItems.adjustment,0))),
                        @SalesBuyValue = SUM(ISNULL(InventoryItems.item_length,0) * ISNULL(Inventory.buy_price,0)),
                        @SalesQty = SUM(ISNULL(InventoryItems.item_length,0))
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

            variables = appendVariable(variables, "SalesSellValue");
            variables = appendVariable(variables, "SalesBuyValue");
            variables = appendVariable(variables, "SalesQty");
        }

        public static void sql_SalesShippingCost(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesShippingCost decimal(15,2) = 0
                    DECLARE @SalesShippingExpense decimal(15,2) = 0
                    SELECT @SalesShippingCost = SUM(ISNULL(Sales.shipping_cost,0)),
                        @SalesShippingExpense = SUM(ISNULL(Sales.ShippingExpense,0))
                    FROM Sales
                    WHERE 1=1
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesShippingCost");
            variables = appendVariable(variables, "SalesShippingExpense");
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
                    --        SELECT @Receivables = SUM(ISNULL(CompiledSales.Amount,0) + ISNULL(Sales.shipping_cost,0) - ISNULL(SalePayments.Amount,0))
                    --        FROM (
                    --                SELECT SaleItems.sale_id, SUM((ISNULL(InventoryItems.item_length,0) * (ISNULL(SaleItems.sell_price,0) + ISNULL(SaleItems.adjustment,0)))) AS Amount
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
                    --                SELECT Payments.ReferenceId, SUM(ISNULL(Payments.Amount,0)) AS Amount
                    --                FROM Payments
                    --                WHERE Payments.Timestamp < @PeriodEnd
                    --                GROUP BY Payments.ReferenceId
                    --            ) SalePayments ON SalePayments.ReferenceId = Sales.id
                    --        WHERE Sales.time_stamp < @PeriodEnd
                      
                ";

            variables = appendVariable(variables, "Receivables");
        }

        public static void sql_SalesPayments_Cash(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Cash decimal(15,2) = 0
                    SELECT @SalesPayments_Cash = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 0
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_Cash");
        }

        public static void sql_SalesPayments_EDC(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_EDC decimal(15,2) = 0
                    SELECT @SalesPayments_EDC = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 1
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_EDC");
        }

        public static void sql_SalesPayments_Transfer(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Transfer decimal(15,2) = 0
                    SELECT @SalesPayments_Transfer = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 2
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_Transfer");
        }

        public static void sql_SalesPayments_Credit(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Credit decimal(15,2) = 0
                    SELECT @SalesPayments_Credit = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 3
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_Credit");
        }

        public static void sql_SalesPayments_Giro(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Giro decimal(15,2) = 0
                    SELECT @SalesPayments_Giro = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 4
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_Giro");
        }

        public static void sql_SalesPayments_Others(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @SalesPayments_Others decimal(15,2) = 0
                    SELECT @SalesPayments_Others = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                        LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 6
                        AND Sales.time_stamp >= @PeriodStart 
                        AND Sales.time_stamp < @PeriodEnd
                        AND Sales.Vendors_Id IS NULL
                ";

            variables = appendVariable(variables, "SalesPayments_Others");
        }

        /* INVENTORY ******************************************************************************************************************************************/

        public static void sql_StockIncrease(ref string statements, ref string variables)
        {
            sql_BeginningStock(ref statements, ref variables);
            sql_EndingStock(ref statements, ref variables);

            statements += @"
                    DECLARE @StockIncreaseValue decimal(15,2) = ISNULL(@EndingStockValue,0) - ISNULL(@BeginningStockValue,0);
                    DECLARE @StockIncreaseQty decimal(15,2) = ISNULL(@EndingStockQty,0) - ISNULL(@BeginningStockQty,0);                                         
                ";

            variables = appendVariable(variables, "StockIncreaseValue");
            variables = appendVariable(variables, "StockIncreaseQty");
        }

        public static void sql_BeginningStock(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @BeginningStockValue decimal(15,2) = 0
                    DECLARE @BeginningStockQty decimal(15,2) = 0
                    SELECT @BeginningStockValue = SUM(ISNULL(InventoryItems.item_length,0) * ISNULL(Inventory.buy_price,0)),
                        @BeginningStockQty = SUM(ISNULL(InventoryItems.item_length,0))
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp <= @PeriodStart
                    WHERE Sales.id IS NULL
                        AND Inventory.receive_date <= @PeriodStart
                ";

            variables = appendVariable(variables, "BeginningStockValue");
            variables = appendVariable(variables, "BeginningStockQty");
        }

        public static void sql_EndingStock(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @EndingStockValue decimal(15,2) = 0
                    DECLARE @EndingStockQty decimal(15,2) = 0
                    SELECT @EndingStockValue = SUM(ISNULL(InventoryItems.item_length,0) * ISNULL(Inventory.buy_price,0)),
                        @EndingStockQty = SUM(ISNULL(InventoryItems.item_length,0))
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp < @PeriodEnd
                    WHERE Sales.id IS NULL
                        AND Inventory.receive_date < @PeriodEnd
                ";

            variables = appendVariable(variables, "EndingStockValue");
            variables = appendVariable(variables, "EndingStockQty");
        }

        public static void sql_NetPurchasedInventory(ref string statements, ref string variables)
        {
            sql_ReceivedInventory(ref statements, ref variables);
            sql_ReturnedToVendorInventory(ref statements, ref variables);

            statements += @"
                    DECLARE @NetPurchasedInventoryQty decimal(15,2) = ISNULL(@ReceivedInventoryQty,0) - ISNULL(@ReturnedToVendorInventoryQty,0)
                    DECLARE @NetPurchasedInventoryValue decimal(15,2) = ISNULL(@ReceivedInventoryValue,0) - ISNULL(@ReturnedToVendorInventoryValue,0)
                ";

            variables = appendVariable(variables, "NetPurchasedInventoryValue");
            variables = appendVariable(variables, "NetPurchasedInventoryQty");
        }

        public static void sql_ReceivedInventory(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedInventoryQty decimal(15,2) = 0
                    DECLARE @ReceivedInventoryValue decimal(15,2) = 0
                    SELECT @ReceivedInventoryQty = SUM(ISNULL(InventoryItems.item_length,0)),
                        @ReceivedInventoryValue = SUM(ISNULL(InventoryItems.item_length,0) * ISNULL(Inventory.buy_price,0))
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                    WHERE 1=1
                        AND Inventory.receive_date >= @PeriodStart
                        AND Inventory.receive_date < @PeriodEnd
                ";

            variables = appendVariable(variables, "ReceivedInventoryValue");
            variables = appendVariable(variables, "ReceivedInventoryQty");
        }

        public static void sql_ReturnedToVendorInventory(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReturnedToVendorInventoryQty decimal(15,2) = 0
                    DECLARE @ReturnedToVendorInventoryValue decimal(15,2) = 0
                    SELECT @ReturnedToVendorInventoryQty = SUM(ISNULL(InventoryItems.item_length,0)),
                        @ReturnedToVendorInventoryValue = SUM(ISNULL(InventoryItems.item_length,0) * ISNULL(Inventory.buy_price,0))
                    FROM InventoryItems
                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                        LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp >= @PeriodStart AND Sales.time_stamp < @PeriodEnd
                    WHERE 1=1
                        AND Sales.Vendors_Id IS NOT NULL           
                ";

            variables = appendVariable(variables, "ReturnedToVendorInventoryValue");
            variables = appendVariable(variables, "ReturnedToVendorInventoryQty");
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
                    DECLARE @BeginningPettyCashBalance decimal(15,2) = 0		
                    DECLARE @EndingPettyCashBalance decimal(15,2) = 0
	                SELECT @BeginningPettyCashBalance = ISNULL(LastEntry.InitialBalance,0),
		                @EndingPettyCashBalance = ISNULL(LastEntry.Balance,0)
	                FROM (
			                SELECT TOP 1 * FROM (
				                SELECT MoneyAccountItems.*,
					                ISNULL(InitialBalance.Amount,0) + (SUM(ISNULL(MoneyAccountItems.Amount,0)) OVER(ORDER BY MoneyAccountItems.Timestamp ASC)) AS Balance,
					                ISNULL(InitialBalance.Amount,0) AS InitialBalance
				                FROM MoneyAccountItems
					                LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
					                LEFT JOIN (
							                SELECT 1 AS Id, SUM(ISNULL(MoneyAccountItems.Amount,0)) AS Amount
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

            variables = appendVariable(variables, "BeginningPettyCashBalance");
            variables = appendVariable(variables, "EndingPettyCashBalance");
        }

        public static void sql_ReceivedCashFromSales(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedCashFromSales decimal(15,2) = 0
                    SELECT @ReceivedCashFromSales = SUM(ISNULL(Payments.Amount,0))
                    FROM Payments
                    WHERE 1=1
                        AND Payments.PaymentMethod_enumid = 0
                        AND Payments.Timestamp >= @PeriodStart 
                        AND Payments.Timestamp < @PeriodEnd
                ";

            variables = appendVariable(variables, "ReceivedCashFromSales");
        }

        public static void sql_ReceivedCashFromOthers(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @ReceivedCashFromOthers decimal(15,2) = 0
                    SELECT @ReceivedCashFromOthers = SUM(ISNULL(MoneyAccountItems.Amount,0))
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.ReceivedCash = 1
                ";

            variables = appendVariable(variables, "ReceivedCashFromOthers");
        }

        public static void sql_BankCashDeposits(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @BankCashDeposits decimal(15,2) = 0
                    SELECT @BankCashDeposits = SUM(ISNULL(MoneyAccountItems.Amount,0) * -1)
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.BankCashDeposit = 1
                ";

            variables = appendVariable(variables, "BankCashDeposits");
        }

        public static void sql_Expenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @Expenses decimal(15,2) = 0
                    SELECT @Expenses = SUM(ISNULL(MoneyAccountItems.Amount,0) * -1)
                    FROM MoneyAccountItems
			            LEFT JOIN MoneyAccounts ON MoneyAccounts.Id = MoneyAccountItems.MoneyAccounts_Id
                        LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
                    WHERE 1=1
                        AND MoneyAccounts.[Default] = 1
                        AND MoneyAccountItems.Timestamp >= @PeriodStart
                        AND MoneyAccountItems.Timestamp < @PeriodEnd
                        AND MoneyAccountCategoryAssignments.Expense = 1
                ";

            variables = appendVariable(variables, "Expenses");
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
                    DECLARE @TotalRevenuesAndExpenses decimal(15,2) = 0
                    SELECT @TotalRevenuesAndExpenses = SUM(ISNULL(RevenuesAndExpenses.Amount,0))
                    FROM RevenuesAndExpenses
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                ";

            variables = appendVariable(variables, "TotalRevenuesAndExpenses");
        }

        public static void sql_CompanyTotalRevenuesAndExpenses(ref string statements, ref string variables)
        {
            sql_CompanyRevenues(ref statements, ref variables);
            sql_CompanyExpenses(ref statements, ref variables);

            statements += @"
                    DECLARE @CompanyTotalRevenuesAndExpenses decimal(15,2) = ISNULL(@CompanyRevenues,0) - ISNULL(@CompanyExpenses,0)
                ";

            variables = appendVariable(variables, "CompanyTotalRevenuesAndExpenses");
        }

        public static void sql_CompanyRevenues(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @CompanyRevenues decimal(15,2) = 0
                    SELECT @CompanyRevenues = SUM(ISNULL(RevenuesAndExpenses.Amount,0))
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Company = 1
                        AND Revenue = 1
                ";

            variables = appendVariable(variables, "CompanyRevenues");
        }

        public static void sql_CompanyExpenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @CompanyExpenses decimal(15,2) = 0
                    SELECT @CompanyExpenses = SUM(ISNULL(RevenuesAndExpenses.Amount,0))
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Company = 1
                        AND Expense = 1
                ";

            variables = appendVariable(variables, "CompanyExpenses");
        }

        public static void sql_PersonalTotalRevenuesAndExpenses(ref string statements, ref string variables)
        {
            sql_PersonalRevenues(ref statements, ref variables);
            sql_PersonalExpenses(ref statements, ref variables);

            statements += @"
                    DECLARE @PersonalTotalRevenuesAndExpenses decimal(15,2) = ISNULL(@PersonalRevenues,0) - ISNULL(@PersonalExpenses,0)
                ";

            variables = appendVariable(variables, "PersonalTotalRevenuesAndExpenses");
        }

        public static void sql_PersonalRevenues(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PersonalRevenues decimal(15,2) = 0
                    SELECT @PersonalRevenues = SUM(ISNULL(RevenuesAndExpenses.Amount,0))
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Personal = 1
                        AND Revenue = 1
                ";

            variables = appendVariable(variables, "PersonalRevenues");
        }

        public static void sql_PersonalExpenses(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PersonalExpenses decimal(15,2) = 0
                    SELECT @PersonalExpenses = SUM(ISNULL(RevenuesAndExpenses.Amount,0))
                    FROM RevenuesAndExpenses
                        LEFT JOIN RevenueAndExpenseCategories ON RevenueAndExpenseCategories.Id = RevenuesAndExpenses.RevenueAndExpenseCategories_Id
                    WHERE RevenuesAndExpenses.Timestamp >= @PeriodStart
                        AND RevenuesAndExpenses.Timestamp < @PeriodEnd
                        AND Personal = 1
                        AND Expense = 1
                ";

            variables = appendVariable(variables, "PersonalExpenses");
        }

        /* PERSONAL NET PROFIT ********************************************************************************************************************************/

        public static void sql_PersonalNetProfit(ref string statements, ref string variables)
        {
            statements += string.Format(@"
                    DECLARE @PersonalAssetsStartingBalance decimal(15,2) = 0
                    SELECT TOP 1 @PersonalAssetsStartingBalance = ISNULL(ReportBalances.Amount,0)
                    FROM ReportBalances
                    WHERE ReportBalances.[Period] = DATEADD(month, -1, @PeriodStart) AND ReportBalances.TypeId = '{0}' 

                    DECLARE @PersonalNetProfit decimal(15,2) = ISNULL(@SalesNetProfit,0) + ISNULL(@PersonalTotalRevenuesAndExpenses,0)

                    DECLARE @PersonalAssetsEndingBalance decimal(15,2) = ISNULL(@PersonalAssetsStartingBalance,0) + ISNULL(@PersonalNetProfit,0)
                    
                    DELETE ReportBalances WHERE ReportBalances.[Period] = @PeriodStart AND ReportBalances.TypeId = '{0}'               
                    INSERT INTO ReportBalances(Id,Period,Amount,TypeId) VALUES(NEWID(),@PeriodStart,@PersonalAssetsEndingBalance,'{0}')
                ", Guid_PersonalAssets);

            variables = appendVariable(variables, "PersonalNetProfit");
            variables = appendVariable(variables, "PersonalAssetsStartingBalance");
            variables = appendVariable(variables, "PersonalAssetsEndingBalance");
        }

        /******************************************************************************************************************************************************/

        public static void sql_VendorInvoices(ref string statements, ref string variables)
        {
            statements += @"
                    -- INVOICES -----------------------------------------------------------------------------------------------------------------------
                    DECLARE @TotalVendorInvoices decimal(15,2) = 0
                    SELECT @TotalVendorInvoices = SUM(ISNULL(VendorInvoices.Amount,0))
                    FROM VendorInvoices
                    WHERE VendorInvoices.timestamp >= @PeriodStart
                        AND VendorInvoices.timestamp < @PeriodEnd
                ";

            variables = appendVariable(variables, "TotalVendorInvoices");
        }

        public static void sql_PayableVendorInvoices(ref string statements, ref string variables)
        {
            statements += @"
                    DECLARE @PayableVendorInvoices decimal(15,2) = 0
                    SELECT @PayableVendorInvoices = SUM(ISNULL(TotaledVendorInvoicePaymentItems.Amount,0) - ISNULL(VendorInvoices.Amount,0))
                    FROM VendorInvoices
                        LEFT JOIN (
                            SELECT VendorInvoicePaymentItems.VendorInvoices_Id, SUM(ISNULL(VendorInvoicePaymentItems.Amount,0)) AS Amount
                            FROM VendorInvoicePaymentItems
                            GROUP BY VendorInvoicePaymentItems.VendorInvoices_Id
                        ) TotaledVendorInvoicePaymentItems ON TotaledVendorInvoicePaymentItems.VendorInvoices_Id =  VendorInvoices.id
                    WHERE VendorInvoices.timestamp < @PeriodEnd
                ";

            variables = appendVariable(variables, "PayableVendorInvoices");
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