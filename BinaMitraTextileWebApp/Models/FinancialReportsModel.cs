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


        [Display(Name = "Sales Qty")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesQty { get; set; }


        [Display(Name = "Sales Sell Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesSellValue { get; set; }


        [Display(Name = "Sales Buy Value (COGS)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesBuyValue { get; set; }


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


        [Display(Name = "Total Vendor Invoices")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? TotalVendorInvoices { get; set; }


        [Display(Name = "Payable Vendor Invoices")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PayableVendorInvoices { get; set; }


        [Display(Name = "Bank Deposits")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BankDeposits { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Receivables { get; set; }


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Transfers { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Expenses { get; set; }


        /******************************************************************************************************************************************************/

    }
}