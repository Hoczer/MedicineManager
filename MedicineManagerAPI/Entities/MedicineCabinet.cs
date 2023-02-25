namespace MedicineManagerAPI.Entities
{
    public class MedicineCabinet
    {
        public int Id { get; set; }
        public string MedName { get; set; }
        public string MedDescription { get; set; }
        public DateTime MedExpirationDate { get; set; }
        public int MedAmount { get; set; }

        public int? CreatedById { get; set; }
        //public virtual User CreatedBy { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}
