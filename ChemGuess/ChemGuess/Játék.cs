using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemGuess
{
    partial class Játék
    {
        bool finished = false;
        bool won = false;
        List<Ion> Unkowns;
        public Játék(int rule)
        {
            Console.Write("Add meg a vegyületek számát: ");
            Unkowns = GenerateSample(int.Parse(Console.ReadLine()));
            setRule(rule);
        }

        private void setRule(int rule)
        {
            switch (rule)
            {
                case 0:
                    Console.WriteLine("Anionok száma: {0}\nKationok száma: {1}", Unkowns.Where(item => item.IonType == IonType.Anion).Count(), Unkowns.Where(item => item.IonType == IonType.Kation).Count());
                    break;
                case 1:
                    Unkowns.RemoveAll(item => item.IonType == IonType.Kation);
                    Console.WriteLine("Anionok száma: {0}", Unkowns.Count);
                    break;
                case 2:
                    Unkowns.RemoveAll(item => item.IonType == IonType.Anion);
                    Console.WriteLine("Kationok száma: {0}", Unkowns.Count);
                    break;
            }
        }

        private void fetchDataFromTable(out List<Ion> anionok, out List<Ion> kationok)
        {
            DataTable ionTable = DatabaseConnection.GetTable("Ionok");
            anionok = new List<Ion>();
            kationok = new List<Ion>();
            foreach (DataRow row in ionTable.Rows)
            {
                if (row["Flag"].ToString() == "0")
                {
                    Ion temp = new Ion((string)row["Név"], (string)row["Jel"], (int)row["Töltés"]);
                    if (temp.IonType == IonType.Anion)
                        anionok.Add(temp);
                    else
                        kationok.Add(temp);
                }
            }
        }
        private List<Ion> GenerateSample(int numberOfCompounds)
        {
            List<Ion> anionok = new List<Ion>();
            List<Ion> kationok = new List<Ion>();
            fetchDataFromTable(out anionok, out kationok);

            Random rand = new Random();
            List<Ion> unkownIons = new List<Ion>();
            /*for (int i = 0; i < numberOfCompounds; i++)
            {
                Ion temp1 = kationok[rand.Next(0, kationok.Count)];
                Ion temp2 = anionok[rand.Next(0, anionok.Count)];
                if (unkownIons.Contains(temp1) == false)
                    unkownIons.Add(temp1);
                if (unkownIons.Contains(temp2) == false)
                    unkownIons.Add(temp2);
            }*/

            unkownIons.Add(anionok.Find(item => item.Sign == "Cl"));
            kémcsövek.Add(new Kémcső(-1, "Alap minta", unkownIons, "semmi", -2));
            return unkownIons;
        }

        public void MainLoop()
        {
            while(finished == false)
            {
                Console.Write("Parancs: ");
                finished = HandleInput(Console.ReadLine());
            }
            if (won)
                Console.WriteLine("Gratulálok, nyertél!");
            else
                Console.WriteLine("Sajnos nem sikerült, majd legközelebb!");
        }
        List<Kémcső> kémcsövek = new List<Kémcső>();
        public bool HandleInput(string input)
        {

            string[] inputArray = input.Split(' ');
            switch(inputArray[0])
            {
                case "?":
                    Help(inputArray);
                    return false;
                case "gondol":
                        return CheckGuessed(inputArray);
                case "reagens":
                    AddReagent(inputArray);
                    return false;
                case "kémcsövek":
                    KémcsövekListázása();
                    return false;
                default:
                    Console.WriteLine("Ismeretlen parancs, segítségért írd be a '?' jelet");
                    break;
            }
            return false;
        }

    }
}