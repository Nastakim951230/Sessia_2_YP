using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sessia_2_YP.Page
{
    /// <summary>
    /// Логика взаимодействия для ImageUser.xaml
    /// </summary>
    public partial class ImageUser
    {
        public static int image;
        public ImageUser()
        {
            InitializeComponent();
            if(image!=0)
            {
                Sotrudnik sotrudnik = Class.ClassBase.Bd.Sotrudnik.FirstOrDefault(x => x.SotrudnikID == image);
                if(sotrudnik.Photo!=null)
                {
                    polzovatelImg.Source = new BitmapImage(new Uri(sotrudnik.Photo, UriKind.Relative));
                }
            
                else
                {
                    polzovatelImg.Source = new BitmapImage(new Uri("../Image/Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
                }
            
            }
            else
            {
                polzovatelImg.Source = new BitmapImage(new Uri("../Image/Фото для заглушки при отсутствии фото сотрудника.jpg", UriKind.Relative));
            }
        }
    }
}
