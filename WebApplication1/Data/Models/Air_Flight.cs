using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Data.Models
{
    public class Air_Flight
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public int Air_FlightId { get; set; }
        public Trip Trip { get; set; }
        public string CompanyName { get; set; }
        public int NumberHours  { get; set; }
        public int LevelComfort { get; set; }
    }
}
