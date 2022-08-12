using System;
using System.Windows.Input;

namespace ReceptWpf.App.Components.NavPages.Home.NavigateConfigs;

 public class BaseCommand : ICommand
 {
        private Predicate<object> _canExecute;
        private Action<object> _method;
        public event EventHandler CanExecuteChanged;

        public BaseCommand(Action<object> method)
            : this(method, null)
        {
        }
        public BaseCommand(Action<object> method, Predicate<object> canExecute)
        {
            _method = method;
            _canExecute = canExecute;
        }
        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }
        public void Execute(object parameter)
        {
            _method.Invoke(parameter);
        }
 }
