using GalaSoft.MvvmLight;
using System;
using System.Reflection;
using System.Windows;

namespace NetEase_clund_music.ViewModel
{
    public class FindMusicViewModel : ViewModelBase
    {
        public FindMusicViewModel()
        {
       
        }

     

        private FrameworkElement contentControl;

        public FrameworkElement ContentControl
        {
            get { return contentControl; }
            set { contentControl = value; RaisePropertyChanged(); }
        }

        public void ActivateControl(string name)
        {
            Type type = Type.GetType("NetEase_clund_music.Views.FindMusicUserControl." + name);
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            ContentControl = (FrameworkElement)cti.Invoke(null);
        } 
    }
}
