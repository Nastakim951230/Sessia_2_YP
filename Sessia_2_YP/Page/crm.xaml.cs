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

namespace Sessia_2_YP
{
    /// <summary>
    /// Логика взаимодействия для crm.xaml
    /// </summary>
    public partial class crm 
    {
        
        public crm()
        {
            InitializeComponent();
            Dann();
        }

        public void Dann()
        {
            
            List<Subscriber> subscribers = Class.ClassBase.Bd.Subscriber.ToList();
            if (tbPhone.Text.Length > 0)
            {
                subscribers = subscribers.Where(x => x.Phone.ToLower().Contains(tbPhone.Text.ToLower())).ToList();
            }
            if (tbSurname.Text.Length > 0)
            {
                subscribers = subscribers.Where(x => x.Surname.ToLower().Contains(tbSurname.Text.ToLower())).ToList();
            }
            for (int i = 0; i < subscribers.Count; i++)
            {
                cmbSubscriber.Items.Add(subscribers[i].FIO);
            }



        }
        private void tbPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dann();
        }

        private void tbSurname_TextChanged(object sender, TextChangedEventArgs e)
        {
            Dann();
        }

        private void Oformlenie_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
