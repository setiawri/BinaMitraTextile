using System;
using System.ComponentModel.DataAnnotations;

namespace BinaMitraTextileWebApp.Models
{
    public class SupplyItemsModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Display(Name = "Name")]
        public string Name { get; set; }
        public static ModelMember COL_Name = new ModelMember { Name = "Name", Display = "Name", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Name") };


        [Required]
        [Display(Name = "Unit")]
        public Guid Units_Id { get; set; }
        public static ModelMember COL_Units_Id = new ModelMember { Name = "Units_Id", Display = "Unit", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Unit") };
        public string Units_Name { get; set; } = string.Empty;


        [Display(Name = "Minimum Qty")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int? MinimumQty { get; set; }
        public static ModelMember COL_MinimumQty = new ModelMember { Name = "MinimumQty", Display = "MinimumQty", LogDisplay = LIBUtil.ActivityLog.editIntFormat("Minimum qty") };


        public string Notes { get; set; } = null;
        public static ModelMember COL_Notes = new ModelMember { Name = "Notes", Display = "Notes", LogDisplay = LIBUtil.ActivityLog.editStringFormat("Notes") };


        public bool Active { get; set; } = true;
        public static ModelMember COL_Active = new ModelMember { Name = "Active", Display = "Active", LogDisplay = LIBUtil.ActivityLog.editBooleanFormat("Active") };

        /******************************************************************************************************************************************************/

    }
}