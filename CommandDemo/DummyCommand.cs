using System;
using System.Windows.Input;

namespace CommandDemo
{
    public class DummyCommand : ICommand
    {
        //private readonly T _instance;
        private readonly Action<object> _action;
        private readonly Predicate<object> _condition;
        public DummyCommand(Action<object> action, Predicate<object> condition)
        {
            //_instance = instance;
            _action = action;
            _condition = condition;
        }

        public bool CanExecute(object parameter)
        {

            return _condition ==null || _condition(parameter);
        }

        public void Execute(object parameter)
        {
            _action(parameter);
        }

        /// <summary>
        /// http://stackoverflow.com/a/2588145/1069200
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}