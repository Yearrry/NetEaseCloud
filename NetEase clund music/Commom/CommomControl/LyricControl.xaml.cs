using NetEase_clund_music.Commom.AttchedProperty;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Commom.CommomControl
{
    /// <summary>
    /// LyricControl.xaml 的交互逻辑
    /// </summary>
    public partial class LyricControl : UserControl
    {
        public LyricControl()
        {
            InitializeComponent();
        }

        #region 变量
        //歌词集合
        Dictionary<double, LyricModel> Lyrics = new Dictionary<double, LyricModel>();
        //焦点歌词
        public LyricModel FocusLyric { get; set; }
        //默认歌词颜色
        public SolidColorBrush DefaultLyricsColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ADAFB2"));
        //焦点歌词颜色
        public SolidColorBrush FocusLyricsColor = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFFFFF"));

        #endregion

        /// <summary>
        /// 加载歌词
        /// </summary>
        /// <param name="lyricstr">歌词字符串   \n[时间]\n歌词</param>
        public void LoadLyric(string lyricstr)
        {
            //循环以\n切割出歌词
            foreach (string str in lyricstr.Split('\n'))
            {
                if(str.Length > 0 && str.IndexOf(":") != -1)
                {
                        //歌词时间
                        TimeSpan time = GetTime(str);
                        //歌词
                        string lyric = str.Split(']')[1];
                        //歌词控件
                        TextBlock tb = new TextBlock();
                        tb.Text = lyric;

                        if(lyricstr.Split('\n').Length == 1)
                        {
                            tb.FontSize = 23;
                            tb.Margin = new Thickness(50, 150, 0, 0);
                        }

                        //添加到集合
                        Lyrics.Add(time.TotalMilliseconds, new LyricModel()
                        {
                            LyricText = lyric,
                            LyricTextblock = tb,
                            Time = time.ToString()
                        });

                        LyricParentControl.Children.Add(tb);
                }
            }
        }

        /// <summary>
        /// 正则表达式获取歌词时间
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public TimeSpan GetTime(string str)
        {
            Regex reg = new Regex(@"\[(?<time>.*)\]", RegexOptions.IgnoreCase);

            string timestr = reg.Match(str).Groups["time"].Value;

            //获得分
            int m = Convert.ToInt32(timestr.Split(':')[0]);
            
            //获得秒、毫秒
            int s = 0, f = 0;
            if (timestr.Split(':')[1].IndexOf(".") != -1)
            {
                s = Convert.ToInt32((timestr.Split(':')[1].Split('.')[0]));
                f = Convert.ToInt32((timestr.Split(':')[1].Split('.')[1]));
            }
            else
            {
                s = Convert.ToInt32((timestr.Split(':')[1]));
            }

            return new TimeSpan(0, 0, m, s, f);
        }

        #region 歌词滚动
        /// <summary>
        /// 歌词滚动、定位焦点
        /// </summary>
        /// <param name="nowtime"></param>
        public void LrcRoll(double nowtime)
        {
            if (FocusLyric == null)
            {
                FocusLyric = Lyrics.Values.First();
                FocusLyric.LyricTextblock.Foreground = FocusLyricsColor;
            }
            else
            {
                //查找焦点歌词
                IEnumerable<KeyValuePair<double, LyricModel>> s = Lyrics.Where(m => nowtime >= m.Key);
                if (s.Count() > 0)
                {
                    LyricModel lm = s.Last().Value;
                    FocusLyric.LyricTextblock.Foreground = DefaultLyricsColor;

                    FocusLyric = lm;
                    FocusLyric.LyricTextblock.Foreground = FocusLyricsColor;
                    //定位歌词在控件中间区域
                    ResetLrcviewScroll();
                }
                else
                {

                }
            }
        }
        #endregion

        #region 调整歌词控件滚动条位置
        public void ResetLrcviewScroll()
        {
            //获得焦点歌词位置
            GeneralTransform gf = FocusLyric.LyricTextblock.TransformToVisual(LyricParentControl);
            Point p = gf.Transform(new Point(0, 0));

            //计算滚动位置（p.Y是焦点歌词控件(c_LrcTb)相对于父级控件c_lrc_items(StackPanel)的位置）
            //拿焦点歌词位置减去滚动区域控件高度除以2的值得到的【大概】就是歌词焦点在滚动区域控件的位置
            double os = p.Y - (LyricScroll.ActualHeight / 2) + 10;

            //滚动
            DoubleAnimation db = new DoubleAnimation();
            db.To = os;
            db.Duration = TimeSpan.FromMilliseconds(600);
            db.EasingFunction = new BackEase() { Amplitude = 0.2, EasingMode = EasingMode.EaseOut };
            Timeline.SetDesiredFrameRate(db, 90);

            LyricScroll.BeginAnimation(ScrollViewerBehavior.VerticalOffsetProperty, db);
           
            //LyricScroll.ScrollToVerticalOffset(os);

        }
        #endregion

    }

    public class LyricModel
    {
        //歌词字符串
        public string LyricText { get; set; }

        //歌词所在控件
        public TextBlock LyricTextblock { get; set; }

        //时间（读取格式参照网易云音乐歌词格式：xx:xx.xx，即分:秒.毫秒，秒小数点保留2位。如：00:28.64）
        public string Time { get; set; }
    }
}
