﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using System.Data.Entity;

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
            //var customerList = GetCustomers();

            //var customer = customerList.SingleOrDefault(cust => cust.Id == id);

            var customer = _context.Customers.Include(cust => cust.MembershipType).SingleOrDefault(cus=>cus.Id==id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>()
            {
               new Customer { Id = 1, Name="Vishnu" },
               new Customer { Id = 2, Name="Safari"}
            };
        }
    }
}