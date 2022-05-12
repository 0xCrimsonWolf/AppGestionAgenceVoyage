using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionAgenceVoyage
{
    public class EnregistrementEvent : EventArgs
    {
        private MainWindowViewModel _viewModel;
        public MainWindowViewModel ViewModel { get => _viewModel; set => _viewModel = value; }

        public EnregistrementEvent(MainWindowViewModel viewModel)
        {
            this._viewModel = viewModel;
        }
    }
}
