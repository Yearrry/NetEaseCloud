using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace NetEase_clund_music.ResuourceHome.PropertyHelper
{
    public class Btn_Attached
    {
        public static bool GetInform(DependencyObject obj)
        {
            return (bool)obj.GetValue(InformProperty);
        }

        public static void SetInform(DependencyObject obj, bool value)
        {
            obj.SetValue(InformProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty InformProperty =
            DependencyProperty.RegisterAttached("Inform", typeof(bool), typeof(Btn_Attached), new PropertyMetadata(false));



        public static bool GetCardiac(DependencyObject obj)
        {
            return (bool)obj.GetValue(CardiacProperty);
        }

        public static void SetCardiac(DependencyObject obj, bool value)
        {
            obj.SetValue(CardiacProperty, value);
        }

        // Using a DependencyProperty as the backing store for Cardiac.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CardiacProperty =
            DependencyProperty.RegisterAttached("Cardiac", typeof(bool), typeof(Btn_Attached), new PropertyMetadata(false));

    }
}
