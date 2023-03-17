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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Sessia_2_YP
{
    /// <summary>
    /// Логика взаимодействия для examination.xaml
    /// </summary>
    public partial class examination : Window
    {
        bool var;
        public examination()
        {
            InitializeComponent();
            var=true;
        }

        private void Otmena_Click(object sender, RoutedEventArgs e)
        {
            var=false;
            this.Close();
        }

        private async void proverka_Click(object sender, RoutedEventArgs e)
        {
            for(int i = 0; i <= 100; i++)
            {
                await Task.Delay(50);
                loading.Value++;
            }

            if(var==true)
            {
                Random random = new Random();
                int a = random.Next(2,3);
                if(a != 2)
                {
                    MessageBox.Show("Требуется выезд");
                    statement.variant = 2;
                    this.Close();
                }
               else if (a != 3)
                {
                    MessageBox.Show("Оборудование исправно");
                    statement.variant = 3;
                    this.Close();
                }
            }

        }
    }
}
