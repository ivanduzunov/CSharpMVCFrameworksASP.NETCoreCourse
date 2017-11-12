using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartModel> All();

        void CreatePart(string name, decimal price, int quantity, int supplierI);
        void Delete(int id);
        object ById(string id);
    }
}
