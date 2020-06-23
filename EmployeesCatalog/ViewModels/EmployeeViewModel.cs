using System;
using System.Collections.ObjectModel;
using EmployeesCatalog.Models;
using EmployeesCatalog.Enums;
using EmployeesCatalog.UtilityClasses;
using System.Windows;

namespace EmployeesCatalog.ViewModels
{
    class EmployeeViewModel
    {
        
        public EmployeeViewModel()
        {
            LoadEmployees();
            DeleteEmployeeCommand = new CustomICommand(RemoveEmployee, IsItemSelected);
        }

        public ObservableCollection<Employee> EmployeesCollection
        {
            get;
            set;
        }

        public CustomICommand DeleteEmployeeCommand
        {
            get;
            set;
        }

        public void CommitChanges()
        {

            foreach(var employee in EmployeesCollection)
            {
                if (employee.Equals(SelectedGridItem))
                {
                    Console.WriteLine($"Name: {employee.Name}\n" +  
                            $"Surname: {employee.Surname}\n" +
                            $"Gender: {employee.Gender}\n" +
                            $"DOB: {employee.DateOfBirth}\n" +
                            $"Email: {employee.Email}\n" +
                            $"Home address: {employee.HomeAddress}\n");

                    employee.Name = SelectedGridItem.Name;
                    employee.Surname = SelectedGridItem.Surname;
                    employee.Gender = SelectedGridItem.Gender;
                    employee.Email = SelectedGridItem.Email;
                    employee.DateOfBirth = SelectedGridItem.DateOfBirth;
                    employee.HomeAddress = SelectedGridItem.HomeAddress;
                }
            }
        }
        public void AddNewEmployee()
        {
            if (NewEmployee !=  null)
                EmployeesCollection.Add(NewEmployee);
            NewEmployee = null;
        }
        
        private Employee _selectedGridItem;
        public Employee SelectedGridItem
        {
            get { return _selectedGridItem; }
            set 
            {
                if (_selectedGridItem != value)
                {
                    _selectedGridItem = value; 
                    DeleteEmployeeCommand.RaisedCanExecuteChanged();
                }
            }
        }

        private Employee _newEmployee;
        public Employee NewEmployee
        {
            get { return _newEmployee; }
            set
            {
                if (_newEmployee != value)
                    _newEmployee = value;
            }
        }
   
        private bool IsItemSelected()
        {
            return SelectedGridItem != null;
        }
        private void RemoveEmployee()
        {
            EmployeesCollection.Remove(SelectedGridItem);

        }
        private void LoadEmployees()
        {
            ObservableCollection<Employee> employees = new ObservableCollection<Employee>()
            {
                new Employee { 
                    Name = "Kraber",Surname = "Sniper", DateOfBirth = "01-01-2000", Email = "user@company.com",
                    Gender = GenderEnum.Male, HomeAddress = "80 Damage, Headshot road, Insta kill city, 2091"
                },
                new Employee {
                    Name = "Devotion", Surname = "SMG",Gender = GenderEnum.Male, Email = "user@company.com",
                    DateOfBirth = "01-01-2000", HomeAddress = "80 Damage, Headshot road, Insta kill city, 2091"
                },
                new Employee {
                    Name = "Havoc", Surname = "Energy-SMG", Gender = GenderEnum.Female, Email = "user@company.com",
                    DateOfBirth = "01-01-2000", HomeAddress = "80 Damage, Headshot road, Insta kill city, 2091"
                },
                new Employee {
                    Name = "Wingman", Surname = "Pistol", Gender = GenderEnum.Female, Email = "user@company.com",
                    DateOfBirth = "01-01-2000", HomeAddress = "80 Damage, Headshot road, Insta kill city, 2091"
                }
            };

            this.EmployeesCollection = employees;
        }
    }
}
