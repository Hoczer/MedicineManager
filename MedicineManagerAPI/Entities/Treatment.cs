namespace MedicineManagerAPI.Entities
{
    public class Treatment
    {
        public int Id { get; set; }
        public string Medicine { get; set; }
        public int Amount { get; set; }
        public DateTime WhenToTake { get; set; }
        public bool WasTaken { get; set; }

        public Patient Patient { get; set; }
        public int PatientId { get; set; }
    }
}
