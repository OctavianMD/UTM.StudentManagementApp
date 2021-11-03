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
    public sealed class TeacherHelper
    {
        private readonly IGenericRepository<Teacher> _teacherRepository;

        public TeacherHelper(IGenericRepository<Teacher> teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task<int> ProcessFetchedData(string result)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(result))
                return counter;

            var teachers = JsonConvert.DeserializeObject<List<TeacherApi>>(result);

            if (teachers == null)
                return counter;

            foreach (var teacher in teachers)
            {
                if (teacher.IsValid() && !await _teacherRepository.Any(x => 
                        x.Name == teacher.Name && x.Name == teacher.Name))
                {
                    await _teacherRepository.Add(teacher.ToEntity());
                    counter++;
                }
            }

            return counter;
        }
    }
}
