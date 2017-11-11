using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface IPartService
    {
        IEnumerable<PartModel> All();
    }
}
