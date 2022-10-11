using borker_api.DAL.Data;
using borker_api.DAL.Entities.Base;
using borker_api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace borker_api.DAL
{
    public class Repository<T> : IRepository<T>
        where T : Entity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _Set;
        public Repository(AppDbContext context)
        {
            _context = context;
            _Set = context.Set<T>();
        }

        public virtual IQueryable<T> Items => _Set;

        public T Add(T item)
        {
            if (item is null) throw new ArgumentNullException(nameof(item));

            _context.Entry(item).State = EntityState.Added;
            _context.SaveChanges();
            return item;
        }

        public Task<T> AddAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> AddRange(IEnumerable<T> items)
        {
            if (items is null) throw new ArgumentNullException(nameof(items));

            foreach (var item in items)
            {
                _context.Entry(item).State = EntityState.Added;
            }
            _context.SaveChanges();

            return items;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public T Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id, CancellationToken Cancel = default)
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

        public void Update(T item)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(T item, CancellationToken Cancel = default)
        {
            throw new NotImplementedException();
        }
    }
}
