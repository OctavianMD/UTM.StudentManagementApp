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
    public sealed class StudentHelper
    {
        private readonly IGenericRepository<Student> _studentRepository;

        public StudentHelper(IGenericRepository<Student> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<int> ProcessFetchedData(string result)
        {
            var counter = 0;
            if (string.IsNullOrWhiteSpace(result))
                return counter;

            var students = JsonConvert.DeserializeObject<List<StudentApi>>(result);

            if (students == null)
                return counter;

            foreach (var student in students)
            {
                if (student.IsValid() && !await _studentRepository.Any(x=>x.Idnp == student.Idnp))
                {
                    await _studentRepository.Add(student.ToEntity());
                    counter++;
                }
            }

            return counter;
        }
    }
}
