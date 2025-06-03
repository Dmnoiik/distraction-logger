using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using MudBlazor;
using Distraction_Logger_PWA.ViewModels;

namespace Distraction_Logger_PWA.Data.Tags
{
    public class DistractionTagRepository
    {
        private readonly HttpClient _httpClient;

        private readonly Dictionary<string, string> _iconsForTags = new Dictionary<string, string>
        {
            { "YouTube", Icons.Custom.Brands.YouTube},
            { "Instagram", Icons.Custom.Brands.Instagram },
            { "VideogameAsset", Icons.Material.Filled.VideogameAsset },
            { "PhoneAndroid", Icons.Material.Filled.PhoneAndroid },
            { "Web", Icons.Material.Filled.Web },
            { "MusicNote", Icons.Material.Filled.MusicNote }
        };
        private readonly Dictionary<string, Color> _colorForTags = new Dictionary<string, Color>
        {
            { "Error", Color.Error},
            { "Secondary", Color.Secondary},
            { "Tertiary", Color.Tertiary },
            { "Info", Color.Info },
            { "Success", Color.Success},
            { "Warning", Color.Warning }
        };
        private List<DistractionTag>? _standardTags;

        public DistractionTagRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<DistractionTag>> GetStandardTagsAsync()
        {
            if(_standardTags is not null)
            {
                return _standardTags;
            }

            _standardTags = await _httpClient.GetFromJsonAsync<List<DistractionTag>>("data/StandardTags.json");

            if (_standardTags is null)
            {
                throw new Exception("Could not read StandardTags json file");
            }

            return _standardTags;
        }

        public string GetTagIcon(string iconKey)
        {
            string output = string.Empty;

            if (!_iconsForTags.TryGetValue(iconKey, out output))
            {
                throw new ArgumentException($"Could not find {iconKey}");
            }
            return output;
        }

        public Color GetTagColor(string colorKey)
        {
            if (colorKey is null)
            {
                throw new ArgumentNullException($"Could not find color for {colorKey}");
            }
            return _colorForTags[colorKey];
        }

        public async Task<List<DistractionTag>> GetTagsAsync(List<string> iconKeys)
        {
            List<DistractionTag> tags = new List<DistractionTag>();
            foreach(string iconKey in iconKeys)
            {
                var currentTag = await GetTag(iconKey);
                tags.Add(currentTag);
            }
            return tags;
        }

        public async Task<DistractionTag> GetTag(string iconKey)
        {
            var tags = await _httpClient.GetFromJsonAsync<List<DistractionTag>>("data/StandardTags.json");
            var output = tags.FirstOrDefault(x => x.IconKey == iconKey);
            return output;
        }

        public DistractionTagViewModel GetTagViewModel(string iconKey)
        {
            var tagIcon = _iconsForTags[iconKey];
            var colorIcon = _colorForTags[iconKey];

            return new DistractionTagViewModel
            {
                Icon = tagIcon,
                Color = colorIcon,
            };
        }
    }
}
