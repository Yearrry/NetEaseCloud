using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetEase_clund_music.ViewModel
{
    public class MusicTableViewModel:ViewModelBase
    {
        public MusicTableViewModel()
        {
            CustomType = Commom.CommomControl.CustomType.默认;
        }


        private Commom.CommomControl.CustomType customType;

        public Commom.CommomControl.CustomType CustomType
        {
            get { return customType; }
            set { customType = value; }
        }



    }
}
