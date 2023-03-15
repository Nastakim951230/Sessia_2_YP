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

namespace Sessia_2_YP.Page
{
    /// <summary>
    /// Логика взаимодействия для WindowAbonent.xaml
    /// </summary>
    public partial class WindowAbonent : Window
    {
        Subscriber subscriber;
        Contract contract;
        public WindowAbonent(Subscriber subscriber)
        {
            InitializeComponent();
            this.subscriber = subscriber;

            NomerAbonenta.Text="Номер абонента: " +subscriber.Nomer;
            FIO.Text= "ФИО абонента: " + subscriber.FIO;
            Passport.Text = "Серия паспорта: " + subscriber.SeriaPassport + "  Номер паспорта: " + subscriber.NomerPassport;
            PassportDann.Text = "Кем выдан: " + subscriber.IssuedBy;
            PassportData.Text= " Дата выдачи: " + String.Format("{0:dd MMMM yyyy}", subscriber.DateOfIssue);
            contract = Class.ClassBase.Bd.Contract.FirstOrDefault(x => x.ContractID == subscriber.SubscriberID);
            NomerContract.Text = "Номер договора с абонентом: " + contract.Number;
            ContractType contractType = Class.ClassBase.Bd.ContractType.FirstOrDefault(x => x.ContractTypeID == contract.TypeContractID);
            TypeContract.Text = "Тип договора: " + contractType.Type;
            if(contract.ReasonForTermination==null)
            {
                DataContract.Text = "Дата заключения: " + String.Format("{0:dd MMMM yyyy}", contract.DateOfCinclusion);
            }
            else
            {
                PrichinaContract.Visibility=Visibility.Visible;
                DataContract.Text = "Дата заключения: " + String.Format("{0:dd MMMM yyyy}", contract.DateOfCinclusion)+ "Дата расторжения: " + String.Format("{0:dd MMMM yyyy}", contract.TermibationDate);
            }
        }
    }
}
