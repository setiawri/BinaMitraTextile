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


        [Display(Name = "Sales Sell Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesSellValue { get; set; }


        [Display(Name = "Sales Shipping Cost")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesShippingCost { get; set; }


        [Display(Name = "Sales Shipping Expense")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesShippingExpense { get; set; }


        [Display(Name = "Sales Buy Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesBuyValue { get; set; }


        [Display(Name = "Sales Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesProfit { get; set; }


        [Display(Name = "Beginning Inventory Buy Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BeginningInventoryBuyValue { get; set; }


        [Display(Name = "Ending Inventory Buy Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? EndingInventoryBuyValue { get; set; }


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