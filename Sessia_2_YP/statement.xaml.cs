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
using System.Windows.Shapes;

namespace Sessia_2_YP
{
    /// <summary>
    /// Логика взаимодействия для statement.xaml
    /// </summary>
    public partial class statement : Window
    {
        CRM crmadd;

        public statement(int IDSubr)
        {
            InitializeComponent();
            crmadd = new CRM();
            Subscriber subscriber = Class.ClassBase.Bd.Subscriber.FirstOrDefault(x => x.SubscriberID == IDSubr);
            NomerTelefona.Text = subscriber.Phone;
            Contract contract = Class.ClassBase.Bd.Contract.FirstOrDefault(x => x.ContractID == IDSubr);
            Personal.Text = Convert.ToString(contract.PersonalAccount);
           
            dataStart.Text = string.Format("{0:dd MMMM yyyy}", DateTime.Today);


        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Oformlenie_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Proverka_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
