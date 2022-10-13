using AutoMapper;
using borker_api.Models;
using borker_api.Services.Interfaces;
using Rate = borker_api.DAL.Entities.Rate;

namespace borker_api.Services
{
    public class BestExchangeComputer : IBestExchangeCompute
    {
        private readonly IMapper _mapper;
        private readonly double _brokerComission;

        public BestExchangeComputer(IMapper mapper)
        {
            _mapper = mapper;
            _brokerComission = 1;
        }

        public BestExchangeModel GetBestExchange(List<Rate> rates, double moneyUSD = 100)
        {
            BestExchangeModel bestExchangeModel = new BestExchangeModel();
            bestExchangeModel.Rates = _mapper.Map<Dictionary<DateTime, RateVis>>(rates);

            for (int i = 0; i < rates.Count(); i++)
            {
                foreach (var currentCurrency in rates[i].GetListOfCurrencyString())
                {
                    for (int j = i + 2; j < rates.Count(); j++)
                    {
                        var revenue = rates[i].GetCurrencyOf(currentCurrency) * moneyUSD / rates[j].GetCurrencyOf(currentCurrency) - (_brokerComission * (j - i));

                        if (revenue > bestExchangeModel.Revenue && revenue > moneyUSD)
                        {
                            bestExchangeModel.Revenue = revenue;
                            bestExchangeModel.BuyDate = rates[i].Date;
                            bestExchangeModel.SellDate = rates[j].Date;
                            bestExchangeModel.Tool = currentCurrency;
                        }
                    }
                }
            }

            return bestExchangeModel;
        }
    }
}
