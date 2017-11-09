using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Services.Models;
using CarDealer.Web.Models.Sales;

namespace CarDealer.Web.Controllers
{
    public class SalesController : Controller
    {
        private readonly ISaleService sales;

        public SalesController(ISaleService sales)
        {
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
    }
}
