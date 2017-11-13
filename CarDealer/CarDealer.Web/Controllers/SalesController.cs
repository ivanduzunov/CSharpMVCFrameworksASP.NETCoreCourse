using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Sales;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;


namespace CarDealer.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService sales;
        private readonly ICarService cars;
        private readonly ICustomerService customers;

        public SalesController(ISaleService sales, ICarService cars, ICustomerService customers)
        {
            this.customers = customers;
            this.cars = cars;
            this.sales = sales;
        }

        [Route("sales")]
        public IActionResult All()
        {
            var result = sales.All();

            return this.View(new AllSales
            {
                Sales = result
            });
        }


        [Route("sales/discounted")]
        public IActionResult AllDiscounted()
        {
            var result = sales.All().Where(s => s.IsYoungDriver || s.Discount > 0);

            return this.View(new AllSales
            {
                Sales = result
            });
        }

        [Route("sales/discounted/{percent}")]
        public IActionResult DiscountedByPercent(string percent)
        {
            var isYoungDriverDiscount = 0;
            var result = sales.All()
                .Where(s => ((s.Discount * 100) + (isYoungDriverDiscount = s.IsYoungDriver ? 5 : 0)) == double.Parse(percent));

            return this.View(new AllSales
            {
                Sales = result
            });
        }


        [Route("sales/{id}")]
        public IActionResult Details(string id)
            => this.View(sales.SaleDetails(id));

        [Route("sales/discounted/{id}")]
        public IActionResult DetailsForDiscounted(string id)
            => this.View(sales.SaleDetails(id));

        [Route("sales/create")]
        public IActionResult Create()
       => View(new SaleFormModel
       {
           Cars = this.cars.CarsWithParts()
               .Select(s => new SelectListItem
               {
                   Text = $"{s.Make} {s.Model}",
                   Value = s.Id.ToString()
               }),

           Customers = this.customers.OrderedCustomers(OrderDirection.Ascending)
              .Select(c => new SelectListItem
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              })
       });

        [HttpPost]
        [Route("sales/create")]
        public IActionResult Create(SaleFormModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(new SaleFormModel
                {
                    Cars = this.cars.CarsWithParts()
               .Select(s => new SelectListItem
               {
                   Text = $"{s.Make} {s.Model}",
                   Value = s.Id.ToString()
               }),

                    Customers = this.customers.OrderedCustomers(OrderDirection.Ascending)
              .Select(c => new SelectListItem
              {
                  Text = c.Name,
                  Value = c.Id.ToString()
              })
                });
            }
            this.sales.Create(model.CarId, model.CustomerId, model.Discount);

            return Redirect("/sales");
        }      
    }
}
