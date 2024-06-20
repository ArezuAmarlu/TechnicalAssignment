using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class ExemptedDateRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) :
	BaseRepository<ExemptedDate>(context, sieveProcessor)
{
	public async Task<bool> IsExemptedDateAsync(DateOnly date, int cityId, CancellationToken cancellationToken = default) =>
		await context.ExemptedDatas!.AnyAsync(x => x.CityId == cityId && x.Date == date, cancellationToken);
}