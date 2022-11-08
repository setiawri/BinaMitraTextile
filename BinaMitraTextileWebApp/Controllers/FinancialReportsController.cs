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

            string sql = string.Format(@"                        

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
                                AND Vendors_Id IS NULL

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
                                AND Vendors_Id IS NULL

                            DECLARE @SalesNetProfit decimal(15,2) = NULL
                            SET @SalesNetProfit = @SalesGrossProfit + @SalesShippingCost - @SalesShippingExpense;
                        
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
                        
                            DECLARE @Receivables decimal(15,2) = NULL
                            SELECT @Receivables = SUM(CompiledSales.Amount + Sales.shipping_cost - SalePayments.Amount)
                            FROM (
                                    SELECT SaleItems.sale_id, SUM((InventoryItems.item_length * (SaleItems.sell_price+SaleItems.adjustment))) AS Amount
                                    FROM SaleItems
                                        LEFT JOIN Sales ON Sales.id = SaleItems.sale_id
                                        LEFT JOIN InventoryItems ON InventoryItems.id = SaleItems.inventory_item_id
                                        LEFT JOIN Inventory ON Inventory.id = InventoryItems.inventory_id
                                    WHERE Sales.time_stamp <= @PeriodEnd
                                        AND Sales.Vendors_Id IS NULL
                                    GROUP BY SaleItems.sale_id
                                ) CompiledSales
                                LEFT JOIN Sales ON Sales.id = CompiledSales.sale_id
                                LEFT JOIN (
                                    SELECT Payments.ReferenceId, SUM(Payments.Amount) AS Amount
                                    FROM Payments
                                    WHERE Payments.Timestamp <= @PeriodEnd
                                    GROUP BY Payments.ReferenceId
                                ) SalePayments ON SalePayments.ReferenceId = Sales.id
                            WHERE Sales.time_stamp <= @PeriodEnd
                        
                            DECLARE @Transfers decimal(15,2) = NULL
                            SET @Transfers = 0;
                        
                            DECLARE @Expenses decimal(15,2) = NULL
                            SET @Expenses = 0;

							IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NULL
                            BEGIN
                        	    SELECT 
                                    NEWID() AS Id,
                                    @PeriodStart AS [Period],
                                    @SalesQty AS SalesQty,
                                    @SalesSellValue AS SalesSellValue,
                                    @SalesBuyValue AS SalesBuyValue,
                                    @SalesGrossProfit AS SalesGrossProfit,
                                    @SalesShippingCost AS SalesShippingCost,
                                    @SalesShippingExpense AS SalesShippingExpense,
                                    @SalesNetProfit AS SalesNetProfit,
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
                                    @TotalVendorInvoices AS TotalVendorInvoices,
                                    @PayableVendorInvoices AS PayableVendorInvoices,
                                    @BankDeposits AS BankDeposits,
                                    @Receivables AS Receivables,
                                    @Transfers AS Transfers,
                                    @Expenses AS Expenses
                                INTO #TEMP_RESULT 
                            END
							ELSE 
                            BEGIN
                                INSERT INTO #TEMP_RESULT
                                SELECT
                                    NEWID() AS Id,
                                    @PeriodStart AS [Period],
                                    @SalesQty AS SalesQty,
                                    @SalesSellValue AS SalesSellValue,
                                    @SalesBuyValue AS SalesBuyValue,
                                    @SalesGrossProfit AS SalesGrossProfit,
                                    @SalesShippingCost AS SalesShippingCost,
                                    @SalesShippingExpense AS SalesShippingExpense,
                                    @SalesNetProfit AS SalesNetProfit,
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
                                    @TotalVendorInvoices AS TotalVendorInvoices,
                                    @PayableVendorInvoices AS PayableVendorInvoices,
                                    @BankDeposits AS BankDeposits,
                                    @Receivables AS Receivables,
                                    @Transfers AS Transfers,
                                    @Expenses AS Expenses
                            END
		
                        END

                        SELECT * FROM #TEMP_RESULT
						
						-- clean up
						IF(SELECT object_id('TempDB..#TEMP_RESULT')) IS NOT NULL
							DROP TABLE #TEMP_RESULT
                        

                    ");

            return new DBContext().Database.SqlQuery<FinancialReportsModel>(sql,
                    DBConnection.getSqlParameter(FinancialReportsModel.COL_Id.Name, Id),
                    DBConnection.getSqlParameter("FILTER_DateFrom", FILTER_DateFrom),
                    DBConnection.getSqlParameter("FILTER_DateTo", Util.getAsEndDate(FILTER_DateTo))
                ).ToList();
        }

        /******************************************************************************************************************************************************/
    }
}