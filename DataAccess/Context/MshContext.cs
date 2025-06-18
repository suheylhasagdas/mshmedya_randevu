using Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class MshContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=89.252.183.170\\MSSQLSERVER2019; Database=mshmedya_randevu;User Id=mshmedya_randevu;password=101014BBjk**;Trusted_Connection=False;MultipleActiveResultSets=true;");
        }

        public DbSet<AppUsers> AppUsers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<Services> Services { get; set; }
        public DbSet<Sessions> Sessions { get; set; }
        public DbSet<StaffServices> StaffServices { get; set; }
        public DbSet<StaffSessions> StaffSessions { get; set; }
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<Logs> Logs { get; set; }
    }
}
