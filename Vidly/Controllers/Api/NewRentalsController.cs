using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /rentals
        public IHttpActionResult GetData()
        {
            throw new NotImplementedException();
        
        }

        // GET /rentals
        [HttpPost]
        public IHttpActionResult AddNewRentals(NewRentalDto newRental)
        {
            //The validation we add here is more suitable for an api that is used publicly or by other teams
            //If this api was only used internally, we would only polute or could with all the validation

            if(newRental.MovieIds.Count == 0)
                return BadRequest("No movieIds have been provided.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == newRental.CustomerId);

            if (customer == null)
                return BadRequest("Invalid customerId.");

            var movies = _context.Movies.Where(m => newRental.MovieIds.Contains(m.Id)).ToList();

            if (newRental.MovieIds.Count != movies.Count)
                return BadRequest("One or more movieIds are invalid");

            foreach (var movie in movies)
            {
                if (!(movie.NumberAvailable > 0))
                    return BadRequest("Movie is not available.");

                movie.NumberAvailable--;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }

    }
}
