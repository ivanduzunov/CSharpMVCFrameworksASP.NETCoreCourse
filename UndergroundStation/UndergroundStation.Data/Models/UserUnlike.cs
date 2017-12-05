namespace UndergroundStation.Data.Models
{
    public class UserUnlike
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int ArticleId { get; set; }

        public NewsArticle Article { get; set; }
    }
}
