using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using BinaMitraTextileWebApp.Controllers;

namespace BinaMitraTextileWebApp.Models
{
    public class InventoryChecksModel
    {
        [Key]
        public Guid id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "id", Display = "Id" };


        public Guid inventory_item_id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_inventory_item_id = new ModelMember { Name = "inventory_item_id" };
        public string InventoryItems_barcode { get; set; }


        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm}")]
        public DateTime time_stamp { get; set; } = Helper.getCurrentDateTime();
        public static ModelMember COL_time_stamp = new ModelMember { Name = "time_stamp" };


        [Required]
        [Display(Name = "User")]
        public Guid user_id { get; set; }
        public static ModelMember COL_user_id = new ModelMember { Name = "user_id", Display = "User" };
        public string Users_username { get; set; } = string.Empty;


        [Display(Name = "Manual")]
        public bool manual_input { get; set; } = true;
        public static ModelMember COL_manual_input = new ModelMember { Name = "manual_input", Display = "Manual" };


        [Display(Name = "Ignore Sold")]
        public bool IgnoreSold { get; set; } = true;
        public static ModelMember COL_IgnoreSold = new ModelMember { Name = "IgnoreSold", Display = "Ignore Sold" };


        [Required]
        [Display(Name = "Location")]
        public string ItemLocation { get; set; } = string.Empty;
        public static ModelMember COL_ItemLocation = new ModelMember { Name = "ItemLocation", Display = "Location" };


        /******************************************************************************************************************************************************/

    }
}