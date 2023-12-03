using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetEase_clund_music.Tools.ConverterHelper
{
    public class UserDiscussConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            string result;
            
            result = string.Format("{0} {1}", values[0].ToString().Trim(), "虚拟宠物IC为基础我曾经拦蓄把控六级考了附件是打开拉法基受到了发生的卡拉腹上的拉法基阿斯兰的看法萨克利夫手打阿斯蒂芬撒地方士大夫");
            //values[1].ToString() 
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
