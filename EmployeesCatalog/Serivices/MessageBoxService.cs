using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EmployeesCatalog.Serivices
{
    public static class MessageBoxService
    {
        public static MessageBoxResult ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxImage image)
        {
            return MessageBox.Show(message, title, button, image);
        }
    }
}
