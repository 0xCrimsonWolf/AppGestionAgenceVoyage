﻿using System;
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
            ListeDestination = new ObservableCollection<Destination>();
            ListeTransport = new ObservableCollection<MoyenDeTransport>();
            ListeLogement = new ObservableCollection<Logement>();
            ListeVoyage = new ObservableCollection<Voyage>();
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
            if (LoginCheckRegistry(username, password))       // A remettre !
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
            }
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
                throw new Exception("Erreur d'entrée: Données manquantes.");
            }
            else
            {
                DateTime naiss = DateTime.Parse(datenaissance);

                ListeVoyageur.Add(new Voyageur(prenom, nom, sexe.ToUpper(), naiss.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), email, numtel));
                return true;
            }
        }

        public bool ModifyClient(Voyageur voy, int num, string prenom, string nom, string sexe, string datenaissance, string email, string numtel)
        {
            if (voy == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un client.");
            }

            if (prenom == "" || nom == "" || sexe == "" || datenaissance == "" || email == "" || numtel == "")
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier " + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeVoyageur[num].Nom = nom;
                ListeVoyageur[num].Prenom = prenom;
                ListeVoyageur[num].Sexe = sexe;
                DateTime naissance = DateTime.Parse(datenaissance);
                ListeVoyageur[num].DateNaissance = naissance.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR"));
                ListeVoyageur[num].Email = email;
                ListeVoyageur[num].Numtel = numtel;
                return true;
            }
            throw new WarningException();
        }

        public bool DeleteClient(Voyageur voy, int num)
        {
            if (voy == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un client.");
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer " + ListeVoyageur[num].Prenom + " " + ListeVoyageur[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeVoyageur.Remove(voy);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                throw new WarningException();
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
                throw new Exception("Erreur d'entrée: Données manquantes.");
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
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné une destination.");
            }

            if (continent == "" || country == "" || city == "" || climate == "")
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
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
            throw new WarningException();
        }

        public bool DeleteDestination(Destination dest, int num)
        {
            if (dest == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné une destination.");
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer la destination vers " + ListeDestination[num].City, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeDestination.Remove(dest);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                throw new WarningException();
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
                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
                                else
                                    ListeTransport.Add(new TransportAerien(nom, Convert.ToInt32(passagermax), (float)Convert.ToDouble(chargeutile), typefuel, "img/plane.png", compagnie, modele));
                                break;
                            }
                        case "Bateau":
                            {
                                if (compagnie == "" || modele == "")
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                throw new Exception("Erreur de format: Formatage d'une(des) donnée(s) incorrect.");
            }
        }

        public bool ModifyTransport(MoyenDeTransport transport, int num, string type, string nom, string typefuel, int passagermax, float chargeutile, string compagnie, string modele)
        {
            if (transport == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un transport.");
            }

            if (type == "" || nom == "" || typefuel == "" || passagermax <= 0 || chargeutile <= 0)
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
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
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                                    throw new Exception("Erreur d'entrée: Données manquantes.");
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
                    throw new WarningException();
            }
            return true;
        }

        public bool DeleteTransport(MoyenDeTransport transport, int num)
        {
            if (transport == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un transport.");
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le moyen de transport " + ListeTransport[num].Nom + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeTransport.Remove(transport);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                throw new WarningException();
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
                    throw new Exception("Erreur d'entrée: Données manquantes.");
                }
                else
                {
                    ListeLogement.Add(new Logement(type, nom, adressepostale, Convert.ToInt32(nbrpersonnes), commentary));
                    return true;
                }
            }
            catch (FormatException)
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
            }
        }

        public bool ModifyLogement(Logement logement, int num, string type, string nom, string adressepostale, int nbrpersonnes, string commentary)
        {
            if (logement == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un logement.");
            }

            if (type == "" || nom == "" || adressepostale == "")
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
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
            throw new WarningException();
        }

        public bool DeleteLogement(Logement logement, int num)
        {
            if (logement == null)
            {
                throw new Exception("Erreur de sélection: Vous n'avez pas sélectionné un logement.");
            }

            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer le logement " + ListeLogement[num].Nom, "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                ListeLogement.Remove(logement);
                return true;
            }
            else if (result == MessageBoxResult.No)
            {
                throw new WarningException();
            }

            return false;
        }

        #endregion

        // Méthodes pour la gestion des voyages
        #region Méthodes "Voyage"

        public bool AddVoyage(Voyageur voyageur, string dateDebut, string dateFin, Destination destination, MoyenDeTransport transport, Logement logement, string com)
        {
            if (voyageur == null || dateDebut == "" || dateFin == "" || destination == null || transport == null || logement == null)
            {
                throw new Exception("Erreur d'entrée: Données manquantes.");
            }

            int num = ListeVoyage.Count + 1;

            DateTime debut = DateTime.Parse(dateDebut);
            DateTime fin = DateTime.Parse(dateFin);

            Voyage voyage = new Voyage(num, voyageur, debut.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), fin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), destination, transport, logement, com);
            ListeVoyage.Add(voyage);

            return true;
        }

        public bool ModifyVoyage(Voyage voyage, int num, Voyageur voyageur, string dateDebut, string dateFin, Destination destination, MoyenDeTransport transport, Logement logement, string com)
        {
            MessageBoxResult result = MessageBox.Show("Êtes-vous sûr de vouloir modifier le voyage numero " + ListeVoyage[num].Id + " ?", "Attention !", MessageBoxButton.YesNo, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                DateTime debut = DateTime.Parse(dateDebut);
                DateTime fin = DateTime.Parse(dateFin);
                Voyage currentVoyage = new Voyage(num+1, voyageur, debut.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), fin.ToString("dd/MM/yyyy", System.Globalization.CultureInfo.CreateSpecificCulture("fr-FR")), destination, transport, logement, com);
                ListeVoyage[num] = currentVoyage;

                return true;
            }
            return false;
        }

        public bool DeleteVoyage(Voyage voyage, int num)
        {
            if (voyage == null)
            {
                throw new Exception("Vous n'avez pas sélectionné un voyage");
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
                return true;
            }
            else
                throw new WarningException();
        }

        public MainWindowViewModel LoadFromBinary(string filename)
        {
            if (filename != "")
            {
                BinaryFormatter binFormat = new BinaryFormatter();

                using (Stream fstream = File.OpenRead(filename))
                {
                    MainWindowViewModel binImport = (MainWindowViewModel)binFormat.Deserialize(fstream);
                    MessageBox.Show("Fichier binaire importé", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return binImport;
                }
            }
            else
            {
                throw new Exception("Vous n'avez pas sélectionné un dossier à charger");
            }
        }

        public void SaveAsXML(string root)
        {
            if (MessageBox.Show("Voulez-vous sauvegarder en fichier XML ?", "Attention", MessageBoxButton.YesNo, MessageBoxImage.Exclamation) == MessageBoxResult.Yes)
            {
                root = Path.Combine(root, "Test.xml");
                XmlSerializer xs = new XmlSerializer(typeof(MainWindowViewModel));
                using (StreamWriter wr = new StreamWriter(root))
                {
                    xs.Serialize(wr, this);
                }
                MessageBox.Show("Fichier XML sauvegardé", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
                throw new WarningException();
        }

        public MainWindowViewModel LoadFromXML(string filename)
        {
            if (filename != "")
            {
                XmlSerializer xs = new XmlSerializer(typeof(MainWindowViewModel));

                using (Stream fstream = File.OpenRead(filename))
                {
                    MainWindowViewModel importXML = (MainWindowViewModel)xs.Deserialize(fstream);
                    MessageBox.Show("Fichier XML importé", "Information", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    return importXML;
                }
            }
            else
            {
                throw new Exception("Vous n'avez pas sélectionné un dossier à charger");
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
