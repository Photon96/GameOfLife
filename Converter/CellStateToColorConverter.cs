using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;

namespace GameOfLifeProject
{
    class CellStateToColorConverter : IValueConverter
    {
        object IValueConverter.Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (value != null)
            {
                Cell cell = (Cell)value;
                switch (cell.GetState())
                {
                    case Cell.CellState.Allive:
                        return Brushes.Green;
                    case Cell.CellState.Dead:
                        return Brushes.Red;
                    case Cell.CellState.Empty:
                        return Brushes.WhiteSmoke;
                    default:
                        return null;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
