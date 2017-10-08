using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace YzWangYiMusicSliderDemo
{
    public class MainWindowModel
    {
        public List<BitmapImage> images { get; set; }

        public MainWindowModel()
        {
            this.images = (from c in Enumerable.Range(1, 5)
                           select CreateImage(c)).ToList();
        }

        private static BitmapImage CreateImage(int index)
        {
            return new BitmapImage(new Uri(@"C:\Users\yangz\Desktop\YzSliderDemoPictures\"+index+".jpg"));
        }
    }
}
