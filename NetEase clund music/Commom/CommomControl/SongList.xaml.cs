using NetEase_clund_music.Db;
using NetEase_clund_music.Model;
using NetEase_clund_music.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Commom.CommomControl
{
    /// <summary>
    /// SongList.xaml 的交互逻辑
    /// </summary>
    public partial class SongList : UserControl
    {
        MusicHelperDb helper = new MusicHelperDb();

        public SongList()
        {
            InitializeComponent();

            DataContext = this;

            //Binding binding = new Binding("CustomType");
            //binding.Mode = BindingMode.TwoWay;

            //SetBinding(CustomTypeProperty, binding);

            modelDictionary.Add(dataGridItem, DataGridBorder);
            modelDictionary.Add(commentsItem, CommentsModel);
            modelDictionary.Add(collectorsItem, CollectorsModel);
            modelDictionary.Add(albumDetailItem, AlbumDetails);
        }

        public SongList(ButtonType type,album album)
        {
            InitializeComponent();

            CustomType = type;
            Album = album;

            DataContext = this;

            //Binding binding = new Binding("CustomType");
            //binding.Mode = BindingMode.TwoWay;

            //SetBinding(CustomTypeProperty, binding);

            modelDictionary.Add(dataGridItem, DataGridBorder);
            modelDictionary.Add(commentsItem, CommentsModel);
            modelDictionary.Add(collectorsItem, CollectorsModel);
            modelDictionary.Add(albumDetailItem, AlbumDetails);
        }

        public Dictionary<ListBoxItem, Border> modelDictionary = new Dictionary<ListBoxItem, Border>();


        private void TitleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem boxitem = e.AddedItems[0] as ListBoxItem;

            TabSwitchAnimation(boxitem);

            if (modelDictionary.Count != 0)
            {
                foreach (Border item in modelDictionary.Values)
                {
                    if (item.Visibility == Visibility.Visible)
                    {
                        AnimationHelper.Positioning(false, false, null, item, item, 0, 0, TransitionType.Right, TimeSpan.FromMilliseconds(0), this);
                    }
                }

                ListBoxItem boxItem = e.AddedItems[0] as ListBoxItem;

                foreach (ListBoxItem box in modelDictionary.Keys)
                {
                    if (box == boxItem)
                    {
                        AnimationHelper.Positioning(true, false, null, modelDictionary[box], modelDictionary[box], 0, 0, TransitionType.Left, TimeSpan.FromMilliseconds(500), this);
                    }
                }
            }
        }

        public Task TabSwitchAnimation(ListBoxItem item)
        {
            //下边框
            borderSubscript.Width = item.ActualWidth;
            DoubleAnimation dbanimation = new DoubleAnimation();
            dbanimation.To = item.TransformToAncestor(this).Transform(new Point(0, 0)).X;
            dbanimation.Duration = TimeSpan.FromMilliseconds(700);
            dbanimation.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };
            //加载层
            borderSubscript.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation);

            return Task.CompletedTask;
        }

        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            TitleList.SelectedItem = TitleList.Items[0];

            if(Album.songs.Count == 0 && !string.IsNullOrWhiteSpace(Album.id))
            {
                 album newalbum =  await helper.GetAlbumById(Album.id);

                Album = newalbum;
            }
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


        #region 依赖属性

        public ButtonType CustomType
        {
            get { return (ButtonType)GetValue(CustomTypeProperty); }
            set { SetValue(CustomTypeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for type.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomTypeProperty =
            DependencyProperty.Register("ControlType", typeof(ButtonType), typeof(SongList), new PropertyMetadata(ButtonType.专辑));


        public album Album
        {
            get { return (album)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Album.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlbumProperty =
            DependencyProperty.Register("Album", typeof(album), typeof(SongList), new PropertyMetadata(new album()));


        #endregion
    }
}
