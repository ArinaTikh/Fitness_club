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

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        public Registration()
        {
            InitializeComponent();
        }


        private void Regis_Click(object sender, RoutedEventArgs e)
        {
            var a = new Client();
            a.FirstName = fname.Text;
            a.Name = name.Text;
            a.Phone = int.Parse(phone.Text);
            a.Login = login.Text;
            a.password = psswrd.Text;
            bd_connection.conn.Client.Add(a);
            bd_connection.conn.SaveChanges();
            MessageBox.Show("Успешно");
            NavigationService.GoBack();


        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Закрыть приложение?", "Выход",
                MessageBoxButton.OKCancel, MessageBoxImage.Question );
            if( result == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
