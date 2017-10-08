using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace YzWangYiMusicSliderDemo
{
    public class YzSlider:Control
    {

        public DataTemplate navItemDataTemplate
        {
            get { return (DataTemplate)GetValue(navItemDataTemplateProperty); }
            set { SetValue(navItemDataTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for navItemDataTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty navItemDataTemplateProperty =
            DependencyProperty.Register("navItemDataTemplate", typeof(DataTemplate), typeof(YzSlider), new PropertyMetadata(null));



        public DataTemplate mainItemDataTemplate
        {
            get { return (DataTemplate)GetValue(mainItemDataTemplateProperty); }
            set { SetValue(mainItemDataTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for itemDataTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty mainItemDataTemplateProperty =
            DependencyProperty.Register("mainItemDataTemplate", typeof(DataTemplate), typeof(YzSlider), new PropertyMetadata(null));




        public Object Images
        {
            get { return (Object)GetValue(ImagesProperty); }
            set { SetValue(ImagesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Images.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagesProperty =
            DependencyProperty.Register("Images", typeof(Object), typeof(YzSlider), new PropertyMetadata(null));


        //主滚动列表
        private YzSliderMainListBox sliderInnerMainListBox;
        //导航列表
        private ListBox sliderInnerNavListBox;
        //左箭头导航
        private Button leftArrowButton;
        //右箭头导航
        private Button RightArrowButton;
        //箭、主滚动布局Grid
        private Grid sliderInnerGrid;


        public void AttachItemSoures(object items)
        {
            this.sliderInnerMainListBox.ItemsSource = (List<BitmapImage>)items;
            this.sliderInnerNavListBox.ItemsSource = (List<BitmapImage>)items;
        }



        public YzSlider()
        {
            this.DefaultStyleKey = typeof(YzSlider);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            sliderInnerGrid = (Grid)this.GetTemplateChild("sliderInnerGrid");
            sliderInnerGrid.MouseEnter += SliderInnerGrid_MouseEnter;
            sliderInnerGrid.MouseLeave += SliderInnerGrid_MouseLeave;

            sliderInnerMainListBox = (YzSliderMainListBox)this.GetTemplateChild("sliderInnerMainListBox");

            sliderInnerNavListBox = (ListBox)this.GetTemplateChild("sliderInnerNavListBox");

            leftArrowButton = (Button)this.GetTemplateChild("leftArrowButton");

            leftArrowButton.Click += LeftArrowButton_Click;

            RightArrowButton = (Button)this.GetTemplateChild("rightArrowButton");

            RightArrowButton.Click += RightArrowButton_Click;

            AttachItemSoures(Images);

            this.AddHandler(YzSliderNavItem.SliderNavMouseEnterEvent, new EventHandler<SliderNavRoutedEventArgs>(navItemMouseEnter));
        }

        private void navItemMouseEnter(object sender, SliderNavRoutedEventArgs e)
        {
            this.sliderInnerMainListBox.ScrollIntoView(e.MouseEnterItem);
        }

        private void SliderInnerGrid_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            leftArrowButton.Visibility = Visibility.Hidden;
            RightArrowButton.Visibility = Visibility.Hidden;
        }

        private void SliderInnerGrid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            leftArrowButton.Visibility = Visibility.Visible;
            RightArrowButton.Visibility = Visibility.Visible;
        }

        private void LeftArrowButton_Click(object sender, RoutedEventArgs e)
        {
            int prevMainListBoxSelectedIndex;
            prevMainListBoxSelectedIndex = this.sliderInnerMainListBox.SelectedIndex - 1;
            var prevImageItem = ((List<BitmapImage>)this.Images)[prevMainListBoxSelectedIndex];
            this.sliderInnerMainListBox.SelectedIndex = prevMainListBoxSelectedIndex;
            this.sliderInnerMainListBox.ScrollIntoView(prevImageItem);
        }

        private void ScrollToItemIndex(int index)
        {
            double horizontalOffset = (index-1) * 250;
            this.sliderInnerMainListBox.ScrollHorizontalPosition(horizontalOffset);
        }

        private void RightArrowButton_Click(object sender, RoutedEventArgs e)
        {
            int mainListBoxSelectedIndex;
            if (this.sliderInnerMainListBox.SelectedIndex == -1)
            {
                mainListBoxSelectedIndex = this.sliderInnerMainListBox.SelectedIndex + 3;
            }
            else
            {
                mainListBoxSelectedIndex = this.sliderInnerMainListBox.SelectedIndex + 1;
            }
            var nextSelectedItem = ((List<BitmapImage>)this.Images)[mainListBoxSelectedIndex];
            this.sliderInnerMainListBox.SelectedIndex = mainListBoxSelectedIndex;
            //this.sliderInnerMainListBox.ScrollIntoView(nextSelectedItem);
            ScrollToItemIndex(mainListBoxSelectedIndex);
            var mainListBoxItem = ((YzSliderMainItem)this.sliderInnerMainListBox.ItemContainerGenerator.ContainerFromIndex(mainListBoxSelectedIndex));
            var mainItemScaleTransform = new ScaleTransform();
            mainItemScaleTransform.ScaleX = 1;
            mainItemScaleTransform.ScaleY = 1.5;
            mainListBoxItem.RenderTransformOrigin = new Point(0.5,1);
            mainListBoxItem.RenderTransform = mainItemScaleTransform;
            var prevMainItemBoxItem = ((YzSliderMainItem)this.sliderInnerMainListBox.ItemContainerGenerator.ContainerFromIndex(mainListBoxSelectedIndex - 1));
            var prevMainListScaleTransform = new ScaleTransform();
            prevMainListScaleTransform.ScaleX = 1;
            prevMainListScaleTransform.ScaleY = 1;
            prevMainItemBoxItem.RenderTransformOrigin = new Point(0.5, 1);
            prevMainItemBoxItem.RenderTransform = prevMainListScaleTransform;
            


        }
    }
}
