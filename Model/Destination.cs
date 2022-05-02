using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Destination : INotifyPropertyChanged
    {
        private string _continent;
        private string _country;
        private string _city;
        private string _climate;
        private string _image;
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
        public string Image
        {
            get { return _image; }
            set
            { 
                _image = value;
                OnPropertyChanged();
            }
        }

        public Destination(string continent, string country, string city, string climate, string image)
        {
            Continent = continent;
            Country = country;
            City = city;
            Climate = climate;
            Image = image;
        }

        public Destination() : this("Continent", "Country", "City", "Climat", "https://flagcdn.com/")
        { }

        public override string ToString()
        {
            return Continent + " " + Country + " " + City + " " + Climate + " " + Image;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
