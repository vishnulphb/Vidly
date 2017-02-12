using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;
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

        // GET: Customers
        public ActionResult Index()
        {
            var customerList = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customerList);
        }

        // [Route("customers/details/{id?}")]

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(cust => cust.MembershipType).SingleOrDefault(cus=>cus.Id==id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                MembershipTypes = membershipTypes

            };
            ViewBag.Action = "new_customer";
            return View("CustomerForm",viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(cus => cus.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            ViewBag.Action = "edit_customer";
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(cus => cus.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDay = customer.BirthDay;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }

            _context.SaveChanges();
            return RedirectToAction("Index","Customers");
        }

        //private IEnumerable<Customer> GetCustomers()
        //{
        //    return new List<Customer>()
        //    {
        //       new Customer { Id = 1, Name="Vishnu" },
        //       new Customer { Id = 2, Name="Safari"}
        //    };
        //}
    }
}