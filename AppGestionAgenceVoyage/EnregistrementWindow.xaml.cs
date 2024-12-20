﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Serialization;

namespace AppGestionAgenceVoyage
{
    public partial class EnregistrementWindow : Window
    {
        MainWindowViewModel _viewModel;

        public delegate void EnregistrementDelegate(object sender, EnregistrementEvent e);
        public event EnregistrementDelegate _enregistrementEvent;
        public EnregistrementWindow(MainWindowViewModel viewModel, string root)
        {
            InitializeComponent();

            _viewModel = viewModel;
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

        private void ButtonImportationOpenFile_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.OpenFileDialog openFileDlg = new System.Windows.Forms.OpenFileDialog();
            var result = openFileDlg.ShowDialog();
            if (result.ToString() != string.Empty)
            {
                TextBoxImportation.Text = openFileDlg.FileName;
            }
        }

        private void ButtonExporterBinaire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.SaveAsBinary(TextBoxExportation.Text);
                this.Close();
            }
            catch (WarningException wex)
            { WarningException warning = wex; }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ButtonImporterBinaire_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindowViewModel binaryData = _viewModel.LoadFromBinary(TextBoxImportation.Text);
                if (binaryData != null)
                {
                    _enregistrementEvent(this, new EnregistrementEvent(binaryData));
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ButtonExporterXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _viewModel.SaveAsXML(TextBoxExportation.Text);
                this.Close();
            }
            catch (WarningException wex)
            { WarningException warning = wex; }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }

        private void ButtonImporterXML_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MainWindowViewModel xmlData = _viewModel.LoadFromXML(TextBoxImportation.Text);
                if (xmlData != null)
                {
                    _enregistrementEvent(this, new EnregistrementEvent(xmlData));
                    this.Close();
                }
            }
            catch (WarningException wex)
            { WarningException warning = wex; }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erreur", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
