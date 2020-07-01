using System;
using System.Collections.Generic;
using EmployeesCatalog.Models;
using EmployeesCatalog.Enums;

namespace EmployeesCatalog.Serivices
{
    class EmployeeFactory
    {
        public EmployeeFactory()
        {
        }

        public Employee createEmploee(string name, string surname, GenderEnum gender, DateTime dateOfbirth, string email, string address)
        {

            return new Employee
            {
                Name = name,
                Surname = surname,
                DateOfBirth = dateOfbirth,
                Gender = gender,
                Email = email,
                HomeAddress = address
            };
        }
    }
}
