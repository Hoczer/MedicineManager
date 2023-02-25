namespace MedicineManagerAPI.Models
{
    public class MedicineCabinetDto
    {
        public int Id { get; set; }
        public string MedName { get; set; }
        public string MedDescription { get; set; }
        public DateTime MedExpirationDate { get; set; }
        public int MedAmount { get; set; }
    }
}
