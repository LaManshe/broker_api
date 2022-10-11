using borker_api.DAL.Entities;

namespace borker_api.Models
{
    public class BestExchangeModel
    {
        public Dictionary<DateTime, RateVis> Rates { get; set; }
        public DateTime BuyDate { get; set; }
        public DateTime SellDate { get; set; }
        public string Tool { get; set; }
        public double Revenue { get; set; }
    }
}
