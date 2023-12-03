using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// MusicDetails.xaml 的交互逻辑
    /// </summary>
    public partial class MusicDetails : UserControl
    {
        public MusicDetails()
        {
            InitializeComponent();
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

        private void MusicDetails_Loaded(object sender, RoutedEventArgs e)
        {
            Task.Run(async() =>
            {
                await Task.Run( async() =>
                {
                    
                    Dispatcher.Invoke(() =>
                    {
                        OneRow.Visibility = Visibility.Visible;
                        DoubleAnimation db = new DoubleAnimation();
                        db.To = 1;
                        db.Duration = TimeSpan.FromMilliseconds(300);
                        OneRow.BeginAnimation(OpacityProperty, db);
                    });

                    await Task.Delay(300);

                    Dispatcher.Invoke(() =>
                    {
                        TwoRow.Visibility = Visibility.Visible;
                        DoubleAnimation db = new DoubleAnimation();
                        db.To = 1;
                        db.Duration = TimeSpan.FromMilliseconds(300);
                        TwoRow.BeginAnimation(OpacityProperty, db);
                    });
                });
            });
        }
    }
}
