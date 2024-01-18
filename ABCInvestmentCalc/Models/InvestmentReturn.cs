namespace ABCInvestmentCalc.Models
{
	public class InvestmentReturn
	{

		public InvestmentReturn(int invReturnAUD, int invFees)
		{
			InvestmentReturnAUD = invReturnAUD;
			InvestmentFees = invFees;
		}
		public int InvestmentReturnAUD { get; set; }

		public int InvestmentFees { get; set; }
	}
}
