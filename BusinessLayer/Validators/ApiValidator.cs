using System;
using CommonLayer.ApiModels;

namespace BusinessLayer.Validators
{
    public static class ApiValidator
    {
        public static bool IsValid(this StudentApi student)
        {
            return !string.IsNullOrWhiteSpace(student.Name)
                   && !string.IsNullOrWhiteSpace(student.Surname)
                   && IsValidIdnp(student.Idnp)
                   && student.BirthDate > DateTime.MinValue
                   && student.EnrollmentDate >= new DateTime(DateTime.Now.Year - 5, 09, 01);
        }

        private static bool IsValidIdnp(string idnp)
        {
            return !string.IsNullOrWhiteSpace(idnp) && idnp.Length == 13;
        }
    }

}
