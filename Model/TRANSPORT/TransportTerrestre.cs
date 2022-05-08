using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransportTerrestre : MoyenDeTransport
    {
        private string _type;
        private string _modele;

        public string Modele
        {
            get { return _modele; }
            set 
            {
                _modele = value;
            }
        }
        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + " " + Modele;
        }

        public TransportTerrestre() : base()
        {
            Modele = "Default";
        }

        public TransportTerrestre(string nom, int nbrpassager, float chargeutile, string typefuel, string image, string modele, string type)
            : base(nom, nbrpassager, chargeutile, typefuel, image)
        {
            Modele = modele;
            Type = type;
        }
    }
}
