using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly2.Dtos;
using Vidly2.Models;

namespace Vidly2.Controllers.Api
{
    public class RentingsController : ApiController
    {

        private ApplicationDbContext _context;

        public RentingsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetRentings()
        {
            var rent = _context.Rentings;

            return Ok(rent.ToList());    
        }

        [HttpPost]
        public IHttpActionResult CreateRentings(RentingDto rentObject)
        {
            var customer = _context.Customers.Single(c => c.Id == rentObject.CustomerId);

           if (customer == null)
                return BadRequest("Not found");

            var movies = _context.Movies.Where(m => rentObject.MoviesId.Contains(m.Id)).ToList();

            if (movies == null)
                return BadRequest("Not found");

            foreach(var i in movies)
            {
                if (i.NumberAvailable == 0)
                {
                    
                    return BadRequest("Movie is not available");
                    
                }

                i.NumberAvailable--;
                var rentings = new Renting
                {
                    Customer = customer,
                    Movie = i,
                    DateRented = DateTime.Now,
                };
                _context.Rentings.Add(rentings);

            }

            _context.SaveChanges();
            return Ok();
        }
    }
}
