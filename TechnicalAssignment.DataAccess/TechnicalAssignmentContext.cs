using Microsoft.EntityFrameworkCore;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.DataAccess;

public class TechnicalAssignmentContext(DbContextOptions options) : DbContext(options)
{

	#region [Properties]

	public DbSet<City>? Cities { get; set; }

	public DbSet<ExemptedDate>? ExemptedDatas { get; set; }

	public DbSet<Rate>? Rates { get; set; }

	public DbSet<ExemptedVehiclePerCity>? ExemptedVehiclePerCity { get; set; }

	public DbSet<Tax>? Taxes { get; set; }

	public DbSet<Vehicle>? Vehicles { get; set; }

	public DbSet<VehicleType>? VehicleTypes { get; set; }

	#endregion

	#region [Method(s)]

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<City>().HasData(new List<City>
		{
			new()
			{
				Id = 1,
				Name = "Tokyo",
				CurrencyCode = "JPY",
				MaximumAmountPerDay = 1000
			},
			new ()
			{
				Id = 2,
				Name = "London",
				CurrencyCode = "GBP",
				MaximumAmountPerDay = 10
			},
			new ()
			{
				Id = 3,
				Name = "Gothenburg",
				CurrencyCode = "SEK",
				MaximumAmountPerDay = 60
			}
		});

		modelBuilder.Entity<VehicleType>().HasData(new List<VehicleType>
		{
			new()
			{
				Id = 1,
				Title = "Emergency"
			},
			new()
			{
				Id = 2,
				Title = "Bus"
			},
			new()
			{
				Id = 3,
				Title = "Diplomat"
			},
			new()
			{
				Id = 4,
				Title = "Motorcycle"
			},
			new()
			{
				Id = 5,
				Title = "Military"
			},
			new()
			{
				Id = 6,
				Title = "Foreign"
			},
			new()
			{
				Id = 7,
				Title = "Personal"
			}

		});

		modelBuilder.Entity<ExemptedVehiclePerCity>().HasData(new List<ExemptedVehiclePerCity>
		{
			new()
			{
				Id = 1,
				CityId = 1,
				VehicleTypeId = 1
			},
			new()
			{
				Id = 2,
				CityId = 1,
				VehicleTypeId = 2
			},
			new()
			{
				Id = 3,
				CityId = 1,
				VehicleTypeId = 3
			},
			new()
			{
				Id = 4,
				CityId = 1,
				VehicleTypeId = 4
			},
			new()
			{
				Id = 5,
				CityId = 1,
				VehicleTypeId = 5
			},
			new()
			{
				Id = 6,
				CityId = 1,
				VehicleTypeId = 6
			}
		});

		modelBuilder.Entity<Rate>().HasData(new List<Rate>
		{
			new()
			{
				Id = 1,
				CityId = 3,
				StartTime = new TimeOnly(6,00),
				EndTime = new TimeOnly(6,29),
				Amount = 8
			},
			new()
			{
				Id = 2,
				CityId = 3,
				StartTime = new TimeOnly(6,30),
				EndTime = new TimeOnly(6,59),
				Amount = 13
			},
			new()
			{
				Id = 3,
				CityId = 3,
				StartTime = new TimeOnly(7,00),
				EndTime = new TimeOnly(7,59),
				Amount = 18
			},
			new()
			{
				Id = 4,
				CityId = 3,
				StartTime = new TimeOnly(8,00),
				EndTime = new TimeOnly(8,29),
				Amount = 13
			},
			new()
			{
				Id = 5,
				CityId = 3,
				StartTime = new TimeOnly(8,30),
				EndTime = new TimeOnly(14,59),
				Amount = 8
			},
			new()
			{
				Id = 6,
				CityId = 3,
				StartTime = new TimeOnly(15,00),
				EndTime = new TimeOnly(15,29),
				Amount = 13
			},
			new()
			{
				Id = 7,
				CityId = 3,
				StartTime = new TimeOnly(15,30),
				EndTime = new TimeOnly(16,59),
				Amount = 18
			},
			new()
			{
				Id = 8,
				CityId = 3,
				StartTime = new TimeOnly(17,00),
				EndTime = new TimeOnly(17,59),
				Amount = 13
			},
			new()
			{
				Id = 9,
				CityId = 3,
				StartTime = new TimeOnly(18,00),
				EndTime = new TimeOnly(18,29),
				Amount = 8
			},
			new()
			{
				Id = 10,
				CityId = 3,
				StartTime = new TimeOnly(18,30),
				EndTime = new TimeOnly(5,59),
				Amount = 0
			}
		});

		modelBuilder.Entity<Vehicle>().HasData(new List<Vehicle>
		{
			new()
			{
				Id = 1,
				VehicleTypeId = 7,
				PlateNumber = "535 JJ 75"
			},
			new()
			{
				Id = 2,
				VehicleTypeId = 7,
				PlateNumber = "927 NN 82"
			},
			new()
			{
				Id = 3,
				VehicleTypeId = 3,
				PlateNumber = "137 EE 41"
			}
		});

		modelBuilder.Entity<ExemptedDate>().HasData(CalculateExemptedDates());

		base.OnModelCreating(modelBuilder);
	}

	public static List<ExemptedDate> CalculateExemptedDates()
	{
		var startDate = new DateTime(2013, 1, 1, 0, 0, 0, 0);

		var initialId = 0;

		var list = GetDaysBetween(
				startDate,
				startDate.AddYears(1))
			.Where(d => d.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday or DayOfWeek.Friday || d.Month == 6)
			.Select(x => new ExemptedDate
			{
				CityId = 1,
				Date = new DateOnly(x.Year, x.Month, x.Day)
			})
			.ToList();

		foreach (var item in list)
		{
			item.Id = initialId + 1;
			initialId++;
		}

		return list;

		IEnumerable<DateTime> GetDaysBetween(DateTime start, DateTime end)
		{
			for (var i = start; i < end; i = i.AddDays(1))
				yield return i;
		}
	}

	#endregion
}