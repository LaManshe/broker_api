using borker_api.DAL.Entities;

namespace borker_api.Services.Interfaces
{
    public interface IGetRates<T>
    {
        List<T> GetRates(DateTime startDate, DateTime endDate);
    }
}
