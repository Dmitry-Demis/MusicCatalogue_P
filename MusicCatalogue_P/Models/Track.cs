using System.Collections.ObjectModel;

namespace MusicCatalogue_P.Models
{
    public sealed class Track : BaseIdEntity
    {
        public required string Title { get; init; }
        public required Album Album { get; init; }
        public required double Duration { get; init; }

        public ObservableCollection<Compilation> Compilations { get; set; } = [];
    }
}
