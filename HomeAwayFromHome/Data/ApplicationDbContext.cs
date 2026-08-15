using HomeAwayFromHome.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeAwayFromHome.Data
{
    public class ApplicationDbContext
            : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Property> Property { get; set; }

        public DbSet<Amenity> Amenity { get; set; }

        public DbSet<PropertyAmenity> PropertyAmenity { get; set; }

        public DbSet<Booking> Booking { get; set; }

        public DbSet<Availability> Availability { get; set; }

        public DbSet<Review> Review { get; set; }

        public DbSet<FinancialTransaction> FinancialTransaction { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // PropertyAmenity composite primary key
            builder.Entity<PropertyAmenity>()
                .HasKey(pa => new
                {
                    pa.PropertyID,
                    pa.AmenityID
                });

            // Property -> PropertyAmenity
            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Property)
                .WithMany(p => p.PropertyAmenities)
                .HasForeignKey(pa => pa.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            // Amenity -> PropertyAmenity
            builder.Entity<PropertyAmenity>()
                .HasOne(pa => pa.Amenity)
                .WithMany(a => a.PropertyAmenities)
                .HasForeignKey(pa => pa.AmenityID)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> User
            builder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(u => u.Bookings)
                .HasForeignKey(b => b.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Booking -> Property
            builder.Entity<Booking>()
                .HasOne(b => b.Property)
                .WithMany(p => p.Bookings)
                .HasForeignKey(b => b.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            // Review -> User
            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserID)
                .OnDelete(DeleteBehavior.Restrict);

            // Review -> Booking
            builder.Entity<Review>()
                .HasOne(r => r.Booking)
                .WithMany(b => b.Reviews)
                .HasForeignKey(r => r.BookingID)
                .OnDelete(DeleteBehavior.Restrict);

            // FinancialTransaction -> Property
            builder.Entity<FinancialTransaction>()
                .HasOne(f => f.Property)
                .WithMany(p => p.FinancialTransactions)
                .HasForeignKey(f => f.PropertyID)
                .OnDelete(DeleteBehavior.Restrict);

            // FinancialTransaction -> Booking
            builder.Entity<FinancialTransaction>()
                .HasOne(f => f.Booking)
                .WithMany(b => b.FinancialTransactions)
                .HasForeignKey(f => f.BookingID)
                .OnDelete(DeleteBehavior.Restrict);

            // Decimal precision
            builder.Entity<Property>()
                .Property(p => p.PricePerNight)
                .HasPrecision(18, 2);

            builder.Entity<Booking>()
                .Property(b => b.TotalAmount)
                .HasPrecision(18, 2);

            builder.Entity<FinancialTransaction>()
                .Property(f => f.Amount)
                .HasPrecision(18, 2);
        }
    }
}
