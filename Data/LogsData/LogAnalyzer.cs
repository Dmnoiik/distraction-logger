using Distraction_Logger_PWA.ViewModels;

namespace Distraction_Logger_PWA.Data.LogsData
{
    public class LogAnalyzer
    {

        public static Dictionary<DateTime, List<DistractionLogViewModel>> GetLogsByUniqueDates(List<DistractionLogViewModel> viewModels)
        {
            Dictionary<DateTime, List<DistractionLogViewModel>> outputDict = new();

            foreach (var viewModel in viewModels)
            {
                DateTime viewModelDate = viewModel.DateOfCreation.Date;
                if (outputDict.ContainsKey(viewModelDate))
                {
                    outputDict[viewModelDate].Add(viewModel);
                }
                else
                {
                    outputDict.Add(viewModelDate, new List<DistractionLogViewModel> { viewModel });
                }
            }
            return outputDict;
        }

    }
}
