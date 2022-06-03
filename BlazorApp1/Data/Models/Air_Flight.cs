namespace BlazorApp1.Data.Models
{
    public class Air_Flight
    {
        public int Air_FlightId { get; set; }
        public Trip Trip { get; set; }
        public string CompanyName { get; set; }
        public int NumberHours { get; set; }
        public int LevelComfort { get; set; }
    }
}
