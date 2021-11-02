using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для Kabinet.xaml
    /// </summary>
    public partial class Kabinet : Page
    {
        public static ObservableCollection<card> cardt { get; set; }
        public static ObservableCollection<Client> clietss { get; set; }
        public Kabinet()
        {
            InitializeComponent();
            balance.Text = GetBalance();
            Kuser.Text = Name.ToString();

        }
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Закрыть приложение?", "Выход",
               MessageBoxButton.OKCancel, MessageBoxImage.Question);
            if (result == MessageBoxResult.OK)
            {
                NavigationService.Navigate(new login_form());
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
        private string GetBalance()
        {
            return CurrentSession.client.card.balance.ToString();
        }
    }
}
