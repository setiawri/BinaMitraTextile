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

            string sql = getSQL();
            return new DBContext().Database.SqlQuery<FinancialReportsModel>(getSQL(),
                    DBConnection.getSqlParameter(FinancialReportsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_DateFrom", FILTER_DateFrom),
                    DBConnection.getSqlParameter("FILTER_DateTo", Util.getAsEndDate(FILTER_DateTo))
                ).ToList();
        }

        public static string getSQL()
        {
            return string.Format(@"                        

    DECLARE @PeriodStart datetime = @FILTER_DateFrom
    DECLARE @PeriodEnd datetime = @FILTER_DateFrom

    WHILE @PeriodEnd < @FILTER_DateTo
    BEGIN
        SET @PeriodStart = @PeriodEnd
        SET @PeriodEnd = DATEADD(day, 1, EOMONTH(@PeriodEnd))
							    
        -- SALES --------------------------------------------------------------------------------------------------------------------------
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
            AND Sales.time_stamp <= @PeriodEnd
            AND SaleItems.return_id IS NULL
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesGrossProfit decimal(15,2) = NULL
        SET @SalesGrossProfit = @SalesSellValue - @SalesBuyValue;

        DECLARE @SalesShippingCost decimal(15,2) = NULL
        DECLARE @SalesShippingExpense decimal(15,2) = NULL
        SELECT @SalesShippingCost = SUM(COALESCE(Sales.shipping_cost,0)),
            @SalesShippingExpense = SUM(COALESCE(Sales.ShippingExpense,0))
        FROM Sales
        WHERE 1=1
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesNetProfit decimal(15,2) = NULL
        SET @SalesNetProfit = @SalesGrossProfit + @SalesShippingCost - @SalesShippingExpense;

        -- SALES PAYMENTS -----------------------------------------------------------------------------------------------------------------

        DECLARE @SalesPayments_Cash decimal(15,2) = NULL
        SELECT @SalesPayments_Cash = SUM(COALESCE(Payments.Amount,0))
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 0
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesPayments_EDC decimal(15,2) = 0
        SELECT @SalesPayments_EDC = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 1
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesPayments_Transfer decimal(15,2) = 0
        SELECT @SalesPayments_Transfer = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 2
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesPayments_Credit decimal(15,2) = 0
        SELECT @SalesPayments_Credit = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 3
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesPayments_Giro decimal(15,2) = 0
        SELECT @SalesPayments_Giro = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 4
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @SalesPayments_Others decimal(15,2) = 0
        SELECT @SalesPayments_Others = ISNULL(SUM(COALESCE(Payments.Amount,0)),0)
        FROM Payments
            LEFT JOIN Sales ON Sales.Id = Payments.ReferenceId
        WHERE 1=1
            AND Payments.PaymentMethod_enumid = 6
            AND Sales.time_stamp >= @PeriodStart 
            AND Sales.time_stamp <= @PeriodEnd
            AND Sales.Vendors_Id IS NULL

        DECLARE @Receivables decimal(15,2) = 
            @SalesSellValue 
            + @SalesShippingCost
            - @SalesPayments_Cash 
            - @SalesPayments_EDC 
            - @SalesPayments_Transfer
            - @SalesPayments_Credit
            - @SalesPayments_Giro
            - @SalesPayments_Others                        

--        SELECT @Receivables = SUM(CompiledSales.Amount + Sales.shipping_cost - SalePayments.Amount)
--        FROM (
--                SELECT SaleItems.sale_id, SUM((InventoryItems.item_length * (SaleItems.sell_price+SaleItems.adjustment))) AS Amount
--                FROM SaleItems
--                    LEFT JOIN Sales ON Sales.id = SaleItems.sale_id
--                    LEFT JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
--                    LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
--                WHERE Sales.time_stamp <= @PeriodEnd
--                    AND Sales.Vendors_Id IS NULL
--                GROUP BY SaleItems.sale_id
--            ) CompiledSales
--            LEFT JOIN Sales ON Sales.id = CompiledSales.sale_id
--            LEFT JOIN (
--                SELECT Payments.ReferenceId, SUM(Payments.Amount) AS Amount
--                FROM Payments
--                WHERE Payments.Timestamp <= @PeriodEnd
--                GROUP BY Payments.ReferenceId
--            ) SalePayments ON SalePayments.ReferenceId = Sales.id
--        WHERE Sales.time_stamp <= @PeriodEnd
                        
        -- INVENTORY ----------------------------------------------------------------------------------------------------------------------
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
                        
        DECLARE @EndingStockValue decimal(15,2) = NULL
        DECLARE @EndingStockQty decimal(15,2) = NULL
        SELECT @EndingStockValue = SUM(InventoryItems.item_length * Inventory.buy_price),
            @EndingStockQty = SUM(InventoryItems.item_length)
        FROM InventoryItems
            LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
            LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
            LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp <= @PeriodEnd
        WHERE Sales.id IS NULL
            AND Inventory.receive_date <= @PeriodEnd

        DECLARE @StockIncreaseValue decimal(15,2) = NULL
        SET @StockIncreaseValue = @EndingStockValue - @BeginningStockValue;
        DECLARE @StockIncreaseQty decimal(15,2) = NULL
        SET @StockIncreaseQty = @EndingStockQty - @BeginningStockQty;
                                         
        DECLARE @ReceivedInventoryQty decimal(15,2) = NULL
        DECLARE @ReceivedInventoryValue decimal(15,2) = NULL
        SELECT @ReceivedInventoryQty = SUM(InventoryItems.item_length),
            @ReceivedInventoryValue = SUM(InventoryItems.item_length * Inventory.buy_price)
        FROM InventoryItems
            LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
        WHERE 1=1
            AND Inventory.receive_date >= @PeriodStart
            AND Inventory.receive_date <= @PeriodEnd

        DECLARE @ReturnedToVendorInventoryQty decimal(15,2) = NULL
        DECLARE @ReturnedToVendorInventoryValue decimal(15,2) = NULL
        SELECT @ReturnedToVendorInventoryQty = SUM(InventoryItems.item_length),
            @ReturnedToVendorInventoryValue = SUM(InventoryItems.item_length * Inventory.buy_price)
        FROM InventoryItems
            LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
            LEFT JOIN SaleItems ON SaleItems.inventory_item_id = InventoryItems.id AND SaleItems.return_id IS NULL
            LEFT JOIN Sales ON Sales.id = SaleItems.sale_id AND Sales.time_stamp >= @PeriodStart AND Sales.time_stamp <= @PeriodEnd
        WHERE 1=1
            AND Sales.Vendors_Id IS NOT NULL
           
        DECLARE @NetPurchasedInventoryQty decimal(15,2) = NULL
        SELECT @NetPurchasedInventoryQty = @ReceivedInventoryQty - @ReturnedToVendorInventoryQty

        DECLARE @NetPurchasedInventoryValue decimal(15,2) = NULL
        SELECT @NetPurchasedInventoryValue = @ReceivedInventoryValue - @ReturnedToVendorInventoryValue

        -- PETTY CASH ---------------------------------------------------------------------------------------------------------------------
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


        DECLARE @BankCashDeposits decimal(15,2) = NULL
        SELECT @BankCashDeposits = SUM(MoneyAccountItems.Amount * -1)
        FROM MoneyAccountItems
            LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
        WHERE 1=1
            AND MoneyAccountItems.Timestamp >= @PeriodStart
            AND MoneyAccountItems.Timestamp <= @PeriodEnd
            AND MoneyAccountCategoryAssignments.BankCashDeposit = 1

        DECLARE @Expenses decimal(15,2) = NULL
        SELECT @Expenses = SUM(MoneyAccountItems.Amount * -1)
        FROM MoneyAccountItems
            LEFT JOIN MoneyAccountCategoryAssignments ON MoneyAccountCategoryAssignments.MoneyAccounts_Id = MoneyAccountItems.MoneyAccounts_Id AND MoneyAccountCategoryAssignments.MoneyAccountCategories_Id = MoneyAccountItems.MoneyAccountCategories_Id 
        WHERE 1=1
            AND MoneyAccountItems.Timestamp >= @PeriodStart
            AND MoneyAccountItems.Timestamp <= @PeriodEnd
            AND MoneyAccountCategoryAssignments.Expense = 1

        -- INVOICES -----------------------------------------------------------------------------------------------------------------------
        DECLARE @TotalVendorInvoices decimal(15,2) = NULL
        SELECT @TotalVendorInvoices = SUM(VendorInvoices.Amount)
        FROM VendorInvoices
        WHERE VendorInvoices.timestamp >= @PeriodStart
            AND VendorInvoices.timestamp <= @PeriodEnd

        DECLARE @PayableVendorInvoices decimal(15,2) = NULL
        SELECT @PayableVendorInvoices = SUM(TotaledVendorInvoicePaymentItems.Amount - VendorInvoices.Amount)
        FROM VendorInvoices
            LEFT JOIN (
                SELECT VendorInvoicePaymentItems.VendorInvoices_Id, SUM(VendorInvoicePaymentItems.Amount) AS Amount
                FROM VendorInvoicePaymentItems
                GROUP BY VendorInvoicePaymentItems.VendorInvoices_Id
            ) TotaledVendorInvoicePaymentItems ON TotaledVendorInvoicePaymentItems.VendorInvoices_Id =  VendorInvoices.id
        WHERE VendorInvoices.timestamp <= @PeriodEnd


        DECLARE @BankDeposits decimal(15,2) = NULL
        SET @BankDeposits = 0;
                        
        DECLARE @Transfers decimal(15,2) = NULL
        SET @Transfers = 0;
                        

        -- COMPILE RESULTS ----------------------------------------------------------------------------------------------------------------

		IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NULL
        BEGIN
            SELECT {0} INTO #TEMP_RESULT 
        END
		ELSE 
        BEGIN
            INSERT INTO #TEMP_RESULT SELECT {0} 
        END
		
    END

    SELECT * FROM #TEMP_RESULT
						
	-- clean up
	IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NOT NULL
		DROP TABLE #TEMP_RESULT
", @"
    NEWID() AS Id,
    @PeriodStart AS [Period],
    @SalesQty AS SalesQty,
    @SalesSellValue AS SalesSellValue,
    @SalesBuyValue AS SalesBuyValue,
    @SalesGrossProfit AS SalesGrossProfit,
    @SalesShippingCost AS SalesShippingCost,
    @SalesShippingExpense AS SalesShippingExpense,
    @SalesNetProfit AS SalesNetProfit,

    @SalesPayments_Cash AS SalesPayments_Cash,
    @SalesPayments_EDC AS SalesPayments_EDC,
    @SalesPayments_Transfer AS SalesPayments_Transfer,
    @SalesPayments_Credit AS SalesPayments_Credit,
    @SalesPayments_Giro AS SalesPayments_Giro,
    @SalesPayments_Others AS SalesPayments_Others,
    @Receivables AS Receivables,

    @BeginningStockValue AS BeginningStockValue,
    @BeginningStockQty AS BeginningStockQty,
    @EndingStockValue AS EndingStockValue,
    @EndingStockQty AS EndingStockQty,
    @StockIncreaseValue AS StockIncreaseValue,
    @StockIncreaseQty AS StockIncreaseQty,
    @ReceivedInventoryValue AS ReceivedInventoryValue,
    @ReceivedInventoryQty AS ReceivedInventoryQty,
    @ReturnedToVendorInventoryValue AS ReturnedToVendorInventoryValue,
    @ReturnedToVendorInventoryQty AS ReturnedToVendorInventoryQty,
    @NetPurchasedInventoryValue AS NetPurchasedInventoryValue,
    @NetPurchasedInventoryQty AS NetPurchasedInventoryQty,

    @BeginningPettyCashBalance AS BeginningPettyCashBalance,
    @EndingPettyCashBalance AS EndingPettyCashBalance,
    @BankCashDeposits AS BankCashDeposits,
    @Expenses AS Expenses,

    @TotalVendorInvoices AS TotalVendorInvoices,
    @PayableVendorInvoices AS PayableVendorInvoices
                    ");
        }

        /******************************************************************************************************************************************************/
    }
}