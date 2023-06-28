using pjExamenPII.Data;
using pjExamenPII.RepostoryF.IRepositoryF;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace pjExamenPII.RepostoryF
{
    public class Repostitory<T> : IRepository<T> where T : class
    {
        private FacturaContext _db;
        internal DbSet<T> dbSet;

        public Repostitory(FacturaContext db)
        {
            this._db = db;
            dbSet = db.Set<T>();
        }

        public async Task Add(T entity)
        {
            await dbSet.AddAsync(entity);
            await Save();
        }

        public async Task<T>? Get(Expression<Func<T, bool>> filter = null, bool tracked = true)
        {
            IQueryable<T> query = dbSet;
            if (!tracked)
            {
                query = query.AsNoTracking();
            }
            if (filter != null)
            {
                query = query.Where(filter);
            }
            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>>? GetAll(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = (query.Where(filter));
            }
            return await query.ToListAsync();
        }

        public async Task Remove(T entity)
        {
            dbSet.Remove(entity);
            await Save();
        }

        public async Task Save()
        {
            await _db.SaveChangesAsync();
        }
    }
}
