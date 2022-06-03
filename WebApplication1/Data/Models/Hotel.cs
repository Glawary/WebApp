using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebApplication1.Data.Models
{
    public class Hotel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int HotelId { get; set; }
        public Trip Trip { get; set; }
        public string HotelName { get; set; }
        public int HotelStatus { get; set; }
        public string HotelDescription { get; set; }
    }

}
