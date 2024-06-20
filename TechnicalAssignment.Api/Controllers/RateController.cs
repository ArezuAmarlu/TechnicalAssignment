using Microsoft.AspNetCore.Mvc;
using Sieve.Models;
using TechnicalAssignment.Business.Contract;
using TechnicalAssignment.Model.Entities;

namespace TechnicalAssignment.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class RateController(IBaseBusiness<Rate> rateBusiness) : ControllerBase
{
	[HttpGet]
	[HttpHead]
	public async Task<IActionResult> Get([FromQuery] SieveModel sieveModel, CancellationToken cancellationToken) =>
		Ok(await rateBusiness.LoadAllAsync(sieveModel, cancellationToken));
}