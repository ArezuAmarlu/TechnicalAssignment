using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class Rate : BaseEntity
{
	#region [Properties]

	public TimeOnly StartTime { get; set; }

	public TimeOnly EndTime { get; set; }

	public double Amount { get; set; }

	public int CityId { get; set; }

	[ForeignKey(nameof(CityId))]
	public City? City { get; set; }

	#endregion
}