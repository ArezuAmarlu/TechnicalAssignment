using System.ComponentModel.DataAnnotations;

namespace TechnicalAssignment.Model.Entities;

public class City : BaseEntity
{
	#region [Properties]

	[MaxLength(50)]
	public string? Name { get; set; }

	[MaxLength(3)]
	public string? CurrencyCode { get; set; }

	public double MaximumAmountPerDay { get; set; }

	public IEnumerable<Rate>? Rates { get; set; }

	public IEnumerable<ExemptedVehiclePerCity>? ExemptedVehiclePerCity { get; set; }

	public IEnumerable<ExemptedDate>? ExemptedData { get; set; }

	#endregion
}