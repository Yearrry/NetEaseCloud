using NetEase_clund_music.Commom;
using NetEase_clund_music.Commom.CommomControl;
using NetEase_clund_music.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Views
{
    /// <summary>
    /// ArtistPage.xaml 的交互逻辑
    /// </summary>
    public partial class ArtistPage : UserControl
    {
        public ArtistPage()
        {
            InitializeComponent();
        }

        ArtistPageViewModel viewmodel;

        public ArtistPage(string str)
        {
            InitializeComponent();

            viewmodel = new ArtistPageViewModel(str);

            this.DataContext = viewmodel;

            modelDictionary.Add(AlbumButton, AlbumBorder);
            modelDictionary.Add(MVButton, MvBorder);
            modelDictionary.Add(ArtistButton, ArtistData);
            modelDictionary.Add(SimilarButton, SimilarityArtist);
        }

        //

        RadioButton CheckButton;

        public Dictionary<RadioButton, Border> modelDictionary = new Dictionary<RadioButton, Border>();

        private void StackPanel_Click(object sender, RoutedEventArgs e)
        {
            RadioButton newCheckButton = e.OriginalSource as RadioButton;

            if(CheckButton == newCheckButton)
            {
                return;
            }

            CheckButton = newCheckButton;

            foreach (Border item in modelDictionary.Values)
            {
                if (item.Visibility == Visibility.Visible)
                {
                    AnimationHelper.Positioning(false, false, null, item, item, 0, 0, TransitionType.Right, TimeSpan.FromMilliseconds(0), this);
                }
            }

            foreach (RadioButton box in modelDictionary.Keys)
            {
                if (box == newCheckButton)
                {
                    AnimationHelper.Positioning(true, false, null, modelDictionary[box], modelDictionary[box], 0, 0, TransitionType.Left, TimeSpan.FromMilliseconds(500), this);
                }
            }

            Animationfun(CheckButton);

            e.Handled = true;
        }

        public void Animationfun(FrameworkElement button)
        {
            DoubleAnimation db = new DoubleAnimation();
            db.To = button.TransformToAncestor(this).Transform(new Point(0, 0)).X;
            db.Duration = TimeSpan.FromMilliseconds(700);
            db.EasingFunction = new BackEase() { Amplitude = 0.3, EasingMode = EasingMode.EaseOut };

            borderSubscript.RenderTransform.BeginAnimation(TranslateTransform.XProperty, db);
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            AlbumButton.IsChecked = true;
            CheckButton = AlbumButton;
            borderSubscript.Width = 60;
            Animationfun(CheckButton);
            AnimationHelper.Positioning(true, false, null, AlbumBorder, AlbumBorder, 0, 0, TransitionType.Left, TimeSpan.FromMilliseconds(500), this);

            lisAlbumView.View = (ViewBase)this.FindResource("LargerViewMode");

            
        }

        private void StackPanel_Click_1(object sender, RoutedEventArgs e)
        {
            RadioButton rb = e.OriginalSource as RadioButton;

            viewmodel.AblumsmallReset();

            if (!string.IsNullOrWhiteSpace(rb.Tag.ToString()))
            {
                if(rb.Tag.ToString() == "TheListMode")
                {
                    lisAlbumView.AlternationCount = 2;
                }
                else
                {
                    lisAlbumView.AlternationCount = 1;
                }

                lisAlbumView.View = (ViewBase)this.FindResource(rb.Tag);
            }

            e.Handled = true;
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

        bool code;double oldHeight;

        private async void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            double offset = Convert.ToDouble((e.OriginalSource as TextBox).Text);

            double scrHeight = Convert.ToDouble(scrollHeight.Text);

            if (scrHeight >= oldHeight ) code = false;

            if (offset > (scrHeight * 0.7))
            {
                if (code)
                {
                    return;
                }
                await  viewmodel.AlbumsmallAdd();
                code = true;
                oldHeight = Convert.ToDouble(scrollHeight.Text);
            }
        }

        private void ListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListBox listbox = sender as ListBox;

            var s = listbox.SelectedItem as ListBoxItem;

            RoutedEventArgs changed = new RoutedEventArgs(PlayDataGrid.PlayChangedEvent, s);

            listbox.RaiseEvent(changed);
        }
    }
}
