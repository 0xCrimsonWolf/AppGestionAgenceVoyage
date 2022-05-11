using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class TransportAerien : MoyenDeTransport
    {
        private string _compagnieAerienne;
        private string _modeleAvion;

        public string CompagnieAerienne
        {
            get { return _compagnieAerienne; }
            set
            {
                _compagnieAerienne = value;
            }
        }

        public string ModeleAvion
        {
            get { return _modeleAvion; }
            set
            {
                _modeleAvion = value;
            }
        }

        public TransportAerien() : base()
        {
            CompagnieAerienne = "Default";
            ModeleAvion = "Default";
            Image = "Default";
        }

        public TransportAerien(string nom, int nbrpassager, float chargeutile, string typefuel, string image, string compagnieaerienne, string modeleavion)
            : base (nom, nbrpassager, chargeutile, typefuel, image)
        {
            CompagnieAerienne = compagnieaerienne;
            ModeleAvion = modeleavion;
        }

        public override string ToString()
        {
            return base.ToString() + " " + CompagnieAerienne + " " + ModeleAvion + " " + Image;
        }
    }
}
