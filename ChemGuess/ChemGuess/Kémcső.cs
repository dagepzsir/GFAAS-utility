using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemGuess
{
    class Kémcső
    {
        public int Id { get; set; }
        public string Eredmény { get; set; }
        public List<Ion> Ionok { get; set; }

        public List<string> HozzáadottReagens { get; set; }
        public int EhhezLettAdva { get; set; }
        public Kémcső(int id, string eredmény, List<Ion> tartionok, string hozzáadott, int ehhez)
        {
            HozzáadottReagens = new List<string>();
            Id = id;
            Eredmény = eredmény;
            Ionok = tartionok;
            EhhezLettAdva = ehhez;
            HozzáadottReagens.Add(hozzáadott);
        }

        public override string ToString()
        {
            string output = string.Format("Id: {0} IdH: {1} Tapasztalat: {2} Reagensek: ", Id, EhhezLettAdva, Eredmény); ;
            HozzáadottReagens.ForEach(item => output += item + " ");
            return output;
        }
    }
}