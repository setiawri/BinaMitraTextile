using System;
using System.ComponentModel.DataAnnotations;
    
namespace BinaMitraTextileWebApp.Models
{
    public class ProfitLossStatementsModel
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


        [Display(Name = "Beginning Stock Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? BeginningStockValue { get; set; }


        [Display(Name = "Ending Stock Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? EndingStockValue { get; set; }


        [Display(Name = "Net Purchased Inventory Value")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? NetPurchasedInventoryValue { get; set; }


        [Display(Name = "Sales Gross Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? SalesGrossProfit { get; set; }


        [Display(Name = "Company Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? CompanyExpenses { get; set; }


        [Display(Name = "Operating Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? OperatingProfit { get; set; }


        [Display(Name = "Other Revenues And Expenses")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? OtherRevenuesAndExpenses { get; set; }


        [Display(Name = "Pre Tax Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? PreTaxProfit { get; set; }


        [Display(Name = "Taxes")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? Taxes { get; set; }


        [Display(Name = "Net Profit")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal? NetProfit { get; set; }

        /******************************************************************************************************************************************************/

    }
}