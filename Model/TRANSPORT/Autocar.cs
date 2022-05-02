using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Autocar : TransportTerrestre
    {
        private string _typeFuel;
        private string _image;

        public string TypeFuel
        {
            get { return _typeFuel; }
            set
            {
                _typeFuel = value;
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

        public Autocar() : base()
        {
            TypeFuel = "Default";
            Image = "Default";
        }

        public Autocar(string nom, int nbrpassager, float chargeutile, string modele, string typefuel)
            : base(nom, nbrpassager, chargeutile, modele)
        {
            TypeFuel = typefuel;
            Image = IMG_AUTOCAR;
        }

        public override string ToString()
        {
            return base.ToString() + " " + TypeFuel + " " + Image;
        }
    }
}
