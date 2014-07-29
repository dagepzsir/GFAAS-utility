using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChemGuess
{
    public enum IonType
    {
        Anion,
        Kation
    }
    class Ion
    {
        public string Name { get; set; }
        public int Charge { get; set; }
        public string Sign { get; set; }

        public IonType IonType { get; private set; }
        public Ion(string name, string sign, int charge)
        {
            Name = name;
            Charge = charge;
            Sign = sign;

            if (Charge > 0)
                this.IonType = ChemGuess.IonType.Kation;
            else
                this.IonType = ChemGuess.IonType.Anion;

        }
    }
}
