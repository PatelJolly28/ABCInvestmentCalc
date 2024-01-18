using FluentValidation;
using FluentValidation.Validators;

namespace ABCInvestmentCalc.Models
{
	public class InvestmentOptValidatior : AbstractValidator<InvestmentOpt>
	{
		public enum InvOpt
		{
			Cash,
			Fixed,
			Shares,
			ManagedFunds,
			ETFs,
			Investmentbonds,
			Annuities,
			LICs,
			REITs
		}
		public InvestmentOptValidatior()
		{
			RuleFor(p => p.InvestmentType).NotEmpty();
			RuleFor(p => p.InvestmentPerc).NotEmpty();
			RuleFor(p => p.InvestmentPerc).GreaterThan(0);
			RuleFor(x => x.InvestmentType).IsEnumName(typeof(InvOpt), caseSensitive: false);

		}
	}


	
}
