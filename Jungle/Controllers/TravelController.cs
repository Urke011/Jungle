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
                ProfileImage = viewModel.ProfileImage
               
            };
         if(travel.TravelPhoto == null)
            {
                travel.TravelPhoto = "some test travel path";
            }
            string uniqueFileName = null;
            if (viewModel.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/travel-images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + viewModel.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
             
                    viewModel.ProfileImage.CopyTo(fileStream);
             
                }
            }


            await dbContext.Travelinfo.AddAsync(travel);
            await dbContext.SaveChangesAsync();

            return View();
        }
    }
}
