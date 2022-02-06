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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        aaaEntities context;
        public MainWindow()
        {
            InitializeComponent();
            context = new aaaEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridClient.ItemsSource = context.Client.ToList();
        }

        private void BtnAdeteData_Click(object sender, RoutedEventArgs e)
        {
            var NewClient = new Client();
            context.Client.Add(NewClient);
            var EditWindow = new WindowClient(context, NewClient);
            EditWindow.ShowDialog();
            ShowTable();

        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentClient = DataGridClient.SelectedItem as Client;
            if (currentClient == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult ==MessageBoxResult.Yes)
            {
                context.Client.Remove(currentClient);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void Btnser_Click(object sender, RoutedEventArgs e)
        {
            var EditWindo = new WindowSer();
            EditWindo.ShowDialog();
            
        }

        private void Btnsercli_Click(object sender, RoutedEventArgs e)
        {
            var EditWindo = new WindowCS();
            EditWindo.ShowDialog();
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentClient = BtnEdit.DataContext as Client;
            var EditWindow = new WindowClient(context, currentClient);
            EditWindow.ShowDialog();
        }
    }
}
