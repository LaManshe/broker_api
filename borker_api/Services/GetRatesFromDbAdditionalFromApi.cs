using AutoMapper;
using borker_api.ApiInteraction.Service.Interfaces;
using borker_api.DAL.Entities;
using borker_api.DAL.Entities.Base;
using borker_api.Data;
using borker_api.Interfaces;
using borker_api.Services.Interfaces;

namespace borker_api.Services
{
    public class GetRatesFromDbAdditionalFromApi<T> : IGetRates<T>
    {
        public IEnumerable<T> Items { get; set; }
        private readonly DataRates _data;

        public GetRatesFromDbAdditionalFromApi(DataRates data)
        {
            _data = data;
        }
        public List<T> GetRates(DateTime startDate, DateTime endDate)
        {
            Items = (IEnumerable<T>)_data.GetDataFromDbAndApi(startDate, endDate);
            return Items.ToList();
        }
    }
}
