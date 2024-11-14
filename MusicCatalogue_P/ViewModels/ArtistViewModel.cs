using MusicCatalogue_P.Models;
using System.Collections.ObjectModel;

namespace MusicCatalogue_P.ViewModels
{
    /// <summary>
    /// Представляет модель данных для артиста в MVVM паттерне.
    /// </summary>
    /// <remarks>
    /// Конструктор для создания экземпляра модели артиста.
    /// </remarks>
    /// <param name="artist">Артист, который будет отображён в UI.</param>
    public sealed class ArtistViewModel(Artist artist) : BaseViewModel
    {
        private readonly Artist _artist = artist ?? throw new ArgumentNullException(nameof(artist));

        /// <summary>
        /// Имя артиста.
        /// </summary>
        public string Name
        {
            get => _artist.Name;
            set
            {
                // Проверка, если новое значение отличается от текущего
                if (_artist.Name != value)
                {
                    _artist.Name = value; // Присваиваем значение свойству Name объекта _artist
                    OnPropertyChanged(); // Уведомляем UI о изменении
                }
            }
        }

        /// <summary>
        /// Список альбомов артиста.
        /// </summary>
        public ObservableCollection<Album> Albums { get; } = new (artist.Albums);
    }

}
