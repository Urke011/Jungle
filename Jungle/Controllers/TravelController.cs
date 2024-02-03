using jungletribe.Data;
using jungletribe.Models;
using jungletribe.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Globalization;
using System.IO;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
           //caluculate days duration
            TimeSpan duration = viewModel.EndDate - viewModel.StartDate;
            int daysPeriod = duration.Days;
            if (daysPeriod < 0)
            {
                daysPeriod = 0;
            }

            //if TravelPrice is bigger then int
           
           

            var travel = new Travelinfo
            {
                Traveler = viewModel.Traveler,
                TravelerEmail = viewModel.TravelerEmail,
                TravelDestinacion = viewModel.TravelDestinacion,
                TravelPrice = viewModel.TravelPrice,
                StartDate = viewModel.StartDate,
                EndDate = viewModel.EndDate,
                TravelContinent = viewModel.TravelContinent,
                PhotoUrl = viewModel.PhotoUrl,
                TravelPeriod = daysPeriod
            };

            await dbContext.Travelinfo.AddAsync(travel);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("ShowAllTrips", "Travel");
        }

        [HttpGet]
        public async Task<IActionResult> ShowAllTrips() {

          var allTrips = await dbContext.Travelinfo.ToListAsync();
            return View(allTrips); }

        [HttpGet]
        public async Task<IActionResult> Description(Guid id)
        {
            return View();
        }
    }
}
