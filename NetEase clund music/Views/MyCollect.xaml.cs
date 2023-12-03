using NetEase_clund_music.Commom;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// MyCollect.xaml 的交互逻辑
    /// </summary>
    public partial class MyCollect : UserControl
    {
        public MyCollect()
        {
            InitializeComponent();
        }

        //滑动条转移路由
        private void listbox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            Border[] borders = { AlbumBorder,SingerBorder,VideoBorder,SpecialBorder };
            string[] namestr = { "AlbumButton", "SingerButton", "VideoButton", "SpecialButton" };

            foreach (Border border in borders)
            {
                if(border.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false, false, null, border, border, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
                }
            }

            RadioButton rb = e.Source as RadioButton;

            for (int i = 0; i < namestr.Length; i++)
            {
                if (rb.Name == namestr[i])
                {
                    AnimationHelper.Positioning(true, false, null, borders[i], borders[i], 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(500), this);
                }
            }
        }

        private void MyCollect_Loaded(object sender, RoutedEventArgs e)
        {
            AnimationHelper.Positioning(true, false, null, AlbumBorder, AlbumBorder, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(500), this);
        }
    }
}
