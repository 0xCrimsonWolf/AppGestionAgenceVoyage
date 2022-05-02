using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;
using Model;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using System.Globalization;

namespace AppGestionAgenceVoyage
{
    internal class MainWindowViewModel : INotifyPropertyChanged, ILoginUtility
    {
        public ObservableCollection<Voyageur> ListeVoyageur { get; set; }
        private Voyageur _voyageur;
        public ObservableCollection<Destination> ListeDestination { get; set; }
        private Destination _destination;

        public ObservableCollection<MoyenDeTransport> ListeTransport { get; set; }
        private Destination _transport;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "LOGIN_PASSWORD";
        const string keyName = userRoot + "\\" + subkey;
        public MainWindowViewModel()
        {
            ListeVoyageur = new ObservableCollection<Voyageur>();
            ListeVoyageur.Add(new Voyageur("Thomas", "Jehasse", "H", "20/04/2002", "thomas.jehasse@gmail.com", "0496.75.68.45"));
            ListeVoyageur.Add(new Voyageur("Frank", "Niouk", "H", "19/04/1996", "frank94@gmail.com", "0497.20.65.57"));
            ListeVoyageur.Add(new Voyageur("Elise", "Mahieu", "F", "02/05/2010", "mahieuelise@gmail.com", "0499.03.69.50"));

            ListeDestination = new ObservableCollection<Destination>();
            ListeDestination.Add(new Destination("Afrique", "Maroc", "Marakech", "Chaud", "https://flagcdn.com/w20/ma.png"));
            ListeDestination.Add(new Destination("Amérique du Nord", "Texas", "Houston", "Tempéré", "https://flagcdn.com/w20/us-tx.png"));
            ListeDestination.Add(new Destination("Europe", "Belgique", "Liège", "Froid", "https://flagcdn.com/w20/be.png"));

            ListeTransport = new ObservableCollection<MoyenDeTransport>();
            ListeTransport.Add(new TransportMarin("Bateau", 500, (float)10.5, "WaterBoat", "Ferry"));
            ListeTransport.Add(new TransportAerien("Avion", 600, (float)100.7, "PowerPlane", "AirBus978"));
            ListeTransport.Add(new Voiture("Audi", 6, (float)50.2, "CabrioletA3", "Essence", 3));
            ListeTransport.Add(new Train("Thalys", 560, (float)900.5, "TGV"));
            ListeTransport.Add(new Autocar("Leonard", 100, (float)50.6, "R203", "Diesel"));
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

        public Destination CurrentDestination
        {
            get { return _destination; }
            set
            {
                _destination = value;
                OnPropertyChanged();
            }
        }

        public Destination CurrentTransport
        {
            get { return _transport; }
            set
            {
                _transport = value;
                OnPropertyChanged();
            }
        }

        public void DataBidonnage()
        {
            if ((string)Registry.GetValue(keyName, "admin", null) != GetHashSHA256("admin"))
            {
                // Création des RegistryValues (password en sha256)

                RegistryKey key;
                key = Registry.CurrentUser.CreateSubKey("LOGIN_PASSWORD");
                key.SetValue("Marie", "f2d81a260dea8a100dd517984e53c56a7523d96942a834b9cdc249bd4e8c7aa9");      // MDP en clair : azerty
                key.SetValue("Kentin", "6ca13d52ca70c883e0f0bb101e425a89e8624de51db2d2392593af6a84118090");        // MDP en clair : abc123
                key.SetValue("Bunyamin", "8987e1174cd9077ae12f1d37281889056c1c3f3f3fb00a2d0ee901ca2f017b15");     // MDP en clair : bubu456
                key.SetValue("admin", "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918");      // MDP en clair : admin
                key.Close();
            }
        }
        public bool LoginCheck(string username, string password)
        {
            if (LoginCheckRegistry(username, password))
            {
                ApplicationWindow applicationWindow;
                applicationWindow = new ApplicationWindow(username);
                applicationWindow.Show();

                return true;
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            return true;
        }

        public bool LoginCheckRegistry(string username, string password)
        {
            string _password = (string) Registry.GetValue(keyName, username, null);
            string hashPassword = GetHashSHA256(password);

            if (_password == hashPassword)
                return true;
            else 
                return false;
        }

        public string GetHashSHA256(string source)
        {
            SHA256 sHA256 = SHA256.Create();
            byte[] data = Encoding.UTF8.GetBytes(source);
            byte[] hashBytes = sHA256.ComputeHash(data);
            string hash = BitConverter.ToString(hashBytes).Replace("-", String.Empty);

            return hash;
        }

        public bool AddClient(string prenom, string nom, string sexe, string datenaissance, string email, string numtel)
        {
            if (prenom == "" || nom == "" || sexe == "" || datenaissance == "" || email == "" || numtel == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                DateTime naiss = DateTime.Parse(datenaissance);

                // Faire un forçage pour le format du numéro de tel

                ListeVoyageur.Add(new Voyageur(prenom, nom, sexe, naiss.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), email, numtel));
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

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier " + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer " + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
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

        #region Méthodes "Destination"

        public bool AddDestination(string continent, string country, string city, string climate)
        {
            if (continent == "" || country == "" || city == "" || climate == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                ListeDestination.Add(new Destination(continent, country, city, climate, "blbl"));
                return true;
            }
        }

        public bool ModifyDestination(Destination dest, int num, string continent, string country, string city, string climate)
        {
            if (dest == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné une destination", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (continent == "" || country == "" || city == "" || climate == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier la destination vers " + ListeDestination[num].City, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeDestination[num].Continent = continent;
                ListeDestination[num].Country = country;
                ListeDestination[num].City = city;
                ListeDestination[num].Climate = climate;
                return true;
            }
            return false;
        }

        public bool DeleteDestination(Destination dest, int num)
        {
            if (dest == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné une destination", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer la destination vers " + ListeDestination[num].City, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeDestination.Remove(dest);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                return false;
            }

            return false;
        }

        #endregion

        public string BrowseFileDirectory()
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                return openFileDlg.SelectedPath;
            }
            return "null";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
