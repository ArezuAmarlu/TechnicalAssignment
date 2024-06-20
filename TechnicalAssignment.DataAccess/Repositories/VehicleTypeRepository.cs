using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class VehicleTypeRepository
	(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : BaseRepository<VehicleType>(context,
		sieveProcessor)
{
	public async Task<List<VehicleType?>> LoadExemptedByCityId(int cityId,
		CancellationToken cancellationToken = default) =>
		await context.ExemptedVehiclePerCity!.Where(x => x.CityId == cityId)
			.Include(x => x.VehicleType)
			.Select(x => x.VehicleType)
			.ToListAsync(cancellationToken);
}