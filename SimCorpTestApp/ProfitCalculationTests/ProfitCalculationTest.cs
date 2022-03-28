using SimCorpTestApp;
using System;
using Xunit;

namespace ProfitCalculationTests
{
    public class ProfitCalculationTest
    {
        BussinessInterestRateCalculation bussinessCalculator;
        public ProfitCalculationTest()
        {
            bussinessCalculator = new BussinessInterestRateCalculation();
        }
             

        [Theory]
        [InlineData (1, 10, 12000, 13256.56)]
        [InlineData (5, 3, 15000, 17422.08)]
        [InlineData (5, 2.8, 1000, 1150.09)]
        public void GettingTotalSumOfPersentsTets(uint term, decimal rate, decimal sum, decimal expectedResult)
        {
            //ACT
            var result = bussinessCalculator.GetTotalSumOfPersents(term, rate, sum);
            //ASSERT
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(1, 10, 12000, 13256)]
        [InlineData(0, 0, 0, 1)]
        [InlineData(5, 2.8, 1000, 1150)]
        public void GettingTotalSumOfPersentsFailedTets(uint term, decimal rate, decimal sum, decimal expectedResult)
        {
            //ACT
            var result = bussinessCalculator.GetTotalSumOfPersents(term, rate, sum);
            //ASSERT
            Assert.NotEqual(expectedResult, result);
        }

    }
}
