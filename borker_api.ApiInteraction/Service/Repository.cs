using borker_api.ApiInteraction.Models;
using borker_api.ApiInteraction.Service.Interfaces;

namespace borker_api.ApiInteraction.Service
{
    internal class Repository : IRatesRepository
    {
        private IEnumerable<Rate> _Rates;
        public IEnumerable<Rate> Rates 
        { 
            get => _Rates ?? new List<Rate>(); 
            set { _Rates = value; } 
        }

        public IEnumerable<Rate> GetRatesWithDates(DateTime startDate, DateTime endDate)
        {
            Rates = ApiContext.GetRates(startDate, endDate);
            return Rates;
        }
    }
}
