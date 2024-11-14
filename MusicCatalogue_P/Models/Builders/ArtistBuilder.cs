using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicCatalogue_P.Models.Builders
{
    public class ArtistBuilder : IBuilder<Artist>
    {
        private string _name = string.Empty;
        private ObservableCollection<Album> _albums = [];

        /// <summary>
        /// Устанавливает имя артиста.
        /// </summary>
        public ArtistBuilder WithName(string name)
        {
            _name = name;
            return this;
        }

        /// <summary>
        /// Устанавливает список альбомов артиста.
        /// </summary>
        public ArtistBuilder WithAlbums(IEnumerable<Album> albums)
        {
            _albums = new ObservableCollection<Album>(albums);
            return this;
        }

        /// <summary>
        /// Добавляет альбом в список альбомов.
        /// </summary>
        public ArtistBuilder AddAlbum(Album album)
        {
            _albums.Add(album);
            return this;
        }

        /// <summary>
        /// Строит объект Artist с текущими значениями.
        /// </summary>
        public Artist Build()
        {
            return new Artist
            {
                Name = _name,
                Albums = _albums
            };
        }
    }

}
