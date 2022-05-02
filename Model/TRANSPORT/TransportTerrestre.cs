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
        private string _modele;

        public string Modele
        {
            get { return _modele; }
            set 
            {
                _modele = value;
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

        public TransportTerrestre(string nom, int nbrpassager, float chargeutile, string modele)
            : base(nom, nbrpassager, chargeutile)
        {
            Modele = modele;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }*/

    }
}
