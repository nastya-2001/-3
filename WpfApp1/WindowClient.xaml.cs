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
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        aaaEntities context;

        public WindowClient(aaaEntities context, Client newClient)
        {
            InitializeComponent();
            this.context=context;

            CmbGender.ItemsSource = context.Gender.ToList();
            this.DataContext = newClient;
          
        }

        

        private void BtnSaveData_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnSaveData_Click_1(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
            this.Close();
        }
    }
}
