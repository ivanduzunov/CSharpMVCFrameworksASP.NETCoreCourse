using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Customers;

namespace CarDealer.Web.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ICustomerService customers;

        public CustomersController(ICustomerService customer)
        {
            this.customers = customer;
        }

        [Route("customers/all/{order}")]
        public IActionResult All(string order)
        {
            var orderDirection = order.ToLower()
                == "ascending" ? OrderDirection.Ascending
                : OrderDirection.Descending;

            var result = this.customers.OrderedCustomers(orderDirection);

            return View(new AllCustomersModel
            {
                Customers = result,
                OrderDirection = orderDirection
            });
        }

        [Route("customers/{id}")]
        public IActionResult TotalSales(string id)
        {
            var result = this.customers.TotalSalesByCustomer(id);

            return View(result);
        }

        [Route("customers/create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("customers/create")]
        public IActionResult Create(CutomerCreateModel customerModel)
        {
            customers.CreateCustomer(customerModel);

            return Redirect("/customers/all/ascending");
        }
    }
}
