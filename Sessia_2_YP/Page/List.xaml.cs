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
    /// Логика взаимодействия для List.xaml
    /// </summary>
    public partial class List 
    {
        public static int id;
        public List()
        {
            InitializeComponent();


            string dateInput = "27/08/2023";
            var parsedDate = DateTime.Parse(dateInput);
           
            if (id != 0)
            {
                ListEvent.ItemsSource = Class.ClassBase.Bd.Events.Where(x => x.IdRole == id && x.DataEvent == parsedDate).ToList();
            }
        

            //события на сегодняшний день
            //if (id != 0)
            //{
            //    ListEvent.ItemsSource = Class.ClassBase.Bd.Events.Where(x => x.IdRole == id && x.DataEvent == DateTime.Today).ToList();
            //}
           
        }
    }
}
