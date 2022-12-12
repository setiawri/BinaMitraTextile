using System;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp.Models
{
    public class RevenueAndExpenseCategoriesModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Display(Name = "Name")]
        public string Name { get; set; }
        public static ModelMember COL_Name = new ModelMember { Name = "Name", Display = "Name", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Name") };


        public bool Revenue { get; set; } = false;
        public static ModelMember COL_Revenue = new ModelMember { Name = "Revenue", Display = "Revenue", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Revenue") };


        public bool Expense { get; set; } = false;
        public static ModelMember COL_Expense = new ModelMember { Name = "Expense", Display = "Expense", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Expense") };


        public bool Personal { get; set; } = false;
        public static ModelMember COL_Personal = new ModelMember { Name = "Personal", Display = "Personal", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Personal") };


        public bool Company { get; set; } = false;
        public static ModelMember COL_Company = new ModelMember { Name = "Company", Display = "Company", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Company") };


        public bool ProfitLoss { get; set; } = false;
        public static ModelMember COL_ProfitLoss = new ModelMember { Name = "ProfitLoss", Display = "ProfitLoss", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("ProfitLoss") };


        public string Notes { get; set; }
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Notes") };


        public bool Active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "Active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };

        /******************************************************************************************************************************************************/

    }
}