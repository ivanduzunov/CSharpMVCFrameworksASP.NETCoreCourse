namespace UndergroundStation.Services.Admin.Implementations
{
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using Data;


    public class AdminArticleService : IAdminArticleService
    {
        private readonly UndergroundStationDbContext db;

        public AdminArticleService(UndergroundStationDbContext db)
        {
            this.db = db;
        }

        public async Task<bool> DeleteComment(string commentId)
        {
            int id = int.Parse(commentId);

            if (id == 0)
            {
                return false;
            }

            var comment = await this.db.Comments
                   .Where(c => c.Id == id)
                   .FirstOrDefaultAsync();

           comment.IsDeleted = true;

            await this.db.SaveChangesAsync();

            return true;
        }
    }
}
