using NetEase_clund_music.Db;
using NetEase_clund_music.Model;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NetEase_clund_music.Views.FindMusicUserControl
{
    /// <summary>
    /// HostStation.xaml 的交互逻辑
    /// </summary>
    public partial class HostStation  : UserControl
    {
        ListBoxItem leftBoxitem;
        ListBoxItem RightBoxitem;
        System.Timers.Timer t = new System.Timers.Timer(3000);
        localDb db;

        public HostStation()
        {
            InitializeComponent();
            db = new localDb();
        }

        ~HostStation(){
            t.Stop();
        }
        private void HostStation_Loaded(object sender, RoutedEventArgs e)
        {
            init();
            t.Elapsed += T_Elapsed;
            t.AutoReset = true;
            t.Enabled = true;
            t.Start();
        }

        private void T_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            t.Stop();
            this.Dispatcher.Invoke(() =>
            {
                RightMove(sender, new RoutedEventArgs());
            });
            t.Start();
        }

        private void leftMove(object sender, RoutedEventArgs e)
        {
            int olditem = 0;
            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        foreach (ListBoxItem item in LunboListBox.Items)
                        {
                            if (item.IsSelected)
                            {
                                item.IsSelected = false;
                                int newitem = olditem - 1;

                                Panel.SetZIndex(RightBoxitem, 0);
                                DoubleAnimation dbanimation = new DoubleAnimation();
                                dbanimation.EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn };
                                dbanimation.To = 0;
                                dbanimation.Duration = TimeSpan.FromMilliseconds(300);
                                Storyboard.SetTargetName(dbanimation, "RightBoxItem");
                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation);
                                this.UnregisterName("RightBoxItem");

                                DoubleAnimation dbanimation3 = new DoubleAnimation();
                                dbanimation3.To = 0;
                                dbanimation3.Duration = TimeSpan.FromMilliseconds(5000);
                                dbanimation3.EasingFunction = new ElasticEase() { Oscillations = 2, Springiness = 30, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation3, "LeftBoxItem");
                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation3);
                                this.UnregisterName("LeftBoxItem");

                                TranslateTransform ttf = new TranslateTransform();
                                ttf.X = 0;
                                item.RenderTransform = ttf;
                                this.RegisterName("RightBoxItem", ttf);
                                RightBoxitem = item;

                                if (newitem == 0)
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[0];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[0];

                                    Panel.SetZIndex(LunboListBox.Items[LunboListBox.Items.Count - 1] as ListBoxItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("LeftBoxItem", ttf2);
                                    (LunboListBox.Items[LunboListBox.Items.Count - 1] as ListBoxItem).RenderTransform = ttf2;
                                    leftBoxitem = LunboListBox.Items[LunboListBox.Items.Count - 1] as ListBoxItem;
                                }
                                else if (newitem < 0)
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[LunboListBox.Items.Count - 1];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[signbyLunboList.Items.Count - 1];

                                    Panel.SetZIndex(LunboListBox.Items[LunboListBox.Items.Count - 1] as ListBoxItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("LeftBoxItem", ttf2);
                                    (LunboListBox.Items[LunboListBox.Items.Count - 2] as ListBoxItem).RenderTransform = ttf2;
                                    leftBoxitem = LunboListBox.Items[LunboListBox.Items.Count - 2] as ListBoxItem;
                                }
                                else
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[newitem];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[newitem];

                                    Panel.SetZIndex(LunboListBox.Items[LunboListBox.Items.Count - 1] as ListBoxItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("LeftBoxItem", ttf2);
                                    (LunboListBox.Items[newitem - 1] as ListBoxItem).RenderTransform = ttf2;
                                    leftBoxitem = LunboListBox.Items[newitem - 1] as ListBoxItem;
                                }

                                Panel.SetZIndex(RightBoxitem, 2);
                                DoubleAnimation dbanimation2 = new DoubleAnimation();
                                dbanimation2.To = 200;
                                dbanimation2.Duration = TimeSpan.FromMilliseconds(300);
                                //dbanimation2.EasingFunction = new ElasticEase() { Oscillations = 2, Springiness = 20, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation2, "RightBoxItem");
                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation2);

                                DoubleAnimation dbanimation4 = new DoubleAnimation();
                                dbanimation4.To = -200;
                                dbanimation4.Duration = TimeSpan.FromMilliseconds(300);
                                //dbanimation4.EasingFunction = new ElasticEase() { Oscillations = 2 , Springiness = 20, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation4, "LeftBoxItem");
                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation4);
                                return;
                            }
                            else
                            {
                                olditem++;
                            }
                        }
                    });
                });
            });
        }

        private void RightMove(object sender, RoutedEventArgs e)
        {
            int olditem = 0;
            Task.Run(async () =>
            {
                await Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        foreach (ListBoxItem item in LunboListBox.Items)
                        {
                            if (item.IsSelected)
                            {
                                item.IsSelected = false;
                                int newitem = olditem + 1;

                                Panel.SetZIndex(leftBoxitem, 0);
                                DoubleAnimation dbanimation = new DoubleAnimation();
                                dbanimation.EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn };
                                dbanimation.To = 0;
                                dbanimation.Duration = TimeSpan.FromMilliseconds(300);
                                Storyboard.SetTargetName(dbanimation, "LeftBoxItem");
                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation);
                                this.UnregisterName("LeftBoxItem");

                                DoubleAnimation dbanimation3 = new DoubleAnimation();
                                dbanimation3.To = 0;
                                dbanimation3.Duration = TimeSpan.FromMilliseconds(5000);
                                dbanimation3.EasingFunction = new ElasticEase() { Oscillations = 4, Springiness = 30, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation3, "RightBoxItem");
                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation3);
                                this.UnregisterName("RightBoxItem");

                                TranslateTransform ttf = new TranslateTransform();
                                ttf.X = 0;
                                item.RenderTransform = ttf;
                                this.RegisterName("LeftBoxItem", ttf);
                                leftBoxitem = item;

                                if (newitem == LunboListBox.Items.Count)
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[0];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[0];

                                    ListBoxItem RightItem = LunboListBox.Items[1] as ListBoxItem;

                                    Panel.SetZIndex(RightItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("RightBoxItem", ttf2);
                                    RightItem.RenderTransform = ttf2;
                                    RightBoxitem = RightItem;
                                }
                                else if (newitem + 1 == LunboListBox.Items.Count)
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[newitem];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[newitem];

                                    ListBoxItem RightItem = LunboListBox.Items[0] as ListBoxItem;

                                    Panel.SetZIndex(RightItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("RightBoxItem", ttf2);
                                    RightItem.RenderTransform = ttf2;
                                    RightBoxitem = RightItem;
                                }
                                else
                                {
                                    LunboListBox.SelectedItem = LunboListBox.Items[newitem];
                                    signbyLunboList.SelectedItem = signbyLunboList.Items[newitem];

                                    ListBoxItem RightItem = LunboListBox.Items[newitem + 1] as ListBoxItem;

                                    Panel.SetZIndex(RightItem, 1);
                                    TranslateTransform ttf2 = new TranslateTransform();
                                    ttf2.X = 0;
                                    this.RegisterName("RightBoxItem", ttf2);
                                    RightItem.RenderTransform = ttf2;
                                    RightBoxitem = RightItem;
                                }

                                Panel.SetZIndex(RightBoxitem, 2);
                                DoubleAnimation dbanimation2 = new DoubleAnimation();
                                dbanimation2.To = 200;
                                dbanimation2.Duration = TimeSpan.FromMilliseconds(300);
                                //dbanimation2.EasingFunction = new ElasticEase() { Oscillations = 2, Springiness = 20, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation2, "RightBoxItem");
                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation2);

                                DoubleAnimation dbanimation4 = new DoubleAnimation();
                                dbanimation4.To = -200;
                                dbanimation4.Duration = TimeSpan.FromMilliseconds(300);
                                //dbanimation4.EasingFunction = new ElasticEase() { Oscillations = 2 , Springiness = 20, EasingMode = EasingMode.EaseOut };
                                Storyboard.SetTargetName(dbanimation4, "LeftBoxItem");
                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimation4);

                                return;
                            }
                            else
                            {
                                olditem++;
                            }
                        }
                    });
                });
            });
        }

        public void init()
        {
            Task.Run(() =>
            {
                Dispatcher.Invoke(() =>
                {
                    LunboListBox.ItemsSource = db.GetList<ListBoxItem>("HostStationListBoxItems");
                    LunboListBox.SelectedItem = LunboListBox.Items[0];


                    List<ListBoxItem> iconitem = new List<ListBoxItem>();

                    for (int i = 0; i < db.GetList<ListBoxItem>("HostStationListBoxItems").Count; i++)
                    {
                        iconitem.Add(new ListBoxItem());
                    }

                    signbyLunboList.ItemsSource = iconitem;
                    signbyLunboList.SelectedItem = signbyLunboList.Items[0];


                    ChangedHelper();
                });
            });
        }

        DoubleAnimation dbanimationleft = new DoubleAnimation();
        DoubleAnimation dbanimationright = new DoubleAnimation();

        public void ChangedHelper()
        {
            ListBox listbox = LunboListBox as ListBox;
            int icon = 0;
            int Code = 0;

            foreach (ListBoxItem item in listbox.Items)
            {
                if (item.IsSelected)
                {
                    Code = icon;
                }
                else
                {
                    icon++;
                }
            }
            if (Code - 1 < 0)
            {
                leftBoxitem = LunboListBox.Items[listbox.Items.Count - 1] as ListBoxItem;
            }
            else
            {
                leftBoxitem = listbox.Items[Code - 1] as ListBoxItem;
            }
            if (Code == listbox.Items.Count - 1)
            {
                RightBoxitem = listbox.Items[0] as ListBoxItem;
            }
            else
            {
                RightBoxitem = listbox.Items[Code + 1] as ListBoxItem;
            }
            if (leftBoxitem.FindName("LeftBoxItem") == null)
            {
                TranslateTransform x = new TranslateTransform();

                x.X = 0;
                leftBoxitem.RenderTransform = x;
                this.RegisterName("LeftBoxItem", x);

            }
            if (RightBoxitem.FindName("RightBoxItem") == null)
            {
                TranslateTransform xx = new TranslateTransform();

                xx.X = 0;
                RightBoxitem.RenderTransform = xx;
                this.RegisterName("RightBoxItem", xx);
            }

            dbanimationleft.To = -200;
            dbanimationleft.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetName(dbanimationleft, "LeftBoxItem");

            dbanimationright.To = 200;
            dbanimationright.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetName(dbanimationright, "RightBoxItem");

            leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimationleft);
            RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, dbanimationright);
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

        private void StopTimer(object sender, MouseEventArgs e)
        {
            t.Stop();
        }

        private void StartTimer(object sender, MouseEventArgs e)
        {
            t.Start();
        }

        bool start = false;

        private void RightButton_Click(object sender, RoutedEventArgs e)
        {
            if(start == true)
            {
                return;
            }
            Task.Run(async () =>
            {
                start = true;
                await Task.Run(async () =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        Double y = radioShowList.ActualWidth;
                        var z = RenderSize.Width;

                        Double Trans = rankingListButtontrans.X;

                        if ((Math.Abs(Trans) + 645) > y)
                        {
                            return;
                        }

                        DoubleAnimation dbanimation = new DoubleAnimation();
                        Timeline.SetDesiredFrameRate(dbanimation, 144);
                        dbanimation.Duration = TimeSpan.FromMilliseconds(1000);
                        dbanimation.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };

                        DoubleAnimation dbanimatione = new DoubleAnimation();
                        dbanimatione.Duration = TimeSpan.FromMilliseconds(0);
                        dbanimatione.To = 0;

                        if (rankingButton.Width != 0)
                        {
                            rankingButton.BeginAnimation(WidthProperty, dbanimatione);
                        }
                        if ((Math.Abs(Trans) + 1290) > y)
                        {
                            DoubleAnimation dbanimations = new DoubleAnimation();
                            dbanimations.To = 0;
                            dbanimations.Duration = TimeSpan.FromMilliseconds(300);
                            RightBorder.BeginAnimation(WidthProperty, dbanimations);
                            rightButton.IsEnabled = false;
                        }

                        if (Trans == -645)
                        {
                            dbanimation.By = -690;
                        }
                        else if (Trans == 0)
                        {
                            dbanimation.By = -645;
                            DoubleAnimation dbanimations = new DoubleAnimation();
                            dbanimations.To = 50;
                            dbanimations.Duration = TimeSpan.FromMilliseconds(300);
                            Leftborder.BeginAnimation(WidthProperty, dbanimations);
                            leftbutton.IsEnabled = true;
                        }
                        else
                        {
                            dbanimation.By = -645;
                        }

                        rankingListButtontrans.BeginAnimation(TranslateTransform.XProperty, dbanimation);
                    });
                    await Task.Delay(1000);
                });
                start = false;
            });
        }

        private void LeftButton_Click(object sender, RoutedEventArgs e)
        {
            if (start == true)
            {
                return;
            }
          
            Task.Run(async () =>
            {
                start = true;

                await Task.Run(async() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        Double y = radioShowList.ActualWidth;
                        var z = RenderSize.Width;

                        Double Trans = rankingListButtontrans.X;

                        if (Trans == 0)
                        {
                            return;
                        }

                        DoubleAnimation dbanimation = new DoubleAnimation();
                        Timeline.SetDesiredFrameRate(dbanimation, 144);
                        dbanimation.Duration = TimeSpan.FromMilliseconds(1000);
                        dbanimation.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };

                        DoubleAnimation dbanimatione = new DoubleAnimation();
                        dbanimatione.Duration = TimeSpan.FromMilliseconds(0);

                        if (Trans == -645)
                        {
                            rankingButton.BeginAnimation(WidthProperty, dbanimatione);
                        }

                        if (Trans == -1335)
                        {
                            dbanimation.By = 690;
                            DoubleAnimation dbanimations = new DoubleAnimation();
                            dbanimations.To = 50;
                            dbanimations.Duration = TimeSpan.FromMilliseconds(300);
                            RightBorder.BeginAnimation(WidthProperty, dbanimations);
                            rightButton.IsEnabled = true;
                        }
                        else
                        {
                            dbanimation.By = 645;
                            if (Trans + 645 == 0)
                            {
                                DoubleAnimation dbanimations = new DoubleAnimation();
                                dbanimations.To = 0;
                                dbanimations.Duration = TimeSpan.FromMilliseconds(300);
                                Leftborder.BeginAnimation(WidthProperty, dbanimations);
                                leftbutton.IsEnabled = false;
                            }
                        }
                        rankingListButtontrans.BeginAnimation(TranslateTransform.XProperty, dbanimation);
                    });
                    await Task.Delay(1000);
                });
               
                start = false;
            });
        }
    }
}
