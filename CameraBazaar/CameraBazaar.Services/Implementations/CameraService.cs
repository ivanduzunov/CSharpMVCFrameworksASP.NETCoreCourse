using System;
using System.Collections.Generic;
using System.Text;
using CameraBazaar.Data.Enums;
using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using System.Linq;

namespace CameraBazaar.Services.Implementations
{
    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public void Create(MakeType make,
            string cameraModel,
            decimal price,
            int quantity,
            string description,
            bool isFullFrame,
            IEnumerable<LightMeteringType> lightMetering,
            MinISOType minISO,
            int maxISO,
            int minShutterSpeed,
            int maxShutterSpeed,
            string imageUrl,
            string videoResolution)
        {
            var camera = new Camera
            {
                Make = make,
                Model = cameraModel,
                Quantity = quantity,
                Description = description,
                IsFullFrame = isFullFrame,
                LightMetering = (LightMeteringType)lightMetering.Cast<int>().Sum(),
                MinISO = minISO,
                MaxISO = maxISO,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                ImageUrl = imageUrl,
                VideoResolution = videoResolution
            };

            db.Cameras.Add(camera);
            db.SaveChanges();
        }
    }
}
