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
            if (model.StartDate == DateTime.MinValue
                || model.EndDate == DateTime.MinValue)
            {
                throw new Exception("Fields Dates is required");
            }

            var rates = _getRates.GetRates(model.StartDate, model.EndDate);

            if(rates == null)
            {
                throw new Exception("Recieving rates error");
            }

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
