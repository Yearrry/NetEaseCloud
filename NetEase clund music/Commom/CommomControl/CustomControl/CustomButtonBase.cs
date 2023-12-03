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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetEase_clund_music
{
    public class CustomButtonBase : Button
    {
        static CustomButtonBase()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButtonBase), new FrameworkPropertyMetadata(typeof(CustomButtonBase)));
        }

        //备用
        public string Remark
        {
            get { return (string)GetValue(RemarkProperty); }
            set { SetValue(RemarkProperty, value); }
        }

        public static readonly DependencyProperty RemarkProperty =
            DependencyProperty.Register("Remark", typeof(string), typeof(CustomButtonBase), new PropertyMetadata(""));

        //类型
        public ButtonType CustomType
        {
            get { return (ButtonType)GetValue(CustomTypeProperty); }
            set { SetValue(CustomTypeProperty, value); }
        }

        public static readonly DependencyProperty CustomTypeProperty =
            DependencyProperty.Register("CustomType", typeof(ButtonType), typeof(CustomButtonBase), new PropertyMetadata(ButtonType.歌手));

        //内容名称
        public string ContentName
        {
            get { return (string)GetValue(ContentNameProperty); }
            set { SetValue(ContentNameProperty, value); }
        }

        public static readonly DependencyProperty ContentNameProperty =
            DependencyProperty.Register("ContentName", typeof(string), typeof(SongerButton), new PropertyMetadata(""));



        public static readonly RoutedEvent ChangedContentEvent = EventManager.RegisterRoutedEvent("ChangedContent", RoutingStrategy.Bubble,
           typeof(EventHandler<ChangeContentEventArgs>), typeof(CustomButtonBase));


        public event RoutedEventHandler ChangedContent
        {
            add { this.AddHandler(ChangedContentEvent, value); }
            remove { this.RemoveHandler(ChangedContentEvent, value); }
        }
    }

    //自定义路由事件参数的承载
    public class ChangeContentEventArgs : RoutedEventArgs
    {
        public ChangeContentEventArgs(RoutedEvent routedEvent, object source) : base(routedEvent, source) { }

        public string viewName { get; set; }

        public object[] parameters { get; set; }
    }

    public enum ButtonType
    {
        歌手 = 0,
        专辑 = 1,
        单曲 = 2,
        视频 = 3,
        歌单 = 4,
        主播电台 = 5,
        用户 = 6,
        喜欢 = 7
    }
}
