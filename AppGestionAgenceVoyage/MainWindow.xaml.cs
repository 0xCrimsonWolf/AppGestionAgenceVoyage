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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;

namespace AppGestionAgenceVoyage
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonLogin.Background = new SolidColorBrush(Color.FromRgb(77, 199, 243));
        }

        private void ButtonLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonLogin.Background = new SolidColorBrush(Color.FromRgb(245, 135, 53));
        }
    }
}
