using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;
using ClassesUtiles;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace AppGestionAgenceVoyage
{
    internal class MainWindowViewModel : INotifyPropertyChanged, ILoginUtility
    {
        public ObservableCollection<Voyageur> ListeVoyageur { get; set; }
        private Voyageur _voyageur;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "LOGIN_PASSWORD";
        const string keyName = userRoot + "\\" + subkey;
        public MainWindowViewModel()
        {
            ListeVoyageur = new ObservableCollection<Voyageur>();
            ListeVoyageur.Add(new Voyageur("Thomas", "Jehasse", "H", "20/04/2002"));
            ListeVoyageur.Add(new Voyageur());
            ListeVoyageur.Add(new Voyageur());
        }

        public Voyageur CurrentVoyageur
        {
            get { return _voyageur; }
            set
            {
                _voyageur = value;
                OnPropertyChanged();
            }
        }

        public void DataBidonnage()
        {
            // Vérifier si déjà pas créé grâce potentiellement à check si "admin" a bien été créé

            /*RegistryKey key;
            key = Registry.CurrentUser.CreateSubKey("LOGIN_PASSWORD");
            key.SetValue("Marie", "azerty");
            key.SetValue("Kentin", "abc123");
            key.SetValue("Bunyamin", "bubu456");
            key.SetValue("admin", "admin");
            key.Close();*/
        }
        public bool LoginCheck(string username, string password)
        {
            if (LoginCheckRegistry(username, password))
            {
                /*ApplicationWindow applicationWindow;
                applicationWindow = new ApplicationWindow();
                applicationWindow.Show();*/
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return true;
        }

        public bool LoginCheckRegistry(string username, string password)
        {
            string _password;
            _password = (string) Registry.GetValue(keyName, username, null);

            if (password == _password)
                return true;
            else 
                return false;
        }

        public bool AddClient(string prenom, string nom, string sexe, string datenaissance)
        {
            if (prenom == "" || nom == "" || sexe == "" || datenaissance == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                DateTime naiss = DateTime.Parse(datenaissance);
                ListeVoyageur.Add(new Voyageur(prenom, nom, sexe, naiss.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"))));
                return true;
            }
        }

        public bool ModifyClient(Voyageur voy, int num, string prenom, string nom, string sexe, string datenaissance)
        {
            if (voy == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un client", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (prenom == "" || nom == "" || sexe == "" || datenaissance == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier" + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeVoyageur[num].Nom = nom;
                ListeVoyageur[num].Prenom = prenom;
                ListeVoyageur[num].Sexe = sexe;
                DateTime naissance = DateTime.Parse(datenaissance);
                ListeVoyageur[num].DateNaissance = naissance.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                return true;
            }
            
            return false;
        }

        public bool DeleteClient(Voyageur voy, int num)
        {
            if (voy == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un client", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer" + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeVoyageur.Remove(voy);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                return false;
            }

            return false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
