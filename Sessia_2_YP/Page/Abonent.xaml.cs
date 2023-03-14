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
    /// Логика взаимодействия для Abonent.xaml
    /// </summary>
    public partial class Abonent 
    {
        public static int index;
        public Abonent()
        {
            InitializeComponent();
            listAbonent.ItemsSource = Class.ClassBase.Bd.Subscriber.ToList();
            cbPoisk.SelectedIndex = 0;

            Street.Items.Add("Улица не выбрана");
            List<Raion> raions=Class.ClassBase.Bd.Raion.ToList();
            for(int i=0;i<raions.Count;i++)
            {
                Street.Items.Add(raions[i].Tytle);
            }
            Street.SelectedIndex = 0;
        }

        private void cbPoisk_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         // вариант выбора поиска
          if (cbPoisk.SelectedIndex > 0)
            {
                if (cbPoisk.SelectedIndex == 3)
                {
                    Poisk.Visibility = Visibility.Collapsed;
                    Street.Visibility = Visibility.Visible;
                }
                else
                {
                    Poisk.Visibility = Visibility.Visible;
                    Street.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                Poisk.Visibility = Visibility.Collapsed;
                Street.Visibility = Visibility.Collapsed;
            }
        }
        void Filter()
        {
            List<Subscriber> subscribers = Class.ClassBase.Bd.Subscriber.ToList();
            //Поиск
            if (cbPoisk.SelectedIndex != 3)
            {
               
                    switch (cbPoisk.SelectedIndex)
                    {
                        case 1:
                        {
                            if (!string.IsNullOrWhiteSpace(Poisk.Text))
                            {
                                subscribers = subscribers.Where(x => x.Surname.ToLower().Contains(Poisk.Text.ToLower())).ToList();
                            }
                        }
                            break;
                        case 2:
                        {
                            if (!string.IsNullOrWhiteSpace(Poisk.Text))
                            {
                                List<Subscriber> addSub = new List<Subscriber>();
                                List<Subscriber> subscribers1 = Class.ClassBase.Bd.Subscriber.ToList();
                                List<Subscriber> subscribers3= Class.ClassBase.Bd.Subscriber.ToList();
                                List<ResidentialAddress> residentialAddresses = Class.ClassBase.Bd.ResidentialAddress.ToList();
                               List <Raion> raions = Class.ClassBase.Bd.Raion.Where(x => x.Tytle.ToLower().Contains(Poisk.Text.ToLower())).ToList();
                                for (int i = 0; i < raions.Count; i++)
                                {
                                    List<ResidentialAddress> residentials = new List<ResidentialAddress>();
                                    residentials = residentialAddresses.Where(x => x.RaionID == raions[i].RaionID).ToList();
                                    if(residentials.Count > 0)
                                    {
                                        for (int j = 0; j < residentials.Count; j++)
                                        {
                                            List<Subscriber> subscribers2 = new List<Subscriber>();
                                        subscribers2 = subscribers1.Where(x => x.ResidentialAddressID == residentialAddresses[j].ResidentialAddressID).ToList();
                                            for (int k = 0; k < subscribers2.Count; k++)
                                            {
                                                
                                                    addSub.Add(subscribers2[k]);
                                               
                                            }
                                        }
                                    }
                                  
                                }
                                subscribers = addSub.Distinct().ToList();
                            }
                        }
                            break;
                        case 4:
                            break;
                    }
                
            }
            else
            {

            }
            listAbonent.ItemsSource = subscribers;
        }

        private void Poisk_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }

        private void Street_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Filter();
        }
    }
}
