using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TransportMarin : MoyenDeTransport
    {
        private string _compagnieMaritime;
        private string _modeleBateau;
        private string _image;

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

        public string Image
        {
            get { return _image; }
            set
            {
                _image = value;
            }
        }

        public TransportMarin() : base()
        {
            CompagnieMaritime = "Default";
            ModeleBateau = "Default";
            Image = "Default";
        }

        public TransportMarin(string nom, int nbrpassager, float chargeutile, string compagniemaritime, string modelebateau)
            : base (nom, nbrpassager, chargeutile)
        {
            CompagnieMaritime = compagniemaritime;
            ModeleBateau= modelebateau;
            Image = IMG_BATEAU;
        }

        public override string ToString()
        {
            return base.ToString() + " " + CompagnieMaritime + " " + ModeleBateau + " " + Image;
        }

        /*public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }*/
    }
}
