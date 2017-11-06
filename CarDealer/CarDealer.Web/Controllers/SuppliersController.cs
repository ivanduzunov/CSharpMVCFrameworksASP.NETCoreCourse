using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CarDealer.Services;
using CarDealer.Web.Models.Suppliers;

namespace CarDealer.Web.Controllers
{
    public class SuppliersController : Controller
    {
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService supplier)
        {
            this.suppliers = supplier;
        }

        [Route("suppliers/{type}")]
        public IActionResult SuppliersByType(string type)
        {
            var result = suppliers.AllSuppliers(type);

            return View(new SuppliersByType
            {
                Suppliers = result,
                Type = type
            });
        }
    }
}
