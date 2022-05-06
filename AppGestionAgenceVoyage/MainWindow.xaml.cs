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
using Microsoft.Win32;

namespace AppGestionAgenceVoyage
{
    public partial class MainWindow : Window
    {

        private MainWindowViewModel _viewModel;

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "OPTIONS_PATH";
        const string keyName = userRoot + "\\" + subkey;
        public MainWindow()
        {
            InitializeComponent();

            _viewModel = new MainWindowViewModel();
            _viewModel.DataBidonnage();
            if (Registry.CurrentUser.OpenSubKey(subkey) != null)
            {
                SolidColorBrush brush = (SolidColorBrush)new BrushConverter().ConvertFrom(Registry.GetValue(keyName, "Thème", null).ToString());

                this.Background = brush;
                TextboxUsername.Background = brush;
                TextboxPassword.Background = brush;
            }
        }

        private void ButtonLogin_MouseEnter(object sender, MouseEventArgs e)
        {
            ButtonLogin.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(77, 199, 243));
        }

        private void ButtonLogin_MouseLeave(object sender, MouseEventArgs e)
        {
            ButtonLogin.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(245, 135, 53));
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            bool result;
            result = _viewModel.LoginCheck(TextboxUsername.Text, TextboxPassword.Password.ToString());
            if (result)
                this.Close();
        }   
    }
}
