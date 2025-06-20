using Distraction_Logger_PWA.ViewModels;

namespace Distraction_Logger_PWA.Data.Tags
{
    public class TagAnalyzer
    {

        public static List<DistractionTagViewModel> GetTopFrequentTags(List<TagWithFrequency> tagsWithFrequency)
        {
            if(tagsWithFrequency.Count == 0)
            {
                return new();
            }

            int maxFrequency = tagsWithFrequency.First().Frequency;

            return tagsWithFrequency
                .Where(tag => tag.Frequency == maxFrequency)
                .Select(tag => tag.TagViewModel)
                .ToList();
        }

        public static List<TagWithFrequency> GetDescFrequencyTags(List<DistractionLogViewModel> models)
        {
            var tagsCount = GetTagsCount(models);
            var orderedTagsCount = tagsCount.OrderByDescending(x => x.Value.Frequency).ToDictionary();
            return orderedTagsCount.Values.ToList();
        }

        private static Dictionary<string, TagWithFrequency> GetTagsCount(List<DistractionLogViewModel> logViewModels)
        {
            Dictionary<string, TagWithFrequency> tagFrequencyDict = new();
            foreach (DistractionLogViewModel logViewModel in logViewModels)
            {
                foreach (DistractionTagViewModel tagViewModel in logViewModel.Tags)
                {
                    string tagViewName = tagViewModel.Name;
                    if (!tagFrequencyDict.ContainsKey(tagViewName))
                    {
                        tagFrequencyDict.Add(tagViewName, new TagWithFrequency
                        {
                            TagViewModel = tagViewModel,
                            Frequency = 1
                        });
                    }
                    else
                    {
                        tagFrequencyDict[tagViewName].Frequency++;
                    }
                }
            }
            return tagFrequencyDict;
        }
    }
}
