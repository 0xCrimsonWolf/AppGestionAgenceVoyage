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
    public partial class EnregistrementWindow : Window
    {
        public EnregistrementWindow(string root)
        {
            InitializeComponent();

            TextBoxExportation.Text = root;
        }

        private void Exporter_Click(object sender, RoutedEventArgs e)
        {
            ButtonExporter.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
            ButtonImporter.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
            PanelExporter.Visibility = Visibility.Visible;
            PanelImporter.Visibility = Visibility.Hidden;
        }

        private void Importer_Click(object sender, RoutedEventArgs e)
        {
            ButtonExporter.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53)); 
            ButtonImporter.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
            PanelExporter.Visibility = Visibility.Hidden;
            PanelImporter.Visibility = Visibility.Visible;
        }
    }
}
