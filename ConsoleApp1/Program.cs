using ConsoleApp1;
using ConsoleApp1.Interfaces;
using System;
using System.Runtime.Intrinsics.X86;

namespace MyApp 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ISimplifiedSlotMachine simplifiedSlotMachine = new SimplifiedSlotMachine();
            simplifiedSlotMachine.Play();
        }
    }
}