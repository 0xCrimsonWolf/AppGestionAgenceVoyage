using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Logement
    {
        private string _type;
        private string _nom;
        private string _adressePostale;
        private int _nbrPersonnes;
        private string _commentary;

        public Logement()
        {
            Type = "Default";
            Nom = "Default";
            AdressePostale = "Default";
            NbrPersonnes = 0;
            Commentary = "Default";
        }

        public Logement(string type, string nom, string adressePostale, int nbrpersonnes, string commentary)
        {
            Type = type;
            Nom = nom;
            AdressePostale = adressePostale;
            NbrPersonnes = nbrpersonnes;
            Commentary= commentary;
        }

        public string Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Nom
        {
            get { return _nom; }
            set 
            {
                _nom = value;
                OnPropertyChanged();
            }
        }

        public int NbrPersonnes
        {
            get { return _nbrPersonnes; }
            set 
            {
                _nbrPersonnes = value;
                OnPropertyChanged();
            }
        }

        public string AdressePostale
        {
            get { return _adressePostale; }
            set 
            {
                _adressePostale = value;
                OnPropertyChanged();
            }
        }

        public string Commentary
        {
            get { return _commentary; }
            set
            {
                _commentary = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return Type + " " + Nom + " " + AdressePostale + " " + NbrPersonnes + "" + Commentary;
        }

        [field: NonSerializedAttribute()] public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
