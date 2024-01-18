using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABCInvestmentCalc.Models;
using Microsoft.AspNetCore.Http;

namespace ABCInvestmentUnitTestt.Mock
{
	internal class CalculateInvestmentReturnMockData
	{
		public static int getTotalInvestment()
		{
			int TotalInvestment = 100000;
			return TotalInvestment;
		}

		public static List<InvestmentOpt> getInvestmentOpt()
		{

			return new List<InvestmentOpt>
			{
				new InvestmentOpt
				{
					InvestmentType = "Cash",//1700-100
					InvestmentPerc = 20
				},
				new InvestmentOpt
				{
					InvestmentType = "Fixed",//3000-300 -104700(400)
					InvestmentPerc = 30
				}
			};
		}
	}
}
