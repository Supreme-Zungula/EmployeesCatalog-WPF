using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EmployeesCatalog.UtilityClasses
{
    class CustomICommand : ICommand
    {
        Action _TargetExecuteMethod;
        Func<bool> _TargetCanExecuteMethod;

        public CustomICommand(Action executeMethod)
        {
            _TargetExecuteMethod = executeMethod;
        }

        public CustomICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = executeMethod;
            _TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaisedCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        #region Implementation of ICommand interface methods
        public event EventHandler CanExecuteChanged = delegate { };

        bool ICommand.CanExecute(object parameter)
        {
            if (_TargetCanExecuteMethod != null)
                return _TargetCanExecuteMethod();

            if (_TargetExecuteMethod != null)
                return true;

            return false;
        }

        void ICommand.Execute(object parameter)
        {
            if (_TargetExecuteMethod != null)
            {
                _TargetExecuteMethod();
            }
        }

        #endregion

    }
}
