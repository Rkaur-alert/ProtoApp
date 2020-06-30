using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProtoApp.Models;
using ProtoApp.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Infrastructure.MappingViews;
using Microsoft.ApplicationInsights.Channel;
using System.Runtime.Caching;

namespace ProtoApp.Controllers
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
            if (MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }

            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;
            //no need of list of customers because data table is now used
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);

            return View();

        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("New", viewModel);
        }

        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new NewCustomerViewModel(membershiptypes);

            return View("New", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                ModelState.Values.SelectMany(v => v.Errors).ToList()
                    .ForEach(x => Console.WriteLine(x.ErrorMessage));

                var customerViewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
            return View("New", customerViewModel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // can also use Mapper class to map properties in both objects
                //Mapper.Map(customer, customerInDb); -- not so secure
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.isSubscribedToNewsletter = customer.isSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", customer);
        }
        public ActionResult Details(int Id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            return View(customer);
        }

        public IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1 , Name = "John Doe", },
                new Customer { Id = 2 , Name = "Kate Smith" }
            };
        }

    }
}