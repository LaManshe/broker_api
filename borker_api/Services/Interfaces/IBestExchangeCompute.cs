using borker_api.ApiInteraction.Models;
using borker_api.Models;
using Rate = borker_api.DAL.Entities.Rate;

namespace borker_api.Services.Interfaces
{
    public interface IBestExchangeCompute
    {
        BestExchangeModel GetBestExchange(List<Rate> rates, double moneyUSD);
    }
}
