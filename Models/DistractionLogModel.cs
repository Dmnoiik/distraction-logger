using Distraction_Logger_PWA.Data.Tags;
using Distraction_Logger_PWA.DB;
using Magic.IndexedDb;
using Magic.IndexedDb.SchemaAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Distraction_Logger_PWA.Models
{
    public class DistractionLogModel : MagicTableTool<DistractionLogModel>, IMagicTable<DbSets>
    {
        public static readonly IndexedDbSet DistractionLoggerDb = IndexedDbContext.DistractionLoggerDb;

        public IMagicCompoundKey GetKeys() =>
            CreatePrimaryKey(x => x.ID, true);

        public string GetTableName() => "DistractionLog";
        public IndexedDbSet GetDefaultDatabase() => IndexedDbContext.DistractionLoggerDb;
        public DbSets Databases { get; } = new();
        public sealed class DbSets
        {
            public readonly IndexedDbSet DistractionLoggerDb = IndexedDbContext.DistractionLoggerDb;
        }


        [Required]
        public long ID { get; set; }

        [Required]
        public List<string> TagsKeys { get; set; }

        public string Notes { get; set; }

        [MagicIndex]
        [Required]
        public DateTime Date { get; set; }
    }
}

