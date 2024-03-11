using System;
using System.Linq.Expressions;
using Book_Libirary_Api.Core.Repositories;
using Book_Libirary_Api.DTO;
using Book_Libirary_Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Book_Libirary_Api.Data.Implimentations
{
	public class Repository<T>:IRepository<T> where T:BaseEntity
	{
        private readonly DataContext _dataContext;
        private readonly DbSet<T> _table;
		public Repository(DataContext dataContext)
		{
            _dataContext = dataContext;
            _table = dataContext.Set<T>();
		}

        public async Task<int> Commit()
        {
           
            return await _dataContext.SaveChangesAsync();
        }

        public async Task Create(T entity)
        {
            entity.CreatedAt = DateTime.UtcNow.AddHours(4);
            var resoult = _dataContext.Entry(entity);
            resoult.State = EntityState.Added;
        }

        public async Task Delete(T entity)
        {
            var resoult = _dataContext.Entry(entity);
            resoult.State = EntityState.Deleted;
            
        }

        public async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length > 0)
            {
                query = await SaveAllIncludes(includes);
            }
            
            return predicate == null ?await query.ToListAsync() :await query.Where(predicate).ToListAsync();
        }
        public async Task<IQueryable<T>> SaveAllIncludes(params string[] includes)
        {
            IQueryable<T> query = _table;
            foreach (var item in includes)
            {
                query= query.Include(item);
            }
            return query;
        }
        public async Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, params string[] includes)
        {
            IQueryable<T> query = _table;
            if (includes.Length>0)
            {
                query =await SaveAllIncludes(includes);
            }
            return predicate == null ?await query.FirstOrDefaultAsync() :await query.FirstOrDefaultAsync(predicate);
        }

        public async Task<bool> IsExist(Expression<Func<T, bool>> predicate = null)
        {
            return predicate == null ? false :await _table.AnyAsync(predicate);
        }

        public async Task Update(T entity)
        {
            var resoult = _dataContext.Entry(entity);
            resoult.State = EntityState.Modified;
        }
    }
}

