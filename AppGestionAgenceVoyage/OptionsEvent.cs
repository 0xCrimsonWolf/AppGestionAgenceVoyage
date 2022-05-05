using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace AppGestionAgenceVoyage
{
    public class OptionsEvent : EventArgs
    {
        private string _saveRoot;
        private SolidColorBrush _colorBrush;

        public string SaveRoot { get => _saveRoot; set => _saveRoot = value; }
        public SolidColorBrush ColorBrush { get => _colorBrush; set => _colorBrush = value; }

        public OptionsEvent(string _saveRoot, SolidColorBrush brush)
        {
            this.SaveRoot = _saveRoot;
            this.ColorBrush = brush;
        }
    }
}
