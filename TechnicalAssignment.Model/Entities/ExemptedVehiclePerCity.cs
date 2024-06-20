using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class ExemptedVehiclePerCity : BaseEntity
{
	public int VehicleTypeId { get; set; }

	[ForeignKey(nameof(VehicleTypeId))]
	public VehicleType? VehicleType { get; set; }

	public int CityId { get; set; }

	[ForeignKey(nameof(CityId))]
	public City? City { get; set; }
}