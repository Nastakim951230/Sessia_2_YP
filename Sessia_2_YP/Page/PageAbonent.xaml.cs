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

        Sotrudnik img;
        public PageAbonent()
        {
            InitializeComponent();
            buttons.Navigate(new Page.Buttons());
            Class.ClassFrame.buttonSotrudnic = buttons;
            Event.Navigate(new Page.List());
            Class.ClassFrame.events = Event;
            TitleFrame.Navigate(new Page.PageTitle());
            Class.ClassFrame.titleframe = TitleFrame;
            Img.Navigate(new Page.ImageUser());
            Class.ClassFrame.imgUser = Img;
            Module.Navigate(new Page.Abonent());
            Class.ClassFrame.modul = Module;
            List<Sotrudnik> sotrud = Class.ClassBase.Bd.Sotrudnik.ToList();
           
            fio_polzoval.Items.Add("Не выбрано");
            for (int i = 0; i < sotrud.Count; i++)  // цикл для записи в выпадающий список всех пород котов из БД
            {
                fio_polzoval.Items.Add(sotrud[i].Fio);
            }
            fio_polzoval.SelectedIndex = 0;
           
        }



        private void fio_polzoval_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Sotrudnik> imgSotr = Class.ClassBase.Bd.Sotrudnik.ToList();
            if (fio_polzoval.SelectedIndex > 0)
            {
                img = imgSotr.FirstOrDefault(x => x.SotrudnikID == fio_polzoval.SelectedIndex);
                Page.Buttons.id = img.Role;
                Class.ClassFrame.buttonSotrudnic.Navigate(new Buttons());
                Page.List.id=img.Role;
                Class.ClassFrame.events.Navigate(new List());
                Page.PageTitle.index_button = 1;
                Class.ClassFrame.titleframe.Navigate(new Page.PageTitle());
                Page.ImageUser.image = fio_polzoval.SelectedIndex;
                Class.ClassFrame.imgUser.Navigate(new Page.ImageUser());
            }
          else
            {
                Page.Buttons.id = 0;
                Class.ClassFrame.buttonSotrudnic.Navigate(new Buttons());
                Page.List.id = 0;
                Class.ClassFrame.events.Navigate(new List());
                Page.PageTitle.index_button = 1;
                Class.ClassFrame.titleframe.Navigate(new Page.PageTitle());
                Page.ImageUser.image = 0;
                Class.ClassFrame.imgUser.Navigate(new Page.ImageUser());

            }
        }

    }
}
