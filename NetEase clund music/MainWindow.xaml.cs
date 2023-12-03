using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;
using NetEase_clund_music.Commom;
using NetEase_clund_music.Commom.CommomControl;
using NetEase_clund_music.Tools.apiHelper;
using NetEase_clund_music.ViewModel;
using NetEase_clund_music.Views;
using Newtonsoft.Json;

namespace NetEase_clund_music
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        MainViewModel viewmodel = new MainViewModel();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = viewmodel;

            boxitemControl.Add("发现音乐", "FindMusic");
            boxitemControl.Add("私人FM", "PersonalFM");
            boxitemControl.Add("LOOK 直播", "Lookzhibo");
            boxitemControl.Add("视频", "VideoControl");
            boxitemControl.Add("朋友", "FriendDynamic");
            boxitemControl.Add("本地音乐", "LocalMusic");
            boxitemControl.Add("下载管理", "DownloadManagement");
            boxitemControl.Add("我的音乐云盘", "MusicCloundDisk");
            boxitemControl.Add("我的收藏", "MyCollect");
            boxitemControl.Add("我喜欢的音乐", "LikeMusic");
        }

        #region 一些东西

        DispatcherTimer dt;

        //进度条的比例
        double SliderHelper;

        //左边操作栏  ListBoxitem 对应的  UserContrl
        Dictionary<string, string> boxitemControl = new Dictionary<string, string>();

        #endregion


        #region  ：私人FM

        //播放音乐
        public void PlayingMusic()
        {
            MusicPlayer.Play();

        }

        //辅助   播放时间、歌词位置 
        public void OneFunction()
        {
            startPosition.Text = MusicPlayer.Position.ToString("mm") + ":" + MusicPlayer.Position.ToString("ss");

            PersonalFM person = ContentView.Content as PersonalFM;

            if (person != null)
            {
                LyricControl lyric = (person.FindName("LyricControl") as ContentControl).Content as LyricControl;

                lyric.LrcRoll(MusicPlayer.Position.TotalMilliseconds);
            }
        }

        //停止音乐
        public void StopMusic()
        {
            dt.Stop();
            MusicPlayer.Pause();
        }

        #endregion


        #region 播放操作

        //进度滑块左键离开事件
        private void LyricSlider_PreviewMouseLeftButtonup(object sender, MouseButtonEventArgs e)
        {
            if (MusicPlayer.Source == null)
            {
                return;
            }
            MusicPlayer.Position = new TimeSpan(0, 0, Convert.ToInt32(LyricSlider.Value / SliderHelper));

            OneFunction();
        }

        #endregion


        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            oneList.SelectedItem = oneList.Items[0];
            //var yy = viewmodel.PlayingSong.SongDiskAddress;
            //MusicPlayer.Source = new Uri(viewmodel.PlayingSong.SongDiskAddress, UriKind.Absolute);
        }

        //拖动窗口
        private void MoveWindow(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        #region 操作动画
        private void planModeSwitch(object sender, RoutedEventArgs e)
        {
            if (planMode.ToolTip.ToString() == "列表循环")
            {
                planMode.Content = "😏";
                planMode.ToolTip = "单曲循环";
            }
            else if (planMode.ToolTip.ToString() == "单曲循环")
            {
                planMode.Content = "🥴";
                planMode.ToolTip = "随机播放";
            }
            else if (planMode.ToolTip.ToString() == "随机播放")
            {
                planMode.Content = "😃";
                planMode.ToolTip = "顺序播放";
            }
            else if (planMode.ToolTip.ToString() == "顺序播放")
            {
                planMode.Content = "😶";
                planMode.ToolTip = "列表循环";
            }
            else
            {
                planMode.Content = "🤪";
                planMode.ToolTip = "心动模式";
            }
        }

        //左边ListBox 选中改变事件
        private void oneList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count < 1) return;

            if (e.AddedItems.Count != 0)
            {
                ListBox[] arraybox = { oneList, twoList, threeList, fourList };

                foreach (ListBox listBox in arraybox)
                {
                    if (listBox == sender as ListBox)
                    {
                        listBox.SelectedItem = e.AddedItems[0] as ListBoxItem;
                    }
                    else
                    {
                        listBox.SelectedItem = null;
                    }
                }
            }

            if ((e.AddedItems[0] as ListBoxItem).Content.ToString() == "朋友")
            {
                ScrollViewer.SetVerticalScrollBarVisibility(ContentscrollViewer, ScrollBarVisibility.Disabled);
            }
            else
            {
                ScrollViewer.SetVerticalScrollBarVisibility(ContentscrollViewer, ScrollBarVisibility.Visible);
            }

            viewmodel.ActivateControl(boxitemControl[(e.AddedItems[0] as ListBoxItem).Content.ToString()]);
        }

        private void BorderChecked(object sender, RoutedEventArgs e)
        {
            if (songListCode.Opacity == 0)
            {
                songListCode.Opacity = 1;
            }
            else
            {
                songListCode.Opacity = 0;
            }
        }

        private void ShowModelSong(object sender, RoutedEventArgs e)
        {
            AnimationHelper.Positioning(true, true, addMusicList, addMusicListPopup, PopupParent, 32, 40, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
        }

        private void HidePopup(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement x = sender as FrameworkElement;
            AnimationHelper.Positioning(false, false, null, addMusicListPopup, PopupParent, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
        }

        private void showDiscussModel(object sender, MouseButtonEventArgs e)
        {
            TextBlock haojiahuo = e.OriginalSource as TextBlock;
            if (haojiahuo != null && haojiahuo.Text == "回复")
            {
                ListBoxItem isi = e.Source as ListBoxItem;
                Grid tt = isi.Template.FindName("discussHidemodel", isi) as Grid;
                DoubleAnimation db = new DoubleAnimation();
                db.Duration = TimeSpan.FromMilliseconds(700);
                if (tt.Height == 110)
                {
                    db.To = 0;
                    db.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseIn };
                }
                else
                {
                    db.To = 110;
                    db.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };
                }
                tt.BeginAnimation(HeightProperty, db);
                e.Handled = true;
            }
        }

        private void SwitchModel(object sender, RoutedEventArgs e)
        {
            RadioButton NowButton = e.Source as RadioButton;
            if (NowButton != null)
            {
                SwitchModelFunction(NowButton.Content.ToString());
                e.Handled = true;

            }
        }

        public void SwitchModelFunction(string key)
        {
            Dictionary<string, ListBox> modelDictionary = new Dictionary<string, ListBox>();
            modelDictionary.Add("私信", LetterModel); modelDictionary.Add("评论", DiscussModel); modelDictionary.Add("通知", informModel);
            modelDictionary.Add("@我", SeekMeModel);

            if (modelDictionary.Keys.Contains(key))
            {
                LoadingModel.Visibility = Visibility.Visible;
                NullModel.Visibility = Visibility.Collapsed;

                Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        foreach (ListBox item in modelDictionary.Values)
                        {
                            if (item.Visibility == Visibility.Visible)
                            {
                                DoubleAnimationOperation(false, 0, TimeSpan.FromMilliseconds(400), item, TranslateTransform.YProperty, 0.2, TimeSpan.FromSeconds(0));
                                item.Visibility = Visibility.Collapsed;
                            }
                        }
                        ListBox ShowModel = modelDictionary[key];
                        if (ShowModel.Items.Count != 0)
                        {
                            ShowModel.Visibility = Visibility.Visible;
                            DoubleAnimationOperation(true, 0, TimeSpan.FromMilliseconds(400), ShowModel, TranslateTransform.YProperty, 0.2, TimeSpan.FromSeconds(0));
                        }
                        else NullModel.Visibility = Visibility.Visible;
                    });
                });

                LoadingModel.Visibility = Visibility.Collapsed;
            }
            else if (key == "demo")
            {
                foreach (ListBox item in modelDictionary.Values)
                {
                    if (item.Visibility == Visibility.Visible)
                    {
                        DoubleAnimationOperation(false, 0, TimeSpan.FromMilliseconds(400), item, TranslateTransform.YProperty, 0.2, TimeSpan.FromSeconds(0));
                    }
                }
            }
        }

        private void HideListModelParent(object sender, RoutedEventArgs e)
        {
            DoubleAnimationOperation(false, 370, TimeSpan.FromMilliseconds(700), ListModelParent, TranslateTransform.XProperty, 0.3, TimeSpan.FromMilliseconds(0));
            SwitchModelFunction("demo");
        }

        public void DoubleAnimationOperation(bool code, double offset, TimeSpan duration, FrameworkElement onwork, DependencyProperty workproperty, double amplitude, TimeSpan beginTime)
        {
            DoubleAnimation dbanimation = new DoubleAnimation();
            Timeline.SetDesiredFrameRate(dbanimation, 144);
            dbanimation.Duration = duration;
            dbanimation.BeginTime = beginTime;
            if (code)
            {
                dbanimation.To = offset;
                dbanimation.EasingFunction = new BackEase() { Amplitude = amplitude, EasingMode = EasingMode.EaseOut };
            }
            else dbanimation.EasingFunction = new BackEase() { Amplitude = amplitude, EasingMode = EasingMode.EaseIn };

            if (workproperty == TranslateTransform.XProperty || workproperty == TranslateTransform.YProperty)
            {
                onwork.RenderTransform.BeginAnimation(workproperty, dbanimation);
            }
            else if (workproperty == ScaleTransform.ScaleXProperty || workproperty == ScaleTransform.ScaleYProperty ||
                workproperty == ScaleTransform.CenterXProperty || workproperty == ScaleTransform.CenterYProperty)
            {
                onwork.RenderTransform.BeginAnimation(workproperty, dbanimation);
            }
            else
            {
                onwork.BeginAnimation(workproperty, dbanimation);
            }
        }

        #endregion

        //路由关闭Model
        private async void SuperRoute(object sender, MouseButtonEventArgs e)
        {
            if (ListModelParent.RenderTransform.Value.OffsetX != 370)
            {
                DoubleAnimationOperation(false, 370, TimeSpan.FromMilliseconds(700), ListModelParent, TranslateTransform.XProperty, 0.3, TimeSpan.FromSeconds(0));
            }
            if (switchColorGrid.Height != 0)
            {
                DoubleAnimationOperation(false, 0, TimeSpan.FromMilliseconds(500), switchColorGrid, HeightProperty, 0.3, TimeSpan.FromSeconds(0));
            }
            if (userDataModel.Visibility == Visibility.Visible)
            {
                await AnimationHelper.Positioning(false, false, null, userDataModel, userDataModel, 0, 0, TransitionType.Top, TimeSpan.FromMilliseconds(0), this);
            }
            if ((e.Source as TextBox) != null)
            {
                if (ListModelParent.RenderTransform.Value.OffsetX != 370 || userDataModel.Visibility == Visibility || switchColorGrid.Height != 0)
                {
                    await AnimationHelper.Positioning(true, false, null, searchModel, searchModel, 0, 0, TransitionType.Bottom, TimeSpan.FromMilliseconds(500), this);
                }
                else
                {
                    await AnimationHelper.Positioning(true, false, null, searchModel, searchModel, 0, 0, TransitionType.Bottom, TimeSpan.FromMilliseconds(0), this);
                }
            }
            else
            {
                if (searchModel.Visibility == Visibility)
                {
                    await AnimationHelper.Positioning(false, false, null, searchModel, searchModel, 0, 0, TransitionType.Bottom, TimeSpan.FromMilliseconds(0), this);
                }
            }
        }

        private void SuperClick(object sender, RoutedEventArgs e)
        {
            if ((e.Source as Button).Name == "switchcolorButton")
            {
                if (ListModelParent.RenderTransform.Value.OffsetX != 370 || searchModel.Visibility == Visibility || userDataModel.Visibility == Visibility)
                {
                    DoubleAnimationOperation(true, 230, TimeSpan.FromMilliseconds(500), switchColorGrid, HeightProperty, 0.3, TimeSpan.FromMilliseconds(500));
                }
                else
                {
                    DoubleAnimationOperation(true, 230, TimeSpan.FromMilliseconds(500), switchColorGrid, HeightProperty, 0.3, TimeSpan.FromSeconds(0));
                }
                e.Handled = true;
            }
            else if ((e.Source as Button).Name == "messageModel")
            {
                if (switchColorGrid.Height != 0 || userDataModel.Visibility == Visibility || searchModel.Visibility == Visibility)
                {
                    DoubleAnimationOperation(true, 0, TimeSpan.FromMilliseconds(700), ListModelParent, TranslateTransform.XProperty, 0.3, TimeSpan.FromMilliseconds(500));
                }
                else
                {
                    DoubleAnimationOperation(true, 0, TimeSpan.FromMilliseconds(700), ListModelParent, TranslateTransform.XProperty, 0.3, TimeSpan.FromMilliseconds(0));
                }
                e.Handled = true;
                SwitchModelFunction("私信");
            }
            else if ((e.Source as Button).Name == "userDataButton")
            {
                if (switchColorGrid.Height != 0 || ListModelParent.RenderTransform.Value.OffsetX != 370 || searchModel.Visibility == Visibility)
                {
                    AnimationHelper.Positioning(true, false, null, userDataModel, userDataModel, 0, 0, TransitionType.Bottom, TimeSpan.FromMilliseconds(500), this);
                }
                else
                {
                    AnimationHelper.Positioning(true, false, null, userDataModel, userDataModel, 0, 0, TransitionType.Bottom, TimeSpan.FromMilliseconds(0), this);
                }
                e.Handled = true;
            }
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

        //媒体缓存好后取结束时间
        private void MusicPlayer_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaElement media = sender as MediaElement;
            endPosition.Text = media.NaturalDuration.TimeSpan.ToString("mm") + ":" + media.NaturalDuration.TimeSpan.ToString("ss");
            media.LoadedBehavior = MediaState.Manual;

            loadingMusic.Visibility = Visibility.Collapsed;

           if(dt != null)
            {
                dt = new DispatcherTimer();
            }

            dt.Interval = TimeSpan.FromSeconds(0.5);

            dt.Tick += (a, c) =>
            {
                SliderHelper = LyricSlider.Width / MusicPlayer.NaturalDuration.TimeSpan.TotalSeconds;

                LyricSlider.Value = MusicPlayer.Position.TotalSeconds * SliderHelper;
            };
            dt.Start();
        }

        private void shiyixia(object sender, RoutedEventArgs e)
        {
            viewmodel.shixxii();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            scrollvier.ScrollToVerticalOffset(0);
        }

        public void taskrun(Action action)
        {
            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    Dispatcher.Invoke(action);
                });
            });
        }

        private async void Border_PlayChanged(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            Model.song Playsong;

            if (e.OriginalSource as ListBox != null)
            {
                ListBox box = e.OriginalSource as ListBox;

                Playsong = box.SelectedItem as Model.song;
            }
            else
            {
                DataGrid dtg = e.OriginalSource as DataGrid;

                Playsong = dtg.SelectedItem as Model.song;
            }
           
            Music163Helper music163 = new Music163Helper();

            viewmodel.PlaySong = Playsong;

            await InitMusicCommom();

            //请求歌手图片、没有就默认是gd2.jpg；
            if (string.IsNullOrEmpty(Playsong.album.blurPicUrl))
            {
               (bool,string) result =  await music163.GetAlbumimage(Playsong.album.id);

                if (result.Item1)
                {
                    Model.album a = JsonConvert.DeserializeObject<Model.album>(result.Item2);
                    Playsong.album = a;
                }
                else
                {
                    Playsong.album.blurPicUrl = "pack://application:,,,/ResuourceHome/images/gd2.jpg";
                }
                viewmodel.PlaySong = Playsong;
            }

            //下载歌曲缓存
            var playpath = await music163.GetPalyPath(Playsong.id, Playsong.name);

            if (playpath.Item1)
            {
                viewmodel.PlayPath = playpath.Item2;

                MusicPlayer.Play();
               
            }
            else
            {
                MessageBox.Show( playpath.Item2);
            }
        }

        //初始化播放、切换歌曲
        public Task InitMusicCommom()
        {
            //初始化定时器；
            if (MusicPlayer.CanPause)
            {
                MusicPlayer.Pause();
            }
            if (dt != null && dt.IsEnabled)
            {
                dt.Stop();
            }
            dt = new DispatcherTimer();

            //初始化进度条、音乐长度、按钮状态
            LyricSlider.Value = 0;
            startPosition.Text = "00:00";
            TimeSpan endpos = TimeSpan.FromMilliseconds(Convert.ToDouble(viewmodel.PlaySong.duration));
            endPosition.Text = endpos.ToString("mm") + ":" + endpos.ToString("ss");
            playButton.Visibility = Visibility.Collapsed;
            PauseButton.Visibility = Visibility.Visible;
            loadingMusic.Visibility = Visibility.Visible;

            return Task.CompletedTask;
        }

        private void MusicData_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MusicDetails md = new MusicDetails();
            MusicDetailsModel.Content = md;
        }

        private void playButton_Click(object sender, RoutedEventArgs e)
        {
            MusicPlayer.Play();
            dt.Start();
            playButton.Visibility = Visibility.Collapsed;
            PauseButton.Visibility = Visibility.Visible;
        }

        private void PauseButton_Click(object sender, RoutedEventArgs e)
        {
            if (MusicPlayer.CanPause)
            {
                MusicPlayer.Pause();
                dt.Stop();
                playButton.Visibility = Visibility.Visible;
                PauseButton.Visibility = Visibility.Collapsed;
            }
        }

        private void LyricSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            OneFunction();
        }

        double volume;

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (!MusicPlayer.IsMuted)
            {
                MusicPlayer.IsMuted = true;
                MutedHelper.Opacity = 1;
                volume = MusicPlayer.Volume;
                MusicPlayer.Volume = 0;
            }
            else
            {
                MusicPlayer.IsMuted = false;
                MutedHelper.Opacity = 0;
                MusicPlayer.Volume = volume;
            }
            e.Handled = true;
        }

        private void ContentView_ChangedContent(object sender, ChangeContentEventArgs e)
        {
            e.Handled = true;

            viewmodel.ActivateControl(e.viewName,e.parameters);
        }

        private void CloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
    public enum TransitionType
    {
        Left = 0,
        Top = 1,
        Right = 2,
        Bottom = 3,
    }
}
