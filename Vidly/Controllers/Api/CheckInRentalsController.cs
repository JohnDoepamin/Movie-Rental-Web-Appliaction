using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CheckInRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public CheckInRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [HttpPost]
        public IHttpActionResult CheckInRental(int id)
        {
            var rental = _context.Rentals
                .Include(r => r.Movie)
                .Include(r => r.Customer)
                .SingleOrDefault(r => r.Id == id);

            if(rental == null)
                return BadRequest("Invalid rentalId.");

            if(rental.DateReturned != null)
                return BadRequest("Rental already checked in.");

            rental.DateReturned = DateTime.Now;
            rental.Movie.NumberAvailable++;
            rental.Customer.ActiveRentals--;

            _context.SaveChanges();

            return Ok();
        }

    }
}
