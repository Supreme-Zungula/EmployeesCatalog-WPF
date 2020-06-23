using System;
using System.Windows;
using System.Windows.Controls;

namespace EmployeesCatalog.Views
{
    /// <summary>
    /// Interaction logic for EditEmployeeDetailsPopup.xaml
    /// </summary>
    public partial class EditEmployeeDetailsPopup : UserControl
    {
        public EditEmployeeDetailsPopup()
        {
            InitializeComponent();
        }

        private void SaveChanges(object sender, RoutedEventArgs eventArgs)
        {
            //CommitChanges();
            editRowPopup.IsOpen = false;
        }

        private void ClosePopup(object sender, RoutedEventArgs eventArgs)
        {
            if (editRowPopup.IsOpen == true)
                editRowPopup.IsOpen = false;
        }
    }
}
