using Newtonsoft.Json;

namespace RGBMAUI.Model
{
    public class Item
    {
        [JsonProperty("colors")]
        public List<ColorModel> Colors { get; set; }
    }
}
