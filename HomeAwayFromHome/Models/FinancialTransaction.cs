using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class FinancialTransaction
    {
        [Key]
        public int FinancialTransactionID { get; set; }

        public int PropertyID { get; set; }

        public Property Property { get; set; } = null!;

        public int? BookingID { get; set; }

        public Booking? Booking { get; set; }

        [Required]
        [StringLength(20)]
        public string TransactionType { get; set; } = string.Empty;

        [Required]
        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        [Range(0.01, 10000000)]
        public decimal Amount { get; set; }

        public DateTime TransactionDate { get; set; } = DateTime.UtcNow;
    }
}
