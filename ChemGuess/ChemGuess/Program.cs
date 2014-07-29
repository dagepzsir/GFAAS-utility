using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ChemGuess
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            DatabaseConnection.Result(unkownIons, "AgNO3");*/

            Console.Write("Add meg a szabályt (összes = 0, anion = 1, kation = 2): ");
            Játék jatek = new Játék(int.Parse(Console.ReadLine()));

            jatek.MainLoop();
            Console.ReadKey(true);
        }
    }
}