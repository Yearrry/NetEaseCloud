using NetEase_clund_music.Commom.CommomControl;
using System;
using System.Windows;

namespace NetEase_clund_music
{

    public class AlbumButton : CustomButtonBase
    {
        static AlbumButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(AlbumButton), new FrameworkPropertyMetadata(typeof(AlbumButton)));
        }

        public AlbumButton()
        {
            CustomType = ButtonType.专辑;
        }

        public Model.album Album
        {
            get { return (Model.album)GetValue(AlbumProperty); }
            set { SetValue(AlbumProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Album.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AlbumProperty =
            DependencyProperty.Register("Album", typeof(Model.album), typeof(AlbumButton), new PropertyMetadata(new Model.album()));

        protected override void OnClick()
        {
            base.OnClick();

            ChangeContentEventArgs eventargs = new ChangeContentEventArgs(ChangedContentEvent, this);

            object[] parameters = { CustomType, Album };

            eventargs.parameters = parameters;

            eventargs.viewName = "NetEase_clund_music.Commom.CommomControl.SongList";



            this.RaiseEvent(eventargs);
        }

    }
}
