using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [Required]
        public string UserID { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

        public int BookingID { get; set; }

        public Booking Booking { get; set; } = null!;

        [Range(1, 5)]
        public int Rating { get; set; }

        [Required]
        [StringLength(1000)]
        public string Comment { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [StringLength(20)]
        public string Status { get; set; } = "Pending";
    }
}
