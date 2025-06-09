using Distraction_Logger_PWA.Models;
using Magic.IndexedDb;

namespace Distraction_Logger_PWA.Data.Logs
{
    public class DistractionLogRepository
    {
        private IMagicIndexedDb _db;

        public DistractionLogRepository(IMagicIndexedDb db)
        {
            _db = db;
        }

        public async Task<List<DistractionLogModel>> GetAllLogsAsync()
        {
            var result = await _db.Query<DistractionLogModel>();
            if (result is null)
            {
                throw new Exception("Couldn't read database");
            }
            return await result.ToListAsync();
        }

    }
}
