namespace BlazorApp1.Data.Models
{
    public class Hotel
    {
        public int HotelId { get; set; }
        public Trip Trip { get; set; }
        public string HotelName { get; set; }
        public int HotelStatus { get; set; }
        public string HotelDescription { get; set; }
    }
}
