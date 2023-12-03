using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// LocalMusic.xaml 的交互逻辑
    /// </summary>
    public partial class LocalMusic : UserControl
    {
        public LocalMusic()
        {
            InitializeComponent();

            InitLstDemo();

            DataContext = this;
        }

        public List<DataDemo> listDataDemo { get; set; }

        public void InitLstDemo()
        {
            listDataDemo = new List<DataDemo>();
            DataDemo spike = new DataDemo
            {
                Ranking = 1,
                LastRanking = 3,
                Score = 525,
                LastScore = 495,
                Count = 10,
                Dan = "至臻",
                Client = new ClientDemo
                {
                    PeopleImage = "pack://application:,,,/ResuourceHome/images/gd2.jpg",
                    PeopleName = "Spike"
                },
            };
            spike.IsRank = spike.Ranking < spike.LastRanking ? "升" : "降";
            spike.ScoreDiffer = (spike.Score - spike.LastScore) > 0 ? string.Format("+{0}", spike.Score - spike.LastScore) : (spike.Score - spike.LastScore).ToString();

            DataDemo Vincent = new DataDemo
            {
                Ranking = 2,
                LastRanking = 2,
                Score = 510,
                LastScore = 500,
                Count = 12,
                Dan = "至臻",
                Client = new ClientDemo
                {
                    PeopleImage = "pack://application:,,,/ResuourceHome/images/gd1.jpg",
                    PeopleName = "Vincent"
                },
            };
            Vincent.IsRank = Vincent.Ranking < Vincent.LastRanking ? "升" : "降";
            Vincent.ScoreDiffer = (Vincent.Score - Vincent.LastScore) > 0 ? string.Format("+{0}", Vincent.Score - Vincent.LastScore) : (Vincent.Score - Vincent.LastScore).ToString();

            DataDemo Faye = new DataDemo
            {
                Ranking = 3,
                LastRanking = 1,
                Score = 350,
                LastScore = 545,
                Count = 10,
                Dan = "至臻",
                Client = new ClientDemo
                {
                    PeopleImage = "pack://application:,,,/ResuourceHome/images/gd3.jpg",
                    PeopleName = "Faye"
                },
            };
            Faye.IsRank = Faye.Ranking < Faye.LastRanking ? "升" : "降";
            Faye.ScoreDiffer = (Faye.Score - Faye.LastScore) > 0 ? string.Format("+{0}", Faye.Score - Faye.LastScore) : (Faye.Score - Faye.LastScore).ToString();

            DataDemo Jojo = new DataDemo
            {
                Ranking = 4,
                LastRanking = 4,
                Score = 100,
                LastScore = 100,
                Count = 1,
                Dan = "白龙",
                Client = new ClientDemo
                {
                    PeopleImage = "pack://application:,,,/ResuourceHome/images/gd4.jpg",
                    PeopleName = "Jojo"
                },
            };
            Jojo.IsRank = Jojo.Ranking < Jojo.LastRanking ? "升" : "降";
            Jojo.ScoreDiffer = (Jojo.Score - Jojo.LastScore) > 0 ? string.Format("+{0}", Jojo.Score - Jojo.LastScore) : (Jojo.Score - Jojo.LastScore).ToString();

            listDataDemo.Add(spike);
            listDataDemo.Add(Vincent);
            listDataDemo.Add(Faye);
            listDataDemo.Add(Jojo);
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if(sender as RadioButton != null)
            {
                if((sender as RadioButton).Name == "one")
                {
                    ConditionListBox.Visibility = Visibility.Collapsed;
                    Grid.SetColumn(DataGridBorder, 0);
                    Grid.SetColumnSpan(DataGridBorder, 2);
                    TitleColumn.Width = 250;
                    GeshouColumn.Width = 170;
                    ZhuaniColumn.Width = 170;
                    this.Resources["OneTextWidth"] = 200d;
                    this.Resources["TwoTextWidth"] = 150d;

                    MatchMusic.Visibility = Visibility.Visible;
                    Grid.SetColumn(ButtonStackpanel, 0);
                    Grid.SetColumn(StrechCanvas, 1);
                    StrechCanvas.HorizontalAlignment = HorizontalAlignment.Right;
                    StrechCanvas.Margin = new Thickness(0, 1, 30, 0);
                    OneColumnBorder.Width = 0;
                    StreachTextbox.Tag = "搜索本地音乐";
                }
                else
                {
                    ConditionListBox.Visibility = Visibility.Visible;
                    Grid.SetColumn(DataGridBorder, 1);
                    Grid.SetColumnSpan(DataGridBorder, 1);
                    TitleColumn.Width = 200;
                    GeshouColumn.Width = 120;
                    ZhuaniColumn.Width = 120;
                    this.Resources["OneTextWidth"] = 150d;
                    this.Resources["TwoTextWidth"] = 100d;

                    MatchMusic.Visibility = Visibility.Collapsed;
                    Grid.SetColumn(ButtonStackpanel, 1);
                    Grid.SetColumn(StrechCanvas, 0);
                    StrechCanvas.HorizontalAlignment = HorizontalAlignment.Left;
                    StrechCanvas.Margin = new Thickness(10, 0, 10, 0);
                    OneColumnBorder.Width = 1;

                    if((sender as RadioButton).Name == "two") StreachTextbox.Tag = "查找歌手";
                    if((sender as RadioButton).Name == "three") StreachTextbox.Tag = "查找专辑";
                    if((sender as RadioButton).Name == "four") StreachTextbox.Tag = "查找文件夹";
                }
            }
        }

        private void LocalMusic_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in RadioButtonPanel.Children)
            {
                if(item as RadioButton != null)
                {
                    (item as RadioButton).Checked += RadioButton_Checked;
                }
            }
            one.IsChecked = true;
        }
    }
    public class DataDemo
    {
        public int Ranking { get; set; }
        public int LastRanking { get; set; }
        public string IsRank { get; set; }
        public int Score { get; set; }
        public int LastScore { get; set; }
        public string ScoreDiffer { get; set; }
        public ClientDemo Client { get; set; }
        public int Count { get; set; }
        public string Dan { get; set; }
    }
    public class ClientDemo
    {
        public string PeopleImage { get; set; }
        public string PeopleName { get; set; }
    }
}
