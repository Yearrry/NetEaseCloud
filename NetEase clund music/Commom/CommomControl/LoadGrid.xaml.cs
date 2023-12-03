using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace NetEase_clund_music.Commom.CommomControl
{
    /// <summary>
    /// LoadGrid.xaml 的交互逻辑
    /// </summary>
    public partial class LoadGrid : Grid
    {
        public LoadGrid()
        {
            InitializeComponent();
        }



        public Brush LoadingBackground
        {
            get { return (Brush)GetValue(LoadingBackgroundProperty); }
            set { SetValue(LoadingBackgroundProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadingBackground.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingBackgroundProperty =
            DependencyProperty.Register("LoadingBackground", typeof(Brush), typeof(LoadGrid), new PropertyMetadata(Brushes.White));



        public double LoadingWidth
        {
            get { return (double)GetValue(LoadingWidthProperty); }
            set { SetValue(LoadingWidthProperty, value); }
        }

        // Using a DependencyProperty as the backing store for LoadingWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LoadingWidthProperty =
            DependencyProperty.Register("LoadingWidth", typeof(double), typeof(LoadGrid), new PropertyMetadata(4.5));


    }
}
