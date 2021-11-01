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
    /// Логика взаимодействия для FBalanse.xaml
    /// </summary>
    public partial class FBalanse : Page
    {
        public FBalanse()
        {
            InitializeComponent();
        }

        private void pay_Click(object sender, RoutedEventArgs e)
        {
            var p = new card();
            p.number_card = int.Parse(numb.Text);
            p.date = date.Text;
            p.vladelec = namef.Text;
            p.cvc = int.Parse(cvc.Text);
            p.balance = int.Parse(sum.Text);
            bd_connection.conn.card.Add(p);
            bd_connection.conn.SaveChanges();
            MessageBox.Show("Успешно");
            NavigationService.GoBack();

        }
    }
}
