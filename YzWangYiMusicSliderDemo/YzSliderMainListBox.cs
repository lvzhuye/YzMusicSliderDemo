using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace YzWangYiMusicSliderDemo
{
    public class YzSliderMainListBox:ListBox
    {

        public YzSliderMainListBox()
        {
            this.DefaultStyleKey = typeof(YzSliderMainListBox);
        }

        private ScrollViewer sliderMainListBoxScrollViewer;

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new YzSliderMainItem();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return false;
        }

        public void ScrollHorizontalPosition(double HorizontalPosition)
        {

            sliderMainListBoxScrollViewer.ScrollToHorizontalOffset(HorizontalPosition);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            sliderMainListBoxScrollViewer = (ScrollViewer)this.GetTemplateChild("sliderMainListBoxScrollViewer");
        }

    }
}
