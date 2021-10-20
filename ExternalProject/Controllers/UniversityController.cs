using System;
using System.Collections.Generic;
using CommonLayer.ApiModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;


namespace ExternalProject.Controllers
{
    [ApiController]
    [Route("api/university")]
    public class UniversityController : ControllerBase
    {
        private readonly ILogger<UniversityController> _logger;

        public UniversityController(ILogger<UniversityController> logger)
        {
            _logger = logger;
        }

        [HttpGet("courses")]
        public List<CourseApi> GetCourses()
        {
            _logger.LogInformation("Getting courses.");
            return new List<CourseApi>
            {
                new CourseApi
                {
                    Name = "ASDN",
                    CreditsAmount = 15
                },
                new CourseApi
                {
                    Name = "TTGE",
                    CreditsAmount = 10
                },
                new CourseApi
                {
                    Name = "IP",
                    CreditsAmount = 5
                },
                new CourseApi
                {
                    Name = "PCD",
                    CreditsAmount = 20
                },
                new CourseApi
                {
                    Name = "IA",
                    CreditsAmount = 15
                }
            };
        }

        [HttpGet("teachers")]
        public List<TeacherApi> GetTeachers()
        {
            _logger.LogInformation("Getting teachers.");
            return new List<TeacherApi>
            {
                new TeacherApi
                {
                    Name = "Viorica",
                    Surname = "Sudacevschii"
                },
                new TeacherApi
                {
                    Name = "Octavian",
                    Surname = "Godonoga"
                },
                new TeacherApi
                {
                    Name = "Viorel",
                    Surname = "Carbune"
                },
                new TeacherApi
                {
                    Name = "Victor",
                    Surname = "Ababii"
                }
            };
        }

        [HttpGet("students")]
        public List<StudentApi> GetStudents()
        {
            _logger.LogInformation("Getting students.");
            return new List<StudentApi>
            {
                new StudentApi
                {
                    Name = "Andrei",
                    Surname = "Babălungă",
                    BirthDate = new DateTime(2000, 4,12),
                    Idnp = "1111111111",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Oleg",
                    Surname = "Bonari",
                    BirthDate = new DateTime(2000, 1,12),
                    Idnp = "22222222222",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Cătălina",
                    Surname = "Bucur",
                    BirthDate = new DateTime(2000, 3,12),
                    Idnp = "3333333333",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Mihai",
                    Surname = "Ciobanu",
                    BirthDate = new DateTime(2000, 4,1),
                    Idnp = "44444444444",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Cristian",
                    Surname = "Conea",
                    BirthDate = new DateTime(2000, 4,22),
                    Idnp = "555555555",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Alexandru",
                    Surname = "Dutca",
                    BirthDate = new DateTime(2000, 8,12),
                    Idnp = "66666666666",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },new StudentApi
                {
                    Name = "Maxim",
                    Surname = "Gușciuc",
                    BirthDate = new DateTime(2000, 12,12),
                    Idnp = "7777777777",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Nicolae",
                    Surname = "Istrate",
                    BirthDate = new DateTime(2000, 7,12),
                    Idnp = "888888888888",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Valeriu",
                    Surname = "Juc",
                    BirthDate = new DateTime(2000, 4,7),
                    Idnp = "999999999",
                    EnrollmentDate = new DateTime(2017, 09,1)
                },
                new StudentApi
                {
                    Name = "Veaceslav",
                    Surname = "Lazari",
                    BirthDate = new DateTime(2000, 8,1),
                    Idnp = "00000000000",
                    EnrollmentDate = new DateTime(2017, 09,1)
                }
            };
        }
    }
}
