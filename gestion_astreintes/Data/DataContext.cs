using gestion_astreintes.Models;
using Microsoft.EntityFrameworkCore;


namespace gestion_astreintes.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        { 

        }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<TeamMemberType> TeamMembersMemberTypes { get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMemberType>().HasData(
                new TeamMemberType { Id = 1, Name = "TeamLeader" },
                new TeamMemberType { Id = 2, Name = "Employee" }
                );

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
