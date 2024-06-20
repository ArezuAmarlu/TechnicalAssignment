using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class CityRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : BaseRepository<City>(context, sieveProcessor)
{ }