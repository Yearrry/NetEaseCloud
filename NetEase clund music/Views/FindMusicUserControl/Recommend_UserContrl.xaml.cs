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
    /// Recommend_UserContrl.xaml 的交互逻辑
    /// </summary>
    public partial class Recommend_UserContrl : UserControl
    {
        ListBoxItem leftBoxitem;
        ListBoxItem RightBoxitem;
        System.Timers.Timer t = new System.Timers.Timer(3000);
        localDb db;
        public Recommend_UserContrl()
        {
            InitializeComponent();
            db = new localDb();
        }
        ~Recommend_UserContrl()
        {
            t.Stop();
            t.Enabled = false;
        }

        private void Recommend_Loaded(object sender, RoutedEventArgs e)
        {
            init();
            t.Elapsed += T_Elapsed;
            t.AutoReset = true;
            t.Enabled = true;
            t.Start();
            shilidonhua();
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

        //先实例动画  看看能不能提速
        DoubleAnimation LeftOneDbanimation = new DoubleAnimation();
        DoubleAnimation LeftTwoDbanimation = new DoubleAnimation();
        DoubleAnimation LeftThreeDbanimation = new DoubleAnimation();
        DoubleAnimation LeftFourDbanimation = new DoubleAnimation();
        DoubleAnimation RightOneDbanimation = new DoubleAnimation();
        DoubleAnimation RightTwoDbanimation = new DoubleAnimation();
        DoubleAnimation RightThreeDbanimation = new DoubleAnimation();
        DoubleAnimation RightFourDbanimation = new DoubleAnimation();

        public void shilidonhua()
        {
            LeftOneDbanimation.EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn };
            LeftOneDbanimation.To = 0;
            LeftOneDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetName(LeftOneDbanimation, "RightBoxItem");

            LeftTwoDbanimation.To = 0;
            LeftTwoDbanimation.Duration = TimeSpan.FromMilliseconds(5000);
            LeftTwoDbanimation.EasingFunction = new ElasticEase() { Oscillations = 4, Springiness = 30, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(LeftTwoDbanimation, "RightBoxItem");

            LeftThreeDbanimation.To = 200;
            LeftThreeDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            //dbanimation2.EasingFunction = new ElasticEase() { Oscillations = 2, Springiness = 20, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(LeftThreeDbanimation, "RightBoxItem");

            LeftFourDbanimation.To = -200;
            LeftFourDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            //dbanimation4.EasingFunction = new ElasticEase() { Oscillations = 2 , Springiness = 20, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(LeftFourDbanimation, "LeftBoxItem");

            RightOneDbanimation.EasingFunction = new BackEase() { EasingMode = EasingMode.EaseIn };
            RightOneDbanimation.To = 0;
            RightOneDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            Storyboard.SetTargetName(LeftOneDbanimation, "LeftBoxItem");

            RightTwoDbanimation.To = 0;
            RightTwoDbanimation.Duration = TimeSpan.FromMilliseconds(5000);
            RightTwoDbanimation.EasingFunction = new ElasticEase() { Oscillations = 4, Springiness = 30, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(LeftTwoDbanimation, "LeftBoxItem");

            RightThreeDbanimation.To = 200;
            RightThreeDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            //dbanimation2.EasingFunction = new ElasticEase() { Oscillations = 2, Springiness = 20, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(RightThreeDbanimation, "LeftBoxItem");

            RightFourDbanimation.To = -200;
            RightFourDbanimation.Duration = TimeSpan.FromMilliseconds(300);
            //dbanimation4.EasingFunction = new ElasticEase() { Oscillations = 2 , Springiness = 20, EasingMode = EasingMode.EaseOut };
            Storyboard.SetTargetName(RightFourDbanimation, "RightBoxItem");

        }

        private void leftMove(object sender, RoutedEventArgs e)
        {
            int olditem = 0;

            Task.Run(async () =>
            {
                await Task.Run(() =>{
                     Dispatcher.Invoke(() =>
                {
                    foreach (ListBoxItem item in LunboListBox.Items)
                    {
                        if (item.IsSelected)
                        {
                            item.IsSelected = false;
                            int newitem = olditem - 1;

                            Panel.SetZIndex(RightBoxitem, 0);
                            RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, LeftOneDbanimation);
                            this.UnregisterName("RightBoxItem");

                            leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, LeftTwoDbanimation);
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
                          
                            RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, LeftThreeDbanimation);

                            leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, LeftFourDbanimation);
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
                await Task.Run(() => {
                    Dispatcher.Invoke(() =>
                    {
                        foreach (ListBoxItem item in LunboListBox.Items)
                        {
                            if (item.IsSelected)
                            {
                                item.IsSelected = false;
                                int newitem = olditem + 1;

                                Panel.SetZIndex(leftBoxitem, 0);
                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, RightOneDbanimation);
                                this.UnregisterName("LeftBoxItem");

                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, RightTwoDbanimation);
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

                                RightBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, RightThreeDbanimation);

                                leftBoxitem.RenderTransform.BeginAnimation(TranslateTransform.XProperty, RightFourDbanimation);

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
                     LunboListBox.ItemsSource = db.GetList<ListBoxItem>("listBoxItemsOne");
                     LunboListBox.SelectedItem = LunboListBox.Items[1];

                    List<ListBoxItem> iconitem = new List<ListBoxItem>();

                    for (int i = 0; i < db.GetList<ListBoxItem>("HostStationListBoxItems").Count; i++)
                    {
                        iconitem.Add(new ListBoxItem());
                    }

                    signbyLunboList.ItemsSource = iconitem;
                    signbyLunboList.SelectedItem = signbyLunboList.Items[1];
                  
                    RecommendSongList.ItemsSource = db.GetList<SongList>("SongListsOne");

                    ExclusiveOverBox.ItemsSource = db.GetList<Exclusiveover>("Exclusiveovers");

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
            if(RightBoxitem.FindName("RightBoxItem") == null)
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
        private void listbox_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
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

    }
}
