using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Entities;

namespace MedicineManagerAPI.Entities
{
    public class MedicineManagerDbContext : DbContext
    {
        public MedicineManagerDbContext(DbContextOptions<MedicineManagerDbContext> options ) : base( options )
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<MedicineCabinet> MedicineCabinets { get; set;}
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>(u =>
            {
                u.Property(e => e.Email).IsRequired();
                u.Property(e => e.RoleId).HasDefaultValue(1);
                u.HasOne(c => c.Cabinet).WithOne(us => us.User).HasForeignKey<MedicineCabinet>(m => m.UserId);
                u.HasMany(p => p.Patients).WithOne(u=> u.User).HasForeignKey(p => p.UserId);
            });

            modelBuilder.Entity<Diet>(d =>
            {
                
                d.Property(e => e.WhenToEat).HasDefaultValue(DateTime.Now);
            });

            modelBuilder.Entity<Patient>(d =>
            {
                d.HasOne(t=> t.Treatment).WithOne(p=> p.Patient).HasForeignKey<Treatment>(t=>t.PatientId);
                d.HasOne(d => d.Diet).WithOne(p => p.Patient).HasForeignKey<Diet>(p => p.PatientId);
            });

            modelBuilder.Entity<Treatment>(t =>
            {

                t.Property(e => e.MedWhenToTake).HasDefaultValue(DateTime.Now);
                t.Property(e=>e.MedWasTaken).HasDefaultValue(false);
            });

            modelBuilder.Entity<MedicineCabinet>(d =>
            {

                d.Property(e => e.MedExpirationDate).HasDefaultValue(DateTime.Now.AddDays(30) ) ;
            });

            modelBuilder.Entity<Role>(r =>
            {
                r.Property(e => e.Name).IsRequired();
                r.Property(e => e.Name).HasDefaultValue(1);
            });
        }
    }
}
