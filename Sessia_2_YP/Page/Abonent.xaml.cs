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
            List<Street> streets=Class.ClassBase.Bd.Street.ToList();
            for(int i=0;i<streets.Count;i++)
            {
                Street.Items.Add(streets[i].Tytle);
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
                            else
                            {
                                subscribers=subscribers.ToList();
                            }
                        }
                            break;
                        case 4:
                        {
                            if (!string.IsNullOrWhiteSpace(Poisk.Text))
                            {
                                List<Subscriber> addSub = new List<Subscriber>();
                                List<Contract> contracts = new List<Contract>();
                                List<Contract> contract = Class.ClassBase.Bd.Contract.ToList();
                                List <Subscriber> subscribers1 = Class.ClassBase.Bd.Subscriber.ToList();
                                contracts = contract.Where(x => x.personalAccount.ToLower().Contains(Poisk.Text.ToLower())).ToList();
                                for (int i = 0; i < contracts.Count; i++)
                                {
                                    List<Subscriber> subscribers2 = new List<Subscriber>();
                                    subscribers2 = subscribers1.Where(x => x.SubscriberID == contracts[i].ContractID).ToList();
                                    if (subscribers2.Count > 0)
                                    {
                                        for (int j = 0; j < subscribers2.Count; j++)
                                        {
                                            addSub.Add(subscribers2[j]);
                                        }
                                    }

                                }
                                subscribers = addSub.Distinct().ToList();
                            }
                            else
                            {
                                subscribers = subscribers.ToList();
                            }
                        }
                            break;
                    }
                
            }
            else
            {
             List<ResidentialAddress> addresses = new List<ResidentialAddress>();
                List<ResidentialAddress> residentialAddresses = Class.ClassBase.Bd.ResidentialAddress.ToList();
                List<Subscriber> subscriberList = Class.ClassBase.Bd.Subscriber.ToList();
                List<Subscriber> subscribe = new List<Subscriber>();
                List<Subscriber> subscribe2 = new List<Subscriber>();
                if (Street.SelectedIndex>0)
                {
                    addresses =residentialAddresses.Where(x=>x.StreetID==Street.SelectedIndex).ToList();
                    if (addresses.Count > 0)
                    {
                        for (int i = 0; i < addresses.Count; i++)
                        {

                            subscribe = subscriberList.Where(x => x.ResidentialAddressID == addresses[i].ResidentialAddressID).ToList();
                            if (subscribe.Count > 0)
                            {
                                for (int j = 0; j < subscribe.Count; j++)
                                {
                                    subscribe2.Add(subscribe[j]);
                                }
                                subscribers = subscribe2.ToList();
                            }
                           

                        }
                        
                    }
                    if(subscribe.Count==0)
                    {
                        MessageBox.Show("Нет данных об абонентах на данной улице");
                        Street.SelectedIndex = 0;
                    }

                }
            }
            if (subscribers.Count == 0)
            {
                MessageBox.Show("Нет данных об абонентах");
                Poisk.Text = "";

            }
            else
            {
                listAbonent.ItemsSource = subscribers;
            }
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
