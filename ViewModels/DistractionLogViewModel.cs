namespace Distraction_Logger_PWA.ViewModels
{
    public class DistractionLogViewModel
    {
        public string Notes { get; set; }
        public List<DistractionTagViewModel> Tags { get; set; }
        public TimeOnly TimeOfCreation { get; set; }
    }
}
