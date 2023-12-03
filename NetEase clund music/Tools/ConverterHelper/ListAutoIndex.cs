using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace NetEase_clund_music.Tools.ConverterHelper
{
    public class ListAutoIndex : IValueConverter
    {
        int index;
        ListBox listbox;
        public ListAutoIndex()
        {
             listbox = new ListBox();
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ListBoxItem item = value as ListBoxItem;

            ListBox lbox = ItemsControl.ItemsControlFromItemContainer(item) as ListBox;

            string reuslt;

            if(lbox == listbox)
            {
                index = index + 1;
                reuslt = index.ToString();
            }
            else
            {
                listbox = lbox;
                if (index > 0)
                {
                    index = 0;
                }
                index = index + 1;
                reuslt = index.ToString();
            }

            if(System.Convert.ToInt32(reuslt) < 10)
            {
                reuslt = string.Format("0{0}", reuslt);
            }
            return reuslt;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SwitchTemplateAlbum : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Model.album album = value as Model.album != null ? (value as Model.album) : new Model.album();

            return album;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
