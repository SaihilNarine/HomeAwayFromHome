using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class Property
    {
        public int PropertyID { get; set; }

        [Required]
        [StringLength(100)]
        public string PropertyName { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Range(1, 50)]
        public int MaximumGuests { get; set; }

        [Range(1, 20)]
        public int Bedrooms { get; set; }

        [Range(1, 20)]
        public int Bathrooms { get; set; }

        [Range(0, 100000)]
        public decimal PricePerNight { get; set; }

        public ICollection<Booking> Bookings { get; set; } =
            new List<Booking>();

        public ICollection<Availability> Availabilities { get; set; } =
            new List<Availability>();

        public ICollection<PropertyAmenity> PropertyAmenities { get; set; } =
            new List<PropertyAmenity>();

        public ICollection<FinancialTransaction> FinancialTransactions { get; set; } =
            new List<FinancialTransaction>();
    }
}