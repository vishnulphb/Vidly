﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {

        // GET: Customers
        public ActionResult Index()
        {
            var customerList = GetCustomers();
            return View(customerList);
        }

        [Route("customers/details/{id?}")]
        public ActionResult Details(int id)
        {
            var customerList = GetCustomers();

            var customer = customerList.SingleOrDefault(cust => cust.Id == id);

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