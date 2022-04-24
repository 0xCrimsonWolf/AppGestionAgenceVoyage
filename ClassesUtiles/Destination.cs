using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesUtiles
{
    public class Destination
    {
        private string _continent;
        private string _country;
        private string _city;

        public string Continent { get => _continent; set => _continent = value; }
        public string Country { get => _country; set => _country = value; }
        public string City { get => _city; set => _city = value; }

        public Destination()
        {
            _continent = null;
            _country = null;
            _city = null;
        }
    }
}
