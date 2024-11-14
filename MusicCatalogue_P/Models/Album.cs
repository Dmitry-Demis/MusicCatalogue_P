namespace MusicCatalogue_P.Models
{
    public sealed class Album : BaseIdEntity
    {
        public required string Title { get; set; }
        public required Artist Artist { get; init; }
        public required string ReleaseDate { get; init; }
    }
}
