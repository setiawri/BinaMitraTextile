using BinaMitraTextileWebApp.Controllers;
using System;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp.Models
{
    public class RevenuesAndExpensesModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Display(Name = "Timestamp")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy}")]
        public DateTime? Timestamp { get; set; }
        public static ModelMember COL_Timestamp = new ModelMember { Name = "Timestamp", Display = "Timestamp", LogDisplay = ActivityLogsController.editDateTimeFormat("Timestamp") };


        [Display(Name = "Category")]
        public Guid RevenueAndExpenseCategories_Id { get; set; }
        public static ModelMember COL_RevenueAndExpenseCategories_Id = new ModelMember { Name = "RevenueAndExpenseCategories_Id", Display = "Category", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Category") };
        public string RevenueAndExpenseCategories_Name { get; set; }


        public string Description { get; set; } = null;
        public static ModelMember COL_Description = new ModelMember { Name = "Description", Display = "Description", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Description") };


        [DisplayFormat(DataFormatString = "{0:N2}")]
        public long Amount { get; set; } = 0;
        public static ModelMember COL_Amount = new ModelMember { Name = "Amount", Display = "Amount", LogDisplay = LIBUtil.ActivityLog.editIntFormat("Amount") };


        /******************************************************************************************************************************************************/

    }
}