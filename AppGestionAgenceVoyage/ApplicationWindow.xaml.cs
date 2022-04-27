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
    /// <summary>
    /// Logique d'interaction pour ApplicationWindow.xaml
    /// </summary>
    public partial class ApplicationWindow : Window
    {
        public ApplicationWindow()
        {
            InitializeComponent();
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
    }
}
