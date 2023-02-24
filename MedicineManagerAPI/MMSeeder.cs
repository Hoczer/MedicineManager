using MedicineManagerAPI.Entities;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace MedicineManagerAPI
{
    public class MMSeeder
    {
        private readonly MedicineManagerDbContext _context;
        public MMSeeder( MedicineManagerDbContext context)
        {
            _context = context;
        }
        public void Seed()
        {
            var pendingMigrations = _context.Database.GetPendingMigrations();
            if (pendingMigrations != null && pendingMigrations.Any())
            {
                _context.Database.Migrate();
            }
            if (!_context.Roles.Any())
            {
                var roles = GetRoles();
                _context.Roles.AddRange(roles);
                _context.SaveChanges();
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name= "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name= "Admin"
                }
            };
            return roles;
        }
    }
}
