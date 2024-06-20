using TechnicalAssignment.Common.ViewModels;
using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Business.Businesses;

public class TaxBusiness(IUnitOfWork unitOfWork) : BaseBusiness<Tax>(unitOfWork, unitOfWork.TaxRepository!)
{
	public async Task<bool> PlaceTax(TaxViewModel taxViewModel, CancellationToken cancellationToken = default)
	{
		var city = await unitOfWork.CityRepository!.LoadByIdAsync(taxViewModel.CityId, cancellationToken);

		if (city is null)
			return false;

		var exemptedVehicleTypesForCurrentCity =
			await unitOfWork.VehicleTypeRepository!.LoadExemptedByCityId(taxViewModel.CityId, cancellationToken);

		var currentVehicle = await unitOfWork.VehicleRepository!.LoadByPlateNumber(taxViewModel.PlateNumber, cancellationToken);

		// Check for Exempted Vehicle Types in Current City
		if (exemptedVehicleTypesForCurrentCity.Select(x => x.Id).Contains(currentVehicle.VehicleTypeId))
			return false;

		// Check for Exempted Dates
		if (await unitOfWork.ExemptedDateRepository!.IsExemptedDateAsync(
			    DateOnly.FromDateTime(taxViewModel.DateTime), taxViewModel.CityId, cancellationToken))
			return false;

		var currentDayAllTaxes =
			await unitOfWork.TaxRepository!.LoadAllTaxPerDayByVehicleIdAsync(currentVehicle.Id,
				DateOnly.FromDateTime(taxViewModel.DateTime), cancellationToken);

		// Check for Current City Maximum Tax Per Day Rule
		if (currentDayAllTaxes?.Sum(x => x.Amount) > city.MaximumAmountPerDay)
			return false;



		return true;
	}
}