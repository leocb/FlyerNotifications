using System;
using System.Windows.Input;


namespace Flyer.UI.Utils
{
    public class RelayCommand<T> : ICommand
    {
        readonly Action<T> _executeMethodWithParam;
        readonly Func<T, bool> _canExecuteMethodWithParam;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<T> executeMethod) : this(executeMethod, null) { }
        public RelayCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            _executeMethodWithParam = executeMethod;
            _canExecuteMethodWithParam = canExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethodWithParam != null) return _canExecuteMethodWithParam((T)parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethodWithParam?.Invoke((T)parameter);
        }
    }

    public class RelayCommand : ICommand
    {
        readonly Action _executeMethod;
        readonly Func<bool> _canExecuteMethod;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action executeMethod) : this(executeMethod, null) { }
        public RelayCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            _executeMethod = executeMethod;
            _canExecuteMethod = canExecuteMethod;
        }

        public void Execute()
        {
            _executeMethod?.Invoke();
        }

        
        public bool CanExecute(object parameter)
        {
            if (_canExecuteMethod != null) return _canExecuteMethod();
            return true;
        }

        public void Execute(object parameter)
        {
            _executeMethod?.Invoke();
        }
    }
}
