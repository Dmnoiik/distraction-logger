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

        private readonly Dictionary<string, string> _iconsForTags = new Dictionary<string, string>
        {
            { "YouTube", Icons.Custom.Brands.YouTube},
            { "Instagram", Icons.Custom.Brands.Instagram },
            { "VideogameAsset", Icons.Material.Filled.VideogameAsset }
        };
        private readonly Dictionary<string, Color> _colorForTags = new Dictionary<string, Color>
        {
            { "YouTube", Color.Error},
            { "Instagram", Color.Secondary},
            { "VideogameAsset", Color.Tertiary }
        };

        public DistractionTagRepository(HttpClient httpClient)
        {
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

            if (!_iconsForTags.TryGetValue(iconName, out output))
            {
                throw new ArgumentException($"Could not find {iconName}");
            }
            return output;
        }

        public Color GetTagColor(string iconName)
        {
            if (iconName is null)
            {
                throw new ArgumentNullException($"Could not find color for {iconName}");
            }
            return _colorForTags[iconName];
        }
    }
}
