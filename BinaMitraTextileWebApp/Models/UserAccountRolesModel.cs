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

        /******************************************************************************************************************************************************************************************************************************************************************************************************/

    }
}