using System.Windows;
using System.Windows.Controls;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// DownloadManagement.xaml 的交互逻辑
    /// </summary>
    public partial class DownloadManagement : UserControl
    {
        public DownloadManagement()
        {
            InitializeComponent();
        }

        private void Download_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in RadioButtonPanelt.Children)
            {
                if(item as RadioButton != null)
                {
                    (item as RadioButton).Checked += DownloadManagement_Checked;
                }
            }
            DownloadedMusic.IsChecked = true;
        }

        private void DownloadManagement_Checked(object sender, RoutedEventArgs e)
        {
           if((sender as RadioButton).Content.ToString() == "正在下载")
            {
                ButtonStackpanel.Visibility = Visibility.Visible;
                Borderborder.Visibility = Visibility.Visible;
                PlayAll.Visibility = Visibility.Collapsed;
                AllStart.Visibility = Visibility.Visible;
                AllStop.Visibility = Visibility.Visible;
                DeleteAll.Visibility = Visibility.Visible;
                StrechCanvas.Visibility = Visibility.Collapsed;
                DataGridBorder.Visibility = Visibility.Collapsed;
                DataGridtwoBorder.Visibility = Visibility.Visible;
            }
           else if((sender as RadioButton).Content.ToString() == "已下载MV")
            {
                ButtonStackpanel.Visibility = Visibility.Collapsed;
                Borderborder.Visibility = Visibility.Collapsed;
                StrechCanvas.Visibility = Visibility.Collapsed;
                DataGridBorder.Visibility = Visibility.Collapsed;
            }
            else
            {
                if ((sender as RadioButton).Content.ToString() == "已下载电台节目") DiskPathText.Text = @"存储目录：H:\CloundMusic\电台节目";
                else DiskPathText.Text = @"存储目录：H:\CloundMusic";
                Borderborder.Visibility = Visibility.Visible;
                ButtonStackpanel.Visibility = Visibility.Visible;
                PlayAll.Visibility = Visibility.Visible;
                AllStart.Visibility = Visibility.Collapsed;
                AllStop.Visibility = Visibility.Collapsed;
                DeleteAll.Visibility = Visibility.Collapsed;
                StrechCanvas.Visibility = Visibility.Visible;
                DataGridBorder.Visibility = Visibility.Visible;
                DataGridtwoBorder.Visibility = Visibility.Collapsed;
            }
        }
    }
}
