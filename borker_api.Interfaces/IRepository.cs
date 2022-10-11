using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace borker_api.Interfaces
{
    public interface IRepository<T>
        where T : class, IEntity, new()
    {
        IQueryable<T> Items { get; }

        T Get(int id);
        Task<T> GetAsync(int id, CancellationToken Cancel = default);

        T Add(T item);
        Task<T> AddAsync(T item, CancellationToken Cancel = default);
        IEnumerable<T> AddRange(IEnumerable<T> items);

        void Update(T item);
        Task UpdateAsync(T item, CancellationToken Cancel = default);

        void Remove(int id);
        Task RemoveAsync(int id, CancellationToken Cancel = default);

        void Clear();
    }
}
