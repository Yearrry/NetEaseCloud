using NetEase_clund_music.Commom;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// VideoControl.xaml 的交互逻辑
    /// </summary>
    public partial class VideoControl : UserControl
    {
        public VideoControl()
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

        private void SongList_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (SongListModel.Visibility == Visibility.Visible)
            {
                AnimationHelper.Positioning(false, SongListModel, TransitionType.Top, TimeSpan.FromMilliseconds(0));
            }
        }

        private void SongList_Click(object sender, RoutedEventArgs e)
        {
            if ((e.OriginalSource as Button).Name == "showModelButton")
            {
                if (SongListModel.Visibility == Visibility.Collapsed)
                {
                    AnimationHelper.Positioning(true, SongListModel, TransitionType.Top, TimeSpan.FromMilliseconds(0));
                }
            }
        }

        private void VideoButton_Checked(object sender, RoutedEventArgs e)
        {
            if (VideoModel.Visibility == Visibility.Collapsed)
            {
                if (MovieModel.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false,MovieModel,TransitionType.Top, TimeSpan.FromMilliseconds(0));
                }
                AnimationHelper.Positioning(true,VideoModel, TransitionType.Top, TimeSpan.FromMilliseconds(500));
            }
        }

        private void MovieButton_Checked(object sender, RoutedEventArgs e)
        {
            if (MovieModel.Visibility == Visibility.Collapsed)
            {
                if (VideoModel.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false, VideoModel, TransitionType.Top, TimeSpan.FromMilliseconds(0));
                }
                AnimationHelper.Positioning(true,MovieModel, TransitionType.Top, TimeSpan.FromMilliseconds(500));
            }
        }

        private void VideoControl_Loaded(object sender, RoutedEventArgs e)
        {
            VideoButton.Checked += VideoButton_Checked;
            MovieButton.Checked += MovieButton_Checked;
            VideoButton.IsChecked = true;
        }

    }
}
