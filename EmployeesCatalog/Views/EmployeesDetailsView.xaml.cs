using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EmployeesCatalog.Models;
using EmployeesCatalog.ViewModels;

namespace EmployeesCatalog.Views
{
    /// <summary>
    /// Interaction logic for EmployeesDetailsView.xaml
    /// </summary>
    public partial class EmployeesDetailsView : UserControl
    {
        private EmployeeViewModel _employeeViewModel;
        public EmployeesDetailsView()
        {
            InitializeComponent();
            _employeeViewModel = new ViewModels.EmployeeViewModel();
            this.DataContext = _employeeViewModel;
        }
        
        private void EmployeeDetailsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsDataGrid.ItemsSource = _employeeViewModel.EmployeesCollection;
        }

        public void handleEditEmployees(object sender, RoutedEventArgs eventArgs)
        {
            try
            {
                var gridRows = GetDataGridRows(EmployeeDetailsDataGrid);
                DataGridRow selectedRow = GetSelectedRow(gridRows);
                if (selectedRow == null)
                {
                    MessageBox.Show("Select a row to edit.", "Edit info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                    editRowPopup.IsOpen = true;
            }
            catch { }
        }
        public void handleAddEmployee(object sender, RoutedEventArgs eventArgs)
        {
            addEmployeePopup.IsOpen = true;
            _employeeViewModel.NewEmployee = new Employee();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {
            _employeeViewModel.AddNewEmployee();
            addEmployeePopup.IsOpen = false;
            _employeeViewModel.NewEmployee = null;

        }
        private void AddNewEmployee()
        {
            _employeeViewModel.AddNewEmployee();
        }

        private void SaveChanges(object sender, RoutedEventArgs eventArgs)
        {
            _employeeViewModel.CommitChanges();
        }
        private void ClosePopup(object sender, RoutedEventArgs eventArgs)
        {
            if (editRowPopup.IsOpen == true)
                editRowPopup.IsOpen = false;
            if (addEmployeePopup.IsOpen == true)
                addEmployeePopup.IsOpen = false;
        }

        private void DisplayPopup()
        {
            if (editRowPopup.IsOpen == true)
            {
                editRowPopup.IsOpen = false;
                addEmployeePopup.IsOpen = true;
            }
            else if (addEmployeePopup.IsOpen == true)
            {
                addEmployeePopup.IsOpen = false;
                editRowPopup.IsOpen = true;
            }
        }

        private IEnumerable<DataGridRow> GetDataGridRows(DataGrid grid)
        {
            var itemsSource = grid.ItemsSource;
            if (null == itemsSource) yield return null;
            foreach (var item in itemsSource)
            {
                var row = grid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (null != row) yield return row;
            }
        }

        private DataGridRow GetSelectedRow(IEnumerable<DataGridRow> dataGridsRows)
        {
            try
            {
                var row_list = GetDataGridRows(EmployeeDetailsDataGrid);
                foreach (DataGridRow single_row in dataGridsRows)
                {
                    if (single_row.IsSelected == true)
                    {
                        return single_row;
                    }
                }
            }
            catch { }

            return null;
        }
    }
}
