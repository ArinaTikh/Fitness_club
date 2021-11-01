using System;
using System.Collections.ObjectModel;
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
    }
}
