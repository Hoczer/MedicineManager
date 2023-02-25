using System.ComponentModel.DataAnnotations;

namespace MedicineManagerAPI.Models
{
    public class UpdateMedicine
    {
        [Required]
        public string MedName { get; set; }
        public string MedDescription { get; set; }
        public DateTime MedExpirationDate { get; set; }
        public int MedAmount { get; set; }
    }
}
