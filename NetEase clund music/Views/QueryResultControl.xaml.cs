using NetEase_clund_music.Commom;
using NetEase_clund_music.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// QueryResultControl.xaml 的交互逻辑
    /// </summary>
    public partial class QueryResultControl : UserControl
    {
        QueryResultViewModel viewmodel;
        public QueryResultControl()
        {
            InitializeComponent();
            viewmodel = new QueryResultViewModel();
            modelDictionary.Add(songItem, songborder);
            modelDictionary.Add(artistItem, artistborder);
            modelDictionary.Add(albumItem, albumborder);
        }

        public Dictionary<ListBoxItem, Border> modelDictionary = new Dictionary<ListBoxItem, Border>();

        public QueryResultControl(string querystr)
        {
            InitializeComponent();

            modelDictionary.Add(songItem, songborder);
            modelDictionary.Add(artistItem, artistborder);
            modelDictionary.Add(albumItem, albumborder);
            viewmodel = new QueryResultViewModel();
            viewmodel.conditionla = querystr;
            DataContext = viewmodel;
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

        private async void TitleList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem boxitem = e.AddedItems[0] as ListBoxItem;

            await TabSwitchAnimation(boxitem);

            if (modelDictionary.Count != 0)
            {
                foreach (Border item in modelDictionary.Values)
                {
                    if (item.Visibility == Visibility.Visible)
                    {
                       await AnimationHelper.Positioning(false, false, null, item, item, 0, 0, TransitionType.Right, TimeSpan.FromMilliseconds(0), this);
                    }
                }

                ListBoxItem boxItem = e.AddedItems[0] as ListBoxItem;

                foreach (ListBoxItem box in modelDictionary.Keys)
                {
                    if (box == boxItem)
                    {
                        await AnimationHelper.Positioning(true, false, null, modelDictionary[box], modelDictionary[box], 0, 0, TransitionType.Left, TimeSpan.FromMilliseconds(500), this);
                    }
                }
            }

            string context = boxitem.Content.ToString();

            viewmodel.ResultType = (sender as ListBox).SelectedIndex;

            viewmodel.InitPagingAsync(context);

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

        private void QueryResultControl_Loaded(object sender, RoutedEventArgs e)
        {
            TitleList.SelectedItem = TitleList.Items[0];
        }

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            int page = Convert.ToInt32(RecommendSongnumList.SelectedIndex);

            if ((e.Row.GetIndex() + 1) < 10)
            {
                e.Row.Header = string.Format("0{0}",e.Row.GetIndex() +1 + (page * 100));
            }

            else
            {
                e.Row.Header = e.Row.GetIndex() + 1 + (page * 100);
            }
        }

        private void RecommendSongnumList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox a = sender as ListBox;

        }
    }
}
