using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace MovieStore.Desktop.Helper
{
    class UserControlCreator
    {
        private UserControl CreateMovieItem()
        {
            UserControl u1 = new UserControl();
            u1.Height = 200;
            u1.Width = 120;
            Image img = new Image();
            img.Source = new BitmapImage(new Uri(@"E:\Projects\Develop\MovieStore\MovieStore\MovieStore.Desktop\Assets\SampleCover.jpg", UriKind.RelativeOrAbsolute));
            u1.Content = img;

            return u1;
        }
    }
}
