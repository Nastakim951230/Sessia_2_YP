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
                DataContract.Text = "Дата заключения: " + String.Format("{0:dd MMMM yyyy}", contract.DateOfCinclusion)+ " Дата расторжения: " + String.Format("{0:dd MMMM yyyy}", contract.TermibationDate);
                ReasonForTermination cause = Class.ClassBase.Bd.ReasonForTermination.FirstOrDefault(x => x.ReasonForTerminationID == contract.ReasonForTerminationID);
                PrichinaContract.Text = "Причина расторжения договора: " + cause.Cause;
            }
            PerconalAccount.Text = "Лицевой счет: " + contract.PersonalAccount;
            ResidentialAddress residentialAddress = Class.ClassBase.Bd.ResidentialAddress.FirstOrDefault(x => x.ResidentialAddressID == subscriber.ResidentialAddressID);
            Raion raion=Class.ClassBase.Bd.Raion.FirstOrDefault(x => x.RaionID == residentialAddress.RaionID);
            Street street=Class.ClassBase.Bd.Street.FirstOrDefault(x=>x.StreetID == residentialAddress.StreetID);
            Address.Text = "Адрес: " + residentialAddress.Gorod + ", " + raion.Tytle + " район, " + street.Tytle + ", дом " + residentialAddress.House;

            services.Text = subscriber.service_and_date;
            InstallationEquipment installationEquipment = Class.ClassBase.Bd.InstallationEquipment.FirstOrDefault(x => x.SubscriberID == subscriber.SubscriberID);
            Equipment equipment = Class.ClassBase.Bd.Equipment.FirstOrDefault(x => x.EquipmentID == installationEquipment.EquipmentID);
            NomerEquipment.Text ="Серийный номер оборудования:"+ equipment.SerialNumber;
            NameEquipment.Text = "Название оборудования: " + equipment.Tytle;
            EquipmentType type=Class.ClassBase.Bd.EquipmentType.FirstOrDefault(x=>x.EquipmentTypeID == equipment.EquipmentTypeID);
            typeEquipment.Text = "Тип оборудования: " + type.Title;
            if(equipment.InvertaryNumber!=null && equipment.Adress_MAC!=null)
            {
                DannaEquipment.Visibility = Visibility.Visible;
                DannaEquipment.Text = "Инвертарный номер: " + equipment.InvertaryNumber + ", Адрес MAC: " + equipment.Adress_MAC;
            }
            else if(equipment.InvertaryNumber == null && equipment.Adress_MAC != null)
            {
                DannaEquipment.Visibility = Visibility.Visible;
                DannaEquipment.Text = " Адрес MAC: " + equipment.Adress_MAC;
            }
            else if(equipment.InvertaryNumber != null && equipment.Adress_MAC== null)
            {
                DannaEquipment.Visibility = Visibility.Visible;
                DannaEquipment.Text = "Инвертарный номер: " + equipment.InvertaryNumber ;
            }
            NomerDogovora.Text = "Номер договора : " + contract.Number;
            if(installationEquipment.Notes!=null)
            {
                SrokDogovora.Visibility=Visibility.Visible;
                SrokDogovora.Text = installationEquipment.Notes;
            }
            List<CRM> crm = Class.ClassBase.Bd.CRM.Where(x => x.SubscriberID == subscriber.SubscriberID).ToList();
            if (crm.Count > 0)
            {
                List<CRM> cRMs = new List<CRM>();
                list.Visibility = Visibility.Visible;
                for (int i = 0; i < crm.Count; i++)
                {

                    DateTime date = crm[i].DateCreation;
                    date = date.AddMonths(12);
                    if (DateTime.Today <= date)
                    {
                        cRMs.Add(crm[i]);
                    }


                }
                listCRM.ItemsSource = cRMs;
            }
        }
    }
}
