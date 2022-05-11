using System;
using Model;
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
    public partial class ModifierVoyageWindow : Window
    {
        MainWindowViewModel _viewModel;
        Voyage _currentVoyage;
        public int _num;

        public ModifierVoyageWindow(MainWindowViewModel viewModel, Voyage voyage, int num)
        {

            InitializeComponent();

            _viewModel = viewModel;
            _currentVoyage = voyage;
            _num = num;
            ComboBoxModifNom.ItemsSource = viewModel.ListeVoyageur;
            ComboBoxModifDestination.ItemsSource = viewModel.ListeDestination;
            ComboBoxModifTransport.ItemsSource = viewModel.ListeTransport;
            ComboBoxModifLogement.ItemsSource = viewModel.ListeLogement;

            ComboBoxModifNom.SelectedItem = voyage.VoyageurProp;
            DatePickerDateModifDebut.Text = voyage.DateDebut.ToString();
            DatePickerDateModifFin.Text = voyage.DateFin.ToString();
            ComboBoxModifDestination.SelectedItem = voyage.DestinationProp;
            ComboBoxModifTransport.SelectedItem = voyage.TransportProp;
            ComboBoxModifLogement.SelectedItem = voyage.LogementProp;

        }

        private void ButtonOkModif_Click(object sender, RoutedEventArgs e)
        {
            if (ComboBoxModifNom.Text == "" || DatePickerDateModifDebut.Text == "" || DatePickerDateModifFin.Text == "" || ComboBoxModifDestination.Text == "" || ComboBoxModifTransport.Text == "")
            {
                MessageBox.Show("Données manquantes...", "Erreur d'entrée", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                _viewModel.ModifyVoyage(_currentVoyage, _num, ComboBoxModifNom.SelectedItem as Voyageur, DatePickerDateModifDebut.Text, DatePickerDateModifFin.Text,
                                        ComboBoxModifDestination.SelectedItem as Destination,
                                        ComboBoxModifTransport.SelectedItem as MoyenDeTransport,
                                        ComboBoxModifLogement.SelectedItem as Logement);
            }
            this.Close();
        }

        private void ButtonAnnulerModif_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
