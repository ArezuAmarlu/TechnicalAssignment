using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class Vehicle : BaseEntity
{
	#region [Properties]

	public string? PlateNumber { get; set; }

	public int VehicleTypeId { get; set; }

	[ForeignKey(nameof(VehicleTypeId))]
	public VehicleType? VehicleType { get; set; }

	#endregion
}