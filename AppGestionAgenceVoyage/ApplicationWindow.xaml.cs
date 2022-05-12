using Microsoft.Win32;
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
        public ApplicationWindow(string pseudoAffich)
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            LabelPrenomBVN.Content = pseudoAffich;
            commandes.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Control));       // Permet le ctrl + s

            SolidColorBrush brush = _viewModel.OpenRegistry_OptionsPath();

            _viewModel.Brushhh = brush;
            this.Background = brush;
            TextBoxChargeUtile.Background = brush;
            TextBoxNomTransport.Background = brush;
            TextBoxCountry.Background = brush;
            ComboBoxTypeTransport.Background = brush;
            ComboBoxContinent.Background = brush;
            TextBoxCity.Background = brush;
            TextBoxClimate.Background = brush;
            TextBoxModele.Background = brush;
            TextBoxCompagnie.Background = brush;
            TextBoxNbrPassager.Background = brush;
            TextBoxNbrTypeFuel.Background = brush;
            TextBoxSexe.Background = brush;
            TextBoxNom.Background = brush;
            TextBoxEmail.Background = brush;
            TextBoxPrenom.Background = brush;
            TextBoxNumtel.Background = brush;
            TextBoxAdrPostale.Background = brush;
            TextBoxNomLogement.Background = brush;
            TextBoxCommentaire.Background = brush;
            TextBoxTypeLogement.Background = brush;
            TextBoxNbrPersonne.Background = brush;

            DataGridVoyages.Background = brush;
            DataGridVoyages.RowBackground = brush;
        }

        // Bouton dans la barre de navigation (full esthétique : background + visibilité des différents panels)

        #region Bouton Bienvenue / Accueil
        private void ButtonBienvenue_Click(object sender, RoutedEventArgs e)
        {
            PanelTextLogement.Visibility = Visibility.Hidden;
            PanelButtonLogement.Visibility = Visibility.Hidden;
            PanelLabelLogement.Visibility = Visibility.Hidden;
            ListViewLogement.Visibility = Visibility.Hidden;

            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;

            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;

            PanelLabelTransport.Visibility = Visibility.Hidden;
            PanelTextTransport.Visibility = Visibility.Hidden;
            PanelButtonTransport.Visibility = Visibility.Hidden;
            ListViewTransport.Visibility = Visibility.Hidden;

            PanelButtonVoyages.Visibility = Visibility.Hidden;
            DataGridVoyages.Visibility = Visibility.Hidden;

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

            PanelLabelTransport.Visibility = Visibility.Hidden;
            PanelTextTransport.Visibility = Visibility.Hidden;
            PanelButtonTransport.Visibility = Visibility.Hidden;
            ListViewTransport.Visibility = Visibility.Hidden;

            PanelTextLogement.Visibility = Visibility.Hidden;
            PanelButtonLogement.Visibility = Visibility.Hidden;
            PanelLabelLogement.Visibility = Visibility.Hidden;
            ListViewLogement.Visibility = Visibility.Hidden;

            PanelButtonVoyages.Visibility = Visibility.Hidden;
            DataGridVoyages.Visibility = Visibility.Hidden;
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

            PanelLabelTransport.Visibility = Visibility.Hidden;
            PanelTextTransport.Visibility = Visibility.Hidden;
            PanelButtonTransport.Visibility = Visibility.Hidden;
            ListViewTransport.Visibility = Visibility.Hidden;

            PanelTextLogement.Visibility = Visibility.Hidden;
            PanelButtonLogement.Visibility = Visibility.Hidden;
            PanelLabelLogement.Visibility = Visibility.Hidden;
            ListViewLogement.Visibility = Visibility.Hidden;

            PanelButtonVoyages.Visibility = Visibility.Hidden;
            DataGridVoyages.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Navigation Bouton "Transport"

        private void ButtonNavTransport_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavTransport.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavTransport_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavTransport.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavTransport_Click(object sender, RoutedEventArgs e)
        {
            PanelLabelTransport.Visibility = Visibility.Visible;
            PanelTextTransport.Visibility = Visibility.Visible;
            PanelButtonTransport.Visibility = Visibility.Visible;
            ListViewTransport.Visibility = Visibility.Visible;

            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;

            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;

            PanelLabelBienvenue.Visibility = Visibility.Hidden;

            PanelButtonVoyages.Visibility = Visibility.Hidden;
            DataGridVoyages.Visibility = Visibility.Hidden;

            PanelTextLogement.Visibility = Visibility.Hidden;
            PanelButtonLogement.Visibility = Visibility.Hidden;
            PanelLabelLogement.Visibility = Visibility.Hidden;
            ListViewLogement.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Navigation Bouton "Logement"

        private void ButtonNavLogement_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavLogement.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavLogement_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavLogement.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavLogement_Click(object sender, RoutedEventArgs e)
        {
            PanelTextLogement.Visibility = Visibility.Visible;
            PanelButtonLogement.Visibility = Visibility.Visible;
            PanelLabelLogement.Visibility = Visibility.Visible;
            ListViewLogement.Visibility= Visibility.Visible;

            PanelLabelTransport.Visibility = Visibility.Hidden;
            PanelTextTransport.Visibility = Visibility.Hidden;
            PanelButtonTransport.Visibility = Visibility.Hidden;
            ListViewTransport.Visibility = Visibility.Hidden;

            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;

            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;

            PanelButtonVoyages.Visibility = Visibility.Hidden;
            DataGridVoyages.Visibility = Visibility.Hidden;

            PanelLabelBienvenue.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Navigation Bouton "Voyages"

        private void ButtonNavVoyages_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavVoyages.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavVoyages_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavVoyages.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavVoyages_Click(object sender, RoutedEventArgs e)
        {

            PanelButtonVoyages.Visibility = Visibility.Visible;
            DataGridVoyages.Visibility = Visibility.Visible;

            PanelTextLogement.Visibility = Visibility.Hidden;
            PanelButtonLogement.Visibility = Visibility.Hidden;
            PanelLabelLogement.Visibility = Visibility.Hidden;
            ListViewLogement.Visibility = Visibility.Hidden;

            PanelLabelTransport.Visibility = Visibility.Hidden;
            PanelTextTransport.Visibility = Visibility.Hidden;
            PanelButtonTransport.Visibility = Visibility.Hidden;
            ListViewTransport.Visibility = Visibility.Hidden;

            PanelLabelDestination.Visibility = Visibility.Hidden;
            PanelTextDestination.Visibility = Visibility.Hidden;
            PanelButtonDestination.Visibility = Visibility.Hidden;
            ListViewDestination.Visibility = Visibility.Hidden;

            PanelLabelClient.Visibility = Visibility.Hidden;
            PanelTextClient.Visibility = Visibility.Hidden;
            PanelButtonClient.Visibility = Visibility.Hidden;
            ListViewClient.Visibility = Visibility.Hidden;

            PanelLabelBienvenue.Visibility = Visibility.Hidden;
        }

        #endregion

        #region Navigation Bouton "Enregistrement"

        private void ButtonNavEnregistrement_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavEnregistrement.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavEnregistrement_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavEnregistrement.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        #endregion

        // Méthodes utiles pour les différents boutons 

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
            _viewModel.AddDestination(ComboBoxContinent.Text, TextBoxCountry.Text, TextBoxCity.Text, TextBoxClimate.Text);
        }

        private void ButtonModifierDestination_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.ModifyDestination((Destination)ListViewDestination.SelectedItem, ListViewDestination.SelectedIndex, ComboBoxContinent.Text, TextBoxCountry.Text, TextBoxCity.Text, TextBoxClimate.Text);
            if (result)
            {
                ComboBoxContinent.SelectedItem = null;
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

        #region Boutons "Transport"

        private void ListViewTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentTransport = ListViewTransport.SelectedItem as MoyenDeTransport;
            ComboBoxTypeTransport.Text = _viewModel.ShowTypeOfTransport(ListViewTransport.SelectedItem as MoyenDeTransport);

            switch (_viewModel.TYpeOfTransport(ListViewTransport.SelectedItem as MoyenDeTransport))
            {
                case 1:     // Adapte le format pour le formulaire de l'Avion
                    {
                        ComboBoxTypeTransport.IsEnabled = false;
                        TransportAerien transportAerien = ListViewTransport.SelectedItem as TransportAerien;
                        PanelButtonTransport.Margin = new Thickness(0, 0, 133, -60);
                        LabelCompagnie.Content = "Compagnie";
                        LabelCompagnie.Visibility = Visibility.Visible;
                        LabelModele.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Text = transportAerien.CompagnieAerienne;
                        TextBoxModele.Visibility = Visibility.Visible;
                        TextBoxModele.Text = transportAerien.ModeleAvion;

                        break;
                    }
                case 2:     // Adapte le format pour le formulaire du Bateau
                    {
                        ComboBoxTypeTransport.IsEnabled = false;
                        TransportMarin transportMarin = ListViewTransport.SelectedItem as TransportMarin;
                        PanelButtonTransport.Margin = new Thickness(0, 0, 133, -60);
                        LabelCompagnie.Content = "Compagnie";
                        LabelCompagnie.Visibility = Visibility.Visible;
                        LabelModele.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Text = transportMarin.CompagnieMaritime;
                        TextBoxModele.Visibility = Visibility.Visible;
                        TextBoxModele.Text = transportMarin.ModeleBateau;

                        break;
                    }
                case 3:     // Adapte le format pour le formulaire des transports Terrestre
                    {
                        ComboBoxTypeTransport.IsEnabled = false;
                        TransportTerrestre transportTerrestre = ListViewTransport.SelectedItem as TransportTerrestre;
                        PanelButtonTransport.Margin = new Thickness(0, 0, 133, 0);
                        LabelModele.Visibility = Visibility.Hidden;
                        TextBoxModele.Visibility = Visibility.Hidden;
                        LabelCompagnie.Content = "Modèle";
                        LabelCompagnie.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Visibility = Visibility.Visible;
                        TextBoxCompagnie.Text = transportTerrestre.Modele;

                        break;
                    }
            }
        }

        private void ButtonAjouterTransport_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddTransport(ComboBoxTypeTransport.Text, TextBoxNomTransport.Text, TextBoxNbrTypeFuel.Text, TextBoxNbrPassager.Text, TextBoxChargeUtile.Text, TextBoxCompagnie.Text, TextBoxModele.Text);
        }

        private void ButtonModifierTransport_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.ModifyTransport((MoyenDeTransport)ListViewTransport.SelectedItem, ListViewTransport.SelectedIndex, ComboBoxTypeTransport.Text, TextBoxNomTransport.Text, TextBoxNbrTypeFuel.Text, Convert.ToInt32(TextBoxNbrPassager.Text), (float)Convert.ToDouble(TextBoxChargeUtile.Text), TextBoxCompagnie.Text, TextBoxModele.Text);
            if (result)
            {
                ComboBoxTypeTransport.IsEnabled = true;
                TextBoxCompagnie.Clear();
                TextBoxModele.Clear();
            }
        }

        private void ButtonSupprimerTransport_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.DeleteTransport(ListViewTransport.SelectedItem as MoyenDeTransport, ListViewTransport.SelectedIndex);
            if (result)
            {
                ComboBoxTypeTransport.IsEnabled = true;
                TextBoxCompagnie.Clear();
                TextBoxModele.Clear();
            }
        }

        private void ComboBoxTypeTransport_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Adapte le format pour le formulaire des transports (sans avoir cliqué dessus mais en ayant sélectionné par exemple "voiture" dans la combobox)

            if (ListViewTransport.SelectedItem == null)
            {
                switch (Convert.ToString(ComboBoxTypeTransport.SelectedItem))
                {
                    case "System.Windows.Controls.ComboBoxItem: Voiture":
                    case "System.Windows.Controls.ComboBoxItem: Autocar":
                    case "System.Windows.Controls.ComboBoxItem: Train":
                        {
                            PanelButtonTransport.Margin = new Thickness(0, 0, 133, 0);
                            LabelModele.Visibility = Visibility.Hidden;
                            TextBoxModele.Visibility = Visibility.Hidden;
                            LabelCompagnie.Content = "Modèle";
                            LabelCompagnie.Visibility = Visibility.Visible;
                            TextBoxCompagnie.Visibility = Visibility.Visible;
                            break;
                        }
                    case "System.Windows.Controls.ComboBoxItem: Avion":
                        {
                            PanelButtonTransport.Margin = new Thickness(0, 0, 133, -60);
                            LabelCompagnie.Content = "Compagnie";
                            LabelCompagnie.Visibility = Visibility.Visible;
                            LabelModele.Visibility = Visibility.Visible;
                            TextBoxCompagnie.Visibility = Visibility.Visible;
                            TextBoxModele.Visibility = Visibility.Visible;
                            break;
                        }
                    case "System.Windows.Controls.ComboBoxItem: Bateau":
                        {
                            PanelButtonTransport.Margin = new Thickness(0, 0, 133, -60);
                            LabelCompagnie.Content = "Compagnie";
                            LabelCompagnie.Visibility = Visibility.Visible;
                            LabelModele.Visibility = Visibility.Visible;
                            TextBoxCompagnie.Visibility = Visibility.Visible;
                            TextBoxModele.Visibility = Visibility.Visible;
                            break;
                        }
                }
            }
        }

        private void ListViewTransport_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            ComboBoxTypeTransport.IsEnabled = true;
            TextBoxCompagnie.Clear();
            TextBoxModele.Clear();
            ListViewTransport.SelectedItems.Clear();
        }

        #endregion

        #region Boutons "Logement"

        private void ListViewLogement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentLogement = ListViewLogement.SelectedItem as Logement;
        }

        private void ButtonAjouterLogement_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddLogement(TextBoxTypeLogement.Text, TextBoxNomLogement.Text, TextBoxAdrPostale.Text, TextBoxNbrPersonne.Text, TextBoxCommentaire.Text);
        }

        private void ButtonModifierLogement_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.ModifyLogement((Logement)ListViewLogement.SelectedItem, ListViewLogement.SelectedIndex, TextBoxTypeLogement.Text, TextBoxNomLogement.Text, TextBoxAdrPostale.Text, Convert.ToInt32(TextBoxNbrPersonne.Text), TextBoxCommentaire.Text);
            if (result)
            {
                TextBoxTypeLogement.Clear();
                TextBoxNomLogement.Clear();
                TextBoxAdrPostale.Clear();
                TextBoxNbrPersonne.Clear();
                TextBoxCommentaire.Clear();
            }
        }

        private void ButtonSupprimerLogement_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteLogement((Logement)ListViewLogement.SelectedItem, ListViewLogement.SelectedIndex);
        }

        #endregion

        #region Boutons "Voyages"

        private void ButtonAjouterVoyage_Click(object sender, RoutedEventArgs e)
        {
            AjouterVoyageWindow ajouterVoyageWindow = new AjouterVoyageWindow(_viewModel);
            ajouterVoyageWindow.ShowDialog();
        }

        private void ButtonModifierVoyage_Click(object sender, RoutedEventArgs e)
        {
            ModifierVoyageWindow modifierVoyageWindow = new ModifierVoyageWindow(_viewModel, DataGridVoyages.SelectedItem as Voyage, DataGridVoyages.SelectedIndex);
            modifierVoyageWindow.ShowDialog();
        }

        private void ButtonSupprimerVoyage_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.DeleteVoyage(DataGridVoyages.SelectedItem as Voyage, DataGridVoyages.SelectedIndex);
        }

        #endregion

        #region Boutons "Paramètres"

        private void ButtonNavParametres_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonNavParametres.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonNavParametres_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonNavParametres.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }

        private void ButtonNavParametres_Click(object sender, RoutedEventArgs e)
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.OptionEvent += OptionsWindow_OptionEvent;
            optionsWindow.ShowDialog();
        }

        private void MyCommandExecuted(object sender, ExecutedRoutedEventArgs e)        // CTRL + S : Ouvre la page d'enregistrement
        {
            if (_viewModel.Root == "")
            {
                OptionsWindow optionsWindow = new OptionsWindow();
                optionsWindow.OptionEvent += OptionsWindow_OptionEvent;
                optionsWindow.ShowDialog();
            }
            else
            {
                EnregistrementWindow enregistrementWindow = new EnregistrementWindow(_viewModel, _viewModel.Root);
                enregistrementWindow._enregistrementEvent += EnregistrementWindow_EnregistrementEvent;
                enregistrementWindow.ShowDialog();
            }
        }

        private void OptionsWindow_OptionEvent(object sender, OptionsEvent e)
        {
            _viewModel.Root = e.SaveRoot;
            _viewModel.Brushhh = e.ColorBrush;
            this.Background = e.ColorBrush;

            TextBoxChargeUtile.Background = e.ColorBrush;
            TextBoxNomTransport.Background = e.ColorBrush;
            TextBoxCountry.Background = e.ColorBrush;
            ComboBoxTypeTransport.Background = e.ColorBrush;
            ComboBoxContinent.Background = e.ColorBrush;
            TextBoxCity.Background = e.ColorBrush;
            TextBoxClimate.Background = e.ColorBrush;
            TextBoxModele.Background = e.ColorBrush;
            TextBoxCompagnie.Background = e.ColorBrush;
            TextBoxNbrPassager.Background = e.ColorBrush;
            TextBoxNbrTypeFuel.Background = e.ColorBrush;
            TextBoxSexe.Background = e.ColorBrush;
            TextBoxNom.Background = e.ColorBrush;
            TextBoxEmail.Background = e.ColorBrush;
            TextBoxPrenom.Background = e.ColorBrush;
            TextBoxNumtel.Background = e.ColorBrush;
            TextBoxAdrPostale.Background = e.ColorBrush;
            TextBoxNomLogement.Background = e.ColorBrush;
            TextBoxCommentaire.Background = e.ColorBrush;
            TextBoxTypeLogement.Background = e.ColorBrush;
            TextBoxNbrPersonne.Background = e.ColorBrush;

            DataGridVoyages.Background = e.ColorBrush;
            DataGridVoyages.RowBackground = e.ColorBrush;
        }

        #endregion

        #region Boutons "Enregistrement"

        private void ButtonNavEnregistrement_Click(object sender, RoutedEventArgs e)
        {
            EnregistrementWindow enregistrementWindow = new EnregistrementWindow(_viewModel, _viewModel.Root);
            enregistrementWindow._enregistrementEvent += EnregistrementWindow_EnregistrementEvent;
            enregistrementWindow.ShowDialog();
        }

        private void EnregistrementWindow_EnregistrementEvent(object sender, EnregistrementEvent e)
        {
            this._viewModel.ListeVoyageur.Clear();
            for (int i = 0; i < e.ViewModel.ListeVoyageur.Count; i++)
            {
                this._viewModel.ListeVoyageur.Add(e.ViewModel.ListeVoyageur[i]);
            }
            this._viewModel.ListeDestination.Clear();
            for (int i = 0; i < e.ViewModel.ListeDestination.Count; i++)
            {
                this._viewModel.ListeDestination.Add(e.ViewModel.ListeDestination[i]);
            }
            this._viewModel.ListeLogement.Clear();
            for (int i = 0; i < e.ViewModel.ListeLogement.Count; i++)
            {
                this._viewModel.ListeLogement.Add(e.ViewModel.ListeLogement[i]);
            }
            this._viewModel.ListeTransport.Clear();
            for (int i = 0; i < e.ViewModel.ListeTransport.Count; i++)
            {
                this._viewModel.ListeTransport.Add(e.ViewModel.ListeTransport[i]);
            }
            this._viewModel.ListeVoyage.Clear();
            for (int i = 0; i < e.ViewModel.ListeVoyage.Count; i++)
            {
                this._viewModel.ListeVoyage.Add(e.ViewModel.ListeVoyage[i]);
            }
        }

        #endregion

    }
}