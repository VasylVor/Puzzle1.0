using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PuzzleService.Models
{
    public partial class PuzzleDBContext : DbContext
    {
        public PuzzleDBContext()
        {
        }

        public PuzzleDBContext(DbContextOptions<PuzzleDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Image> Image { get; set; }
        public virtual DbSet<Puzzle> Puzzle { get; set; }
        public virtual DbSet<PuzzleError> PuzzleError { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\LAPTOP-JEMQGI0K\\SQLEXPRESS; Data Source=LAPTOP-JEMQGI0K\\SQLEXPRESS;Initial Catalog=PuzzleDB;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Image>(entity =>
            {
                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Image1).HasColumnName("Image");

                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Puzzle>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Puzzle1).HasColumnName("Puzzle");

                entity.HasOne(d => d.IdImageNavigation)
                    .WithMany(p => p.InverseIdImageNavigation)
                    .HasForeignKey(d => d.IdImage)
                    .HasConstraintName("FK_Image_Puzzle");
            });

            modelBuilder.Entity<PuzzleError>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Message).IsUnicode(false);

                entity.Property(e => e.MethodName)
                    .HasMaxLength(250)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
