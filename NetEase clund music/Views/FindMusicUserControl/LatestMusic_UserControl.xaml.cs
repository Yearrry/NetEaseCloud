using NetEase_clund_music.Commom;
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

namespace NetEase_clund_music.Views.FindMusicUserControl
{
    /// <summary>
    /// LatestMusic_UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class LatestMusic_UserControl : UserControl
    {
        public LatestMusic_UserControl()
        {
            InitializeComponent();
        }

        public void listbox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (!e.Handled)
            {
                e.Handled = true;

                var eventArg = new MouseWheelEventArgs(e.MouseDevice, e.Timestamp, e.Delta);
                eventArg.RoutedEvent = UIElement.MouseWheelEvent;
                eventArg.Source = sender;
                var parent = ((Control)sender).Parent as UIElement;
                parent.RaiseEvent(eventArg);
            }
        }

        private void SongExpress_Checked(object sender, RoutedEventArgs e)
        {
            if(SongExpressBorder.Visibility == Visibility.Collapsed)
            {
               if(AlbumPutawayBorder.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false, false, null, AlbumPutawayBorder, AlbumPutawayBorder, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
                }
                AnimationHelper.Positioning(true, false, null, SongExpressBorder, SongExpressBorder, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(500), this);
            }
        }

        private void AlbumPutaway_Checked(object sender, RoutedEventArgs e)
        {
            if (AlbumPutawayBorder.Visibility == Visibility.Collapsed)
            {
                if(SongExpressBorder.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false, false, null, SongExpressBorder, SongExpressBorder, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
                }
                AnimationHelper.Positioning(true, false, null, AlbumPutawayBorder, AlbumPutawayBorder, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(500), this);
            }
        }

        private void LatestMusic_Loaded(object sender, RoutedEventArgs e)
        {
            SongExpress.Checked += SongExpress_Checked;
            AlbumPutaway.Checked += AlbumPutaway_Checked;
            SongExpress.IsChecked = true;
        }
    }
}
