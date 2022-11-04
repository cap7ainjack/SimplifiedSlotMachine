using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Constants
    {
        internal static char A_Symbol = 'A';
        internal static char B_Symbol = 'B';
        internal static char P_Symbol = 'P';
        internal static char Wildcard_Symbol = '*';

        internal static double A_Coefficient = 0.4;
        internal static double B_Coefficient = 0.6;
        internal static double P_Coefficient = 0.8;
        internal static double Wildcard_Coefficient = 0;

        internal static double A_Probability = 0.45;
        internal static double B_Probability = 0.35;
        internal static double P_Probability = 0.15;
        internal static double Wildcard_Probability = 0.05;

        internal static Dictionary<char, double> _coefficents = new Dictionary<char, double>()
        {
            { A_Symbol, A_Coefficient },
            { B_Symbol, B_Coefficient },
            { P_Symbol, P_Coefficient },
            { Wildcard_Symbol, Wildcard_Coefficient },
        };

        internal static List<char> POSSIBLE_SYMBOLS = new List<char>() { A_Symbol, B_Symbol, P_Symbol, Wildcard_Symbol };


        // Messages
        internal static string StartMessage = "Please deposit money you will be playing with: ";
        internal static string EnterStakeMessage = "Enter stake amount: ";
        internal static string InsufficientAmountMessage = "Insufficient amount!";
        internal static string InvalidAmountMessage = "Invalid amount!";
        internal static string CurrentAmountMessage = "Your current balance is ";
    }
}
