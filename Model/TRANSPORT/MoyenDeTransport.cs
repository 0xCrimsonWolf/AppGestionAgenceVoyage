using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public abstract class MoyenDeTransport
    {
        static public string IMG_BATEAU = "img/boat.png";
        static public string IMG_PLANE = "img/plane.png";
        static public string IMG_TRAIN = "img/train.png";
        static public string IMG_CAR = "img/car.png";
        static public string IMG_AUTOCAR = "img/autocar.png";

        private string _nom;
        private int _nbrPassager;
        private float _chargeUtile;

        public string Nom
        {
            get { return _nom; }
            set
            {
                _nom = value;
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

        public MoyenDeTransport()
        {
            _nom = "Default";
            _nbrPassager = 0;
            _chargeUtile = 0;
        }

        public MoyenDeTransport(string nom, int nbrpassager, float chargeutile)
        {
            Nom = nom;
            NbrPassager = nbrpassager;
            ChargeUtile = chargeutile;
        }

        public override string ToString()
        {
            return Nom + " " + NbrPassager + " " + ChargeUtile;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }*/
    }
}
