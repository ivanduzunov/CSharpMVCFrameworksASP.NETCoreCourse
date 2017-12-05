namespace UndergroundStation.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public List<UserArticleLike> Likes { get; set; } = new List<UserArticleLike>();

        public List<UserArticleUnlike> Unlikes { get; set; } = new List<UserArticleUnlike>();

        public List<ForumArticle> ForumArticles { get; set; } = new List<ForumArticle>();

        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
