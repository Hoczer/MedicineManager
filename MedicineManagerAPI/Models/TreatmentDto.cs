namespace MedicineManagerAPI.Models
{
    public class TreatmentDto
    {
        public int Id { get; set; }
        public string MedName { get; set; }
        public int MedAmount { get; set; }
        public DateTime MedWhenToTake { get; set; }
        public bool MedWasTaken { get; set; }
    }
}
