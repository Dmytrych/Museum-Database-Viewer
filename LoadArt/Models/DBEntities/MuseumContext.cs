using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace LoadArt.Models
{
    public partial class MuseumContext : DbContext
    {
        public MuseumContext()
        {
        }

        public MuseumContext(DbContextOptions<MuseumContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Excursion> Excursions { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Visitor> Visitors { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-4FGGBK0;Initial Catalog=Museum;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.BirthDate).HasColumnType("datetime");

                entity.Property(e => e.DeathDate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Pseudonim)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Excursion>(entity =>
            {
                entity.Property(e => e.ExcursionDate).HasColumnType("datetime");

                entity.Property(e => e.GuideWorkerId).HasColumnName("GuideWorkerID");

                entity.HasOne(d => d.GuideWorker)
                    .WithMany(p => p.Excursions)
                    .HasForeignKey(d => d.GuideWorkerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Excursions_Workers");
            });

            modelBuilder.Entity<Picture>(entity =>
            {
                entity.Property(e => e.AuthorId).HasColumnName("AuthorID");

                entity.Property(e => e.Epoch)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Medium)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Plot)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Style)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.Pictures)
                    .HasForeignKey(d => d.AuthorId)
                    .HasConstraintName("FK_Pictures_Authors");
            });

            modelBuilder.Entity<Visitor>(entity =>
            {
                entity.Property(e => e.LastExcursionId).HasColumnName("LastExcursionID");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.HasOne(d => d.LastExcursion)
                    .WithMany(p => p.Visitors)
                    .HasForeignKey(d => d.LastExcursionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Visitors_Excursions");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
