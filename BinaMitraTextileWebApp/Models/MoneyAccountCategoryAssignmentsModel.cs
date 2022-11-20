using System;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp.Models
{
    public class MoneyAccountCategoryAssignmentsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        public string Notes { get; set; } = null;
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Notes") };


        [Display(Name = "Account")]
        public Guid MoneyAccounts_Id { get; set; }
        public static ModelMember COL_MoneyAccounts_Id = new ModelMember { Name = "MoneyAccounts_Id", Display = "Account", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Money Account") };
        public string MoneyAccounts_Name { get; set; }


        [Display(Name = "Category")]
        public Guid MoneyAccountCategories_Id { get; set; }
        public static ModelMember COL_MoneyAccountCategories_Id = new ModelMember { Name = "MoneyAccountCategories_Id", Display = "Category", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Money Account Category") };
        public string MoneyAccountCategories_Name { get; set; }


        public bool Default { get; set; }
        public static ModelMember COL_Default = new ModelMember { Name = "Default", Display = "Default", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Default") };


        public bool Active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "Active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };


        public bool Expense { get; set; } = false;
        public static ModelMember COL_Expense = new ModelMember { Name = "Expense", Display = "Expense", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Expense") };


        [Display(Name = "Bank Cash Deposit")]
        public bool BankCashDeposit { get; set; } = false;
        public static ModelMember COL_BankCashDeposit = new ModelMember { Name = "BankCashDeposit", Display = "Bank Cash Deposit", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Bank Cash Deposit") };

        [Display(Name = "Received Cash")]
        public bool ReceivedCash { get; set; } = false;
        public static ModelMember COL_ReceivedCash = new ModelMember { Name = "ReceivedCash", Display = "Received Cash", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Received Cash") };

        /******************************************************************************************************************************************************/

    }
}