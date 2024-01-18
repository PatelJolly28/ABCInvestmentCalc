using ABCInvestmentCalc.Controllers;
using ABCInvestmentCalc.Models;
using ABCInvestmentUnitTestt.Mock;
using FluentAssertions;
using Moq;

namespace ABCInvestmentUnitTestt.Controller
{
    public class InvestCalControllerTest
    {
        [Fact]
        public void GetCorrectInvestmentCalculationAUD()
        {

             var InvController = new CalculationController();
         int  intTotalInvestment=  CalculateInvestmentReturnMockData.getTotalInvestment();
			List<InvestmentOpt> lstInvestmentOpt = CalculateInvestmentReturnMockData.getInvestmentOpt();

            var investmentReturn = InvController.CalculateInvestmentReturnAUD( lstInvestmentOpt, intTotalInvestment);
            investmentReturn.InvestmentReturnAUD.Should().Be(104700);
			investmentReturn.InvestmentFees.Should().Be(400);

		}
	}
}