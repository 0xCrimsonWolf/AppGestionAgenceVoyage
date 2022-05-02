using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransportAerien : MoyenDeTransport
    {
        private string _compagnieAerienne;
        private string _modeleAvion;
        private string _image;

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

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        public TransportAerien() : base()
        {
            CompagnieAerienne = "Default";
            ModeleAvion = "Default";
            Image = "Default";
        }

        public TransportAerien(string nom, int nbrpassager, float chargeutile, string compagnieaerienne, string modeleavion)
            : base (nom, nbrpassager, chargeutile)
        {
            CompagnieAerienne = compagnieaerienne;
            ModeleAvion = modeleavion;
            Image = IMG_PLANE;
        }

        public override string ToString()
        {
            return base.ToString() + " " + CompagnieAerienne + " " + ModeleAvion + " " + Image;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }*/
    }
}
