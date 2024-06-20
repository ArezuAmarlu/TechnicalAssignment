using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class VehicleBusiness(IUnitOfWork unitOfWork) : BaseBusiness<Vehicle>(unitOfWork, unitOfWork.VehicleRepository!)
{
}