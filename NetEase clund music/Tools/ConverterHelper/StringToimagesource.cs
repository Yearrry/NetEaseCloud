using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace NetEase_clund_music.Tools.ConverterHelper
{
    public class StringToimagesource : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            BitmapImage image;
            if (!string.IsNullOrWhiteSpace(value.ToString()))
            {
                image = new BitmapImage(new Uri(value.ToString()));
            }
            else
            {
                image = new BitmapImage(new Uri("pack://application:,,,/ResuourceHome/images/gd2.jpg"));
            }
            return image;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
