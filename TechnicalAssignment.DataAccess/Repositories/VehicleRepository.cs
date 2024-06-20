using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class VehicleRepository
	(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : BaseRepository<Vehicle>(context,
		sieveProcessor)
{
	public async Task<Vehicle?> LoadByPlateNumber(string plateNumber, CancellationToken cancellationToken = default) =>
		await context.Vehicles!
			.Include(x => x.VehicleType)
			.SingleOrDefaultAsync(x => x.PlateNumber == plateNumber,
			cancellationToken);
}