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
    /// Логика взаимодействия для WindowCS.xaml
    /// </summary>
    public partial class WindowCS : Window
    {
        aaaEntities context;
        public WindowCS()
        {
            InitializeComponent();
            context = new aaaEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClientService.ItemsSource = context.ClientService.ToList();
        }

        private void BtnAdeteData_Click(object sender, RoutedEventArgs e)
        {
            var NewClientService = new ClientService();
            context.ClientService.Add(NewClientService);
            var EditWindow = new Window222(context, NewClientService);
            EditWindow.ShowDialog();
            ShowTable();

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClientService = DataGridClientService.SelectedItem as ClientService;
            if (currentClientService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.ClientService.Remove(currentClientService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClientService = BtnEdit.DataContext as ClientService;
            var EditWindow = new Window222(context, currentClientService);
            EditWindow.ShowDialog();
        }
    }
}
