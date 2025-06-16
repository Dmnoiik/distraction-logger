using Distraction_Logger_PWA.Data.Tags;
using Distraction_Logger_PWA.LogAndTagsData.Tags;
using Distraction_Logger_PWA.Models;
using Distraction_Logger_PWA.ViewModels;
using System.Globalization;

namespace Distraction_Logger_PWA.Data.LogsData
{
    public class DistractionLogMapper
    {
        private readonly DistractionTagMapper _tagsMapper;
        public DistractionLogMapper(DistractionTagMapper tagsMapper)
        {
            _tagsMapper = tagsMapper;
        }

        public async Task<DistractionLogViewModel> MapToViewModel(DistractionLogModel model)
        {
            List<DistractionTagViewModel> tagsViewModels = new List<DistractionTagViewModel>();

            foreach(string tagKey in model.TagsKeys)
            {
                DistractionTagViewModel tagView = await _tagsMapper.GetViewModel(tagKey);
                tagsViewModels.Add(tagView);
            }

            TimeOnly time = TimeOnly.FromDateTime(model.Date);
            DistractionLogViewModel logView = new DistractionLogViewModel
            {
                Id = model.ID,
                Notes = model.Notes,
                Tags = tagsViewModels,
                TimeOfCreation = time
            };

            return logView;
        }
    }
}
