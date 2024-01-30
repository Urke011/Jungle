using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace jungletribe.Models
{
    public class AddNewTravelViewModel
    {
        public string Traveler { get; set; }
        public string TravelerEmail { get; set; }
        public string TravelDestinacion { get; set; }

        public int TravelPeriod { get; set; }
        public int TravelPrice { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
        public string TravelContinent { get; set; }
        public string TravelPhoto { get; set; }
    }
}
