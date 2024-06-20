namespace TechnicalAssignment.Model.Entities;

public class VehicleType : BaseEntity
{
	#region [Properties]

	public string? Title { get; set; }

	public IEnumerable<Vehicle>? Vehicle { get; set; }

	public IEnumerable<ExemptedDate>? ExemptedData { get; set; }

	#endregion
}