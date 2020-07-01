using System;
using System.ComponentModel;
using EmployeesCatalog.Enums;

namespace EmployeesCatalog.Models
{
    public class Employee : INotifyPropertyChanged
    {
        private string _name;
        private string _surname;
        private DateTime _dateOfBirth;
        private GenderEnum _gender;
        private string _homeAddress;
        private string _email;

        public Employee() {  }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        public string Surname
        {
            get { return _surname; }
            set
            {
                if (_surname != value)
                {
                    _surname = value;
                    RaisePropertyChanged("Surname");
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set
            {
                if (_dateOfBirth != value)
                _dateOfBirth = value;
                RaisePropertyChanged("DateOfBirth"); 
            }
        }

        public GenderEnum Gender
        {
            get { return _gender; }
            set
            {
                if (_gender != value)
                _gender = value;
                RaisePropertyChanged("Gender");
            }
        }

        public string HomeAddress
        {
            get { return _homeAddress; }
            set
            {
                if (_homeAddress != value)
                {
                    _homeAddress = value;
                    RaisePropertyChanged("HomeAddress");
                }
            }
        }

        #region Implement INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }
        #endregion
    }
}
