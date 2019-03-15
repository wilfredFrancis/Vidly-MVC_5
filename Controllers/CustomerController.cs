using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.ViewModel;
using Vidly2.Models;
using System.Data.Entity;
using System.Runtime.Caching;

namespace Vidly2.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
           var membershipType = _context.MembershipType.ToList();
           var ViewModel = new NewCustomerViewModel
            {

               MembershipType = membershipType, 
               Customer = new Customer()

            }; 
            return View("Save", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
           /* if(customer.MembershipType != null )
            { */
                if (!ModelState.IsValid)
                {
                    var viewModel = new NewCustomerViewModel
                    {
                        Customer = customer,
                        MembershipType = _context.MembershipType.ToList()
                    };
                    return View("Save", viewModel);
                };
            /*}*/
           
            
    
            if(customer.Id == 0)
            {
               _context.Customers.Add(customer);
            }
            else
            {
                var custInDb = _context.Customers.Single(c => c.Id == customer.Id);
                custInDb.Name = customer.Name;
                custInDb.Birthday = customer.Birthday;
                custInDb.MembershipType = customer.MembershipType;
                custInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction(actionName: "Index", controllerName: "Customer");
        }

        // GET: Customer
        [Authorize]
        public ViewResult Index()
        {
          //  var customers = _context.Customers.Include(c => c.MembershipType);
           if(MemoryCache.Default["Genres"] == null)
            {
                MemoryCache.Default["Genres"] = _context.Genre.ToList();
            }

            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>; 
            return View();
           // return View(customers);
        }

        public ActionResult Details(byte Id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }

        public ActionResult Edit(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == Id);

            if(customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipType = _context.MembershipType.ToList()
            };
            return View("Save", viewModel);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe"},
                new Customer {Id = 2,  Name = "Christopher"}
            };
        }

    }
}