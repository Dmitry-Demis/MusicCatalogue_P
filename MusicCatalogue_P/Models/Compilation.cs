using System.Collections.ObjectModel;

namespace MusicCatalogue_P.Models
{
    public sealed class Compilation : BaseIdEntity
    {
        public required string Title { get; init; }
        public ObservableCollection<Track> Tracks { get; set; } = [];
    }
}
