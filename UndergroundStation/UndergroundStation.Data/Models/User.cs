namespace UndergroundStation.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.Collections.Generic;

    public class User : IdentityUser
    {
        public string AvatarUrl { get; set; }

        public List<UserLike> Likes { get; set; } = new List<UserLike>();

        public List<UserUnlike> Unlikes { get; set; } = new List<UserUnlike>();

        public List<ForumArticle> ForumArticles { get; set; } = new List<ForumArticle>();

        public List<Comment> ForumComments { get; set; } = new List<Comment>();
    }
}
