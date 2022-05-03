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
        private MoyenDeTransport _transport;

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
            ListeDestination.Add(new Destination("Afrique", "Maroc", "Marakech", "Chaud"));
            ListeDestination.Add(new Destination("Amérique du Nord", "Texas", "Houston", "Tempéré"));
            ListeDestination.Add(new Destination("Europe", "Belgique", "Liège", "Froid"));

            ListeTransport = new ObservableCollection<MoyenDeTransport>();
            ListeTransport.Add(new TransportMarin("NomDuBateau", 500, (float)10.5, "Diesel", "img/boat.png", "WaterBoat", "Ferry"));
            ListeTransport.Add(new TransportAerien("NomAvion", 600, (float)100.7, "Kérozène", "img/plane.png", "PowerPlane", "Airbus789"));
            ListeTransport.Add(new TransportTerrestre("Audi", 6, (float)50.2, "Essence", "img/car.png", "Cabriolet", "Voiture"));
            ListeTransport.Add(new TransportTerrestre("Thalys", 560, (float)900.5, "Electrique", "img/train.png", "TGV", "Train"));
            ListeTransport.Add(new TransportTerrestre("Leonard", 100, (float)50.6, "Diesel", "img/autocar.png", "AutocarV2", "Autocar"));
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

        public MoyenDeTransport CurrentTransport
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
                key.SetValue("Basile", "8884F3BC95155677F72493E033598A827D1396EB623EE32AB499BC88273AE606");     // Chap123
                key.SetValue("Marie", "F2D81A260DEA8A100DD517984E53C56A7523D96942A834B9CDC249BD4E8C7AA9");      // azerty
                key.SetValue("Kentin", "6CA13D52CA70C883E0F0BB101E425A89E8624DE51DB2D2392593AF6A84118090");     // abc123
                key.SetValue("Bunyamin", "8987E1174CD9077AE12F1D37281889056C1C3F3F3FB00A2D0EE901CA2F017B15");   // bubu456
                key.SetValue("admin", "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918");      // admin
                key.Close();
            }
        }

        #region Méthodes "ILoginUtility"

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

        #endregion

        #region Méthodes "Client"

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

        #endregion

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
                ListeDestination.Add(new Destination(continent, country, city, climate));
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

        #region Méthodes "Transport"

        /*public bool AddTransport(string type, string nom, string typefuel, int passagermax, float chargeutile)
        {
            if (type == "" || nom == "" || typefuel == "" || passagermax <= 0 || chargeutile <= 0)
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                switch (type)
                {
                    case "Voiture":
                }

                
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
        }*/

        public bool DeleteTransport(MoyenDeTransport transport, int num)
        {
            if (transport == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un moyen de transport", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le moyen de transport " + ListeTransport[num].Nom + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeTransport.Remove(transport);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                return false;
            }

            return false;
        }

        public string ShowTypeOfTransport(MoyenDeTransport transport)
        {
            if (transport is TransportAerien)
            {
                return "Avion";
            }
            else if (transport is TransportMarin)
            {
                return "Bateau";
            }
            else if (transport is TransportTerrestre)
            {
                TransportTerrestre transportTerrestre = transport as TransportTerrestre;
                return transportTerrestre.Type;
            }

            return "null";
        }

        public int TYpeOfTransport(MoyenDeTransport transport)
        {
            if (transport is TransportAerien)
            {
                return 1;
            }
            else if (transport is TransportMarin)
            {
                return 2;
            }
            else if (transport is TransportTerrestre)
            {
                return 3;
            }

            return 0;
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
