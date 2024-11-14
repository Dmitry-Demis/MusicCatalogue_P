using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MusicCatalogue_P.ViewModels
{

    /// <summary>
    /// Абстрактный класс, который реализует паттерн MVVM, предоставляя поддержку уведомлений об изменении свойств.
    /// Этот класс реализует интерфейс <see cref="INotifyPropertyChanged"/>, который необходим для уведомления UI об изменениях данных.
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие, которое уведомляет подписчиков о том, что свойство изменилось.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Метод, который вызывает событие <see cref="PropertyChanged"/>, уведомляя UI об изменении свойства.
        /// Этот метод автоматически передаёт имя свойства, которое было изменено, с помощью атрибута <see cref="CallerMemberName"/>.
        /// </summary>
        /// <param name="propertyName">Имя свойства, которое было изменено. Передаётся автоматически с помощью атрибута <see cref="CallerMemberName"/>.</param>
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Метод для установки нового значения для свойства и уведомления UI об изменении.
        /// Если новое значение отличается от текущего, то свойство обновляется и вызывается событие <see cref="PropertyChanged"/>.
        /// </summary>
        /// <typeparam name="T">Тип свойства.</typeparam>
        /// <param name="field">Ссылка на поле, которое хранит значение свойства.</param>
        /// <param name="value">Новое значение для свойства.</param>
        /// <param name="propertyName">Имя свойства, которое изменяется, автоматически передаётся с помощью <see cref="CallerMemberName"/>.</param>
        /// <returns>Возвращает true, если значение было изменено, иначе false.</returns>
        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            // Если новое значение равно текущему, то ничего не делаем
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            // Обновляем значение поля
            field = value;

            // Вызываем событие уведомления об изменении свойства
            OnPropertyChanged(propertyName);
            return true;
        }
    }

}
