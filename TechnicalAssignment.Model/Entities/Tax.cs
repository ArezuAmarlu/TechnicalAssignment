using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class Tax : BaseEntity
{
	#region [Properties]

	public DateOnly Date { get; set; }

	public double Amount { get; set; }

	public int VehicleId { get; set; }

	[ForeignKey(nameof(VehicleId))]
	public Vehicle? Vehicle { get; set; }

	#endregion
}