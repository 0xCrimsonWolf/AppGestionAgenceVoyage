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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using System.Windows.Media;

namespace AppGestionAgenceVoyage
{
    [XmlInclude(typeof(System.Windows.Media.MatrixTransform))]
    [Serializable]
    public class MainWindowViewModel : INotifyPropertyChanged, ILoginUtility
    {
        [XmlElement("Voyageur")]
        public ObservableCollection<Voyageur> ListeVoyageur { get; set; }
        private Voyageur _voyageur;
        public ObservableCollection<Destination> ListeDestination { get; set; }
        private Destination _destination;

        public ObservableCollection<MoyenDeTransport> ListeTransport { get; set; }
        private MoyenDeTransport _transport;

        public ObservableCollection<Logement> ListeLogement { get; set; }
        private Logement _logement;

        public ObservableCollection<Voyage> ListeVoyage { get; set; }
        private Voyage _voyage;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "LOGIN_PASSWORD";
        const string keyName = userRoot + "\\" + subkey;

        const string userRoot1 = "HKEY_CURRENT_USER";
        const string subkey1 = "OPTIONS_PATH";
        const string keyName1 = userRoot1 + "\\" + subkey1;

        public string img;
        private static string _root;
        private static SolidColorBrush _colorBrush;
        public MainWindowViewModel()
        {
            ListeVoyageur = new ObservableCollection<Voyageur>();
            ListeVoyageur.Add(new Voyageur("Thomas", "Jehasse", "H", "20/04/2002", "thomas.jehasse@gmail.com", "0496.75.68.45"));
            ListeVoyageur.Add(new Voyageur("Frank", "Aroush", "H", "19/04/1996", "frank94@gmail.com", "0497.20.65.57"));
            ListeVoyageur.Add(new Voyageur("Elise", "Beri", "F", "02/05/2010", "mahieuelise@gmail.com", "0499.03.69.50"));
            ListeVoyageur.Add(new Voyageur("Alix", "Hernish", "H", "03/02/1998", "Alix14@gmail.com", "0476.74.68.65"));
            ListeVoyageur.Add(new Voyageur("Clara", "François", "F", "18/12/1982", "cla.ra@hotmail.com", "0477.02.01.58"));
            ListeVoyageur.Add(new Voyageur("Tom", "Tailor", "H", "12/07/2001", "tomtailor9@outlook.com", "0498.08.68.42"));

            ListeDestination = new ObservableCollection<Destination>();
            ListeDestination.Add(new Destination("Afrique", "Maroc", "Marrakech", "Subhumide/aride"));
            ListeDestination.Add(new Destination("Amérique du Nord", "Texas", "Houston", "Subtropical"));
            ListeDestination.Add(new Destination("Europe", "Belgique", "Liège", "Océanique chaud"));
            ListeDestination.Add(new Destination("Europe", "Espagne", "Barcelone", "Méditerranéen"));
            ListeDestination.Add(new Destination("Europe", "Russie", "Moscou", "Continental humide"));
            ListeDestination.Add(new Destination("Asie", "Japon", "Tokyo", "Subtropical humide"));

            ListeTransport = new ObservableCollection<MoyenDeTransport>();
            ListeTransport.Add(new TransportMarin("Balancelle", 500, (float)10.5, "Diesel", "img/boat.png", "WaterBoat", "Ferry"));
            ListeTransport.Add(new TransportAerien("AriPlane", 600, (float)100.7, "Kérozène", "img/plane.png", "PowerPlane", "Airbus789"));
            ListeTransport.Add(new TransportTerrestre("Audi SLine", 6, (float)50.2, "Essence", "img/car.png", "Cabriolet", "Voiture"));
            ListeTransport.Add(new TransportTerrestre("Thalys", 560, (float)900.5, "Electrique", "img/train.png", "TGV", "Train"));
            ListeTransport.Add(new TransportTerrestre("Leonard", 100, (float)50.6, "Diesel", "img/autocar.png", "AutocarV2", "Autocar"));

            ListeLogement = new ObservableCollection<Logement>();
            ListeLogement.Add(new Logement("Hotel", "Ibis", "Rue du Vieux Bac, 17/3", 5, "jacuzzi, sauna, massage"));
            ListeLogement.Add(new Logement("Villa", "Nature&Co", "Rue des amoureux, 8", 15, "3 salles de bains, 2 toilettes, 1 piscine"));
            ListeLogement.Add(new Logement("Hotel", "RHotel's", "Rue Victor Hugo, 45", 2, "5 étoiles"));

            ListeLogement.Add(new Logement("Gîte", "La maison nature", "Rue du peuplier libre, 17", 20, "Vue sur la forêt et sur le lac"));
            ListeLogement.Add(new Logement("Appartement", "Appart's You", "Avenue de l'Oracle, 2 bis", 10, "1 salles de bains, 1 toilette"));
            ListeLogement.Add(new Logement("Villa", "BeautyAir", "Rue de l'espérance, 54", 50, "Endroit posé pour plusieurs, en famille ou avec amis"));

            ListeVoyage = new ObservableCollection<Voyage>();
            ListeVoyage.Add(new Voyage(1, ListeVoyageur[1], DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), DateTime.Now.AddDays(10).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), ListeDestination[2], ListeTransport[3], ListeLogement[0]));
            ListeVoyage.Add(new Voyage(2, ListeVoyageur[2], DateTime.Now.AddYears(2).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), DateTime.Now.AddYears(2).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), ListeDestination[1], ListeTransport[4], ListeLogement[1]));
            ListeVoyage.Add(new Voyage(3, ListeVoyageur[0], DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), DateTime.Now.AddDays(15).ToString("dd/MM/yyyy", CultureInfo.CreateSpecificCulture("fr-FR")), ListeDestination[0], ListeTransport[0], ListeLogement[2]));
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

        public Logement CurrentLogement
        {
            get { return _logement; }
            set
            {
                _logement = value;
                OnPropertyChanged();
            }
        }

        public Voyage CurrentVoyage
        {
            get { return _voyage; }
            set
            {
                _voyage = value;
                OnPropertyChanged();
            }
        }

        public string Root
        {
            get { return _root; }
            set
            {
                _root = value;
            }
        }

        public SolidColorBrush Brushhh
        {
            get { return _colorBrush; }
            set
            {
                _colorBrush = value;
            }
        }

        public void DataBidonnage()
        {
            if ((string)Registry.GetValue(keyName, "admin", null) != "8C6976E5B5410415BDE908BD4DEE15DFB167A9C873FC4BB8A81F6F2AB448A918")
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

        // Méthodes de l'interface ILoginUtility
        #region Méthodes "ILoginUtility"

        public bool LoginCheck(string username, string password)
        {
            ApplicationWindow applicationWindow;
            applicationWindow = new ApplicationWindow(username);
            applicationWindow.Show();

            return true;

            /*if (LoginCheckRegistry(username, password))       // A remettre !
            {
                ApplicationWindow applicationWindow;
                applicationWindow = new ApplicationWindow(username);
                applicationWindow.Show();
                return true;
            }
            else
            {
                MessageBox.Show("Nom d'utilisateur ou mot de passe incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }*/
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

        // Méthodes pour la gestion des clients
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

        // Méthodes pour la gestion des destinations
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

        // Méthodes pour la gestion des transports
        #region Méthodes "Transport"

        public bool AddTransport(string type, string nom, string typefuel, string passagermax, string chargeutile, string compagnie, string modele)
        {
            try
            {
                if (type == "" || nom == "" || typefuel == "")
                {
                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                else
                {
                    switch (type)
                    {
                        case "Voiture":
                        case "Autocar":
                        case "Train":
                            {
                                if (compagnie == "")
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                else
                                {
                                    if (type == "Voiture")
                                        img = "img/car.png";
                                    else if (type == "Autocar")
                                        img = "img/autocar.png";
                                    else if (type == "Train")
                                        img = "img/train.png";
                                    ListeTransport.Add(new TransportTerrestre(nom, Convert.ToInt32(passagermax), (float)Convert.ToDouble(chargeutile), typefuel, img, compagnie, type));
                                }
                                break;
                            }
                        case "Avion":
                            {
                                if (compagnie == "" || modele == "")
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                else
                                    ListeTransport.Add(new TransportAerien(nom, Convert.ToInt32(passagermax), (float)Convert.ToDouble(chargeutile), typefuel, "img/plane.png", compagnie, modele));
                                break;
                            }
                        case "Bateau":
                            {
                                if (compagnie == "" || modele == "")
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                else
                                    ListeTransport.Add(new TransportMarin(nom, Convert.ToInt32(passagermax), (float)Convert.ToDouble(chargeutile), typefuel, "img/boat.png", compagnie, modele));
                                break;
                            }
                    }
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public bool ModifyTransport(MoyenDeTransport transport, int num, string type, string nom, string typefuel, int passagermax, float chargeutile, string compagnie, string modele)
        {
            if (transport == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un moyen de transport", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (type == "" || nom == "" || typefuel == "" || passagermax <= 0 || chargeutile <= 0)
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le transport " + ListeTransport[num].Nom + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    switch (type)
                    {
                        case "Voiture":
                        case "Autocar":
                        case "Train":
                            {
                                TransportTerrestre transportTerrestre = new TransportTerrestre();
                                if (compagnie == "")
                                {
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return false;
                                }
                                else
                                {
                                    transportTerrestre.Nom = nom;
                                    transportTerrestre.TypeFuel = typefuel;
                                    transportTerrestre.NbrPassager = passagermax;
                                    transportTerrestre.ChargeUtile = chargeutile;
                                    transportTerrestre.Modele = modele;
                                    if (type == "Voiture")
                                        img = "img/car.png";
                                    else if (type == "Autocar")
                                        img = "img/autocar.png";
                                    else if (type == "Train")
                                        img = "img/train.png";
                                    transportTerrestre.Image = img;

                                    ListeTransport[num] = transportTerrestre;
                                }
                                break;
                            }
                        case "Avion":
                            {
                                TransportAerien transportAerien = new TransportAerien();
                                if (compagnie == "" || modele == "")
                                {
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return false;
                                }
                                else
                                {
                                    transportAerien.Nom = nom;
                                    transportAerien.TypeFuel = typefuel;
                                    transportAerien.NbrPassager = passagermax;
                                    transportAerien.ChargeUtile = chargeutile;
                                    transportAerien.CompagnieAerienne = compagnie;
                                    transportAerien.ModeleAvion = modele;
                                    transportAerien.Image = "img/plane.png";

                                    ListeTransport[num] = transportAerien;
                                }
                                break;
                            }
                        case "Bateau":
                            {
                                TransportMarin transportMarin = new TransportMarin();
                                if (compagnie == "" || modele == "")
                                {
                                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                                    return false;
                                }
                                else
                                {
                                    transportMarin.Nom = nom;
                                    transportMarin.TypeFuel = typefuel;
                                    transportMarin.NbrPassager = passagermax;
                                    transportMarin.ChargeUtile = chargeutile;
                                    transportMarin.CompagnieMaritime = compagnie;
                                    transportMarin.ModeleBateau = modele;
                                    transportMarin.Image = "img/boat.png";

                                    ListeTransport[num] = transportMarin;
                                }
                                break;
                            }
                    }
                }
                else
                    return false;
            }
            return true;
        }

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

        // Méthodes pour la gestion des logements
        #region Méthodes "Logement"

        public bool AddLogement(string type, string nom, string adressepostale, string nbrpersonnes, string commentary)
        {
            try
            {
                if (type == "" || nom == "" || adressepostale == "")
                {
                    MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }
                else
                {
                    ListeLogement.Add(new Logement(type, nom, adressepostale, Convert.ToInt32(nbrpersonnes), commentary));
                    return true;
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
        }

        public bool ModifyLogement(Logement logement, int num, string type, string nom, string adressepostale, int nbrpersonnes, string commentary)
        {
            if (logement == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un logement", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            if (type == "" || nom == "" || adressepostale == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le logement " + ListeLogement[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeLogement[num].Nom = nom;
                ListeLogement[num].Type = type;
                ListeLogement[num].AdressePostale = adressepostale;
                ListeLogement[num].NbrPersonnes = nbrpersonnes;
                ListeLogement[num].Commentary = commentary;
                return true;
            }
            return false;
        }

        public bool DeleteLogement(Logement logement, int num)
        {
            if (logement == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un logement", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le logement " + ListeLogement[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeLogement.Remove(logement);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                return false;
            }

            return false;
        }

        #endregion

        // Méthodes pour la gestion des voyages
        #region Méthodes "Voyage"

        public bool AddVoyage(Voyageur voyageur, string dateDebut, string dateFin, Destination destination, MoyenDeTransport transport, Logement logement)
        {
            int num = ListeVoyage.Count + 1;

            DateTime debut = DateTime.Parse(dateDebut);
            DateTime fin = DateTime.Parse(dateFin);

            Voyage voyage = new Voyage(num, voyageur, debut.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), fin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), destination, transport, logement);
            ListeVoyage.Add(voyage);

            return true;
        }

        public bool ModifyVoyage(Voyage voyage, int num, Voyageur voyageur, string dateDebut, string dateFin, Destination destination, MoyenDeTransport transport, Logement logement)
        {
            if (voyage == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un logement", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le voyage numero " + ListeVoyage[num].Id + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                Voyage currentVoyage = new Voyage(num+1, voyageur, dateDebut, dateFin, destination, transport, logement);
                ListeVoyage[num] = currentVoyage;

                return true;
            }
            return false;
        }

        public bool DeleteVoyage(Voyage voyage, int num)
        {
            if (voyage == null)
            {
                MessageBox.Show("Vous n'avez pas sélectionné un voyage", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le voyage numéro " + ListeVoyage[num].Id + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeVoyage.Remove(voyage);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                return false;
            }
            return false;
        }

        #endregion

        // Méthodes pour la sérialisation
        #region Méthodes "Enregistrement"
        public bool SaveAsBinary(string root)
        {
            if (MessageBox.Show("Voulez-vous sauvegarder en fichier binaire ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                root = Path.Combine(root, "Test.dat");
                BinaryFormatter binFormat = new BinaryFormatter();
                using (Stream fStream = new FileStream(root, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    binFormat.Serialize(fStream, this);
                }

                MessageBox.Show("Fichier binaire sauvegardé", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

            return true;
        }

        public MainWindowViewModel LoadFromBinary(string filename)
        {
            if (filename != "")
            {
                BinaryFormatter binFormat = new BinaryFormatter();

                using (Stream fstream = File.OpenRead(filename))
                {
                    MainWindowViewModel binImport = (MainWindowViewModel)binFormat.Deserialize(fstream);
                    return binImport;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas sélectionné un dossier à charger", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        public void SaveAsXML(string root)
        {
            root = Path.Combine(root, "Test.xml");
            XmlSerializer xs = new XmlSerializer(typeof(MainWindowViewModel));
            using (StreamWriter wr = new StreamWriter(root))
            {
                xs.Serialize(wr, this);
            }
            MessageBox.Show("Fichier XML sauvegardé", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
        }

        public MainWindowViewModel LoadFromXML(string filename)
        {
            if (filename != "")
            {
                XmlSerializer xs = new XmlSerializer(typeof(MainWindowViewModel));

                using (Stream fstream = File.OpenRead(filename))
                {
                    MainWindowViewModel importXML = (MainWindowViewModel)xs.Deserialize(fstream);
                    return importXML;
                }
            }
            else
            {
                MessageBox.Show("Vous n'avez pas sélectionné un dossier à charger", "Erreur de sélection", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        #endregion

        // Méthodes autres utiles
        #region Méthodes utiles

        public SolidColorBrush OpenRegistry_OptionsPath()
        {
            if (Registry.CurrentUser.OpenSubKey(subkey1) != null)
            {
                Root = Registry.GetValue(keyName1, "DirectoryPath", null).ToString();
                return (SolidColorBrush)new BrushConverter().ConvertFrom(Registry.GetValue(keyName1, "Thème", null).ToString());
            }
            return null;
        }
        #endregion

        [field: NonSerializedAttribute()] public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }
    }
}
