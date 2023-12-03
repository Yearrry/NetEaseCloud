using System.Collections.Generic;
using System.Windows.Controls;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// LikeMusic.xaml 的交互逻辑
    /// </summary>
    public partial class LikeMusic : UserControl
    {
        public LikeMusic()
        {
            InitializeComponent();

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
    }
}
