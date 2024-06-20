using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class ExemptedDate : BaseEntity
{
	#region [Properties]

	public DateOnly Date { get; set; }

	public int CityId { get; set; }

	[ForeignKey(nameof(CityId))]
	public City? City { get; set; }

	#endregion
}