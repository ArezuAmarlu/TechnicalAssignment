using Sieve.Services;
using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.DataAccess.Repositories;

namespace TechnicalAssignment.DataAccess;

public class UnitOfWork(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : IUnitOfWork
{
	private CityRepository? _cityRepository;
	private ExemptedDateRepository? _exemptedDateRepository;
	private ExemptedVehiclePerCityRepository? _exemptedVehiclePerCityRepository;
	private RateRepository? _rateRepository;
	private TaxRepository? _taxRepository;
	private VehicleRepository? _vehicleRepository;
	private VehicleTypeRepository? _vehicleTypeRepository;

	public CityRepository CityRepository => _cityRepository ??= new CityRepository(context, sieveProcessor);
	public ExemptedDateRepository ExemptedDateRepository => _exemptedDateRepository ??= new ExemptedDateRepository(context, sieveProcessor);
	public ExemptedVehiclePerCityRepository ExemptedVehiclePerCityRepository => _exemptedVehiclePerCityRepository ??= new ExemptedVehiclePerCityRepository(context, sieveProcessor);
	public RateRepository RateRepository => _rateRepository ??= new RateRepository(context, sieveProcessor);
	public TaxRepository TaxRepository => _taxRepository ??= new TaxRepository(context, sieveProcessor);
	public VehicleRepository VehicleRepository => _vehicleRepository ??= new VehicleRepository(context, sieveProcessor);
	public VehicleTypeRepository VehicleTypeRepository => _vehicleTypeRepository ??= new VehicleTypeRepository(context, sieveProcessor);
	public int Commit() =>
		context.SaveChanges();

	public async Task<int> CommitAsync(CancellationToken cancellationToken) =>
		await context.SaveChangesAsync(cancellationToken);
}