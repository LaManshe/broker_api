using borker_api.DAL.Entities;
using borker_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace borker_api.DAL
{
    public class MockRepository : IRepository<Rate>
    {
        public List<Rate> ItemsList { get; set; }

        IQueryable<Rate> IRepository<Rate>.Items => ItemsList.AsQueryable();

        public MockRepository()
        {
            ItemsList = new List<Rate>()
            {
                new Rate
                {
                    Date = DateTime.Parse("2022-09-01 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false
                },
                new Rate
                {
                    Date = DateTime.Parse("2022-09-02 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false
                },
                new Rate
                {
                    Date = DateTime.Parse("2022-09-03 00:00:00.000000"),
                    RUB = 999,
                    EUR = 0,
                    JPY = 0,
                    GBP = 0,
                    IsApiDataNeed = false
                }
            };
        }

        public Rate Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Rate> GetAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public Rate Add(Rate item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Rate> AddRange(IEnumerable<Rate> items)
        {
            if (items is null) throw new ArgumentNullException(nameof(items));

            return items;
        }

        public Task<Rate> AddAsync(Rate item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Update(Rate item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Rate item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }
    }
}
