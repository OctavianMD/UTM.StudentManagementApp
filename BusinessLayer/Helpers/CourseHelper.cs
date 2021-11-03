using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using DataLayer.Entities;
using DataLayer.Repositories.Interfaces;
using Newtonsoft.Json;

namespace BusinessLayer.Helpers
{
    public sealed class CourseHelper
    {
        private readonly IGenericRepository<Course> _courseRepository;

        public CourseHelper(IGenericRepository<Course> courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<int> ProcessFetchedData(string result)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(result))
                return counter;

            var courses = JsonConvert.DeserializeObject<List<CourseApi>>(result);

            if (courses == null)
                return counter;

            foreach (var course in courses)
            {
                if (course.IsValid() && !await _courseRepository.Any(x => 
                        x.Name == course.Name && x.Name == course.Name))
                {
                    await _courseRepository.Add(course.ToEntity());
                    counter++;
                }
            }

            return counter;
        }
    }
}
