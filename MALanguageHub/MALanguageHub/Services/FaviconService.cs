using MALanguageHub.Data;
using MALanguageHub.Models;

namespace MALanguageHub.Services
{
    public class FaviconService
    {
        private readonly MALHdbcontext db;

        public FaviconService(MALHdbcontext _db)
        {
            db = _db;
        }

        public string? GetFaviconURL()
        {
            var favicon = db.tbl_settings.FirstOrDefault();
            return favicon?.LogoFavicon;
        }
    }
}
