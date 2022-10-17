using borker_api.ApiInteraction.Models;
using borker_api.ApiInteraction.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.ApiInteraction.Service
{
    public class MockRepository : IRatesRepository
    {
        private IEnumerable<Rate> _Rates;
        public IEnumerable<Rate> Rates
        {
            get => _Rates ?? new List<Rate>();
            set { _Rates = value; }
        }

        public MockRepository()
        {
            Rates = new List<Rate>()
            {
                new Rate()
                {
                    Date = DateTime.Parse("2022-08-30 00:00:00.000000"),
                    Currency = new JsonObjects.Currency(){ RUB = 333, EUR = 0, GBP = 0, JPY = 0 }
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-08-31 00:00:00.000000"),
                    Currency = new JsonObjects.Currency(){ RUB = 333, EUR = 0, GBP = 0, JPY = 0 }
                },
                new Rate()
                {
                    Date = DateTime.Parse("2022-09-04 00:00:00.000000"),
                    Currency = new JsonObjects.Currency(){ RUB = 333, EUR = 0, GBP = 0, JPY = 0 }
                },
            };
        }

        public IEnumerable<Rate> GetRatesWithDates(DateTime startDate, DateTime endDate)
        {
            return Rates;
        }
    }
}
