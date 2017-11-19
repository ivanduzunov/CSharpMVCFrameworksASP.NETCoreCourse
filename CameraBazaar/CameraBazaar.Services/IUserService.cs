using System;
using System.Collections.Generic;
using System.Text;
using CameraBazaar.Services.Models;

namespace CameraBazaar.Services
{
    public interface IUserService
    {
        UserProfileElementsModel UserProfileElements(string id);
    }
}
