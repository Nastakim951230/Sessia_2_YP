using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sessia_2_YP
{
    public partial class Sotrudnik
    {
        public string Fio
        {
            get
            {
                return Surname + " " + Name + " " + Patronymic;
            }
        }
    }
}
