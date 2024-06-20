using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TechnicalAssignment.Business.Businesses;
using TechnicalAssignment.Business.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class TaxController(IBaseBusiness<Tax> taxBusiness) : ControllerBase
{
	[HttpGet]
	[HttpHead]
	public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel, CancellationToken cancellationToken) =>
		Ok(await taxBusiness.LoadAllAsync(sieveModel, cancellationToken));
}