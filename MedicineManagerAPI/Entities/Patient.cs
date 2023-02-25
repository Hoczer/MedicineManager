namespace MedicineManagerAPI.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }

        public Treatment Treatment { get; set; }
        public int TreatmentID { get; set; }

        public Diet Diet { get; set; }
        public int DietID { get; set; }
    }
}
