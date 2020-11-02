using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Vidly.Models
{
    public partial class VidlyContext : DbContext
    {
        public virtual DbSet<Rental> Rental { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["MovieDbContext"].ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rental>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Movie>()
                .HasOne<Genre>(s => s.Genre)
                .WithMany(g => g.Movies)
                .HasForeignKey(s => s.GenreId);

            modelBuilder.Entity<MembershipType>()
                .HasData(
                  new MembershipType { Id = 1, Name = "Pay as You Go", SignupFee = 0, DurationMonths = 0, DiscountRate = 0 },
                  new MembershipType { Id = 2, Name = "Monthly", SignupFee = 30, DurationMonths = 1, DiscountRate = 10 },
                  new MembershipType { Id = 3, Name = "Quarterly", SignupFee = 90, DurationMonths = 3, DiscountRate = 15 },
                  new MembershipType { Id = 4, Name = "Yearly", SignupFee = 300, DurationMonths = 12, DiscountRate = 20 }
                );

            modelBuilder.Entity<Genre>()
                .HasData(
                  new Genre { Id = 1, Name = "Action" },
                  new Genre { Id = 2, Name = "Thriller" },
                  new Genre { Id = 3, Name = "Family" },
                  new Genre { Id = 4, Name = "Romance" },
                  new Genre { Id = 5, Name = "Comedy" }
                );

            modelBuilder.Entity<Movie>()
                .HasData(
                  new Movie { Id = 1, Name = "Gladiator", DateAdded= DateTime.Parse("2020-09-01"), GenreId=1, NumberAvailable=3, NumberInStock=2, ReleaseDate= DateTime.Parse("2000-01-01") },
                  new Movie { Id = 2, Name = "Despicable Me", DateAdded = DateTime.Parse("2020-07-01"), GenreId = 3, NumberAvailable = 5, NumberInStock = 2, ReleaseDate = DateTime.Parse("2012-01-01") },
                  new Movie { Id = 3, Name = "Entrapment", DateAdded = DateTime.Parse("2020-02-01"), GenreId = 2, NumberAvailable = 3, NumberInStock = 3, ReleaseDate = DateTime.Parse("2010-01-01") }
                );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
