using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class CityBusiness(IUnitOfWork unitOfWork) : BaseBusiness<City>(unitOfWork, unitOfWork.CityRepository!)
{
}