using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Kidregs.Models
{
    public partial class KidregsContext : DbContext
    {
        public KidregsContext()
        {
        }

        public KidregsContext(DbContextOptions<KidregsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KidsInfo> KidsInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NationList>();

            modelBuilder.Entity<KidsInfo>();

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
