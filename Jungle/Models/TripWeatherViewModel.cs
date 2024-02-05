using jungletribe.Models.Entities;

namespace jungletribe.Models
{
    public class TripWeatherViewModel
    {
        public Travelinfo SingleTrip { get; set; }
        public dynamic FormattedWeatherData { get; set; }
    }
}
