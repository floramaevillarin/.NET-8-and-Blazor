using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Logging;
using Miramar.Domain.Entities;

namespace Miramar.Infrastructure.Context
{
    public class MiramarDbContext : DbContext
    {
        public MiramarDbContext(DbContextOptions<MiramarDbContext> options) : base(options)
        {
            
        }

        public DbSet<Timesheet> Timesheets { get; set; }

        /* add this if using fluent api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Timesheet>().Property(e => e.Building).IsRequired();
        }
        */
    }
}
