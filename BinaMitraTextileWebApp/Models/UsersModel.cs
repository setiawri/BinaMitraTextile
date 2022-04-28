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


        [Display(Name = "Active")]
        public bool active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };


        /******************************************************************************************************************************************************/

    }
}