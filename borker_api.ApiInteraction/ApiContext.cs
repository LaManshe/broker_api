using borker_api.ApiInteraction.JsonObjects;
using borker_api.ApiInteraction.Models;
using Newtonsoft.Json;
using RestSharp;

namespace borker_api.ApiInteraction
{
    internal static class ApiContext
    {
        public static IEnumerable<Rate> GetRates(DateTime startDate, DateTime endDate)
        {
            var client = new RestClient($"https://api.apilayer.com/exchangerates_data/timeseries?start_date={startDate.ToString("yyyy-MM-dd")}&end_date={endDate.ToString("yyyy-MM-dd")}&base=USD&symbols=RUB,EUR,GBP,JPY");

            var request = new RestRequest();
            request.AddHeader("apikey", "YvSAcSLbGzwalJAsRZCrRE7rQpaWWcoa");

            var response = client.Execute(request);


            List<Rate> result = new List<Rate>();

            var rates = JsonConvert.DeserializeObject<ResponseJson>(response.Content).Rates;

            foreach (var rate in rates)
            {
                result.Add(new Rate() { Date = rate.Key, Currency = rate.Value });
            }

            return result;
        }
    }
}
