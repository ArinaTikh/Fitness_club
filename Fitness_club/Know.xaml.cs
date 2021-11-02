using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для Know.xaml
    /// </summary>
    public partial class Know : Window
    {
        public static ObservableCollection<card> cards { get; set; }
        public Know()
        {
            InitializeComponent();
            GetBalance();
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            cards = new ObservableCollection<card>(bd_connection.conn.card.ToList());
            var d = cards.Where(a => a.vladelec == nameclient.Text).FirstOrDefault();
            if (d != null)
            {
                MessageBox.Show($"{d.vladelec},Ваш баланс {d.balance}");
            }
            else
            {
                MessageBox.Show("Пользователь не найден", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private string GetBalance()
        {
             return CurrentSession.client.card.balance.ToString();
        }
    }
}
