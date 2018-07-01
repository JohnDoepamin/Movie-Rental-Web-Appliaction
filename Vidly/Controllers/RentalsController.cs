using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{

    public class RentalsController : Controller
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        // GET: Rentals
        public ActionResult New()
        {
            return View();
        }

        public ActionResult List()
        {
            var rentals = _context.Rentals
                .Include(r => r.Customer)
                .Include(r => r.Movie);

            return View(rentals);
        }
    }
}