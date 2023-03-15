using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessia_2_YP
{
    public partial class Subscriber
    {
        
        Contract contract;
     
        public string FIO
        {
            get
            {
                return Surname + " " + Name + " " + Patronymic;
            }
        }

     

        public string service
        {
            get
            {
                contract= Class.ClassBase.Bd.Contract.FirstOrDefault(x=>x.ContractID==SubscriberID);
                List<ConnectedService> connectedServices=Class.ClassBase.Bd.ConnectedService.Where(x=>x.ContractsID==contract.ContractID).ToList();
                int i=connectedServices.Count;
                string serv = "";
                if(i==0)
                {
                    serv = "Никаких услуг не подключено";
                }
                else
                {
                    foreach(ConnectedService connectedService in connectedServices)
                    {
                        serv += " " + connectedService.Service.Tytle + ", ";
                    }
                    serv=serv.Substring(0,serv.Length-2);
                }
                return serv;
            }
        }

        public string service_and_date
        {
            get
            {
                contract = Class.ClassBase.Bd.Contract.FirstOrDefault(x => x.ContractID == SubscriberID);
                List<ConnectedService> connectedServices = Class.ClassBase.Bd.ConnectedService.Where(x => x.ContractsID == contract.ContractID).ToList();
                int i = connectedServices.Count;
                string serv = "";
                if (i == 0)
                {
                    serv = "Никаких услуг не подключено";
                }
                else
                {
                    foreach (ConnectedService connectedService in connectedServices)
                    {
                        if(connectedService.Date==null)
                        {
                            serv += "Услуга: " + connectedService.Service.Tytle + " \n";
                        }
                        else
                        {
                            serv += "Услуга: " + connectedService.Service.Tytle + ", Дата подключения: " + String.Format("{0:dd MMMM yyyy}", connectedService.Date) + " \n";
                        }
                        
                    }
                    serv = serv.Substring(0, serv.Length - 2);
                }
                return serv;
            }
        }


    }
}
