using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class RateBusiness(IUnitOfWork unitOfWork) : BaseBusiness<Rate>(unitOfWork, unitOfWork.RateRepository!)
{
}