using Microsoft.EntityFrameworkCore;
using WebApplication_Test1.Enums;
using WebApplication_Test1.Models;

namespace WebApplication_Test1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserDomain> Users {  get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<User>().HasData(
        //        new User[]
        //        {
        //            new User { Id = 1, Name = "SuperAdmin", Email = "superadmin@mail.com", Role = Role.RoleSuperAdmin },
        //            new User { Id = 2, Name = "Eugene", Email = "eugene@mail.com", Role = Role.RoleUser }
        //        });
        //}
    }
}