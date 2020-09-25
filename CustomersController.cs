using System;
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
            List<Customer> customersList = new List<Customer>();

            customersList.Add(new Customer { Id = 1, FirstName = "Tim Corey" });
            customersList.Add(new Customer { Id = 2, FirstName = "Joe Smith" });
            customersList.Add(new Customer { Id = 3, FirstName = "Sarah Connor" });

            return View(customersList);
        }

        public ActionResult Details(int id)
        {
            
            //return View();
            return Content("Customer Id: " + id);
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost] //capture information gathered in AddCustomer
        [ValidateAntiForgeryToken]
        public ActionResult AddCustomer(Customer model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
                return View();
        }

    }
}