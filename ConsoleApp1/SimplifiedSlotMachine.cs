

using ConsoleApp1.Interfaces;
using System;

namespace ConsoleApp1
{
    public class SimplifiedSlotMachine : ISimplifiedSlotMachine
    {
        private readonly ISlotMachineProfitHelper _profitHelper;
        private readonly ISpinMachineRowGenerator _spinRowGenerator;

        public SimplifiedSlotMachine()
        {
            this._profitHelper = new SlotMachineProfitHelper();
            this._spinRowGenerator = new SpinMachineRowGenerator();
        }

        /// <summary>
        /// Starts the Simple Slot Machine Game
        /// </summary>
        public void Play()
        {
            decimal initialAmount = 0;

            Console.WriteLine(Constants.StartMessage);
            string amount = Console.ReadLine();

            if (decimal.TryParse(amount, out initialAmount))
            {
                while (initialAmount > 0)
                {
                    Console.WriteLine(Constants.EnterStakeMessage);

                    string stake = Console.ReadLine();
                    Console.WriteLine();
                    decimal stakeAmount = 0;

                    if (decimal.TryParse(stake, out stakeAmount))
                    {
                        if (stakeAmount > initialAmount)
                        {
                            Console.WriteLine(Constants.InsufficientAmountMessage);
                        }
                        else
                        {
                            this.NewSpin(stakeAmount, initialAmount);
                            initialAmount = this.UpdateTotalBalance(stakeAmount, initialAmount);

                            Console.WriteLine(Constants.CurrentAmountMessage + initialAmount);
                        }
                    }
                    else
                    {
                        Console.WriteLine(Constants.InvalidAmountMessage);
                    }
                }
            }
            else
            {
                Console.WriteLine(Constants.InvalidAmountMessage);
            }
        }


        /// <summary>
        /// Generates new spin with for rows, each with 3 symbols.
        /// </summary>
        /// <param name="stakeAmount"></param>
        /// <param name="initialAmount"></param>
        /// <returns></returns>
        private void NewSpin(decimal stakeAmount, decimal initialAmount)
        {
            for (int row = 0; row < 4; row++)
            {
                string currentRowResult = this._spinRowGenerator.GenerateCurrentRowResult();
                Console.WriteLine(currentRowResult);

                this._profitHelper.CalculateRowCoefficent(currentRowResult);
            }
        }

        /// <summary>
        /// Update total balance of player and prints if the last spin generated any profit
        /// </summary>
        /// <param name="stakeAmount"></param>
        /// <param name="initialAmount"></param>
        /// <returns></returns>
        private decimal UpdateTotalBalance(decimal stakeAmount, decimal initialAmount)
        {
            initialAmount -= stakeAmount;

            Console.WriteLine();
            decimal profit = this._profitHelper.CalculateSpinProfit(stakeAmount);

            if (profit > 0)
            {
                Console.WriteLine("You have won: " + profit);
                initialAmount += profit;
            }

            return initialAmount;
        }
    }
}
