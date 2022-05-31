using System;
using Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class AjouterVoyageWindow : Window
    {
        MainWindowViewModel _viewModel;
        public AjouterVoyageWindow(MainWindowViewModel viewModel)
        {
            InitializeComponent();

            _viewModel = viewModel;
            ComboBoxAddNom.ItemsSource = viewModel.ListeVoyageur;
            ComboBoxAddDestination.ItemsSource = viewModel.ListeDestination;
            ComboBoxAddTransport.ItemsSource = viewModel.ListeTransport;
            ComboBoxAddLogement.ItemsSource = viewModel.ListeLogement;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.AddVoyage(ComboBoxAddNom.SelectedItem as Voyageur, DatePickerDateDebut.Text, DatePickerDateFin.Text,
                                        ComboBoxAddDestination.SelectedItem as Destination,
                                        ComboBoxAddTransport.SelectedItem as MoyenDeTransport,
                                        ComboBoxAddLogement.SelectedItem as Logement,
                                        TextBoxCom.Text);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
