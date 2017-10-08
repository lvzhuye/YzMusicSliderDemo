using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YzWangYiMusicSliderDemo
{
    public class YzSliderNavListBox:ListBox
    {
        public YzSliderNavListBox()
        {
            this.DefaultStyleKey = typeof(YzSliderNavListBox);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new YzSliderNavItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return false;
        }  

    }
}
