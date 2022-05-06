using Microsoft.Win32;
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

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "OPTIONS_PATH";
        const string keyName = userRoot + "\\" + subkey;

        public SolidColorBrush Brush
        {
            get { return _brush; }
            set { _brush = value; }
        }

        public OptionsWindow()
        {
            InitializeComponent();

            if (Registry.CurrentUser.OpenSubKey("OPTIONS_PATH") == null)
            {
                CheckBoxClair.IsChecked = true;
            }
            else
            {
                TextboxFileDirectory.Text = (string)Registry.GetValue(keyName, "DirectoryPath", null);
                if (ButtonSombre.Background.ToString() == Registry.GetValue(keyName, "Thème", null).ToString())
                {
                    CheckBoxSombre.IsChecked = true;
                }
                else
                    CheckBoxClair.IsChecked = true;
            }
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

            if (Registry.CurrentUser.OpenSubKey("OPTIONS_PATH") == null)
            {
                RegistryKey key;
                key = Registry.CurrentUser.CreateSubKey("OPTIONS_PATH");
                key.SetValue("DirectoryPath", TextboxFileDirectory.Text);
                key.SetValue("Thème", Brush.ToString());
                key.Close();
            }
            else
            {
                RegistryKey key;
                key = Registry.CurrentUser.OpenSubKey("OPTIONS_PATH", true);
                key.SetValue("DirectoryPath", TextboxFileDirectory.Text);
                if (Brush.ToString() != null)
                    key.SetValue("Thème", Brush.ToString());
                key.Close();
            }
            this.Close();
        }

        private void ButtonAppliquer_Click(object sender, RoutedEventArgs e)
        {
            OptionEvent(this, new OptionsEvent(TextboxFileDirectory.Text, Brush));

            if (Registry.CurrentUser.OpenSubKey("OPTIONS_PATH") == null)
            {
                RegistryKey key;
                key = Registry.CurrentUser.CreateSubKey("OPTIONS_PATH", RegistryKeyPermissionCheck.ReadWriteSubTree);
                key.SetValue("DirectoryPath", TextboxFileDirectory.Text);
                key.SetValue("Thème", Brush.ToString());
                key.Close();
            }
            else
            {
                RegistryKey key;
                key = Registry.CurrentUser.OpenSubKey("OPTIONS_PATH", true);
                key.SetValue("DirectoryPath", TextboxFileDirectory.Text);
                if (Brush.ToString() != null)
                    key.SetValue("Thème", Brush.ToString());
                key.Close();
            }
        }

        private void ButtonAnnuler_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
