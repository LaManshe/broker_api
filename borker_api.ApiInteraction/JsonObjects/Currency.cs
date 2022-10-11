using System.ComponentModel.DataAnnotations.Schema;

namespace borker_api.ApiInteraction.JsonObjects
{
    public class Currency
    {
        public double RUB { get; set; }
        public double EUR { get; set; }
        public double GBP { get; set; }
        public double JPY { get; set; }

        public double GetCurrencyOf(string name) => (double)GetType().GetProperty(name).GetValue(this);
    }
}
