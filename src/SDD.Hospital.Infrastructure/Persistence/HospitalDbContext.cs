using Microsoft.EntityFrameworkCore;
using SDD.Hospital.Domain.Models;

namespace SDD.Hospital.Infrastructure.Persistence
{
    public class HospitalDbContext : DbContext
    {
        public HospitalDbContext(DbContextOptions<HospitalDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>(b =>
            {
                b.HasKey(p => p.Id);
                b.Property(p => p.FirstName).IsRequired();
                b.Property(p => p.LastName).IsRequired();
                b.Property(p => p.DateOfBirth).IsRequired();
            });
        }
    }
}
