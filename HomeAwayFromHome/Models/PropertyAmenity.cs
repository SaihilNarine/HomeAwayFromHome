using System.ComponentModel.DataAnnotations;

namespace HomeAwayFromHome.Models
{
    public class PropertyAmenity
    {
        public int PropertyID { get; set; }

        public Property Property { get; set; } = null!;

        public int AmenityID { get; set; }

        public Amenity Amenity { get; set; } = null!;
    }
}