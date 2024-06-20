using FluentValidation;
using TechnicalAssignment.Common.ViewModels;

namespace TechnicalAssignment.Common.Validators;

public class TaxValidator : AbstractValidator<TaxViewModel>
{
	public TaxValidator()
	{
		RuleFor(x => x.PlateNumber).NotEmpty().Length(10);
		RuleFor(x => x.CityId).NotEmpty();
	}
}
