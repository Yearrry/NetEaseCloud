using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace NetEase_clund_music.Commom
{
    public  class AnimationHelper
    {
        /// <summary>
        /// 弹出动画
        /// </summary>
        /// <param name="statu">收/缩</param>
        /// <param name="isposition">效果否</param>
        /// <param name="button">激发按钮</param>
        /// <param name="moveElement">移动的元素</param>
        /// <param name="collapsedElement">显示的元素</param>
        /// <param name="x">位置（跟随显示的才需要）</param>
        /// <param name="y">位置（跟随显示的才需要）</param>
        /// <param name="type">动画方向   上下左右</param>
        /// <param name="beginTime"> 开始时间</param>
        /// <param name="window"></param>
        public static Task Positioning(bool statu, bool isposition, FrameworkElement button, FrameworkElement moveElement, FrameworkElement collapsedElement,
           double x, double y, TransitionType type, TimeSpan beginTime,FrameworkElement window)
        {
            if (moveElement.FindName("translate1") == null && collapsedElement.Visibility == Visibility.Visible)
            {
                return Task.CompletedTask;
            }

            double Sleep = 0;

            Storyboard storyboard = new Storyboard();
            storyboard.BeginTime = beginTime;
            ObjectAnimationUsingKeyFrames frames = new ObjectAnimationUsingKeyFrames();
            ObjectKeyFrameCollection collection = new ObjectKeyFrameCollection();
            DiscreteObjectKeyFrame discrete = new DiscreteObjectKeyFrame();

            DiscreteObjectKeyFrame discrete2 = new DiscreteObjectKeyFrame();

            if (statu)
            {
                discrete.KeyTime = TimeSpan.FromMilliseconds(0);
                discrete.Value = Visibility.Collapsed;

                discrete2.KeyTime = TimeSpan.FromMilliseconds(50);
                discrete2.Value = Visibility.Visible;
            }
            else
            {
                discrete.KeyTime = TimeSpan.FromMilliseconds(0);
                discrete.Value = Visibility.Visible;

                discrete2.KeyTime = TimeSpan.FromMilliseconds(50);
                discrete2.Value = Visibility.Collapsed;
            }
            collection.Add(discrete);
            collection.Add(discrete2);
            frames.KeyFrames = collection;

            Storyboard.SetTargetName(frames, collapsedElement.Name);
            Storyboard.SetTargetProperty(frames, new PropertyPath(UIElement.VisibilityProperty));
            storyboard.Children.Add(frames);

            if (isposition)
            {
                Point point = button.TransformToAncestor(window).Transform(new Point(0, 0));
                if (type == TransitionType.Left) moveElement.Margin = new Thickness(point.X + x - 20, point.Y - y, 0, 0);
                else if (type == TransitionType.Right) moveElement.Margin = new Thickness(point.X + x + 20, point.Y - y, 0, 0);
                else if (type == TransitionType.Top) moveElement.Margin = new Thickness(point.X + x, point.Y - y - 20, 0, 0);
                else moveElement.Margin = new Thickness(point.X + x, point.Y - y + 20, 0, 0);
            }

            if (type == TransitionType.Left || type == TransitionType.Top)
            {
                Sleep = 20;
            }
            else
            {
                Sleep = -20;
            }

            DoubleAnimation doubleAnimation2;
            if (statu)
            {
                doubleAnimation2 = new DoubleAnimation() { To = Sleep, Duration = TimeSpan.FromMilliseconds(500), EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.3 } };
            }
            else
            {
                doubleAnimation2 = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(500), EasingFunction = new BackEase { EasingMode = EasingMode.EaseIn, Amplitude = 0.3 } };
            }

            if (type == TransitionType.Left || type == TransitionType.Right)
            {
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(TranslateTransform.XProperty));
            }
            else
            {
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath(TranslateTransform.YProperty));
            }

            if (moveElement.FindName("translate1") == null && statu == true)
            {
                TranslateTransform translate1 = new TranslateTransform();
                moveElement.RenderTransform = translate1;
                window.RegisterName("translate1", translate1);
                Storyboard.SetTargetName(doubleAnimation2, "translate1");
                storyboard.Children.Add(doubleAnimation2);
                moveElement.BeginStoryboard(storyboard);
            }
            else
            {
                if (collapsedElement.Visibility == Visibility.Visible)
                {
                    collection.Remove(discrete2);
                    DiscreteObjectKeyFrame discrete3 = new DiscreteObjectKeyFrame();
                    discrete3.KeyTime = TimeSpan.FromMilliseconds(500);
                    discrete3.Value = Visibility.Collapsed;
                    collection.Add(discrete3);
                }
                Storyboard.SetTargetName(doubleAnimation2, "translate1");
                storyboard.Children.Add(doubleAnimation2);
                moveElement.BeginStoryboard(storyboard);
                window.UnregisterName("translate1");
            }
            return Task.CompletedTask;
        }

        //弹出动画 、 不跟随
         public static void Positioning(bool statu,FrameworkElement moveElement, TransitionType type, TimeSpan beginTime,double distance = 20)
        {
            if ((moveElement.Visibility == Visibility.Visible && statu == true) || (moveElement.Visibility == Visibility.Collapsed && statu == false))
            {
                return;
            }

            double Sleep = 0;

            if (type == TransitionType.Left || type == TransitionType.Top)
            {
                Sleep = distance;
            }
            else
            {
                Sleep = - distance;
            }

            //如果没有初始的位移就加一个
            if (moveElement.RenderTransform as TranslateTransform == null)
            {
                TranslateTransform translate1 = new TranslateTransform();
                moveElement.RenderTransform = translate1;
            }

            //实例
            Storyboard storyboard = new Storyboard();
            Storyboard.SetTargetName(storyboard, moveElement.Name);
            storyboard.BeginTime = beginTime;

            DoubleAnimation doubleAnimation2;

            ObjectAnimationUsingKeyFrames frames = new ObjectAnimationUsingKeyFrames();
            ObjectKeyFrameCollection collection = new ObjectKeyFrameCollection();

            DiscreteObjectKeyFrame discrete = new DiscreteObjectKeyFrame();
            DiscreteObjectKeyFrame discrete2 = new DiscreteObjectKeyFrame();

            collection.Add(discrete);
            collection.Add(discrete2);
            frames.KeyFrames = collection;
        
            //根据状态判断是显示还是隐藏
            if (statu)
            {
                discrete.KeyTime = TimeSpan.FromMilliseconds(0);
                discrete.Value = Visibility.Collapsed;

                discrete2.KeyTime = TimeSpan.FromMilliseconds(50);
                discrete2.Value = Visibility.Visible;

                doubleAnimation2 = new DoubleAnimation() { To = Sleep, Duration = TimeSpan.FromMilliseconds(500), EasingFunction = new BackEase { EasingMode = EasingMode.EaseOut, Amplitude = 0.3 } };
            }
            else
            {
                discrete.KeyTime = TimeSpan.FromMilliseconds(0);
                discrete.Value = Visibility.Visible;

                discrete2.KeyTime = TimeSpan.FromMilliseconds(500);
                discrete2.Value = Visibility.Collapsed;

                doubleAnimation2 = new DoubleAnimation() { Duration = TimeSpan.FromMilliseconds(500), EasingFunction = new BackEase { EasingMode = EasingMode.EaseIn, Amplitude = 0.3 } };
            }

            //绑定执行动画的属性
            if (type == TransitionType.Left || type == TransitionType.Right)
            {
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("RenderTransform.(TranslateTransform.X)"));
            }
            else
            {
                Storyboard.SetTargetProperty(doubleAnimation2, new PropertyPath("RenderTransform.(TranslateTransform.Y)"));
            }

            Storyboard.SetTargetProperty(frames, new PropertyPath(UIElement.VisibilityProperty));

            storyboard.Children.Add(frames);
            storyboard.Children.Add(doubleAnimation2);

            storyboard.Begin(moveElement);
        }

    }
}
