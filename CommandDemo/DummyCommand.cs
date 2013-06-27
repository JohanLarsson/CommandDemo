using System;
using System.Windows.Input;

namespace CommandDemo
{
    public class DummyCommand<T> : ICommand
    {
        private readonly T _instance;
        private readonly Action<T> _action;
        private readonly Func<T, bool> _condition;
        public DummyCommand(T instance, Action<T> action, Func<T, bool> condition)
        {
            _instance = instance;
            _action = action;
            _condition = condition;
        }

        public bool CanExecute(object parameter)
        {
            return _condition(_instance);
        }

        public void Execute(object parameter)
        {
            _action(_instance);
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