using ConsoleApp1.Interfaces;

namespace ConsoleApp1
{
    internal class SlotMachineProfitHelper : ISlotMachineProfitHelper
    {
        private double totalCoefficent = 0;

        /// <summary>
        /// Calculate coefficent of a single row from spin, row match win condition.
        /// </summary>
        /// <param name="currentRowResult"></param>
        public void CalculateRowCoefficent(string currentRowResult)
        {
            bool win = CheckIfCombinationWin(currentRowResult);
            if (win)
            {
                totalCoefficent += CalculateCoefficent(currentRowResult);
            }
        }

        /// <summary>
        ///  Returns profit of the spin if at least one row match the win condition.
        /// </summary>
        /// <param name="stakeAmount"></param>
        /// <returns></returns>
        public decimal CalculateSpinProfit(decimal stakeAmount)
        {
            if (totalCoefficent > 0)
            {
                decimal profit = CalculateProfit(totalCoefficent, stakeAmount);
                totalCoefficent = 0;

                return profit;
            }

            return 0;
        }

        /// <summary>
        /// Calculate profit by one spin
        /// </summary>
        /// <param name="totalCoefficent"></param> total sum of coefficent of each row included in current spin
        /// <param name="stakeAmount"></param> Stake of the current spin
        /// <returns></returns>
        private decimal CalculateProfit(double totalCoefficent, decimal stakeAmount)
        {
            return stakeAmount * (decimal)totalCoefficent;
        }

        /// <summary>
        /// Calculates coefficent of winnable row
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private double CalculateCoefficent(string result)
        {
            if (!string.IsNullOrEmpty(result) && result.Length == 3)
            {
                double coefficent = Constants._coefficents[result[0]] + Constants._coefficents[result[1]] + Constants._coefficents[result[2]];
                return coefficent;
            }

            return 0;
        }

        /// <summary>
        /// Returns boolen weather the generated single row from a spin is winnable
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool CheckIfCombinationWin(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                result = result.Replace(Constants.Wildcard_Symbol.ToString(), string.Empty);

                if (result.Distinct().Count() == 1)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
