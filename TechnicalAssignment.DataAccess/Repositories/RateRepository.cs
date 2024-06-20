using Sieve.Services;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess.Repositories;

public class RateRepository(TechnicalAssignmentContext context, ISieveProcessor sieveProcessor) : BaseRepository<Rate>(context, sieveProcessor)
{}