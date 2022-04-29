using ClassesUtiles;
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
        public ApplicationWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

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
        }

        private void ListViewClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _viewModel.CurrentVoyageur = ListViewClient.SelectedItem as ClassesUtiles.Voyageur;
        }

        private void ButtonAjouterClient_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.AddClient(TextBoxPrenom.Text, TextBoxNom.Text, TextBoxSexe.Text, DatePickerDateNaissance.ToString());
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
            }
        }

        private void ButtonSupprimerClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
