using System;
using System.Collections.Generic;
using System.Text;

namespace CameraBazaar.Services.Models
{
    public class UserProfileElementsModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int CamerasInStock { get; set; }

        public int CamerasOutOfStock { get; set; }
    }
}
