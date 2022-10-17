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

            return _bestExchange.GetBestExchange(rates, model.MoneyUSD);
        }
    }
}
