using System.ComponentModel;

namespace UndergroundStation.Data.Models.Enums
{
    public enum ArticleType
    {
        [Description("New Albums")] NewAlbums = 0,
        [Description("Concerts")] Concerts = 1,
        [Description("Album Reviews")] AlbumReviews = 3,
        [Description("Interviews")] Interviews = 4,
        [Description("History")] History = 5,
    }
}
