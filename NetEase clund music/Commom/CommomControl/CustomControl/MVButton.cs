using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetEase_clund_music
{
    public class MVButton : AlbumButton
    {
        static MVButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MVButton), new FrameworkPropertyMetadata(typeof(MVButton)));
        }

        public MVButton()
        {
            CustomType = ButtonType.视频;
        }

       
    }
}
