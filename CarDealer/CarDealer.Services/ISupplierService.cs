using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> AllSuppliers(string type);

        IEnumerable<SupplierModel> All();
    }
}
