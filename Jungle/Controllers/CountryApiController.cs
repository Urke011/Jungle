using jungletribe.Data;
using jungletribe.Models;
using jungletribe.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Jungle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly DbContext _context;
        public CountryApiController(DbContext context)
        {
            _context = context;
        }

       
    }
}
