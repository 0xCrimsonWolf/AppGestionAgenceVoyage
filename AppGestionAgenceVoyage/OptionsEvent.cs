using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionAgenceVoyage
{
    public class OptionsEvent : EventArgs
    {
        private string _saveRoot;

        public string SaveRoot { get => _saveRoot; set => _saveRoot = value; }

        public OptionsEvent(string _saveRoot)
        {
            this.SaveRoot = _saveRoot;
        }
    }
}
