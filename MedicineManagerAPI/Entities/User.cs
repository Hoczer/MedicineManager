using RestaurantAPI.Entities;
using System.Data;

namespace MedicineManagerAPI.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PasswordHash { get; set; }

        public int RoleId { get; set; }

        public virtual Role Role { get; set; }
        public MedicineCabinet Cabinet { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
