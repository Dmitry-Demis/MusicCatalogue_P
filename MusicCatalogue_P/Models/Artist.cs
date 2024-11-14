using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace MusicCatalogue_P.Models
{
    public sealed class Artist : BaseIdEntity
    {
        public required string Name { get; set; }
        public ObservableCollection<Album> Albums { get; init; } = [];
    }
}
