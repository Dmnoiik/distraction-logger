using Distraction_Logger_PWA.Data.Tags;
using Distraction_Logger_PWA.Models;
using Distraction_Logger_PWA.ViewModels;
using Magic.IndexedDb;
using System.Threading.Tasks;

namespace Distraction_Logger_PWA.Data.LogsData
{
    public class DistractionLogRepository
    {
        private IMagicIndexedDb _db;

        public DistractionLogRepository(IMagicIndexedDb db)
        {
            _db = db;
        }

        public async Task<DistractionLogModel> GetLogByIdAsync(long id)
        {
            var query = await GetQueryAsync();
            var modelToQuery = await query.FirstOrDefaultAsync(model => model.ID == id);
            if (modelToQuery is null)
            {
                throw new Exception($"Couldn't not find model with id: {id}");
            }
            return modelToQuery;
        }

        public async Task<List<DistractionLogModel>> GetAllLogsAsync()
        {
            var query = await GetQueryAsync();
            return await query.ToListAsync();
        }


        public async Task<List<DistractionLogModel>> GetTodayLogsAsync()
        {
            DateTime dateToday = DateTime.Now.Date;
            var query = await GetQueryAsync();
            var allLogs = await query.Where(log => log.Date.Date == dateToday).ToListAsync();
            return allLogs;
        }

        public async Task<List<DistractionLogModel>> GetLogsFromLastXDays(int days = 7)
        {
            DateTime endDate = DateTime.Now.Date.AddDays(1);
            DateTime startDate = endDate.Date.AddDays(-days);

            var query = await GetQueryAsync();
            var logs = await query.Where(log => log.Date >= startDate && log.Date <= endDate).ToListAsync();
            return logs;
        }
        public async Task SaveLogAsync(DistractionLogModel model)
        {
            var query = await GetQueryAsync();
            await query.AddAsync(model);
        }

        public async Task DeleteLogAsync(DistractionLogModel model)
        {
            var query = await GetQueryAsync();
            await query.DeleteAsync(model);
        }

        private async ValueTask<IMagicQuery<DistractionLogModel>> GetQueryAsync()
        {
            var query = await _db.Query<DistractionLogModel>();
            if (query is null)
            {
                throw new Exception("Couldn't read database");
            }
            return query;
        }

    }
}
