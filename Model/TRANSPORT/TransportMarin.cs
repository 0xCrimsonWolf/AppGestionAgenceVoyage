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
    [Serializable]
    public class TransportMarin : MoyenDeTransport
    {
        private string _compagnieMaritime;
        private string _modeleBateau;

        public string CompagnieMaritime
        {
            get { return _compagnieMaritime; }
            set
            {
                _compagnieMaritime = value;
            }
        }

        public string ModeleBateau
        {
            get { return _modeleBateau; }
            set
            {
                _modeleBateau = value;
            }
        }

        public TransportMarin() : base()
        {
            CompagnieMaritime = "Default";
            ModeleBateau = "Default";
        }

        public TransportMarin(string nom, int nbrpassager, float chargeutile, string typefuel, string image, string compagniemaritime, string modelebateau)
            : base(nom, nbrpassager, chargeutile, typefuel, image)
        {
            CompagnieMaritime = compagniemaritime;
            ModeleBateau= modelebateau;
        }

        public override string ToString()
        {
            return base.ToString() + " " + CompagnieMaritime + " " + ModeleBateau + " " + Image;
        }
    }
}
