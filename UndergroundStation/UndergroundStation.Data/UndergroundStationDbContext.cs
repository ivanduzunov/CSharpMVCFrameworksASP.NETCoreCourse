namespace UndergroundStation.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class UndergroundStationDbContext : IdentityDbContext<User>
    {
        public UndergroundStationDbContext(DbContextOptions<UndergroundStationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<ForumArticle> ForumArticles { get; set; }

        public DbSet<ForumTheme> ForumThemes { get; set; }

        public DbSet<MusicVideo> MusicVideos { get; set; }

        public DbSet<NewsArticle> NewsArticles { get; set; }

        public DbSet<UserArticleLike> UserNewsArticleLikes { get; set; }

        public DbSet<UserArticleUnlike> UserNewsArticleUnlikes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //The Artist has many videos and many comments
            builder.Entity<Artist>()
                .HasMany(a => a.Videos)
                .WithOne(v => v.Artist)
                .HasForeignKey(v => v.ArtistId);

            builder.Entity<Artist>()
               .HasMany(a => a.Comments)
               .WithOne(v => v.Artist)
               .HasForeignKey(v => v.ArtistId);

            //The Comment has one Author and many Answers
            builder.Entity<Comment>()
                .HasMany(c => c.Answers)
                .WithOne(a => a.AnswerComment)
                .HasForeignKey(a => a.AnswerCommentId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

            builder.Entity<Comment>()
                .HasOne(c => c.Author)
                .WithMany(a => a.Comments)
                .HasForeignKey(c => c.AuthorId);

            //Music video has comments
            builder.Entity<MusicVideo>()
                .HasMany(mv => mv.Comments)
                .WithOne(c => c.MusicVideo)
                .HasForeignKey(c => c.MusicVideoId)
                .OnDelete(DeleteBehavior.Restrict);

            //The Forum Theme has many foorum articles
            builder.Entity<ForumTheme>()
                .HasMany(ft => ft.Articles)
                .WithOne(a => a.ForumTheme)
                .HasForeignKey(a => a.ForumThemeId)
                .OnDelete(DeleteBehavior.Restrict); 

            //The ForumArticle has many answers
            builder.Entity<ForumArticle>()
                .HasMany(fa => fa.Answers)
                .WithOne(a => a.MotherArticle)
                .HasForeignKey(a => a.MotherArticleId)
               .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

            //Likes
            builder.Entity<UserArticleLike>()
                .HasKey(ul => new { ul.UserId, ul.ArticleId });

            builder.Entity<UserArticleLike>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.Likes)
                .HasForeignKey(ul => ul.UserId);

            builder.Entity<UserArticleLike>()
                .HasOne(ul => ul.Article)
                .WithMany(u => u.Likes)
                .HasForeignKey(ul => ul.ArticleId);

            //Unlikes
            builder.Entity<UserArticleUnlike>()
               .HasKey(ul => new { ul.UserId, ul.ArticleId });

            builder.Entity<UserArticleUnlike>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.Unlikes)
                .HasForeignKey(ul => ul.UserId);

            builder.Entity<UserArticleUnlike>()
                .HasOne(ul => ul.Article)
                .WithMany(u => u.Unlikes)
                .HasForeignKey(ul => ul.ArticleId);

            base.OnModelCreating(builder);
        }
    }
}
