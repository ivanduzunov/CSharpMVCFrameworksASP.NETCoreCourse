using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services
{
    using Services.Models;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailsModel SaleDetails(string id);
    }
}
