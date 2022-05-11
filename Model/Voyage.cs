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
    public class Voyage
    {
        private int _id;
        private Voyageur _voyageur;
        private string _dateDebut;
        private string _dateFin;
        private Destination _destination;
        private MoyenDeTransport _moyenDeTransport;
        private Logement _logement;

        public int Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public Voyageur VoyageurProp
        {
            get { return _voyageur; }
            set
            {
                _voyageur = value;
                OnPropertyChanged();
            }
        }

        public string DateDebut
        {
            get { return _dateDebut; }
            set
            {
                _dateDebut = value;
                OnPropertyChanged();
            }
        }

        public string DateFin
        {
            get { return _dateFin; }
            set
            {
                _dateFin = value;
                OnPropertyChanged();
            }
        }

        public Destination DestinationProp
        {
            get { return _destination; }
            set
            {
                _destination = value;
                OnPropertyChanged();
            }
        }

        public MoyenDeTransport TransportProp
        {
            get { return _moyenDeTransport; }
            set
            {
                _moyenDeTransport = value;
                OnPropertyChanged();
            }
        }

        public Logement LogementProp
        {
            get { return _logement; }
            set
            {
                _logement = value;
                OnPropertyChanged();
            }
        }

        public Voyage()
        {
            Id = -1;
            VoyageurProp = null;
            DateDebut = DateTime.MinValue.ToString();
            DateFin = DateTime.MinValue.ToString();
            DestinationProp = null;
            TransportProp = null;
            LogementProp = null;
        }

        public Voyage(int id, Voyageur voyageur, string debut, string fin, Destination destination, MoyenDeTransport transport, Logement logement)
        {
            Id = id;
            VoyageurProp = voyageur;
            DateDebut = debut;
            DateFin = fin;
            DestinationProp = destination;
            TransportProp = transport;
            LogementProp = logement;
        }

        public override string ToString()
        {
            return "";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

    }
}
