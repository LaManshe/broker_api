using AutoMapper;
using borker_api.ApiInteraction.JsonObjects;
using borker_api.ApiInteraction.Models;
using borker_api.ApiInteraction.Service.Interfaces;
using borker_api.DAL.Entities;
using borker_api.Interfaces;
using borker_api.Models;
using borker_api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Rate = borker_api.DAL.Entities.Rate;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace borker_api.Controllers
{
    [Route("rates/best")]
    [ApiController]
    public class BestExchangeController : ControllerBase
    {
        private readonly IGetRates<Rate> _getRates;
        private readonly IBestExchangeCompute _bestExchange;

        public BestExchangeController(
            IGetRates<Rate> getRates,
            IBestExchangeCompute bestExchange)
        {
            _getRates = getRates;
            _bestExchange = bestExchange;
        }

        [HttpGet]
        public BestExchangeModel Get([FromQuery] QueryModel model)
        {
            var rates = _getRates.GetRates(model.StartDate, model.EndDate);

            //List<Rate> rates = new List<Rate>();

            //for (DateTime dt = model.StartDate; dt <= model.EndDate; dt = dt.AddDays(1))
            //{
            //    rates.Add(new Rate() { Date = dt });
            //}

            //var ratesFromDb = _rateRepo.Items.Where(x => x.Date <= model.EndDate && x.Date >= model.StartDate).ToList();

            //foreach (var rate in rates)
            //{
            //    var curRate = ratesFromDb.Where(x => x.Date == rate.Date).FirstOrDefault();

            //    if (curRate == null)
            //    {
            //        rate.IsApiDataNeed = true;
            //        continue;
            //    }

            //    rate.RUB = curRate.RUB;
            //    rate.EUR = curRate.EUR;
            //    rate.GBP = curRate.GBP;
            //    rate.JPY = curRate.JPY;
            //    rate.IsApiDataNeed = false;
            //}

            //List<Rate> ratesFromApi;
            //if (rates.Any(x => x.IsApiDataNeed == true))
            //{
            //    var startApiDate = rates.Find(x => x.IsApiDataNeed).Date;

            //    var _ratesFromApi = _ratesRepository.GetRatesWithDates(startApiDate, model.EndDate).ToList();

            //    List<Rate> convertedRatesFromApi = new List<Rate>();
            //    foreach(var rateFromApi in _ratesFromApi)
            //    {
            //        convertedRatesFromApi.Add(_mapper.Map<Rate>(rateFromApi));
            //    }

            //    ratesFromApi = convertedRatesFromApi.Except(ratesFromDb).ToList();

            //    _rateRepo.AddRange(ratesFromApi);

            //    foreach (var rate in rates)
            //    {
            //        var curRate = ratesFromApi.Where(x => x.Date == rate.Date).FirstOrDefault();

            //        if (curRate == null)
            //        {
            //            continue;
            //        }

            //        rate.RUB = curRate.RUB;
            //        rate.EUR = curRate.EUR;
            //        rate.GBP = curRate.GBP;
            //        rate.JPY = curRate.JPY;
            //        rate.IsApiDataNeed = false;
            //    }
            //}



            //List<Rate> dbRate = new List<Rate>();
            //foreach (var rate in rates)
            //{
            //    dbRate.Add(_mapper.Map<Rate>(rate));
            //}
            //_rateRepo.AddRange(dbRate);

            //List<ApiInteraction.Models.Rate> rates = new List<ApiInteraction.Models.Rate>()
            //{
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-15", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 60.17, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-16", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 72.99, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-17", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 66.01, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-18", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 61.44, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-19", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 59.79, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-20", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 59.79, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-21", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 59.79, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-22", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 54.78, EUR = 12 } },
            //    new ApiInteraction.Models.Rate() { Date = "2014-12-23", Currency = new ApiInteraction.JsonObjects.Currency() { RUB = 54.80, EUR = 12 } }
            //};



            return _bestExchange.GetBestExchange(rates, model.MoneyUSD);
        }
    }
}
