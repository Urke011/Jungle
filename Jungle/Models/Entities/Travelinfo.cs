using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jungletribe.Models.Entities
{
    public class Travelinfo
    {
        public Guid Id { get; set; }
        public string Traveler { get; set; }
        public string TravelerEmail { get; set; }
        public string  TravelDestinacion { get; set; }

        public int TravelPeriod { get; set; }
        public int TravelPrice { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime EndDate { get; set; }
        public string TravelContinent { get; set; }
        [NotMapped]
        public IFormFile ProfileImage { get; set; }
        public string PhotoUrl { get; set; }
                
    }
}

