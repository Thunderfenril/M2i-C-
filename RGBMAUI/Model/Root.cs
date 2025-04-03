using Newtonsoft.Json;

namespace RGBMAUI.Model
{
    public class Root
    {
        [JsonProperty("items")]
        public List<Item> Items { get; set; }
    }
}
