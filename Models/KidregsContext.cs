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
            modelBuilder.Entity<KidsInfo>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.FatherName)
                    .HasColumnName("father_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.IdCard)
                    .HasColumnName("IdCard")
                    .HasMaxLength(50);

                entity.Property(e => e.MotherName)
                    .HasColumnName("mother_name")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
