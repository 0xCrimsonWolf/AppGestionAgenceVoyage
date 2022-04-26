using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Microsoft.Win32;
using System.Text;
using System.Threading.Tasks;
using ClassesUtiles;

namespace AppGestionAgenceVoyage
{
    internal class MainWindowViewModel : ILoginUtility
    {

        const string userRoot = "HKEY_CURRENT_USER";
        const string subkey = "LOGIN_PASSWORD";
        const string keyName = userRoot + "\\" + subkey;
        public MainWindowViewModel()
        {}

        public void DataBidonnage()
        {
            RegistryKey key;
            key = Registry.CurrentUser.CreateSubKey("LOGIN_PASSWORD");
            key.SetValue("Marie", "azerty");
            key.SetValue("Kentin", "abc123");
            key.SetValue("Bunyamin", "bubu456");
            key.SetValue("admin", "admin");
            key.Close();
        }
        public bool LoginCheck(string username, string password)
        {
            MessageBox.Show("USER : " + username + "\nPASSWORD : " + password + "\n");
            if (LoginCheckRegistry(username, password))
                MessageBox.Show("GG !");

            return true;
        }

        public bool LoginCheckRegistry(string username, string password)
        {
            string _password;
            _password = (string) Registry.GetValue(keyName, username, null);

            if (password == _password)
                return true;
            else 
                return false;
        }

    }
}
