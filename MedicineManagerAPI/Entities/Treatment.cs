namespace MedicineManagerAPI.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public string MedName { get; set; }
        public int MedAmount { get; set; }
        public DateTime MedWhenToTake { get; set; }
        public bool MedWasTaken { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
