using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarDealer.Services;
using CarDealer.Web.Models.Parts;


namespace CarDealer.Web.Controllers
{
    public class PartsController : Controller
    {
        private readonly IPartService parts;
        private readonly ISupplierService suppliers;


        public PartsController(IPartService parts,
            ISupplierService suppliers)
        {
            this.parts = parts;
            this.suppliers = suppliers;
        }

        [Route("parts/all")]
        public IActionResult All()
        {
            var result = this.parts.All();

            return View(new PartsListModel
            {
                Parts = result
            });
        }

        [Route("parts/create")]
        public IActionResult Create()
        {
            return View( new PartsFormModel
            {
                Suppliers = this.suppliers.All()
                .Select(s => new SelectListItem
                {
                    Text = s.Name,
                    Value = s.Id.ToString()
                })
            });
        }

        [HttpPost]
        [Route("parts/create")]
        public IActionResult Create(PartsFormModel model)
        {
            return null;
        }
    }
}
