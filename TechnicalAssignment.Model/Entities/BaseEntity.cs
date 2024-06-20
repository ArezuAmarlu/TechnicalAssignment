using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechnicalAssignment.Model.Entities;

public class BaseEntity
{
	#region [Constructor]

	public BaseEntity()
	{
		CreatedDate = LastUpdated = DateTime.Now;
		IsDeleted = false;
	}

	#endregion

	#region [Properties]

	[Key]
	[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
	public int Id { get; set; }

	public DateTime CreatedDate { get; set; }

	public DateTime LastUpdated { get; set; }

	public bool IsDeleted { get; set; }

	#endregion
}