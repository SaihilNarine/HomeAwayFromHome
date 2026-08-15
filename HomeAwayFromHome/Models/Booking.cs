using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class Booking
    {
        [Key]
        public int BookingID { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public int PropertyID { get; set; }

        public Property Property { get; set; } = null!;

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Range(1, 50)]
        public int NumberOfGuests { get; set; }

        [Range(0, 1000000)]
        public decimal TotalAmount { get; set; }

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Review> Reviews { get; set; } =
            new List<Review>();

        public ICollection<FinancialTransaction> FinancialTransactions { get; set; } =
            new List<FinancialTransaction>();
    }
}
