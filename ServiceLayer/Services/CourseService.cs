using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Helpers;
using CommonLayer.ViewModels;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ServiceLayer.Interfaces;

namespace ServiceLayer.Services
{
    public sealed class CourseService: ICourseService
    {
        private readonly CourseHelper _courseHelper;
        private readonly ILogger<CourseService> _logger;

        private static readonly JsonSerializerSettings SerializerSettings= new JsonSerializerSettings
        {
            MaxDepth = 4,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public CourseService(CourseHelper courseHelper, ILogger<CourseService> logger)
        {
            _courseHelper = courseHelper;
            _logger = logger;
        }

        public async Task<CourseViewModel> Get(int id)
        {
            try
            {
                _logger.LogInformation($"Getting Course :{id}");
                var model = await _courseHelper.Get(id);
                if (model == null)
                {
                    _logger.LogWarning($"Course :{id} does not exist!");
                }
                return model ?? new CourseViewModel();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception,$"Error while getting Course :{id}");
            }
            return new CourseViewModel();
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            try
            {
                _logger.LogInformation("Getting all Courses");
                return await _courseHelper.GetAll();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, "Error while getting all Course");
            }
            return new List<CourseViewModel>();
        }

        public async Task Add(CourseViewModel model)
        {
            try
            {
                _logger.LogInformation($"Add new Course :{JsonConvert.SerializeObject(model, SerializerSettings)}");
                var course = await _courseHelper.Create(model);
                if (course == null)
                {
                    _logger.LogWarning($"Model is not added. Model details:{JsonConvert.SerializeObject(model, SerializerSettings)}");
                }
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error while add new Course :{JsonConvert.SerializeObject(model,SerializerSettings)}");
            }
        }

        public async Task<bool> Edit(CourseViewModel model)
        {
            try
            {
                _logger.LogInformation($"Edit Course :{JsonConvert.SerializeObject(model, SerializerSettings)}");
                return await _courseHelper.Update(model);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error while updating Course :{JsonConvert.SerializeObject(model, SerializerSettings)}");
            }

            return false;
        }

        public async Task RemoveCourse(int id)
        {
            try
            {
                _logger.LogInformation($"Remove Course :{id}");
                await _courseHelper.Remove(id);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"Error while remove Course :{id}");
            }
        }
    }
}
