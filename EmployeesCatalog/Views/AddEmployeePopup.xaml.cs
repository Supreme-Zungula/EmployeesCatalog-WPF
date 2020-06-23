using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using EmployeesCatalog.ViewModels;

namespace EmployeesCatalog.Views
{
    /// <summary>
    /// Interaction logic for AddEmployeePopup.xaml
    /// </summary>
    public partial class AddEmployeePopup : UserControl
    {
        public AddEmployeePopup()
        {
            InitializeComponent();
        }

        private void AddNewEmployee(object sender, RoutedEventArgs eventArgs)
        {
            var context = this.DataContext;
            addEmployeePopup.IsOpen = false;
        }

        private void ClosePopup(object sender, RoutedEventArgs eventArgs)
        {
            if (addEmployeePopup.IsOpen == true)
                addEmployeePopup.IsOpen = false;
        }
    }
}
