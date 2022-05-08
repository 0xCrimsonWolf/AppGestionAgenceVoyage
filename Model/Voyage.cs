using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Voyage
    {
        private int _id;
        private Voyageur _voyageur;
        private DateTime _dateDebut;
        private DateTime _dateFin;
        private Destination _destination;
        private MoyenDeTransport _moyenDeTransport;
        // ...

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

        public DateTime DateDebut
        {
            get { return _dateDebut; }
            set
            {
                _dateDebut = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateFin
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
