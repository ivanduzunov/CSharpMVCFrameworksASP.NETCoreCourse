using System;
using System.Collections.Generic;
using System.Text;
using CameraBazaar.Data.Enums;
using CameraBazaar.Data.Models;

namespace CameraBazaar.Services
{
    public interface ICameraService
    {
        void Create(MakeType make, string cameraModel, decimal price, int quantity, string description, bool isFullFrame, IEnumerable<LightMeteringType> lightMetering, MinISOType minISO, int maxISO, int minShutterSpeed, int maxShutterSpeed, string imageUrl, string videoResolution, string userId);
    }
}
