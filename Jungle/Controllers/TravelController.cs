using Esprima.Ast;
using jungletribe.Data;
using jungletribe.Models;
using jungletribe.Models.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml;
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
                string folder = "images/travel-images/" + unique + "_";
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
        public async Task<IActionResult> ShowAllTrips()
        {

            var allTrips = await dbContext.Travelinfo.ToListAsync();
            return View(allTrips);
        }

        [HttpGet]
        public async Task<IActionResult> Description(Guid id)
        {
            var singleTrip = await dbContext.Travelinfo.FirstOrDefaultAsync(t => t.Id == id);
            string apiKey = "566362106b93ae738477ddbb292d1712";
            string cityName = singleTrip.TravelDestinacion;
            
            using (var client = new HttpClient())
            {
                var endpoint = new Uri($"https://api.openweathermap.org/data/2.5/weather?q={cityName}&APPID={apiKey}");
                var result = await client.GetAsync(endpoint);

                if (result.IsSuccessStatusCode)
                {
                    var json = await result.Content.ReadAsStringAsync();
                     var  formatedJson = JsonConvert.DeserializeObject(json);

                    return View(singleTrip);
                }
                else
                {
                    // Handle error appropriately, e.g., log the error, return an error view, etc.
                    // You might want to check the status code and take appropriate action.
                    return View("Error");
                }   
            } 
        }
    }
}
    

