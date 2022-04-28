using System;
using System.ComponentModel.DataAnnotations;
    
namespace BinaMitraTextileWebApp.Models
{
    public class SuppliesModel
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        public static ModelMember COL_Id = new ModelMember { Name = "Id", Display = "Id" };


        [Required]
        [Display(Name = "Item")]
        public Guid SupplyItems_Id { get; set; }
        public static ModelMember COL_SupplyItems_Id = new ModelMember { Name = "SupplyItems_Id", Display = "Item" };
        public string SupplyItems_Name { get; set; } = string.Empty;


        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yy HH:mm}")]
        public DateTime Timestamp { get; set; }
        public static ModelMember COL_Timestamp = new ModelMember { Name = "Timestamp", Display = "Timestamp" };


        [Display(Name = "Qty")]
        [DisplayFormat(DataFormatString = "{0:N0}")]
        public int Qty { get; set; }
        public static ModelMember COL_Qty = new ModelMember { Name = "Qty", Display = "Qty" };
        
        
        /******************************************************************************************************************************************************/

        [Display(Name = "Unit")]
        public Guid Units_Id { get; set; }
        public string Units_Name { get; set; } = string.Empty;

        /******************************************************************************************************************************************************/

    }
}