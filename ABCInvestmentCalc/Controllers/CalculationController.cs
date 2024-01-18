using ABCInvestmentCalc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ABCInvestmentCalc.Controllers
{
	public class CalculationController : Controller
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
		public int convertRate(double intAmount)
		{
			try
			{
				var client = new RestClient("https://api.apilayer.com/");
				var request = new RestRequest("exchangerates_data/convert?to=USD&from=AUD&apikey=4rn8hqxWUNI4t1r2AzaF3x4J9IThrvfs", Method.Get);
				request.AddQueryParameter("amount", intAmount);


				RestResponse response = client.Execute(request);
				var result = 0;
				if (response.Content != null)
				{
					var obj = JObject.Parse(response.Content);
					if (obj != null)
					{
						result = (int)obj.SelectToken("result");
					}

				}
				return result;
			}
			catch (Exception ex)
			{
				return -20;
			}
		}
		public InvestmentReturn CalculateInvestmentReturnAUD(List<InvestmentOpt> ListInvestmentOpt, int totalInvestment)
		{//List<InvestmentOpt> ListInvestmentOpt,int totalInvestment
			try
			{
				double InvestmentOnReturn = 0;
				double Fees = 0;
				double InvAmount = 0;
				string invType = string.Empty;
				//string enumType = string.Empty;
				foreach (var invOpt in ListInvestmentOpt)//ListInvestmentOpt)
				{
					InvAmount = 0;
					InvAmount = totalInvestment * invOpt.InvestmentPerc / 100;
					if (invOpt.InvestmentType != null)
						invType = invOpt.InvestmentType.ToString().ToUpper();

					if (invOpt.InvestmentType != null && invOpt.InvestmentPerc > 0)
					{
						if (invType == InvOpt.Cash.ToString().ToUpper() && invOpt.InvestmentPerc <= 50)
						{
							InvestmentOnReturn += (InvAmount * 8.5 / 100);
							Fees += (InvAmount * 0.5 / 100);
						}
						else if (invType == InvOpt.Cash.ToString().ToUpper() && invOpt.InvestmentPerc > 50)
						{
							InvestmentOnReturn += (InvAmount * 10 / 100);

						}
						else if (invType == InvOpt.Fixed.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 10 / 100);
							Fees += (InvAmount * 1 / 100);
						}
						else if (invType == InvOpt.Shares.ToString().ToUpper() && invOpt.InvestmentPerc <= 70)
						{
							InvestmentOnReturn += (InvAmount * 4.3 / 100);
							Fees += (InvAmount * 2.5 / 100);
						}
						else if (invType == InvOpt.Shares.ToString().ToUpper() && invOpt.InvestmentPerc > 70)
						{
							InvestmentOnReturn += (InvAmount * 6 / 100);
							Fees += (InvAmount * 2.5 / 100);
						}
						else if (invType == InvOpt.ManagedFunds.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 12 / 100);
							Fees += (InvAmount * 0.3 / 100);
						}
						else if (invType == InvOpt.ETFs.ToString().ToUpper() && invOpt.InvestmentPerc <= 40)
						{
							InvestmentOnReturn += (InvAmount * 12.8 / 100);
							Fees += (InvAmount * 2 / 100);
						}
						else if (invType == InvOpt.ETFs.ToString().ToUpper() && invOpt.InvestmentPerc > 40)
						{
							InvestmentOnReturn += (InvAmount * 25 / 100);
							Fees += (InvAmount * 2 / 100);
						}
						else if (invType == InvOpt.Investmentbonds.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 8 / 100);
							Fees += (InvAmount * 0.9 / 100);
						}
						else if (invType == InvOpt.Annuities.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 4 / 100);
							Fees += (InvAmount * 1.4 / 100);
						}
						else if (invType == InvOpt.LICs.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 6 / 100);
							Fees += (InvAmount * 1.3 / 100);
						}
						else if (invType == InvOpt.REITs.ToString().ToUpper())
						{
							InvestmentOnReturn += (InvAmount * 4 / 100);
							Fees += (InvAmount * 2 / 100);
						}
					}
				}
				InvestmentReturn objInvOnReturn = new InvestmentReturn(Convert.ToInt32(Math.Ceiling(totalInvestment + InvestmentOnReturn)), Convert.ToInt32(Math.Ceiling(Fees)));

				return objInvOnReturn;
			}
			catch (Exception ex)
			{
				return new InvestmentReturn(-1, -1);
			}
		}
	}
}
