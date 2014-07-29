using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemGuess
{
    partial class Játék
    {
        private bool CheckGuessed(string[] input)
        {
            if (input.Length == 2)
            {
                string[] guessdIons = input[1].Split(',');
                int counter = 0;

                foreach (string str in guessdIons)
                    counter += Unkowns.Where(item => item.Sign == str).Count();

                if (counter == Unkowns.Count)
                {
                    won = true;
                    return true;
                }
                else
                {
                    Console.WriteLine("Nem jó!");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("{0}: {1}", "gondol", DatabaseConnection.GetHelp("gondol"));
                return false;
            }
        }
        private void AddReagent(string[] input)
        {
            if (input.Length >= 2)
            {
                string result;
                if (input.Length == 2)
                {
                    result = DatabaseConnection.Result(Unkowns, input[1]);
                    Console.WriteLine(result);
                    kémcsövek.Add(new Kémcső(kémcsövek.Count, result, DatabaseConnection.GetReagentIons(input[1]), input[1], -1));
                    kémcsövek[kémcsövek.Count - 1].Ionok.AddRange(Unkowns);
                }
                else if(input.Length == 3)
                {
                    Kémcső választottKémcső = kémcsövek.Find(item => item.Id == int.Parse(input[1]));

                    választottKémcső.Ionok.AddRange(DatabaseConnection.GetReagentIons(input[2]));
                    választottKémcső.HozzáadottReagens.Add(input[2]);
                    result = DatabaseConnection.Result(választottKémcső.Ionok, input[2]);

                    választottKémcső.Eredmény = result;
                    Console.WriteLine(result);
                }
                else
                    Console.WriteLine("{0}: {1}", "reagens", DatabaseConnection.GetHelp("reagens"));
            }
            else
                Console.WriteLine("{0}: {1}", "reagens", DatabaseConnection.GetHelp("reagens"));
        }

        private void KémcsövekListázása()
        {
            kémcsövek.ForEach(item => Console.WriteLine(item.ToString()));
        }

        private void Help(string[] inputArray)
        {
            if (inputArray.Length == 1)
                DatabaseConnection.GetHelp().ForEach(item => Console.WriteLine(item));
            else
                Console.WriteLine("{0}: {1}", inputArray[1], DatabaseConnection.GetHelp(inputArray[1]));
        }
    }
}
