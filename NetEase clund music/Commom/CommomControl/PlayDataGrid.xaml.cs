using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetEase_clund_music.Commom.CommomControl
{
    /// <summary>
    /// PlayDataGrid.xaml 的交互逻辑
    /// </summary>
    public partial class PlayDataGrid : DataGrid
    {
        public PlayDataGrid()
        {
            InitializeComponent();
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

        private void DataGrid_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            if ((e.Row.GetIndex() + 1) < 10)
            {
                e.Row.Header = string.Format("0{0}", e.Row.GetIndex() + 1);
            }

            else
            {
                e.Row.Header = e.Row.GetIndex() + 1;
            }
        }

        public static readonly RoutedEvent PlayChangedEvent
            = EventManager.RegisterRoutedEvent("PlayChanged", RoutingStrategy.Bubble, typeof(EventHandler<RoutedEventArgs>), typeof(PlayDataGrid));

        public event RoutedEventHandler PlayChanged
        {
            add { this.AddHandler(PlayChangedEvent, value); }
            remove { this.RemoveHandler(PlayChangedEvent, value); }
        }

        protected override void OnMouseDoubleClick(MouseButtonEventArgs e)
        {
            base.OnMouseDoubleClick(e);

            RoutedEventArgs changedevent = new RoutedEventArgs(PlayChangedEvent, this);
            this.RaiseEvent(changedevent);
        }
    }

}
