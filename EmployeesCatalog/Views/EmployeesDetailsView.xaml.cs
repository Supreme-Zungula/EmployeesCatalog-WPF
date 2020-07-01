using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using EmployeesCatalog.Models;
using EmployeesCatalog.ViewModels;
using EmployeesCatalog.Serivices;

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
            _employeeViewModel.NewEmployee = new Employee();
            _employeeViewModel.NewEmployee.DateOfBirth = new DateTime();
        }

   
        private void EmployeeDetailsDataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            EmployeeDetailsDataGrid.ItemsSource = _employeeViewModel.EmployeesCollection;
            SetComboBoxBackground();
        }
        private void handleEditEmployees(object sender, RoutedEventArgs eventArgs)
        {
            try
            {
                var gridRows = GetDataGridRows(EmployeeDetailsDataGrid);
                DataGridRow selectedRow = GetSelectedRow(gridRows);

                if (selectedRow == null) {
                    MessageBoxService.ShowMessageBox("Select a row to edit.", "Edit info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else {
                    EditEmployeeDetailsPopupControl.editRowPopup.IsOpen = true;
                    EditEmployeeDetailsPopupControl.DataContext = _employeeViewModel;
                    ClosePopup(sender, eventArgs);
                }
            }
            catch { }
        }
        private void handleAddEmployee(object sender, RoutedEventArgs eventArgs)
        {
            //AddEmployeePopupControl.addEmployeePopup.IsOpen = true;
            addEmployeePopup.IsOpen = true;
            if (EditEmployeeDetailsPopupControl.editRowPopup.IsOpen)
            {
                EditEmployeeDetailsPopupControl.editRowPopup.IsOpen = false;
            }
        }
        private void   AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {
            //addEmployeePopup.IsOpen = false;
            _employeeViewModel.AddNewEmployee();
            _employeeViewModel.NewEmployee = new Employee();
            ClosePopup(sender, eventArgs);
        }

        private void ClosePopup(object sender, RoutedEventArgs eventArgs)
        {
            if (addEmployeePopup.IsOpen == true)
                addEmployeePopup.IsOpen = false;
        }

        private void SetComboBoxBackground()
        {
            IEnumerable<DataGridRow> gridRows = GetDataGridRows(EmployeeDetailsDataGrid);
            if (gridRows != null)
            {
                foreach (DataGridRow single_row in gridRows)
                {
                    Console.WriteLine(single_row.Item);
                }
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

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var datePicker = sender as DatePicker;
            var date = datePicker.SelectedDate;
            if (date != null)
            {
                _employeeViewModel.NewEmployee.DateOfBirth = (DateTime)date;
            }
        }

    }
}
