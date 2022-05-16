using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace AppGestionAgenceVoyage
{
    public class DataConverterToColor : IMultiValueConverter
    {
        object IMultiValueConverter.Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string dateDebut = values[0] as string;
            string dateFin = values[1] as string;
            DateTime DateDebut = Convert.ToDateTime(dateDebut);
            DateTime DateFin = Convert.ToDateTime(dateFin);

            if (DateDebut.Year == 2022)
            {
                return Brushes.Green;
            }

            return Brushes.White;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
