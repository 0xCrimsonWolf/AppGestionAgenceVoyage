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
            DateTime bla = Convert.ToDateTime(dateDebut);
            //DateTime dateFin = (DateTime)values[1];

            if (bla.Year > 2023)
            {
                return Brushes.Red;
            }

            return null;
        }

        object[] IMultiValueConverter.ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
