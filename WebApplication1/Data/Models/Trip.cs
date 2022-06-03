using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Trip
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int TripId { get; set; }
        public Country Country { get; set; }
        public Hotel Hotel { get; set; }
        public Air_Flight Air_Flight{ get; set; }
        public int CountryId { get; set; }
        public int HotelId { get; set; }
        public int Air_FlightId { get; set; }
        public int Price { get; set; }
        public int NumberDays { get; set; }
        public int NumberStars { get; set; }
        public string Nutrition { get; set; }
        public string Picture { get; set; }
        public string LongDescription { get; set; }
        public string ShortDescription { get; set; }
        public string Characteristics1 { get; set; }
        public string Characteristics2 { get; set; }
        public string Characteristics3 { get; set; }
        public string Characteristics4 { get; set; }
        public IEnumerable<Customer> Customers{ get; set; }

    }
}
