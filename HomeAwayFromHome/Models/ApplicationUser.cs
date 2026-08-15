using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
