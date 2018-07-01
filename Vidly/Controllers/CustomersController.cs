using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Caching;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            // Example of caching the MemberShipTypes
            //if (MemoryCache.Default["MemberShipTypes"] == null)
            //    MemoryCache.Default["MemberShipTypes"] = _context.MemberShipTypes.ToList();
            //var genres = MemoryCache.Default["MemberShipTypes"] as IEnumerable<MemberShipType>;

            var customers = _context.Customers.Include(c => c.MemberShipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int? id)
        {

            var customer = _context.Customers.Include(c => c.MemberShipType).Single(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }

        public ActionResult New()
        {
            var membershipTypes = _context.MemberShipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MemberShipTypes = membershipTypes
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MemberShipTypes = _context.MemberShipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Update Database Object
                // Not recommended as this can add security issues to our application, it is possible to update all properties of the object.
                //TryUpdateModel(customerInDb);

                // We can limit the properties here with a magic string array, this is not recommended as if the property names are changed we need to update this manually
                //TryUpdateModel(customerInDb,"",new string[]{ "Name", "Email" });

                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.Name = customer.Name;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                customerInDb.MemberShipTypeId = customer.MemberShipTypeId;
                customerInDb.IsDelinquent = customer.IsDelinquent;
                customerInDb.SpecialDiscount = customer.SpecialDiscount;

            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int? id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel()
            {
                Customer = customer,
                MemberShipTypes = _context.MemberShipTypes.ToList()
            };

            return View("CustomerForm", viewModel);

        }
    }
}