using System;
using System.Collections.Generic;
using System.Text;
using CameraBazaar.Data.Enums;
using CameraBazaar.Data;
using CameraBazaar.Data.Models;
using System.Linq;
using CameraBazaar.Services.Models;

namespace CameraBazaar.Services.Implementations
{
    using Models;

    public class CameraService : ICameraService
    {
        private readonly CameraBazaarDbContext db;

        public CameraService(CameraBazaarDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CameraListModel> All()
        {
            var cameras = this.db.Cameras
                 .Select(c => new CameraListModel
                 {
                     Id = c.Id,
                     Make = c.Make.ToString(),
                     Model = c.Model,
                     Price = c.Price,
                     IsInStock = c.Quantity > 0 ? true : false,
                     ImageUrl = c.ImageUrl
                 });

            return cameras;
        }

        public IEnumerable<CameraListModel> ByUserId(string id)
        {
            var cameras = this.db.Cameras.Where(c => c.UserId == id)
                 .Select(c => new CameraListModel
                 {
                     Id = c.Id,
                     Make = c.Make.ToString(),
                     Model = c.Model,
                     Price = c.Price,
                     IsInStock = c.Quantity > 0 ? true : false,
                     ImageUrl = c.ImageUrl
                 }).ToList();

            return cameras;
        }

        public CameraDetailsViewModel CameraDetails(string id)
        => this.db.Cameras.Where(c => c.Id.ToString() == id)
            .Select(c => new CameraDetailsViewModel
            {
                Make = c.Make,
                Model = c.Model,
                Price = c.Price,
                SellersUsername = c.User.UserName,
                IsInStock = c.Quantity > 0,
                ImageUrl = c.ImageUrl,
                MaxISO = c.MaxISO,
                MinISO = c.MinISO,
                MinShutterSpeed = c.MinShutterSpeed,
                MaxShutterSpeed = c.MaxShutterSpeed,
                IsFullFrame = c.IsFullFrame,
                VideoResolution = c.VideoResolution,
                Description = c.Description,
                LightMeterings = c.LightMetering,
            }
            )
            .FirstOrDefault();
  



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
            string videoResolution,
            string userId)
        {
            var camera = new Camera
            {
                Make = make,
                Model = cameraModel,
                Price = price,
                Quantity = quantity,
                Description = description,  
                IsFullFrame = isFullFrame,
                LightMetering = (LightMeteringType)lightMetering.Cast<int>().Sum(),
                MinISO = minISO,
                MaxISO = maxISO,
                MinShutterSpeed = minShutterSpeed,
                MaxShutterSpeed = maxShutterSpeed,
                ImageUrl = imageUrl,
                VideoResolution = videoResolution,
                UserId = userId
            };

            db.Cameras.Add(camera);
            db.SaveChanges();
        }

        
    }
}
