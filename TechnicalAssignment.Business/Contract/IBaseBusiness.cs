using Sieve.Models;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Contract;

public interface IBaseBusiness<T> where T : BaseEntity
{
	Task<T> CreateAsync(T t, CancellationToken cancellationToken);

	Task<List<T>> LoadAllAsync(SieveModel sieveModel, CancellationToken cancellationToken);

	Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken);

	Task<T> UpdateAsync(T t, CancellationToken cancellationToken);

	Task<T?> DeleteAsync(int id, CancellationToken cancellationToken);
}