using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BinaMitraTextileWebApp.Controllers;

namespace BinaMitraTextileWebApp.Models
{
    [Table("UserAccountRoles")]
    public class UserAccountRolesModel
    {
        [Key]
        public Guid Id { get; set; }
        public static ModelMember COL_Id = new ModelMember { Name = "Id" };

        public string Name { get; set; }
        public static ModelMember COL_Name = new ModelMember { Name = "Name", Display = "Name", LogDisplay = ActivityLogsController.editStringFormat("Name") };

        public string Notes { get; set; }
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Notes") };

        /* USER ACCOUNTS ROLES ********************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string UserAccountRoles_Notes { get; set; }
        public static ModelMember COL_UserAccountRoles_Notes = new ModelMember { Name = "UserAccountRoles_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Branches Notes") };

        [Display(Name = "Add")]
        public bool UserAccountRoles_Add { get; set; }
        public static ModelMember COL_UserAccountRoles_Add = new ModelMember { Name = "UserAccountRoles_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("Branches Add") };

        [Display(Name = "View")]
        public bool UserAccountRoles_View { get; set; }
        public static ModelMember COL_UserAccountRoles_View = new ModelMember { Name = "UserAccountRoles_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("Branches View") };

        [Display(Name = "Edit")]
        public bool UserAccountRoles_Edit { get; set; }
        public static ModelMember COL_UserAccountRoles_Edit = new ModelMember { Name = "UserAccountRoles_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("Branches Edit") };

        /* USER ACCOUNTS **************************************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string UserAccounts_Notes { get; set; }
        public static ModelMember COL_UserAccounts_Notes = new ModelMember { Name = "UserAccounts_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("UserAccounts Notes") };

        [Display(Name = "Add")]
        public bool UserAccounts_Add { get; set; }
        public static ModelMember COL_UserAccounts_Add = new ModelMember { Name = "UserAccounts_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("UserAccounts Add") };

        [Display(Name = "View")]
        public bool UserAccounts_View { get; set; }
        public static ModelMember COL_UserAccounts_View = new ModelMember { Name = "UserAccounts_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("UserAccounts View") };

        [Display(Name = "Edit")]
        public bool UserAccounts_Edit { get; set; }
        public static ModelMember COL_UserAccounts_Edit = new ModelMember { Name = "UserAccounts_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("UserAccounts Edit") };

        /* FINANCIAL REPORTS **********************************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string FinancialReports_Notes { get; set; }
        public static ModelMember COL_FinancialReports_Notes = new ModelMember { Name = "FinancialReports_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("FinancialReports Notes") };

        [Display(Name = "Add")]
        public bool FinancialReports_Add { get; set; }
        public static ModelMember COL_FinancialReports_Add = new ModelMember { Name = "FinancialReports_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("FinancialReports Add") };

        [Display(Name = "View")]
        public bool FinancialReports_View { get; set; }
        public static ModelMember COL_FinancialReports_View = new ModelMember { Name = "FinancialReports_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("FinancialReports View") };

        [Display(Name = "Edit")]
        public bool FinancialReports_Edit { get; set; }
        public static ModelMember COL_FinancialReports_Edit = new ModelMember { Name = "FinancialReports_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("FinancialReports Edit") };

        /* MONEY ACCOUNTS *************************************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string MoneyAccounts_Notes { get; set; }
        public static ModelMember COL_MoneyAccounts_Notes = new ModelMember { Name = "MoneyAccounts_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Money Accounts Notes") };

        [Display(Name = "Add")]
        public bool MoneyAccounts_Add { get; set; }
        public static ModelMember COL_MoneyAccounts_Add = new ModelMember { Name = "MoneyAccounts_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("Money Accounts Add") };

        [Display(Name = "View")]
        public bool MoneyAccounts_View { get; set; }
        public static ModelMember COL_MoneyAccounts_View = new ModelMember { Name = "MoneyAccounts_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("Money Accounts View") };

        [Display(Name = "Edit")]
        public bool MoneyAccounts_Edit { get; set; }
        public static ModelMember COL_MoneyAccounts_Edit = new ModelMember { Name = "MoneyAccounts_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("Money Accounts Edit") };

        /* MONEY ACCOUNT CATEGORIES ***************************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string MoneyAccountCategories_Notes { get; set; }
        public static ModelMember COL_MoneyAccountCategories_Notes = new ModelMember { Name = "MoneyAccountCategories_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Money Account Categories Notes") };

        [Display(Name = "Add")]
        public bool MoneyAccountCategories_Add { get; set; }
        public static ModelMember COL_MoneyAccountCategories_Add = new ModelMember { Name = "MoneyAccountCategories_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Categories Add") };

        [Display(Name = "View")]
        public bool MoneyAccountCategories_View { get; set; }
        public static ModelMember COL_MoneyAccountCategories_View = new ModelMember { Name = "MoneyAccountCategories_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Categories View") };

        [Display(Name = "Edit")]
        public bool MoneyAccountCategories_Edit { get; set; }
        public static ModelMember COL_MoneyAccountCategories_Edit = new ModelMember { Name = "MoneyAccountCategories_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Categories Edit") };

        /* MONEY ACCOUNT CATEGORY ASSIGNMENTS *****************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string MoneyAccountCategoryAssignments_Notes { get; set; }
        public static ModelMember COL_MoneyAccountCategoryAssignments_Notes = new ModelMember { Name = "MoneyAccountCategoryAssignments_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Money Account Category Assignments Notes") };

        [Display(Name = "Add")]
        public bool MoneyAccountCategoryAssignments_Add { get; set; }
        public static ModelMember COL_MoneyAccountCategoryAssignments_Add = new ModelMember { Name = "MoneyAccountCategoryAssignments_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Category Assignments Add") };

        [Display(Name = "View")]
        public bool MoneyAccountCategoryAssignments_View { get; set; }
        public static ModelMember COL_MoneyAccountCategoryAssignments_View = new ModelMember { Name = "MoneyAccountCategoryAssignments_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Category Assignments View") };

        [Display(Name = "Edit")]
        public bool MoneyAccountCategoryAssignments_Edit { get; set; }
        public static ModelMember COL_MoneyAccountCategoryAssignments_Edit = new ModelMember { Name = "MoneyAccountCategoryAssignments_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("Money Account Category Assignments Edit") };

        /* REVENUE AND EXPENSE CATEGORIES *********************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string RevenueAndExpenseCategories_Notes { get; set; }
        public static ModelMember COL_RevenueAndExpenseCategories_Notes = new ModelMember { Name = "RevenueAndExpenseCategories_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("RevenueAndExpenseCategories Notes") };

        [Display(Name = "Add")]
        public bool RevenueAndExpenseCategories_Add { get; set; }
        public static ModelMember COL_RevenueAndExpenseCategories_Add = new ModelMember { Name = "RevenueAndExpenseCategories_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("RevenueAndExpenseCategories Add") };

        [Display(Name = "View")]
        public bool RevenueAndExpenseCategories_View { get; set; }
        public static ModelMember COL_RevenueAndExpenseCategories_View = new ModelMember { Name = "RevenueAndExpenseCategories_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("RevenueAndExpenseCategories View") };

        [Display(Name = "Edit")]
        public bool RevenueAndExpenseCategories_Edit { get; set; }
        public static ModelMember COL_RevenueAndExpenseCategories_Edit = new ModelMember { Name = "RevenueAndExpenseCategories_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("RevenueAndExpenseCategories Edit") };

        /* REVENUES AND EXPENSES ******************************************************************************************************************************************************************************************************************************************************************************/

        [Display(Name = "Notes")]
        public string RevenuesAndExpenses_Notes { get; set; }
        public static ModelMember COL_RevenuesAndExpenses_Notes = new ModelMember { Name = "RevenuesAndExpenses_Notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("RevenuesAndExpenses Notes") };

        [Display(Name = "Add")]
        public bool RevenuesAndExpenses_Add { get; set; }
        public static ModelMember COL_RevenuesAndExpenses_Add = new ModelMember { Name = "RevenuesAndExpenses_Add", Display = "Add", LogDisplay = ActivityLogsController.editBooleanFormat("RevenuesAndExpenses Add") };

        [Display(Name = "View")]
        public bool RevenuesAndExpenses_View { get; set; }
        public static ModelMember COL_RevenuesAndExpenses_View = new ModelMember { Name = "RevenuesAndExpenses_View", Display = "View", LogDisplay = ActivityLogsController.editBooleanFormat("RevenuesAndExpenses View") };

        [Display(Name = "Edit")]
        public bool RevenuesAndExpenses_Edit { get; set; }
        public static ModelMember COL_RevenuesAndExpenses_Edit = new ModelMember { Name = "RevenuesAndExpenses_Edit", Display = "Edit", LogDisplay = ActivityLogsController.editBooleanFormat("RevenuesAndExpenses Edit") };

        /******************************************************************************************************************************************************************************************************************************************************************************************************/

    }
}