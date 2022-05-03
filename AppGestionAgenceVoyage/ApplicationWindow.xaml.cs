using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppGestionAgenceVoyage
{
    public partial class ApplicationWindow : Window
    {
        private MainWindowViewModel _viewModel;
        public static RoutedCommand commandes = new RoutedCommand();

        private static string _root;
        public ApplicationWindow(string pseudoAffich)
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            LabelPrenomBVN.Content = pseudoAffich;
            commandes.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));       // Permet le ctrl + s
        }

        public string Root
        {
            get { return _root; }
            set
            {
                _root = value;
            }
        }

        #region Bouton Bienvenue / Accueil
        private void ButtonBienvenue_Click(object sender, RoutedEventArgs e)
        {
            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;
            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;

            PanelLabelBienvenue.Visibility = Visibility.Visible;
        }

        #endregion

        #region Navigation Bouton "Espace Client"

        private void ButtonNavClient_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavClient.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavClient_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavClient.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavClient_Click(object sender, RoutedEventArgs e)
        {
            PanelLabelClient.Visibility = Visibility.Visible;
            PanelTextClient.Visibility = Visibility.Visible;
            PanelButtonClient.Visibility = Visibility.Visible;
            ListViewClient.Visibility = Visibility.Visible;

            PanelLabelBienvenue.Visibility = Visibility.Hidden;
            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Navigation Bouton "Destination"
        private void ButtonNavDestination_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavDestination.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavDestination_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavDestination.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavDestination_Click(object sender, RoutedEventArgs e)
        {
            PanelLabelDestination.Visibility= Visibility.Visible;
            PanelTextDestination.Visibility= Visibility.Visible;
            PanelButtonDestination.Visibility= Visibility.Visible;
            ListViewDestination.Visibility= Visibility.Visible;

            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;
            PanelLabelBienvenue.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Boutons "Client"

        private void ListViewClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentVoyageur = ListViewClient.SelectedItem as Voyageur;
        }

        private void ButtonAjouterClient_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddClient(TextBoxPrenom.Text, TextBoxNom.Text, TextBoxSexe.Text, DatePickerDateNaissance.ToString(), TextBoxEmail.Text, TextBoxNumtel.Text);
        }

        private void ButtonModifierClient_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.ModifyClient((Voyageur)ListViewClient.SelectedItem, ListViewClient.SelectedIndex, TextBoxPrenom.Text, TextBoxNom.Text, TextBoxSexe.Text, DatePickerDateNaissance.ToString());
            if (result)
            {
                TextBoxPrenom.Clear();
                TextBoxNom.Clear();
                TextBoxSexe.Clear();
                DatePickerDateNaissance.SelectedDate = null;
                TextBoxEmail.Clear();
                TextBoxNumtel.Clear(); 
            }
        }

        private void ButtonSupprimerClient_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteClient((Voyageur)ListViewClient.SelectedItem, ListViewClient.SelectedIndex);
        }

        #endregion

        #region Boutons "Destination"

        private void ListViewDestination_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentDestination = ListViewDestination.SelectedItem as Destination;
        }

        private void ButtonAjouterDestination_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddDestination(TextBoxContinent.Text, TextBoxCountry.Text, TextBoxCity.Text, TextBoxClimate.Text);
        }

        private void ButtonModifierDestination_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.ModifyDestination((Destination)ListViewDestination.SelectedItem, ListViewDestination.SelectedIndex, TextBoxContinent.Text, TextBoxCountry.Text, TextBoxCity.Text, TextBoxClimate.Text);
            if (result)
            {
                TextBoxContinent.SelectedItem = null;
                TextBoxCountry.Clear();
                TextBoxCity.Clear();
                TextBoxClimate.Clear();
            }
        }

        private void ButtonSupprimerDestination_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteDestination((Destination)ListViewDestination.SelectedItem, ListViewDestination.SelectedIndex);
        }

        #endregion

        private void ButtonNavParametres_Click(object sender, RoutedEventArgs e)
        {
            // Obligé de s'abonner ici car dans le MainWindowViewModel ça ne reconnait pas bien ?

            OptionsWindow optionsWindow = new OptionsWindow(Root);
            optionsWindow.OptionEvent += OptionsWindow_OptionEvent;
            optionsWindow.ShowDialog();
        }

        private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)        // CTRL + S
        {
            // Vérifier si il a bien entré un chemin d'accès avant sinon lui ouvrir les paramètres

            OptionsWindow optionsWindow = new OptionsWindow(Root);
            optionsWindow.OptionEvent += OptionsWindow_OptionEvent;
            optionsWindow.ShowDialog();
        }

        private void OptionsWindow_OptionEvent(object sender, OptionsEvent e)
        {
            Root = e.SaveRoot;
        }

        private void ListViewTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentTransport = ListViewTransport.SelectedItem as MoyenDeTransport;
        }

        private void ButtonAjouterTransport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonModifierTransport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSupprimerTransport_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
