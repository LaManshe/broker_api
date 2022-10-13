using AutoMapper;
using borker_api.ApiInteraction.Service.Interfaces;
using borker_api.DAL.Entities;
using borker_api.Interfaces;
using borker_api.Services.Interfaces;
using System.Linq;

namespace borker_api.Data
{
    public class DataRates
    {
        private readonly IRatesRepository _ratesRepository;
        private readonly IRepository<Rate> _rateRepo;
        private readonly IMapper _mapper;

        public DataRates(
            IRatesRepository ratesRepository,
            IRepository<Rate> rateRepo,
            IMapper mapper)
        {
            _ratesRepository = ratesRepository;
            _rateRepo = rateRepo;
            _mapper = mapper;
        }
        public List<Rate> GetDataFromDbAndApi(DateTime startDate, DateTime endDate)
        {
            List<Rate> rates = GetCleanListWithDates(startDate, endDate);

            var ratesFromDb = GetRatesFromDb(startDate, endDate);

            foreach (var rate in rates)
            {
                var curRate = ratesFromDb.Where(x => x.Date == rate.Date).FirstOrDefault();

                if (curRate == null)
                {
                    rate.IsApiDataNeed = true;
                    continue;
                }

                rate.RUB = curRate.RUB;
                rate.EUR = curRate.EUR;
                rate.GBP = curRate.GBP;
                rate.JPY = curRate.JPY;
                rate.IsApiDataNeed = false;
            }

            if (!rates.Any(x => x.IsApiDataNeed == true)) 
                return rates.OrderBy(x => x.Date).ToList();

            List<Rate> ratesFromApi = GetRatesFromApiExceptingDbRates(endDate, rates, ratesFromDb);

            foreach (var rate in rates)
            {
                var curRate = ratesFromApi.Where(x => x.Date == rate.Date).FirstOrDefault();

                if (curRate == null)
                {
                    continue;
                }

                rate.RUB = curRate.RUB;
                rate.EUR = curRate.EUR;
                rate.GBP = curRate.GBP;
                rate.JPY = curRate.JPY;
                rate.IsApiDataNeed = false;
            }

            _rateRepo.AddRange(ratesFromApi);
            return rates.OrderBy(x => x.Date).ToList();
        }

        private List<Rate> GetRatesFromApiExceptingDbRates(DateTime endDate, List<Rate> rates, List<Rate> ratesFromDb)
        {
            return GetConvertedRatesFromApi(endDate, rates.Find(x => x.IsApiDataNeed).Date)
                .ExceptBy(ratesFromDb.Select(x => x.Date), x => x.Date).ToList();
        }

        private List<Rate> GetConvertedRatesFromApi(DateTime endDate, DateTime startApiDate)
        {
            var _ratesFromApi = _ratesRepository.GetRatesWithDates(startApiDate, endDate).ToList();

            List<Rate> convertedRatesFromApi = new List<Rate>();
            foreach (var rateFromApi in _ratesFromApi)
            {
                convertedRatesFromApi.Add(_mapper.Map<Rate>(rateFromApi));
            }

            return convertedRatesFromApi;
        }

        private List<Rate> GetCleanListWithDates(DateTime startDate, DateTime endDate)
        {
            List<Rate> rates = new List<Rate>();

            for (DateTime dt = startDate; dt <= endDate; dt = dt.AddDays(1))
            {
                rates.Add(new Rate() { Date = dt });
            }

            return rates;
        }

        private List<Rate> GetRatesFromDb(DateTime startDate, DateTime endDate)
        {
            return _rateRepo.Items.Where(x => x.Date <= endDate && x.Date >= startDate).ToList();
        }
    }
}
