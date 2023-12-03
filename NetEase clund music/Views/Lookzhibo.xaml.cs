using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// Lookzhibo.xaml 的交互逻辑
    /// </summary>
    public partial class Lookzhibo : UserControl
    {
        public Lookzhibo()
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
    }
}
