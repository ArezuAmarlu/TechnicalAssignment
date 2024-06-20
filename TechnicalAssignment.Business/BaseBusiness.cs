using Sieve.Models;
using TechnicalAssignment.Business.Contract;
using TechnicalAssignment.Common.Helper;
using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business;

public class BaseBusiness<T> : IBaseBusiness<T> where T : BaseEntity
{
	private readonly IUnitOfWork _unitOfWork;

	private readonly IBaseRepository<T> _baseRepository;

	public BaseBusiness(IUnitOfWork unitOfWork, IBaseRepository<T> baseRepository)
	{
		_unitOfWork = unitOfWork;
		_baseRepository = baseRepository;
	}

	public async Task<T> CreateAsync(T t, CancellationToken cancellationToken = new())
	{
		var createdEntity = await _baseRepository.CreateAsync(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return createdEntity;
	}

	public async Task<List<T>> LoadAllAsync(SieveModel sieveModel, CancellationToken cancellationToken = new())
	{
		sieveModel = sieveModel.Validate();
		return await _baseRepository.LoadAllAsync(sieveModel, cancellationToken: cancellationToken);
	}

	public async Task<T?> LoadByIdAsync(int id, CancellationToken cancellationToken = new()) =>
		await _baseRepository.LoadByIdAsync(id, cancellationToken);

	public async Task<T> UpdateAsync(T t, CancellationToken cancellationToken)
	{
		var updateEntity = await _baseRepository.UpdateAsync(t, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return updateEntity;
	}

	public async Task<T?> DeleteAsync(int id, CancellationToken cancellationToken = new())
	{
		var record = await _baseRepository.LoadByIdAsync(id, cancellationToken);
		if (record == null) return null;
		var response = await _baseRepository.DeleteAsync(record, cancellationToken);
		await _unitOfWork.CommitAsync(cancellationToken);
		return response;
	}
}