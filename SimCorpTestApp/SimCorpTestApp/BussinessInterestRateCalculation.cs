using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimCorpTestApp
{
    public class BussinessInterestRateCalculation
    {
      
        private readonly uint paimentFrequency = 12;
        private const int percentConstant = 100;


        public decimal GetTotalSumOfPersents(uint term, decimal rate, decimal sum)
        {
            decimal rateForFormula = rate / percentConstant;
            
            var res = sum * (decimal)Math.Pow(decimal.ToDouble(1 + rateForFormula / paimentFrequency), term * paimentFrequency); ;
            res = Math.Round(res, 2);
            return res;
        }


        public decimal GetMonthSumOfPaiment(uint term, decimal rate, decimal sum)
        {
            return GetTotalSumOfPersents(term, rate, sum) / GetNumberOfCompilationPeriod(term, paimentFrequency);
        }

        public uint GetNumberOfCompilationPeriod(uint term, uint paimentFrequency)
        {
            return term * paimentFrequency;
        }

    }
}
