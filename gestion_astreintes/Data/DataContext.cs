using gestion_astreintes.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace gestion_astreintes.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }
        public DbSet<Team> Teams { get; set; } 
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamMemberType> TeamMembersMemberTypes { get; set;}
        public DbSet<Astreinte> Astreintes { get; set; }
        public DbSet<StatutAstreinte> Statuts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMemberType>().HasData(
                new TeamMemberType { Id = 1, Name = "TeamLeader" },
                new TeamMemberType { Id = 2, Name = "Employee" }
                );

            modelBuilder.Entity<StatutAstreinte>().HasData(
                new StatutAstreinte { Id = 1, Name = "Nouveau" },
                new StatutAstreinte { Id = 2, Name = "Validée" },
                new StatutAstreinte { Id = 3, Name = "Rejetée" },
                new StatutAstreinte { Id = 4, Name = "En Cours" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
