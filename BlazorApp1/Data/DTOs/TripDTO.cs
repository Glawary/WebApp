namespace BlazorApp1.Data.DTOs
{
    public class TripDTO
    {
        public int TripId { get; set; }
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
        public int[] CustomersIds { get; set; }
    }
}
