using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Train : TransportTerrestre
    {
        private string _image;

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        public Train() : base()
        {
            Image = "Default";
        }

        public Train(string nom, int nbrpassager, float chargeutile, string modele)
            : base(nom, nbrpassager, chargeutile, modele)
        {
            Image = IMG_TRAIN;
        }

        public override string ToString()
        {
            return base.ToString() + " " + Image;
        }
    }
}
