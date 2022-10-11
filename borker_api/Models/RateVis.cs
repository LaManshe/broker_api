using System.ComponentModel.DataAnnotations.Schema;

namespace borker_api.Models
{
    public class RateVis
    {
        public double RUB { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
        public double JPY { get; set; }
        public IEnumerable<string> GetListOfCurrencyString()
        {
            return new List<string>() { nameof(RUB), nameof(EUR), nameof(GBP), nameof(JPY) };
        }
        public double GetCurrencyOf(string name) => (double)GetType().GetProperty(name).GetValue(this);
    }
}
