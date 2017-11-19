using System;
using System.Collections.Generic;
using System.Text;
using CameraBazaar.Services.Models;
using System.Linq;
using CameraBazaar.Data;

namespace CameraBazaar.Services.Implementations
{
    public class UserService : IUserService
    {

        private readonly CameraBazaarDbContext db;

        public UserService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public UserProfileElementsModel UserProfileElements(string id)
         => this.db.Users.Where(u => u.Id == id)
            .Select(u => new UserProfileElementsModel
            {
                Username = u.UserName,
                Email = u.Email,
                Phone = u.PhoneNumber,
                CamerasInStock = u.Cameras.Where(c => c.Quantity > 0).Count(),
                CamerasOutOfStock = u.Cameras.Where(c => c.Quantity == 0).Count()
            }).FirstOrDefault();
    }
}
