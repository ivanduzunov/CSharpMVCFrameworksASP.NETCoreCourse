namespace UndergroundStation.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;
    using Models.Likes;

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

        public DbSet<ForumSection> ForumSections { get; set; }

        public DbSet<MusicVideo> MusicVideos { get; set; }

        public DbSet<NewsArticle> NewsArticles { get; set; }

        public DbSet<Like> Likes { get; set; }

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

            //ForumSection - ForumThemes

            builder.Entity<ForumTheme>()
                .HasOne(ft => ft.ForumSection)
                .WithMany(fs => fs.Themes)
                .HasForeignKey(ft => ft.ForumSectionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<ForumTheme>()
               .HasOne(ft => ft.Creator)
               .WithMany(c => c.ForumThemes)
               .HasForeignKey(ft => ft.CreatorId)
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

            builder.Entity<Like>()
                .HasOne(l => l.Atrist)
                .WithMany(a => a.Likes)
                .HasForeignKey(l => l.ArtistId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

            builder.Entity<Like>()
                .HasOne(l => l.ForumArtcle)
                .WithMany(fa => fa.Likes)
                .HasForeignKey(l => l.ForumArticleId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

            builder.Entity<Like>()
              .HasOne(l => l.NewsArticle)
              .WithMany(na => na.Likes)
              .HasForeignKey(l => l.NewsArticleId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            builder.Entity<Like>()
              .HasOne(l => l.User)
              .WithMany(u => u.Likes)
              .HasForeignKey(l => l.UserId)
               .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }
    }
}
