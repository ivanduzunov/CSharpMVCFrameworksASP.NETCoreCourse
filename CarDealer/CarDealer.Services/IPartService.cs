using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartModel> All();

        void CreatePart(string name, decimal price, int quantity, int supplierId);

        void Delete(int id);

        PartModel ById(string id);

        bool Exists(string id);

        void Edit(string id,  decimal price, int quantity);
    }
}
