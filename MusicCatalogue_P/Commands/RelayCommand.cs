using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MusicCatalogue_P.Commands
{
    public class RelayCommand(Action execute, Func<bool>? canExecute = null) : ICommand
    {
        private readonly Action _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        /// <summary>
        /// Проверяет, может ли команда быть выполнена.
        /// </summary>
        /// <param name="parameter">Параметр, передаваемый в команду (не используется в данной реализации).</param>
        /// <returns><c>true</c>, если команда может быть выполнена; в противном случае <c>false</c>.</returns>
        public bool CanExecute(object? parameter) => canExecute?.Invoke() ?? true;

        /// <summary>
        /// Событие, которое уведомляет UI о возможности выполнения команды.
        /// </summary>
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        /// <summary>
        /// Выполняет команду.
        /// </summary>
        /// <param name="parameter">Параметр, передаваемый в команду (не используется в данной реализации).</param>
        public void Execute(object? parameter) => _execute();
    }

    public class RelayCommand<T>(Action<T> execute, Func<T, bool>? canExecute = null) : ICommand
    {
        private readonly Action<T> _execute = execute ?? throw new ArgumentNullException(nameof(execute));

        // Проверка, может ли команда быть выполнена
        public bool CanExecute(object? parameter)
        {
            if (parameter is T param)
                return canExecute?.Invoke(param) ?? true;

            return false;
        }

        // Событие, которое уведомляет UI о возможности выполнения команды
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Выполнение команды
        public void Execute(object? parameter)
        {
            if (parameter is T param)
                _execute(param);
        }
    }
}
