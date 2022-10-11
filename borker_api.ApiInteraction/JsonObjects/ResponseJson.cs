using Newtonsoft.Json;

namespace borker_api.ApiInteraction.JsonObjects
{
    internal class ResponseJson
    {

        [JsonProperty("success")]
        public bool Success { get; set; }
        [JsonProperty("timeseries")]
        public bool Timeseries { get; set; }
        [JsonProperty("start_date")]
        public string StartDate { get; set; }
        [JsonProperty("end_date")]
        public string EndDate { get; set; }
        [JsonProperty("base")]
        public string @Base { get; set; }
        [JsonProperty("rates")]
        public Dictionary<DateTime, Currency> Rates { get; set; }
    }
}
