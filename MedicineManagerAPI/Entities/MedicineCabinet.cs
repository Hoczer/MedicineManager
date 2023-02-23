namespace MedicineManagerAPI.Entities
{
    public class MedicineCabinet
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int Amount { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }
    }
}
