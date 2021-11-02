using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для FBalanse.xaml
    /// </summary>
    public partial class FBalanse : Page
    {
        public static ObservableCollection<Client> clients { get; set; }
        public static ObservableCollection<card> cards { get; set; }

        public FBalanse()
        {
            InitializeComponent();
            clients = new ObservableCollection<Client>(bd_connection.conn.Client.ToList());
            cards = new ObservableCollection<card>(bd_connection.conn.card.ToList());
            FillCardData();
        }

        private void FillCardData()
        {
            if (CurrentSession.client.id_card != null)
            {
                var cardData = from cardD in cards
                               where CurrentSession.client.id_card == cardD.id_card
                               select cardD;
                var card = cardData.FirstOrDefault();
                numb.Text = card.number_card.ToString();
                date.Text = card.date;
                namef.Text = card.vladelec;
                cvc.Text = card.cvc.ToString();
            }
        }
        private void pay_Click(object sender, RoutedEventArgs e)
        {
            var p = new card();
            p.number_card = int.Parse(numb.Text);
            p.date = date.Text;
            p.vladelec = namef.Text;
            p.cvc = int.Parse(cvc.Text);
            if (CurrentSession.client.card != null)
            {
                var cardData = from cardD in cards
                               where CurrentSession.client.id_card == cardD.id_card
                               select cardD;
                cardData.FirstOrDefault().balance += int.Parse(sum.Text);
            }
            else
            {
                p.balance = int.Parse(sum.Text);
                bd_connection.conn.card.Add(p);
                InsertClientCard(p.id_card);
            }
            bd_connection.conn.SaveChanges();
            MessageBox.Show("Успешно");
            NavigationService.GoBack();
        }

        private void InsertClientCard(int ID_card)
        {
            var client = from cl in clients
                         where CurrentSession.client.ID_client == cl.ID_client
                         select cl;
            client.FirstOrDefault().id_card = ID_card;
            bd_connection.conn.SaveChanges();
            CurrentSession.client = client.FirstOrDefault();
        }
    }
}
