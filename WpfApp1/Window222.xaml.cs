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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window222.xaml
    /// </summary>
    public partial class Window222 : Window
    {
        aaaEntities context;
        public Window222(aaaEntities context, ClientService newClientService)
        {
            InitializeComponent();
            this.context = context;

            CmbClient.ItemsSource = context.Client.ToList();
            CmbService.ItemsSource = context.Service.ToList();
            this.DataContext = newClientService;
        }

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveData_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void BtnSaveData_Click_2(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
