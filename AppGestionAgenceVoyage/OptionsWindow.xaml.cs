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
        public delegate void OptionDelegate(object sender, OptionsEvent e);
        public event OptionDelegate OptionEvent;

        private SolidColorBrush _brush;

        public SolidColorBrush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        public OptionsWindow(string root, SolidColorBrush brush)
        {
            InitializeComponent();

            TextboxFileDirectory.Text = root;       // Permet de garder le root directory

            if (brush != null)
            {
                if (brush.ToString() == ButtonSombre.Background.ToString())
                    CheckBoxSombre.IsChecked = true;
                else
                    CheckBoxClair.IsChecked = true;
            }
            else
                CheckBoxClair.IsChecked = true;
        }

        public OptionsWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog openFileDlg = new System.Windows.Forms.FolderBrowserDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                TextboxFileDirectory.Text = openFileDlg.SelectedPath;
            }
        }

        private void ButtonSombre_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxClair.IsChecked = false;
            CheckBoxSombre.IsChecked = true;
            Brush = (SolidColorBrush)ButtonSombre.Background;
        }

        private void CheckBoxSombre_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxClair.IsChecked = false;
            CheckBoxSombre.IsChecked = true;
            Brush = (SolidColorBrush)ButtonSombre.Background;
        }

        private void ButtonClair_Click(object sender, RoutedEventArgs e)
        {
            CheckBoxSombre.IsChecked = false;
            CheckBoxClair.IsChecked = true;
            Brush = (SolidColorBrush)ButtonClair.Background;
        }

        private void CheckBoxClair_Checked(object sender, RoutedEventArgs e)
        {
            CheckBoxSombre.IsChecked = false;
            CheckBoxClair.IsChecked = true;
            Brush = (SolidColorBrush)ButtonClair.Background;
        }

        private void ButtonOk_Click(object sender, RoutedEventArgs e)
        {
            OptionEvent(this, new OptionsEvent(TextboxFileDirectory.Text, Brush));
            this.Close();
        }

        private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
        {
            OptionEvent(this, new OptionsEvent(TextboxFileDirectory.Text, Brush));
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
