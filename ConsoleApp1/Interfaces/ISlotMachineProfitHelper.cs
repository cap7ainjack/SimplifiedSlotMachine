
namespace ConsoleApp1.Interfaces
{
    internal interface ISlotMachineProfitHelper
    {
        void CalculateRowCoefficent(string currentRowResult);

        decimal CalculateSpinProfit(decimal stakeAmount);
    }
}
