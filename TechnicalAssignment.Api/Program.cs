using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Sieve.Services;
using TechnicalAssignment.Business.Businesses;
using TechnicalAssignment.Business.Contract;
using TechnicalAssignment.Common.Validators;
using TechnicalAssignment.DataAccess;
using TechnicalAssignment.DataAccess.Contract;
using TechnicalAssignment.Model.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
	.Services
	.AddEndpointsApiExplorer()
	.AddSwaggerGen()
	.AddScoped<ISieveProcessor, SieveProcessor>()
	.AddScoped<IUnitOfWork, UnitOfWork>()
	.AddValidatorsFromAssemblyContaining<TaxValidator>()
	.AddScoped<IBaseBusiness<Tax>, TaxBusiness>()
	.AddScoped<IBaseBusiness<ExemptedDate>, ExemptedDateBusiness>()
	.AddScoped<IBaseBusiness<Rate>, RateBusiness>()
	.AddScoped<IBaseBusiness<VehicleType>, VehicleTypeBusiness>()
	.AddScoped<IBaseBusiness<Vehicle>, VehicleBusiness>()
	.AddScoped<IBaseBusiness<City>, CityBusiness>()
	.AddDbContextPool<TechnicalAssignmentContext>(option => option.UseInMemoryDatabase("TechnicalAssignment"));

var app = builder.Build();

await using var scope = app.Services.CreateAsyncScope();

await using var context = scope.ServiceProvider.GetRequiredService<TechnicalAssignmentContext>();

await context.Database.EnsureCreatedAsync();

if (app.Environment.IsDevelopment())
	app.UseSwagger()
		.UseSwaggerUI();

app.UseHttpsRedirection()
	.UseAuthorization();

app.MapControllers();

await app.RunAsync();
