using System;
using System.ComponentModel.DataAnnotations;
    
namespace BinaMitraTextileWebApp.Models
{
    public class FinancialReportsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Display(Name = "Period")]
        [DisplayFormat(DataFormatString = "{0:MM/yy}")]
        public DateTime? Period { get; set; }
        public static ModelMember COL_Period = new ModelMember { Name = "Period", Display = "Period" };


        public string Notes { get; set; }
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes" };

        /******************************************************************************************************************************************************/

        [Display(Name = "Sales Sell Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesSellValue { get; set; }
        [Display(Name = "Sales Buy Value (COGS)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesBuyValue { get; set; }
        [Display(Name = "Sales Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesQty { get; set; }
        [Display(Name = "Sales Gross Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesGrossProfit { get; set; }


        [Display(Name = "Sales Shipping Cost")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesShippingCost { get; set; }


        [Display(Name = "Sales Shipping Expense")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesShippingExpense { get; set; }


        [Display(Name = "Sales Net Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesNetProfit { get; set; }


        [Display(Name = "Sales Net Profit Up To Date")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesNetProfitUpToDate { get; set; }


        [Display(Name = "Sales Payments - Cash")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_Cash { get; set; }


        [Display(Name = "Sales Payments - EDC")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_EDC { get; set; }


        [Display(Name = "Sales Payments - Transfer")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_Transfer { get; set; }


        [Display(Name = "Sales Payments - Credit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_Credit { get; set; }


        [Display(Name = "Sales Payments - Giro")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_Giro { get; set; }


        [Display(Name = "Sales Payments - Others")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesPayments_Others { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Receivables { get; set; }

        /******************************************************************************************************************************************************/

        [Display(Name = "Beginning Stock Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BeginningStockValue { get; set; }


        [Display(Name = "Beginning Stock Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BeginningStockQty { get; set; }


        [Display(Name = "Ending Stock Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? EndingStockValue { get; set; }


        [Display(Name = "Ending Stock Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? EndingStockQty { get; set; }


        [Display(Name = "Stock Increase Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? StockIncreaseValue { get; set; }


        [Display(Name = "Stock Increase Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? StockIncreaseQty { get; set; }


        [Display(Name = "Received Inventory Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReceivedInventoryValue { get; set; }


        [Display(Name = "Received Inventory Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReceivedInventoryQty { get; set; }


        [Display(Name = "Returned Inventory To Vendor Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReturnedToVendorInventoryQty { get; set; }


        [Display(Name = "Returned Inventory To Vendor Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReturnedToVendorInventoryValue { get; set; }


        [Display(Name = "Net Purchased Inventory Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? NetPurchasedInventoryQty { get; set; }


        [Display(Name = "Net Purchased Inventory Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? NetPurchasedInventoryValue { get; set; }

        /******************************************************************************************************************************************************/

        [Display(Name = "Beginning Petty Cash Balance")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BeginningPettyCashBalance { get; set; }


        [Display(Name = "Ending Petty Cash Balance")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? EndingPettyCashBalance { get; set; }


        [Display(Name = "Received Cash From Sales")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReceivedCashFromSales { get; set; }


        [Display(Name = "Received Cash From Others")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? ReceivedCashFromOthers { get; set; }


        [Display(Name = "Bank Cash Deposits")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BankCashDeposits { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Expenses { get; set; }

        /******************************************************************************************************************************************************/

        [Display(Name = "TOTAL REVENUES & EXPENSES")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TotalRevenuesAndExpenses { get; set; }


        [Display(Name = "Company Revenues & Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? CompanyTotalRevenuesAndExpenses { get; set; }


        [Display(Name = "Company Revenues")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? CompanyRevenues { get; set; }


        [Display(Name = "Company Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? CompanyExpenses { get; set; }


        [Display(Name = "Personal Revenues & Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalTotalRevenuesAndExpenses { get; set; }


        [Display(Name = "Personal Revenues")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalRevenues { get; set; }


        [Display(Name = "Personal Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalExpenses { get; set; }


        /******************************************************************************************************************************************************/

        [Display(Name = "Total Vendor Invoices")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TotalVendorInvoices { get; set; }


        [Display(Name = "Payable Vendor Invoices")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PayableVendorInvoices { get; set; }


        /******************************************************************************************************************************************************/

        [Display(Name = "Personal Net Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalNetProfit { get; set; }


        [Display(Name = "Personal Assets Starting Balance")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalAssetsStartingBalance { get; set; }


        [Display(Name = "Personal Assets Ending Balance")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PersonalAssetsEndingBalance { get; set; }

        /******************************************************************************************************************************************************/

        [Display(Name = "Pending PO Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PendingPOValue { get; set; }


        /******************************************************************************************************************************************************/

    }
}