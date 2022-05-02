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
    public partial class OptionsWindow : Window
    {
        private MainWindowViewModel _viewModel;

        public delegate void OptionDelegate(object sender, OptionsEvent e);
        public event OptionDelegate OptionEvent;
        public OptionsWindow(string root)
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
            TextboxFileDirectory.Text = root;   // Permet de garder le root
        }

        public OptionsWindow()
        {
            InitializeComponent();
            _viewModel = new MainWindowViewModel();
            DataContext = _viewModel;
        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            TextboxFileDirectory.Text = _viewModel.BrowseFileDirectory();
            OptionEvent(this, new OptionsEvent(TextboxFileDirectory.Text));
        }
    }
}
