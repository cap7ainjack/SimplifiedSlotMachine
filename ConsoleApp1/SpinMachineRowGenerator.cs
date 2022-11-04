using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApp1.Interfaces;

namespace ConsoleApp1
{
    internal class SpinMachineRowGenerator : ISpinMachineRowGenerator
    {
        /// <summary>
        /// Generates one random spin row with length of 3 characters.
        /// </summary>
        /// <returns></returns>
        public string GenerateCurrentRowResult()
        {
            Random random = new Random();
            string rowResult = string.Empty;

            for (int i = 0; i < 3; i++)
            {
                double randomDouble = random.NextDouble();
                if (0 <= randomDouble && randomDouble < Constants.A_Probability)
                {
                    rowResult += Constants.POSSIBLE_SYMBOLS[0];
                }
                else if (Constants.A_Probability <= randomDouble && randomDouble < Constants.B_Probability + Constants.A_Probability)
                {
                    rowResult += Constants.POSSIBLE_SYMBOLS[1];
                }
                else if (Constants.B_Probability <= randomDouble && randomDouble < Constants.B_Probability + Constants.A_Probability + Constants.P_Probability)
                {
                    rowResult += Constants.POSSIBLE_SYMBOLS[2];
                }
                else
                {
                    rowResult += Constants.POSSIBLE_SYMBOLS[3];
                }
            }

            return rowResult;
        }
    }
}
