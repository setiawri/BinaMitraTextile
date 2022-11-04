using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BinaMitraTextileWebApp.Controllers;

namespace BinaMitraTextileWebApp.Models
{
    public class UsersModel
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "id", Display = "Id" };


        [Required]
        [Display(Name = "Username")]
        public string username { get; set; } = string.Empty;
        public static ModelMember COL_Username = new ModelMember { Name = "username", Display = "Username" };


        [Required]
        [Display(Name = "Password")]
        public string hashed_password { get; set; } = string.Empty;
        public static ModelMember COL_Password = new ModelMember { Name = "hashed_password", Display = "Password" };


        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? Birthdate { get; set; } = Helper.getCurrentDateTime();
        public static ModelMember COL_Birthdate = new ModelMember { Name = "Birthdate", Display = "Birthdate", LogDisplay = ActivityLogsController.editDateFormat("Birthdate") };


        [Display(Name = "Active")]
        public bool active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };
        

        public string notes { get; set; }
        public static ModelMember COL_notes = new ModelMember { Name = "notes", Display = "Notes", LogDisplay = ActivityLogsController.editStringFormat("Notes") };


        /******************************************************************************************************************************************************/


        [Display(Name = "Roles")]
        public string Roles { get; set; }
        public static ModelMember COL_Roles = new ModelMember { Name = "Roles", LogDisplay = ActivityLogsController.editListStringFormat("Roles") };
        public List<string> Roles_List { get; set; }
        public static ModelMember COL_Roles_List = new ModelMember { Name = "Roles_List" };

    }
}