using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [XmlInclude(typeof(TransportMarin))]
    [XmlInclude(typeof(TransportAerien))]
    [XmlInclude(typeof(TransportTerrestre))]
    
    [Serializable]
    public abstract class MoyenDeTransport
    {
        static public string IMG_BATEAU = "img/boat.png";
        static public string IMG_PLANE = "img/plane.png";
        static public string IMG_TRAIN = "img/train.png";
        static public string IMG_CAR = "img/car.png";
        static public string IMG_AUTOCAR = "img/autocar.png";

        private string _nom;
        private string _typeFuel;
        private int _nbrPassager;
        private float _chargeUtile;
        private string _image;

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
            }
        }

        public string TypeFuel
        {
            get { return _typeFuel; }
            set
            {
                _typeFuel = value;
            }
        }

        public int NbrPassager
        {
            get { return _nbrPassager; }
            set
            {
                _nbrPassager = value;
            }
        }

        public float ChargeUtile
        {
            get { return _chargeUtile; }
            set
            {
                _chargeUtile = value;
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

        public MoyenDeTransport()
        {
            Nom = "Default";
            NbrPassager = 0;
            ChargeUtile = 0;
            TypeFuel = "Default";
            Image = "Default";
        }

        public MoyenDeTransport(string nom, int nbrpassager, float chargeutile, string typefuel, string image)
        {
            Nom = nom;
            NbrPassager = nbrpassager;
            ChargeUtile = chargeutile;
            TypeFuel = typefuel;
            Image = image;
        }

        public override string ToString()
        {
            return Nom + " " + NbrPassager + " " + ChargeUtile;
        }
    }
}
