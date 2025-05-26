using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MudBlazor;

namespace Distraction_Logger_PWA.Data.Tags
{
    public class DistractionTagRepository
    {
        private readonly HttpClient _httpClient;

        private readonly Dictionary<string, string> _iconsForTags = new Dictionary<string, string>();

        public DistractionTagRepository(HttpClient httpClient)
        {
            _iconsForTags.Add("Youtube", Icons.Custom.Brands.YouTube);
            _iconsForTags.Add("Instagram", Icons.Custom.Brands.Instagram);
            _iconsForTags.Add("Gaming", Icons.Material.Filled.VideogameAsset);

            _httpClient = httpClient;
        }


        public async Task<List<DistractionTag>> GetStandardTagsAsync()
        {
            var tags = await _httpClient.GetFromJsonAsync<List<DistractionTag>>("data/StandardTags.json");

            if (tags is null)
            {
                throw new Exception("Could not read StandardTags json file");
            }

            return tags;
        }

        public string GetStandardIcon(string iconName)
        {
            string output = string.Empty;
            
            if(!_iconsForTags.TryGetValue(iconName, out output))
            {
                throw new ArgumentException($"Could not find {iconName}");
            }
            return output;
        }

        public string GetTagColor(DistractionTag tag)
        {
            return $"color: {tag.Color}";
        }
    }
}
