using Microsoft.EntityFrameworkCore.Query;
using Sieve.Models;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Contract;

public interface IBaseRepository<T> where T : BaseEntity
{
	Task<T> CreateAsync(T t, CancellationToken cancellationToken);

	Task<List<T>> LoadAllAsync(SieveModel sieveModel, Func<IQueryable<T>, IIncludableQueryable<T, object?>>? include = null, CancellationToken cancellationToken = default);

	Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken);

	Task<T> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<T> DeleteAsync(T t, CancellationToken cancellationToken);
}