using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Monica.Commands
{
    //一个重载的委托命令 mvvm
    public class DelegateCommand<T> : ICommand
    {
        private readonly Action<T> _executeMethod = null;
        private readonly Func<T, bool> _canExecuteMethod = null;

        public event EventHandler CanExecuteChanged;

        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        { }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethod = executeMethod ?? throw new ArgumentNullException("executeMetnod");
            _canExecuteMethod = canExecuteMethod;
        }

        #region ICommand 成员
        /// <summary>
        ///  Method to determine if the command can be executed
        /// </summary>
        public bool CanExecute(T parameter)
        {
            if (_canExecuteMethod != null)
            {
                return _canExecuteMethod(parameter);
            }
            return true;

        }

        /// <summary>
        ///  Execution of the command
        /// </summary>
        public void Execute(T parameter)
        {
            _executeMethod?.Invoke(parameter);
        }

        #endregion


        //event EventHandler ICommand.CanExecuteChanged {
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}

        #region ICommand 成员

        public bool CanExecute(object parameter)
        {
            if (parameter == null && typeof(T).IsValueType)
            {
                return (_canExecuteMethod == null);

            }

            return CanExecute((T)parameter);
        }

        public void Execute(object parameter)
        {
            Execute((T)parameter);
        }

        #endregion
    }

    public class DelegateCommand : ICommand
    {
        public Action ExecuteCommand = null;
        public Func<object, bool> CanExecuteCommand = null;
        public event EventHandler CanExecuteChanged;

        public DelegateCommand()
        {

        }

        public DelegateCommand(Action executeMethod) => ExecuteCommand = executeMethod ?? throw new ArgumentNullException("executeMetnod");

        public bool CanExecute(object parameter)
        {
            if (CanExecuteCommand != null)
            {
                return this.CanExecuteCommand(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            if (this.ExecuteCommand != null)
            {
                this.ExecuteCommand();
            }
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
