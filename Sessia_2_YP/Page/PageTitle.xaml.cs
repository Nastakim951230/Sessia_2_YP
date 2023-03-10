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
    /// Логика взаимодействия для PageTitle.xaml
    /// </summary>
    public partial class PageTitle 
    {
        public static int index_button;
        public PageTitle()
        {
            InitializeComponent();
            if(index_button!=0)
            {
                switch(index_button)
                {
                    case 1:
                        title.Text = "Абоненты ТНС";
                        break;
                    case 2:
                        title.Text = "Управление оборудованием ТНС";
                        break;
                    case 3:
                        title.Text = "Активы ТНС";
                        break;
                    case 4:
                        title.Text = "Биллинг ТНС";
                        break;
                    case 5:
                        title.Text = "Поддержка пользователей ТНС";
                        break;
                    case 6:
                        title.Text = "CRM ТНС";
                        break;
                }
            }
        }
    }
}
