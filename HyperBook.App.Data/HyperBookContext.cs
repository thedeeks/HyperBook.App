using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HyperBook.App.Data.Model;

#nullable disable

namespace HyperBook.App.Data
{
    public partial class HyperBookContext : DbContext
    {
        public HyperBookContext()
        {
        }

        public HyperBookContext(DbContextOptions<HyperBookContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<PodSchedule> PodSchedules { get; set; }
        public virtual DbSet<RefStatus> RefStatuses { get; set; }
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Trip> Trips { get; set; }
        public virtual DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.Property(e => e.Timezone)
                    .IsRequired()
                    .HasMaxLength(75);

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cities__StateId__60A75C0F");
            });

            modelBuilder.Entity<PodSchedule>(entity =>
            {
                entity.ToTable("PodSchedule");

                entity.Property(e => e.ArrivalTimeGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("ArrivalTimeGMT");

                entity.Property(e => e.DepartureTimeGmt)
                    .HasColumnType("datetime")
                    .HasColumnName("DepartureTimeGMT");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.HasOne(d => d.CityFromNavigation)
                    .WithMany(p => p.PodScheduleCityFromNavigations)
                    .HasForeignKey(d => d.CityFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PodSchedu__CityF__6EF57B66");

                entity.HasOne(d => d.CityToNavigation)
                    .WithMany(p => p.PodScheduleCityToNavigations)
                    .HasForeignKey(d => d.CityTo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PodSchedu__CityT__6FE99F9F");
            });

            modelBuilder.Entity<RefStatus>(entity =>
            {
                entity.ToTable("ref_Status");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Abbreviation)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(75)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Trip>(entity =>
            {
                entity.ToTable("Trip");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.HasOne(d => d.PodScheduleNavigation)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.PodSchedule)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trip__PodSchedul__73BA3083");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trip__StatusId__74AE54BC");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Trips)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Trip__UserId__72C60C4A");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(12);

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Zip)
                    .IsRequired()
                    .HasMaxLength(5);

                entity.HasOne(d => d.StateNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.State)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Users__State__6A30C649");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
