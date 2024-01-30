using jungletribe.Data;
using jungletribe.Models;
using jungletribe.Models.Entities;
using Microsoft.AspNetCore.Mvc;


namespace jungletribe.Controllers
{
    public class TravelController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public TravelController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public ApplicationDbContext DbContext { get; }

        [HttpGet]
        //view with Inputs
        public IActionResult AddTravel()
        {
            return View();
        }

        [HttpPost]
        //insert request with values
        public async Task<IActionResult> AddTravel(AddNewTravelViewModel viewModel)
        {
            var travel = new Travelinfo
            {
                Traveler = viewModel.Traveler,
                TravelerEmail = viewModel.TravelerEmail,
                TravelDestinacion = viewModel.TravelDestinacion,
                TravelPrice = viewModel.TravelPrice,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TravelContinent = viewModel.TravelContinent,
               TravelPhoto = viewModel.TravelPhoto,
            };
            await dbContext.Travelinfo.AddAsync(travel);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
