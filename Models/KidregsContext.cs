using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public virtual DbSet<NationList> NationList { get; set; }
        public virtual DbSet<System> System { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NationList>();

            modelBuilder.Entity<KidsInfo>();

            modelBuilder.Entity<System>(entity =>
            {
                entity.HasNoKey();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
