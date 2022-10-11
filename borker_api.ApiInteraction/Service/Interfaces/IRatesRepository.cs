using borker_api.ApiInteraction.Models;

namespace borker_api.ApiInteraction.Service.Interfaces
{
    public interface IRatesRepository
    {
        IEnumerable<Rate> Rates { get; }
        IEnumerable<Rate> GetRatesWithDates(DateTime startDate, DateTime endDate);
    }
}
