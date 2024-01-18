using System.Collections.Generic;
using ABCInvestmentCalc.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace ABCInvestmentCalc.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class InvestmentCalController : ControllerBase
	{
		
		[HttpPost(Name = "GetInvestmentReturn")]
		public InvestmentReturn CalculateInvestmentReturn(List<InvestmentOpt> ListInvestmentOpt, int totalInvestment)
		{
			try
			{  if (totalInvestment > 0)
				{
					var validator = new InvestmentOptValidatior();
					foreach (var invOpt in ListInvestmentOpt)//ListInvestmentOpt)
					{
						var validationResult = validator.Validate(invOpt);

						if (!validationResult.IsValid)
						{
							return new InvestmentReturn(-1, -1);
						}
					}
					var cn = new CalculationController();
					InvestmentReturn objInvOnReturn = cn.CalculateInvestmentReturnAUD(ListInvestmentOpt, totalInvestment);
					if (objInvOnReturn.InvestmentFees > 0)
					{
						
						var result = cn.convertRate(objInvOnReturn.InvestmentFees);
						objInvOnReturn.InvestmentFees = result;
					}
					else
						objInvOnReturn.InvestmentFees = 0;

					return objInvOnReturn;
				}
				else
					return new InvestmentReturn(-1, -1);
			}
			catch (Exception ex)
			{
				
				return new InvestmentReturn(-1,-1);

			}
		}

		//[HttpGet(Name = "GetConvertRate")]
		


	//	[HttpPut(Name = "GetInvestmentReturnAUD")]
	
	}
}
	

