namespace ABCInvestmentCalc.Models
{
	public class Investment
	{
		public required List<InvestmentOpt> InvestmentOptions { get; set; }
		public int TotalInvestment { get; set; }
	}
}
