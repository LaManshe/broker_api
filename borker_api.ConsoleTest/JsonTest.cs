using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.ConsoleTest
{
    public class JsonTest
    {
        [JsonProperty("success")]
        public bool success { get; set; }
        [JsonProperty("timeseries")]
        public bool timeseries { get; set; }
        [JsonProperty("start_date")]
        public string start_date { get; set; }
        [JsonProperty("end_date")]
        public string end_date { get; set; }
        [JsonProperty("base")]
        public string @base { get; set; }
        [JsonProperty("rates")]
        public Dictionary<string, Moneys> rates { get; set; }
    }

    public class Moneys
    {
        public double RUB { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
        public double JPY { get; set; }

    }
}
