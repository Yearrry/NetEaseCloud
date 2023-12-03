using NetEase_clund_music.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// FindMusic.xaml 的交互逻辑
    /// </summary>
    public partial class FindMusic : UserControl
    {
        FindMusicViewModel viewmodel;

        public FindMusic()
        {
            InitializeComponent();
            viewmodel = new FindMusicViewModel();
            DataContext = viewmodel;

            keyvalueControl = new Dictionary<string, string>();
            keyvalueControl.Add("个性推荐", "Recommend_UserContrl");
            keyvalueControl.Add("歌单", "SongList_UserControl");
            keyvalueControl.Add("主播电台", "HostStation");
            keyvalueControl.Add("排行榜", "RankingList_UserControl");
            keyvalueControl.Add("歌手", "Singer_UserControl");
            keyvalueControl.Add("最新音乐", "LatestMusic_UserControl");
        }

        private Dictionary<string, string> keyvalueControl;

        private async void TitleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem boxitem = e.AddedItems[0] as ListBoxItem;
            if(keyvalueControl[boxitem.Content.ToString()] != null)
            {
                 TabSwitchAnimation(boxitem);

                await Task.Run(async() =>
                {
                    await Task.Run(async () =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            loading.Visibility = Visibility.Visible;
                            viewmodel.ActivateControl(keyvalueControl[boxitem.Content.ToString()]);
                        });
                        await Task.Delay(1000);
                    });
                   
                    Dispatcher.Invoke(() =>
                    {
                        loading.Visibility = Visibility.Collapsed;
                    });
                });
            }
        }

        private void FindMusic_Loaded(object sender, RoutedEventArgs e)
        {
            TitleList.SelectedItem = TitleList.Items[0];
        }

        public Task TabSwitchAnimation(ListBoxItem item)
        {
            //下边框
            borderSubscript.Width = item.ActualWidth;
            DoubleAnimation dbanimation = new DoubleAnimation();
            dbanimation.To = (item.TransformToAncestor(this).Transform(new Point(0, 0)).X - 20);
            dbanimation.Duration = TimeSpan.FromMilliseconds(700);
            dbanimation.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };
            //加载层
            borderSubscript.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation);

            return Task.CompletedTask;
        }
    }
}
