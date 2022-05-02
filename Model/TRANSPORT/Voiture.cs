using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Voiture : TransportTerrestre
    {
        private string _typeFuel;
        private int _nbrPortes;
        private string _image;

        public string TypeFuel
        {
            get { return _typeFuel; }
            set
            {
                _typeFuel = value;
            }
        }
        public int NbrPortes
        {
            get { return _nbrPortes; }
            set
            {
                _nbrPortes = value;
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

        public Voiture() : base()
        {
            TypeFuel = "Default";
            NbrPortes = 0;
        }

        public override string ToString()
        {
            return base.ToString() + " " + TypeFuel + " " + NbrPortes + " " + Image;
        }

        public Voiture(string nom, int nbrpassager, float chargeutile, string modele, string typefuel, int nbrportes)
            : base(nom, nbrpassager, chargeutile, modele)
        {
            TypeFuel = typefuel;
            NbrPortes = nbrportes;
            Image = IMG_CAR;
        }
    }
}
