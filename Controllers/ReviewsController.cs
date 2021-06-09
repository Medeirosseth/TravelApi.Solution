using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TravelApi.Models;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

namespace TravelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewsController : ControllerBase
    {
        private readonly TravelApiContext _db;

        public ReviewsController(TravelApiContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Review>>> Get()
        => await _db.Reviews.ToListAsync();
    }
}
