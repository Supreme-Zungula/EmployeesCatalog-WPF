using System;
using EmployeesCatalog.Enums;
using EmployeesCatalog.Models;
using System.Collections.ObjectModel;

namespace EmployeesCatalog.Serivices
{
    class EmployeeRepository
    {
        private ObservableCollection<Employee> _employeesCollection;
        private EmployeeFactory _employeeFactory; 

        public EmployeeRepository()
        {
            LoadEmployees();
        }

        public  ObservableCollection<Employee> GetEmployees()
        {
            return _employeesCollection;
        }

        public void AddEmployee(Employee newEmployee)
        {
            if (!_employeesCollection.Contains(newEmployee))
            {
                _employeesCollection.Add(newEmployee);
            }
        }

        public void UpdateEmployee(Employee updatedEmployee)
        {
            foreach(var employee in _employeesCollection)
            {
                if (employee.Equals(updatedEmployee) )
                {
                    employee.DateOfBirth = updatedEmployee.DateOfBirth;
                    employee.Email = updatedEmployee.Email;
                    employee.Gender = updatedEmployee.Gender;
                    employee.Name = updatedEmployee.Name;
                    employee.Surname = updatedEmployee.Surname;
                }
            }
        }

        public void DeleteEmployee(Employee employeeToDelete)
        {
            _employeesCollection.Remove(employeeToDelete);
        }
            
        private  void LoadEmployees()
        {
            _employeeFactory = new EmployeeFactory();

            ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
            {
                _employeeFactory.createEmploee("Kraber", "Sniper", GenderEnum.Male, new DateTime(2010, 10, 01),
                                "user@company.com","80 Damage, Headshot road, Insta kill city, 2091"),
                _employeeFactory.createEmploee("Devotion", "SMG", GenderEnum.Male, new DateTime(2010, 10, 01),
                                "user@company.com","80 Damage, Headshot road, Insta kill city, 2091"),
                _employeeFactory.createEmploee("Havoc", "Energy-SMG", GenderEnum.Female, new DateTime(2010, 10, 01),
                                "havoc@apex.com", "80 Damage, Deleter road, Insta kill city, 2091"),
                _employeeFactory.createEmploee("Wingman", "Pistol", GenderEnum.Female, new DateTime(2010, 10, 01),
                                "wingman@apex.com", "80 Damage, Headshot road, Insta kill city, 2091")
            };

            this._employeesCollection = employees;
        }
    }
}
