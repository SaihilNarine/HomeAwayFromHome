using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class Amenity
    {
        public int AmenityID { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(250)]
        public string Description { get; set; } = string.Empty;

        public ICollection<PropertyAmenity> PropertyAmenities { get; set; } = new List<PropertyAmenity>();
    }
}