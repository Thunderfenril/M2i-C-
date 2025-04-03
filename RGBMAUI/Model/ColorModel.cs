using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RGBMAUI.Model
{
    public class ColorModel
    {
        [JsonProperty("type")]
        public int Type { get; set; }

        [JsonProperty("red")]
        public int Red { get; set; }

        [JsonProperty("green")]
        public int Green { get; set; }

        [JsonProperty("blue")]
        public int Blue { get; set; }
    }
}
