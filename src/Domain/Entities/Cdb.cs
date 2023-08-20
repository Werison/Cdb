using Domain.Constants;

namespace Cdb.Domain.Entities
{
    public class Cdb

    {
        public decimal Cash { get; private set; }
        public int Deadline { get; private set; }
        public Cdb(decimal cash, int deadline)
        {
            this.Cash = cash;
            this.Deadline = deadline;
        }

        public static decimal CalculateGrossIncome(decimal cash,int deadline)
        {

            decimal finalCash = 0;

            for (int i = 0; i < deadline; i++)
            {
                finalCash = cash * (1 + (Constant.CDI * Constant.TB));
                cash = finalCash;
            }

            return Math.Round(finalCash, 2, MidpointRounding.AwayFromZero); 
        }

        public static decimal CalculateLiquidIncome(decimal cash, int deadline)
        {
            // Calculate the tax based on the deadline.
            var taxRate = CalculateTax(deadline);

            // Calculate the gross income considering the initial value and the deadline.
            var grossValue = CalculateGrossIncome(cash, deadline);

            
            var grossProfit = grossValue - cash;

            var netProfit = decimal.Round((grossProfit * (1 - taxRate)),2);

            return cash + netProfit;
        }

        public static decimal CalculateTax(int deadline)
        {

            if (deadline <= 6)
            {
                return 0.225M;
            }
            else if (deadline <= 12)
            {
                return 0.20M;
            }
            else if (deadline <= 24)
            {
                return 0.175M;
            }
            else 
            {
                return 0.15M;
            }

        }


    }
}
