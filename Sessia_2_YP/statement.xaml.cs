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
        int id;
        public statement(int IDSubr)
        {
            InitializeComponent();
           id = IDSubr;
            Subscriber subscriber = Class.ClassBase.Bd.Subscriber.FirstOrDefault(x => x.SubscriberID == IDSubr);
            string symbol = subscriber.Phone;
            string phone = "";
            foreach (char c in symbol)
            {
               if(c != '+' && c != '-'&& c != '(' && c != ')' && c != ' ')
                {
                    phone+=c;
                }
            }
            NomerZaivki.Text = phone+"/"+ string.Format("{0:dd}", DateTime.Today)+"/"+string.Format("{0:MM}", DateTime.Today)+"/"+ string.Format("{0:yyyy}", DateTime.Today);
            NomerTelefona.Text = subscriber.Phone;
            Contract contract = Class.ClassBase.Bd.Contract.FirstOrDefault(x => x.ContractID == IDSubr);
            Personal.Text = Convert.ToString(contract.PersonalAccount);
            StatusServices status = Class.ClassBase.Bd.StatusServices.FirstOrDefault(x => x.StatusServicesID == 1);
            Status.Text = status.Status;
            dataStart.Text = string.Format("{0:dd MMMM yyyy}", DateTime.Today);
            Services.Items.Add("Не выбрано");
            List<Service> service = Class.ClassBase.Bd.Service.ToList();
           for(int i = 0; i < service.Count; i++)
            {
                Services.Items.Add(service[i].Tytle);
            }
            Services.SelectedIndex = 0;
            ServicesType.Items.Add("Не выбрано");
            List<TypeServices> typeService = Class.ClassBase.Bd.TypeServices.ToList();
            for (int i = 0; i < typeService.Count; i++)
            {
                ServicesType.Items.Add(typeService[i].Type);
            }
            ServicesType.SelectedIndex = 0;
            ServicesView.Items.Add("Не выбрано");
            List<TypeOfService> typeOfServices = Class.ClassBase.Bd.TypeOfService.ToList();
            for (int i = 0; i < typeOfServices.Count; i++)
            {
                ServicesView.Items.Add(typeOfServices[i].Type);
            }
            ServicesView.SelectedIndex = 0;
            Typeproblem.Items.Add("Не выбрано");
            List<ProblemType> problemTypes = Class.ClassBase.Bd.ProblemType.ToList();
            for (int i = 0; i < problemTypes.Count; i++)
            {
                Typeproblem.Items.Add(problemTypes[i].Type);
            }
            Typeproblem.SelectedIndex = 0;
            TypeEquipment.Items.Add("Не выбрано");
            List<EquipmentType> equipment = Class.ClassBase.Bd.EquipmentType.ToList();
            for (int i = 0; i < equipment.Count; i++)
            {
                TypeEquipment.Items.Add(equipment[i].Title);
            }
            TypeEquipment.SelectedIndex = 0;
        }

        private void nazad_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Oformlenie_Click(object sender, RoutedEventArgs e)
        {
            if(Services.SelectedIndex==0 || TypeEquipment.SelectedIndex==0 || ServicesType.SelectedIndex==0|| Typeproblem.SelectedIndex==0|| ServicesView.SelectedIndex==0)
            {
                MessageBox.Show("Обязательные поля не заполнены");
            }
            else
            {
                crmadd = new CRM();
                crmadd.Number = NomerZaivki.Text;
                crmadd.DateCreation = DateTime.Today;
                crmadd.SubscriberID = id;
                crmadd.ServicesID = Services.SelectedIndex ;
                crmadd.TypeOfServiceID = ServicesView.SelectedIndex ;
                crmadd.ServiceTypeID = ServicesType.SelectedIndex ;
                if(Status.Text== "Новая")
                {
                    crmadd.StatusID = 1;
                }
                else if (Status.Text == "Требует выезда")
                {
                    crmadd.StatusID = 2;
                }
                else if (Status.Text == "Закрыта")
                {
                    crmadd.StatusID = 3;
                }
                crmadd.ProblemTypeID= Typeproblem.SelectedIndex ;
                if (Opisanie.Text==null)
                {
                    crmadd.Description = null;
                }
                else
                {
                    crmadd.Description = Opisanie.Text;
                }
               
                if (dataEnd.Text == "")
                {
                    crmadd.ClosingDate = null;
                }
                else
                {
                    crmadd.ClosingDate = Convert.ToDateTime(dataEnd.Text);
                }
                Class.ClassBase.Bd.CRM.Add(crmadd);
                Class.ClassBase.Bd.SaveChanges();

                MessageBox.Show("Заявка сохранена");
                this.Close();

            }
        }

        private void Proverka_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
