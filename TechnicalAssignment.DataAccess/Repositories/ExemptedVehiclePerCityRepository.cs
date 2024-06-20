using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class ExemptedVehiclePerCityRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) :
	BaseRepository<ExemptedVehiclePerCity>(context, sieveProcessor) { }