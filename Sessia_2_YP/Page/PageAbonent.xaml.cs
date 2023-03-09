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
    /// Логика взаимодействия для PageAbonent.xaml
    /// </summary>
    public partial class PageAbonent 
    {
        public static int id=0;
        public PageAbonent()
        {
            InitializeComponent();
            Class.ClassBase.Bd = new Base();
            List<Sotrudnik> sotrud = Class.ClassBase.Bd.Sotrudnik.ToList();
            fio_polzoval.Items.Add("Не выбрано");
            for (int i = 0; i < sotrud.Count; i++)  // цикл для записи в выпадающий список всех пород котов из БД
            {
                fio_polzoval.Items.Add(sotrud[i].Fio);
            }
            fio_polzoval.SelectedIndex = 0;
            if(id!=0)
            {
                Sotrudnik img;
                img= Class.ClassBase.Bd.Sotrudnik.FirstOrDefault(x=>x.SotrudnikID==id);
                polzovatelImg.Source = Convert.ToString(img.Photo);
            }
        }



        private void fio_polzoval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Sotrudnik> imgSotr = Class.ClassBase.Bd.Sotrudnik.ToList();
            if (fio_polzoval.SelectedIndex > 0)
            {
                imgSotr = imgSotr.Where(x => x.SotrudnikID == fio_polzoval.SelectedIndex).ToList();
                Page.PageAbonent.id = fio_polzoval.SelectedIndex;
                Class.ClassFrame.hod.Navigate(new PageAbonent());
            }
          
        }
    }
}
