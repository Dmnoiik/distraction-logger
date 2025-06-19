using Distraction_Logger_PWA.Data.Tags;
using Distraction_Logger_PWA.ViewModels;
using MudBlazor;


namespace Distraction_Logger_PWA.LogAndTagsData.Tags
{
    public class DistractionTagMapper
    {
        private readonly DistractionTagRepository _tagsRepo;

        public DistractionTagMapper(DistractionTagRepository tagsRepo)
        {
            _tagsRepo = tagsRepo;
        }

        public async Task<DistractionTagViewModel> GetViewModel(string iconKey)
        {
            DistractionTag tag = await _tagsRepo.GetTagModel(iconKey);
            string tagIcon = _tagsRepo.GetTagIcon(tag.IconKey);
            Color colorIcon = _tagsRepo.GetTagColor(tag.ColorKey);
            string note = tag.Description;

            return new DistractionTagViewModel
            {
                Color = colorIcon,
                Icon = tagIcon,
                Note = note
            };
        }

        public async Task<List<DistractionTagViewModel>> GetViewModelList(List<string> iconKeys)
        {
            List<DistractionTagViewModel> output = new List<DistractionTagViewModel>();
            foreach(string iconKey in iconKeys)
            {
                var currentTagView = await GetViewModel(iconKey);
                output.Add(currentTagView);
            }
            return output;
        }
    }
}
