using Sieve.Models;

namespace TechnicalAssignment.Common.Helper;

public static class SieveModelValidator
{
	public static SieveModel Validate(this SieveModel sieveModel)
	{
		sieveModel.Page ??= 1;
		sieveModel.PageSize ??= 10;
		if (string.IsNullOrWhiteSpace(sieveModel.Sorts))
			sieveModel.Sorts = "-id";
		if (sieveModel.PageSize > 100) sieveModel.PageSize = 10;
		return sieveModel;
	}
}