using System;
using System.Linq.Expressions;
using Book_Libirary_Api.Entities;

namespace Book_Libirary_Api.Core.Repositories
{
	public interface IRepository<T>where T:BaseEntity
	{
		Task Create(T entity);
		Task Delete(T entity);
		Task Update(T entity);
		Task<T> GetEntity(Expression<Func<T, bool>> predicate = null, params string[] includes);
		Task<List<T>> GetAll(Expression<Func<T, bool>> predicate = null, params string[] includes);
		Task<bool> IsExist(Expression<Func<T, bool>> predicate=null);
		Task<int> Commit();
	}
}

