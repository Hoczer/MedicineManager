namespace MedicineManagerAPI.Entities
{
    public class MedicineCabinet
    {
        public Guid Id { get; set; }
        public string MedName { get; set; }
        public string MedDescription { get; set; }
        public DateTime MedExpirationDate { get; set; }
        public int MedAmount { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
