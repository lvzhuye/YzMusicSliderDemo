using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace YzWangYiMusicSliderDemo
{
    public class YzSliderNavItem:ListBoxItem
    {
        public YzSliderNavItem()
        {
            this.DefaultStyleKey = typeof(YzSliderNavItem);
        }

        public static readonly RoutedEvent SliderNavMouseEnterEvent = EventManager.RegisterRoutedEvent("SliderNavMouseEnter", RoutingStrategy.Bubble, typeof(EventHandler<SliderNavRoutedEventArgs>), typeof(YzSliderNavItem));

        public event RoutedEventHandler SliderNavMouseEnter
        {
            add { AddHandler(SliderNavMouseEnterEvent, value); }
            remove { RemoveHandler(SliderNavMouseEnterEvent, value); }
        }

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            SliderNavRoutedEventArgs navMouseEnterArgs = new SliderNavRoutedEventArgs(YzSliderNavItem.SliderNavMouseEnterEvent,this);
            navMouseEnterArgs.MouseEnterItem = this.Content;
            RaiseEvent(navMouseEnterArgs);
        }
    }

    public class SliderNavRoutedEventArgs:RoutedEventArgs
    {
        public object MouseEnterItem { get; set; }

        public SliderNavRoutedEventArgs(RoutedEvent routedEvent,object source) : base(routedEvent,source)
        {

        }
    }
}
