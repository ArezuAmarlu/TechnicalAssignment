using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class ExemptedDateBusiness(IUnitOfWork unitOfWork) : BaseBusiness<ExemptedDate>(unitOfWork, unitOfWork.ExemptedDateRepository!)
{
}