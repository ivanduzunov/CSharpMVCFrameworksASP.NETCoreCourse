﻿using System;
using System.Collections.Generic;
using System.Text;
using CarDealer.Services.Models;

namespace CarDealer.Services
{
    public interface ICarService
    {
        IEnumerable<CarModel> ByMake(string make);

        IEnumerable<CarWithPartsModel> CarsWithParts();

        void Create(string make, string model,
            long travelledDistance, List<int> partsId);
    }
}
