using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesUtiles
{
    public class MoyenDeTransport
    {
        private string _nom;
        private string _type;
        private int _nbrPassager;
        private float _chargeUtile;

        public string Nom { get => _nom; set => _nom = value; }
        public string Type { get => _type; set => _type = value; }
        public int NbrPassager { get => _nbrPassager; set => _nbrPassager = value; }
        public float ChargeUtile { get => _chargeUtile; set => _chargeUtile = value; }

        public MoyenDeTransport()
        {
            _nom = null;
            _type = null;
            _nbrPassager = 0;
            _chargeUtile = 0;
        }
    }
}
