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
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Page
    {
        public Kabinet()
        {
            InitializeComponent();
        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Закрыть приложение?", "Выход",
               MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                System.Windows.Application.Current.Shutdown();
            }
        }

        private void Balance_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FBalanse());
        }


        private void Know_Click(object sender, RoutedEventArgs e)
        {
            (new Know()).Show();
        }

        private void abbuy_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Abonement());
        }
    }
}
