using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using Sieve.Services;
using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
{
	#region [Field(s)]

	private readonly DbSet<T> _dbSet;

	private readonly ISieveProcessor _sieveProcessor;

	#endregion

	#region [Constructor]

	public BaseRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor)
	{
		_sieveProcessor = sieveProcessor;
		_dbSet = context.Set<T>();
	}

	#endregion

	#region [Method(s)]

	public virtual async Task<T> CreateAsync(T t, CancellationToken cancellationToken = default) =>
	(await _dbSet.AddAsync(t, cancellationToken)).Entity;

	public virtual async Task<T> DeleteAsync(T t, CancellationToken cancellationToken = default)
	{
		return await Task.FromResult(_dbSet.Remove(t).Entity);
		//var record = await _dbSet.SingleOrdefaultAsync(x => x.Id == id,cancellationToken);
		//if (record == null) return false;
		//_dbSet.Remove(record);
		//return true;
		////await Task.FromResult(_dbSet.Remove(t).Entity);
	}

	public virtual async Task<List<T>> LoadAllAsync(SieveModel sieveModel,
	    Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null,
	    CancellationToken cancellationToken = default)
	{
		var query = _dbSet.AsNoTracking();
		if (include != null)
			query = include(query);
		return await _sieveProcessor.Apply(sieveModel, query).ToListAsync(cancellationToken);
	}

	public virtual async Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken = default) =>
	    await _dbSet.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

	public virtual async Task<T> UpdateAsync(T t, CancellationToken cancellationToken)
	{
		t.LastUpdated = DateTime.Now;
		return await Task.FromResult(_dbSet.Update(t).Entity);
	}

	#endregion
}
