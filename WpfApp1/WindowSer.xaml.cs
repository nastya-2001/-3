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
    /// Логика взаимодействия для WindowSer.xaml
    /// </summary>
    public partial class WindowSer : Window
    {
        aaaEntities context;
        public WindowSer()
        {
            InitializeComponent();
            context = new aaaEntities();
            ShowTable();
        }
        private void ShowTable()
        {
            DataGridService.ItemsSource = context.Service.ToList();
        }

        private void BtnAdeteData_Click(object sender, RoutedEventArgs e)
        {
            var NewService = new Service();
            context.Service.Add(NewService);
            var EditWindow = new Window111(context, NewService);
            EditWindow.ShowDialog();
            ShowTable();
        }

        private void BtnDeleteData_Click(object sender, RoutedEventArgs e)
        {
            var currentService = DataGridService.SelectedItem as Service;
            if (currentService == null)
            {
                MessageBox.Show("Выберите строку!");
                return;
            }
            MessageBoxResult messageBoxResult = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление",
                MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageBoxResult == MessageBoxResult.Yes)
            {
                context.Service.Remove(currentService);
                context.SaveChanges();
                ShowTable();
            }
        }

        private void BtnEditData_Click(object sender, RoutedEventArgs e)
        {
            Button BtnEdit = sender as Button;
            var currentService = BtnEdit.DataContext as Service;
            var EditWindow = new Window111(context, currentService);
            EditWindow.ShowDialog();
        }
    }
}
