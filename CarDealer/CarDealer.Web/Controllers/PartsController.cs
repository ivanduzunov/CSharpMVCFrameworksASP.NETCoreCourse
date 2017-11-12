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
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            parts.CreatePart
                (model.Name, model.Price, model.Quantity, model.SupplierId);

            return this.Redirect("all");
        }

        [Route("parts/delete/{id}")]
        public IActionResult Delete(int id) => View(id);

        [Route("parts/destroy/{id}")]
        public IActionResult Destroy(int id)
        {
            this.parts.Delete(id);

            return RedirectToAction("All");
        }

        [Route("customers/edit/{id}")]
        public IActionResult Edit(string id)
        {
            var cust = this.parts.ById(id);

            if (cust == null)
            {
                return NotFound();
            }

            return this.View(new PartsFormModel
            {
               
            });
        }
    }
}
