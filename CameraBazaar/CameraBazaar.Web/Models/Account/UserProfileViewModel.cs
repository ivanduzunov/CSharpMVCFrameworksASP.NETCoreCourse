using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CameraBazaar.Services.Models;

namespace CameraBazaar.Web.Models.Account
{
    public class UserProfileViewModel
    {
        public string Username { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public int CamerasInStock { get; set; }

        public int  CamerasOutOfStock { get; set; }

        public IEnumerable<CameraListModel> Cameras { get; set; }
    }
}
