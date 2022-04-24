using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesUtiles
{
    public class Voyageur
    {
        private string _nom;
        private string _prenom;
        private bool _sexe;
        private DateTime _datenaissance;

        public string Nom { get => _nom; set => _nom = value; }
        public string Prenom { get => _prenom; set => _prenom = value; }
        public bool Sexe { get => _sexe; set => _sexe = value; }
        public DateTime Datenaissance { get => _datenaissance; set => _datenaissance = value; }

        public Voyageur()
        {
            _nom = "Debras";
            _prenom = "Tom";
            _sexe = true;
            _datenaissance = new DateTime(2002, 03, 14);
        }

        public int getAge()
        {
            DateTime currentDate = DateTime.Now;
            DateTime naissance = _datenaissance;
            int age;
            
            age = currentDate.Year - naissance.Year;

            return age;
        }
    }
}
