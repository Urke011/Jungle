using jungletribe.Data;
using jungletribe.Models;
using jungletribe.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;

namespace jungletribe.Controllers
{
    public class TravelController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IWebHostEnvironment webHostEnvironment;
        public TravelController(ApplicationDbContext dbContext, IWebHostEnvironment webHostEnvironment)
        {
            this.dbContext = dbContext;
            this.webHostEnvironment = webHostEnvironment;
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
            //upload img
            if (viewModel.ProfileImage != null)
            {
                Guid unique = Guid.NewGuid();
                string folder = "images/travel-images/"+unique+"_";
                folder += viewModel.ProfileImage.FileName;
                string serverFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);
                viewModel.PhotoUrl = "/" + folder;
                //save img
                viewModel.ProfileImage.CopyTo(new FileStream(serverFolder, FileMode.Create));
            }

            var travel = new Travelinfo
            {
                Traveler = viewModel.Traveler,
                TravelerEmail = viewModel.TravelerEmail,
                TravelDestinacion = viewModel.TravelDestinacion,
                TravelPrice = viewModel.TravelPrice,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TravelContinent = viewModel.TravelContinent,
                PhotoUrl = viewModel.PhotoUrl
            };

            await dbContext.Travelinfo.AddAsync(travel);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
