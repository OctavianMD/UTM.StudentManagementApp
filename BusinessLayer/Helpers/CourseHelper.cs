using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Mapper;
using BusinessLayer.Validators;
using CommonLayer.ApiModels;
using CommonLayer.ViewModels;
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

        public async Task<CourseViewModel> Get(int id)
        {
            var entity = await _courseRepository.Get(x => x.Id == id);
            return entity?.ToViewModel();
        }

        public async Task<List<CourseViewModel>> GetAll()
        {
            var entities = await _courseRepository.GetAll(x=>true);
            return entities?.ToViewModel() ?? new List<CourseViewModel>();
        }

        public async Task<Course> Create(CourseViewModel model)
        {
            if (model.IsValid())
            {
                return await _courseRepository.Add(model.ToEntity());
            }
            return null;
        }

        public async Task<bool> Update(CourseViewModel model)
        {
            if (model.IsValid())
            {
                await _courseRepository.Update(model.ToEntity());
                return true;
            }

            return false;
        }

        public async Task Remove(int id)
        {
            var entity = await _courseRepository.Get(x => x.Id == id);
            if (entity != null)
            {
                await _courseRepository.Remove(entity);

            }
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
