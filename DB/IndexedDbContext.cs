using Magic.IndexedDb;
using Magic.IndexedDb.Interfaces;

namespace Distraction_Logger_PWA.DB
{
    public class IndexedDbContext : IMagicRepository
    {
        public static readonly IndexedDbSet DistractionLoggerDb = new("DistractionLoggerDb");
    }
}
