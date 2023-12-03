using NetEase_clund_music.Model;
using NetEase_clund_music.ViewModel;
using NetEase_clund_music.Views;
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
    
    public class SongerButton : CustomButtonBase
    {
         static SongerButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SongerButton), new FrameworkPropertyMetadata(typeof(SongerButton)));
        }

        public SongerButton()
        {
            CustomType = ButtonType.歌手;
        }



        public string Conditions
        {
            get { return (string)GetValue(ConditionsProperty); }
            set { SetValue(ConditionsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for conditions.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ConditionsProperty =
            DependencyProperty.Register("Conditions", typeof(string), typeof(SongerButton), new PropertyMetadata(""));

        protected override void OnClick()
        {
            base.OnClick();

            ChangeContentEventArgs changedEvent = new ChangeContentEventArgs(ChangedContentEvent, this);

            object[] parameters = { Conditions };

            changedEvent.parameters = parameters;
            changedEvent.viewName = "ArtistPage";

            this.RaiseEvent(changedEvent);
        }
    }

}
