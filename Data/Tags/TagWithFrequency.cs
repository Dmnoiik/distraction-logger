using Distraction_Logger_PWA.ViewModels;

namespace Distraction_Logger_PWA.Data.Tags
{
    public record TagWithFrequency
    {
        public DistractionTagViewModel TagViewModel { get; set; }

        public int Frequency { get; set; }
    }
}
