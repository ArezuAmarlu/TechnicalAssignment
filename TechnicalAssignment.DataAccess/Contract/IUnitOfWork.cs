using TechnicalAssignment.DataAccess.Repositories;

namespace TechnicalAssignment.DataAccess.Contract;

public interface IUnitOfWork
{
	CityRepository? CityRepository { get; }
	ExemptedDateRepository? ExemptedDateRepository { get; }
	ExemptedVehiclePerCityRepository? ExemptedVehiclePerCityRepository { get; }
	RateRepository? RateRepository { get; }
	TaxRepository? TaxRepository { get; }
	VehicleRepository? VehicleRepository { get; }
	VehicleTypeRepository? VehicleTypeRepository { get; }

	int Commit();

	Task<int> CommitAsync(CancellationToken cancellationToken);
}