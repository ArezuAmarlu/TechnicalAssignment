using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class VehicleTypeBusiness(IUnitOfWork unitOfWork) : BaseBusiness<VehicleType>(unitOfWork, unitOfWork.VehicleTypeRepository!)
{
}