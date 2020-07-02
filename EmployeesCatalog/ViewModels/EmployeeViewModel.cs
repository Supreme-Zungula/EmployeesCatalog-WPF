using System;
using System.Collections.ObjectModel;
using EmployeesCatalog.Models;
using EmployeesCatalog.Enums;
using EmployeesCatalog.UtilityClasses;
using System.Windows;
using EmployeesCatalog.Serivices;

namespace EmployeesCatalog.ViewModels
{
    class EmployeeViewModel
    {
        private EmployeeRepository _employeesRepository;
        public EmployeeViewModel()
        {
            _employeesRepository = new EmployeeRepository();
            EmployeesCollection = _employeesRepository.GetEmployees();
            NewEmployee = new Employee();
            DeleteEmployeeCommand = new CustomICommand(RemoveEmployee, IsItemSelected);
            SaveButtonEnabled = false;
        }

        public ObservableCollection<Employee> EmployeesCollection
        {
            get;
            set;
        }
        public CustomICommand DeleteEmployeeCommand { get; set; }
        public bool SaveButtonEnabled { get; set; }
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
            if (NewEmployee != null)
                _employeesRepository.AddEmployee(NewEmployee);
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
            _employeesRepository.DeleteEmployee(SelectedGridItem);
        }
   
    }
}
