using LearningSystem.Services.Trainer.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Services.Trainer
{
    public interface ITrainerService
    {
        Task<CourseDetailsTrainerServiceView> CourseDetailsAsync(int id);
    }
}
