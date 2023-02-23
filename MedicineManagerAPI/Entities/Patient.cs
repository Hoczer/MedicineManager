namespace MedicineManagerAPI.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User User { get; set; }
        public Guid UserId { get; set; }

        public Treatment Treatment { get; set; }
        public int TreatmentID { get; set; }
    }
}
