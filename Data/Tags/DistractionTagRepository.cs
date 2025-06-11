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
        private readonly string tagsJsonURI = "data/StandardTags.json";

        public DistractionTagRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task EnsureTagsLoaded()
        {
            if (_standardTags is null)
            {
                List<DistractionTag> tagsJson = await _httpClient.GetFromJsonAsync<List<DistractionTag>>(tagsJsonURI);
                if (tagsJson is null)
                {
                    throw new Exception("Couldn't load standard tags");
                }
                _standardTags = tagsJson;
            }
        }

        public async Task<List<DistractionTag>> GetStandardTagsAsync()
        {
            await EnsureTagsLoaded();
            return _standardTags;
        }

        public string GetTagIcon(string iconKey)
        {
            string output = string.Empty;

            if (!_iconsForTags.TryGetValue(iconKey, out output))
            {
                throw new ArgumentException($"Could not find icon for {iconKey}");
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

        public async Task<DistractionTag> GetTagModel(string iconKey)
        {
            await EnsureTagsLoaded();
            DistractionTag output = _standardTags?.FirstOrDefault(x => x.IconKey == iconKey);
            if (output == null)
            {
                throw new Exception($"Couldn't find tag for icon '{iconKey}'");
            }
            return output;
        }
    }
}
