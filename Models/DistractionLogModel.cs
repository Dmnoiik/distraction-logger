using Distraction_Logger_PWA.Data.Tags;
using System.ComponentModel.DataAnnotations;

namespace Distraction_Logger_PWA.Models
{
    public class DistractionLogModel
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public List<DistractionTag> Tags { get; set; }

        public string Notes { get; set; }

        [Required]
        DateTime Date { get; set; }
    }
}

