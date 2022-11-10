using System;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp.Models
{
    public class MoneyAccountsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Display(Name = "Name")]
        public string Name { get; set; }
        public static ModelMember COL_Name = new ModelMember { Name = "Name", Display = "Name", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Name") };


        public string Notes { get; set; }
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Notes") };


        [Display(Name = "User Role Restriction")]
        public bool UserRoleRestriction { get; set; }
        public static ModelMember COL_UserRoleRestriction = new ModelMember { Name = "UserRoleRestriction", Display = "User Role Restriction", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("User Role Restriction") };


        public bool Default { get; set; }
        public static ModelMember COL_Default = new ModelMember { Name = "Default", Display = "Default", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Default") };


        public bool Active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "Active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };

        /******************************************************************************************************************************************************/

    }
}