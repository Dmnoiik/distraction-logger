using Distraction_Logger_PWA.Data.Tags;
using System.ComponentModel.DataAnnotations;

namespace Distraction_Logger_PWA.Models
{
    public class DistractionLog
    {
        [Required]
        public int ID { get; set; }

        [Required]
        public List<DistractionTag> Tags { get; set; }

    }
}

