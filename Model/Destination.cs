using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Model
{
    [Serializable]
    public class Destination : INotifyPropertyChanged
    {
        private string _continent;
        private string _country;
        private string _city;
        private string _climate;
        public string Continent
        {
            get { return _continent; }
            set 
            {
                _continent = value;
                OnPropertyChanged();
            }
        }

        public string Country
        {
            get { return _country; }
            set
            {
                _country = value;
                OnPropertyChanged();
            }
        }

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged();
            }
        }

        public string Climate
        {
            get { return _climate; }
            set
            {
                _climate = value;
                OnPropertyChanged();
            }
        }

        public Destination(string continent, string country, string city, string climate)
        {
            Continent = continent;
            Country = country;
            City = city;
            Climate = climate;
        }

        public Destination() : this("Continent", "Country", "City", "Climat")
        { }

        public override string ToString()
        {
            return Continent + " " + Country + " " + City + " " + Climate;
        }

        [field: NonSerializedAttribute()] public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
