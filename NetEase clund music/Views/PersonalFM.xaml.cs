using NetEase_clund_music.ViewModel;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// PersonalFM.xaml 的交互逻辑
    /// </summary>
    public partial class PersonalFM : UserControl
    {
        PersonalFmViewModel viewmodel = new PersonalFmViewModel();

        public PersonalFM()
        {
            InitializeComponent();
            DataContext = viewmodel;
        }
        //滑动条转移路由
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

        private void smallLunbo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBox lb = e.Source as ListBox;
            if(lb != null)
            {
                var sign = lb.SelectedIndex;
            }
        }

        private void PersonalFm_Loaded(object sender, RoutedEventArgs e)
        {
            smallLunbo.SelectedItem = smallLunbo.Items[0];
        }

        bool code = false;

        private void DescendSong_Click(object sender, RoutedEventArgs e)
        {
            if(code == true)
            {
                return;
            }

            int count = smallLunbo.Items.Count;
            double week = count * 315 + 30;

            if(Math.Abs(DaohangTrans.X) + 315 + 60 < week)
            {
                code = true;
                Task.Run(async () =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        DoubleAnimation db1 = new DoubleAnimation();
                        Timeline.SetDesiredFrameRate(db1, 90);
                        db1.By = -315;
                        db1.Duration = TimeSpan.FromMilliseconds(1000);
                        db1.EasingFunction = new BackEase() { Amplitude = 0.2, EasingMode = EasingMode.EaseOut };
                        //db1.EasingFunction = new CircleEase() { EasingMode = EasingMode.EaseOut };
                        DaohangTrans.BeginAnimation(TranslateTransform.XProperty, db1);
                        smallLunbo.SelectedItem = smallLunbo.Items[smallLunbo.SelectedIndex + 1];
                    });
                    await Task.Delay(1000);
                    code = false;
                });
            }
            else
            {
                MessageBox.Show("last");
                return;
            }
        }

        private void leftChange_Click(object sender, RoutedEventArgs e)
        {
            if (code == true)
            {
                return;
            }

            if (Math.Abs(DaohangTrans.X) - 315  >= -30)
            {
                code = true;
                Task.Run(async () =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        DoubleAnimation db1 = new DoubleAnimation();
                        Timeline.SetDesiredFrameRate(db1, 90);
                        db1.By = 315;
                        db1.Duration = TimeSpan.FromMilliseconds(1000);
                        db1.EasingFunction = new BackEase() { Amplitude = 0.2, EasingMode = EasingMode.EaseOut };
                        DaohangTrans.BeginAnimation(TranslateTransform.XProperty, db1);
                        smallLunbo.SelectedItem = smallLunbo.Items[smallLunbo.SelectedIndex - 1];
                    });
                    await Task.Delay(1000);
                    code = false;
                });
            }
            else
            {
                MessageBox.Show("last");
                return;
            }
        }

        public string GetTime(string str)
        {
            Regex reg = new Regex(@"\[(?<time>.*)\]", RegexOptions.IgnoreCase);
            return reg.Match(str).Groups["time"].Value;
        }

        private void Playbutton_Click(object sender, RoutedEventArgs e)
        {
            if (playbutton.IsChecked == true)
            {
                App.Current.MainWindow.Dispatcher.Invoke(new Action(() =>
                {
                    MainWindow x = App.Current.MainWindow as MainWindow;

                    x.PlayingMusic();

                }));
            }
            else
            {
                App.Current.MainWindow.Dispatcher.Invoke(new Action(() =>
                {
                    MainWindow x = App.Current.MainWindow as MainWindow;

                    x.StopMusic();

                }));
            }
        }
    }
}
