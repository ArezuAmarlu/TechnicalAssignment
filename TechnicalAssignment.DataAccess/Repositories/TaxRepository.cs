using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class TaxRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : BaseRepository<Tax>(
	context, sieveProcessor)
{

	public async Task<List<Tax>?> LoadAllTaxPerDayByVehicleIdAsync(int vehicleId, DateOnly date,
		CancellationToken cancellationToken = default) =>
		await context.Taxes!.Where(x => x.Date == date && x.VehicleId == vehicleId)
			.ToListAsync(cancellationToken);

	//public async Task<bool> IsVehicleBelongToCityAsync(int vehicleId, int cityId,
	//	CancellationToken cancellationToken = default)
	//{
	//	var tax = await context.Taxes!.SingleOrDefaultAsync(x => x.Id == vehicleId, cancellationToken);
	//	if (tax == null) return false;

	//	var vehicleCities = await context.Vehicles!
	//		.Include(x => x.VehicleType)
	//		.Where(x => x.PlateNumber == "")
	//		.Select(x => x.VehicleTypeId)
	//		.ToListAsync(cancellationToken);

	//	return tax.VehicleId == cityId || vehicleCities.Contains(cityId);
	//}


}