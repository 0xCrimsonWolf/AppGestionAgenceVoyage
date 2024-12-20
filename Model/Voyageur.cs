﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    public class Voyageur : INotifyPropertyChanged
    {
        private string _nom;
        private string _prenom;
        private string _sexe;
        private string _datenaissance;
        private string _email;
        private string _numtel;

        public string Nom
        {
            get { return _nom; }
            set 
            {
                _nom = value;
                OnPropertyChanged();
            }
        }

        public string Prenom
        {
            get { return _prenom; }
            set 
            {
                _prenom = value;
                OnPropertyChanged();
            }
        }

        public string Sexe
        {
            get { return _sexe; }
            set 
            {
                _sexe = value;
                OnPropertyChanged();
            }
        }

        public string DateNaissance
        {
            get { return _datenaissance; }
            set
            {
                _datenaissance = value;
                OnPropertyChanged();
            }
        }

        public string Email
        {
            get { return _email; }
            set 
            { 
                _email = value;
                OnPropertyChanged();
            }
        }

        public string Numtel
        {
            get { return _numtel; }
            set
            {
                _numtel = value;
                OnPropertyChanged();
            }
        }

        public Voyageur(string prenom, string nom, string sexe, string datenaissance, string email, string numtel)
        { 
            Prenom = prenom;
            Nom = nom;
            Sexe = sexe;
            DateNaissance = datenaissance;
            Email = email;
            Numtel = numtel;
        }

        public Voyageur() : this("Default", "Default", "H", "01/01/2000", "default@gmail.com", "0496.05.66.55")
        { }

        public int getAge()
        {
            DateTime currentDate = DateTime.Now;
            DateTime naissance =  DateTime.Parse(_datenaissance);
            int age;
            
            age = currentDate.Year - naissance.Year;

            return age;
        }

        public override string ToString()
        {
            return Nom + " " + Prenom + " " + Sexe + " " + DateNaissance + " " + Email + " " + Numtel;
        }

        [field: NonSerializedAttribute()]  public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
