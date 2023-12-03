using NetEase_clund_music.Commom;
using NetEase_clund_music.Model;
using NetEase_clund_music.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetEase_clund_music.Views.FindMusicUserControl
{
    /// <summary>
    /// SongList_UserControl.xaml 的交互逻辑
    /// </summary>
    public partial class SongList_UserControl : UserControl
    {
        SongList_ViewModel viewmodel;
        public SongList_UserControl()
        {
            InitializeComponent();
            viewmodel = new SongList_ViewModel();
            viewmodel.init();
            this.DataContext = viewmodel;
            //init();
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
           if(SongListModel.Visibility == Visibility.Visible)
            {
                Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        AnimationHelper.Positioning(false, false, null, SongListModel, SongListModel, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
                    });
                });
            }
        }

        private void SongList_Click(object sender, RoutedEventArgs e)
        {
            if((e.OriginalSource as Button).Name == "showModelButton")
            {
                if (SongListModel.Visibility == Visibility.Collapsed)
                {
                    AnimationHelper.Positioning(true, false, null, SongListModel, SongListModel, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
                }
            }
        }
        int limit;
        private void SongnumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(limit == Convert.ToInt32((sender as ListBox).SelectedItem))
            {
                return;
            }
            limit = Convert.ToInt32((sender as ListBox).SelectedItem);
            viewmodel.Query(limit);

            if (limit == viewmodel.SongListnum.Last())
            {
                rightButton.IsEnabled = false;
                if (lastlimit.Width != 0) lastlimit.Width = 0;
                if (startNum.Width != 54) startNum.Width = 54;
            }
            else if(limit == 1)
            {
                leftButton.IsEnabled = false;
            }
            else
            {
                if (rightButton.IsEnabled == false) rightButton.IsEnabled = true;
                if (leftButton.IsEnabled == false) leftButton.IsEnabled = true;
                if(limit >= 5)
                {
                    if (startNum.Width != 54) startNum.Width = 54;
                    int limitindex = (sender as ListBox).SelectedIndex;
                    if(limitindex > 3)
                    {
                        if(8 > viewmodel.SongListnum.Count - limit)
                        {
                            lastlimit.Width = 0;
                        }
                    }
                    if(limitindex <= 3)
                    {
                        lastlimit.Width = 54;
                    }
                }
                else if(limit < 5)
                {
                    if (startNum.Width != 0) startNum.Width = 0;
                }
            }
        }

        private void SongList_Loaded(object sender, RoutedEventArgs e)
        {
            RecommendSongnumList.SelectionChanged += SongnumList_SelectionChanged;
            RecommendSongnumList.SelectedItem = RecommendSongnumList.Items[0];

            if (viewmodel.SongListnum.Count > 10)
            {
                lastlimit.Width = 54;
                lastlimitbutton.Content = viewmodel.SongListnum.Count;
            }
        }

        private void rightButton_Click(object sender, RoutedEventArgs e)
        {
            int nowlimitindex = RecommendSongnumList.SelectedIndex;

            RecommendSongnumList.SelectedItem = RecommendSongnumList.Items[nowlimitindex + 1];
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            int nowlimitindex = RecommendSongnumList.SelectedIndex;

            RecommendSongnumList.SelectedItem = RecommendSongnumList.Items[nowlimitindex - 1];
        }

        private void startNum_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.Query(1);
            if (startNum.Width != 0) startNum.Width = 0;
            if (lastlimit.Width != 54) lastlimit.Width = 54;
            RecommendSongnumList.SelectedItem = RecommendSongnumList.Items[0];
        }

        private void lastlimit_Click(object sender, RoutedEventArgs e)
        {
            viewmodel.Query(viewmodel.SongListnum.Count);
        
            RecommendSongnumList.SelectedItem = RecommendSongnumList.Items[RecommendSongnumList.Items.Count - 1];
        }
    }
}
