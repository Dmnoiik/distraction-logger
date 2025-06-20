using Distraction_Logger_PWA.ViewModels;

namespace Distraction_Logger_PWA.Data.Tags
{
    public class TagAnalyzer
    {
        //public static DistractionTagViewModel GetMostFrequentTag(List<DistractionLogViewModel> logViewModels)
        //{
        //    Dictionary<string, TagWithFrequency> tagFrequencyDict = GetTagsCount(logViewModels);
        //    DistractionTagViewModel mostFrequentTag = tagFrequencyDict.Values
        //        .OrderByDescending(x => x.Frequency)
        //        .First()
        //        .TagViewModel;
        //    return mostFrequentTag;
        //}

        public static Dictionary<string, TagWithFrequency> GetTagsCount(List<DistractionLogViewModel> logViewModels)
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
            var orderedTagsCount = tagFrequencyDict.OrderDescending();
            return tagFrequencyDict;
        }
    }
}
