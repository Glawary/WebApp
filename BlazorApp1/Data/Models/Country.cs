namespace BlazorApp1.Data.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public Trip Trip { get; set; }
        public int Code { get; set; }
        public string CountryName { get; set; }
        public string Climate { get; set; }
        public string Language { get; set; }
        public int NumberCities { get; set; }
    }
}
