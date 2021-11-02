using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для Abonement.xaml
    /// </summary>
    public partial class Abonement : Page
    {
        public static ObservableCollection<TypeAbon> typeAbons { get; set; }
        public static ObservableCollection<Zal> zalss { get; set; }
        public static ObservableCollection<Trener> treners { get; set; }
        public static ObservableCollection<Abon> Abons { get; set; }
        public static ObservableCollection<card> cards { get; set; }

        public static ObservableCollection<Client> clients { get; set; }
        public Abonement()
        {
            InitializeComponent();
            FillCmBoxes();
            typeAbons = new ObservableCollection<TypeAbon>(bd_connection.conn.TypeAbon.ToList());
            zalss = new ObservableCollection<Zal>(bd_connection.conn.Zal.ToList());
            treners = new ObservableCollection<Trener>(bd_connection.conn.Trener.ToList());
            Abons = new ObservableCollection<Abon>(bd_connection.conn.Abon.ToList());
            cards = new ObservableCollection<card>(bd_connection.conn.card.ToList());
            clients = new ObservableCollection<Client>(bd_connection.conn.Client.ToList());
            this.DataContext = this;
        }

        private void FillCmBoxes()
        {
            typeAbons = new ObservableCollection<TypeAbon>(bd_connection.conn.TypeAbon.ToList());
            zalss = new ObservableCollection<Zal>(bd_connection.conn.Zal.ToList());
            treners = new ObservableCollection<Trener>(bd_connection.conn.Trener.ToList());
            foreach (var typeAbb in typeAbons)
            {
                Abb.Items.Add(typeAbb.Type);
            }
            foreach (var typeZali in zalss)
            {
                Zali.Items.Add(typeZali.Type);
            }
            foreach (var typeTrenrk in treners)
            {
                trenrk.Items.Add(typeTrenrk.Name);
            }
        }

        private void Buy_Click(object sender, RoutedEventArgs e)
        {
            var n = new Abon()

            {
                secName = Asecname.Text,
                //MessageBox.Show(Abb.SelectedItem.ToString());
                ID_typeAb = GetAbbID(Abb.SelectedItem.ToString()),
                name = Aname.Text,
                ID_zal = GetZallID(Zali.SelectedItem.ToString()),
                ID_trener = GetTrenerID(trenrk.SelectedItem.ToString()),
                Count_trens = int.Parse(much.Text),
                Date_start = start.SelectedDate,
                Date_finish = fin.SelectedDate
            };
            n.Price = GetAbonPrice(n.ID_typeAb, n.Date_start, n.Date_finish);
            bd_connection.conn.Abon.Add(n);
            bd_connection.conn.SaveChanges();
            MessageBoxResult result = MessageBox.Show("Данные внесены успешно!", "Готово",
            MessageBoxButton.OKCancel, MessageBoxImage.Information);
            if (result == MessageBoxResult.OK)
            {
                Summa.Text = n.Price.ToString();
            }
        }

        private decimal? GetAbonPrice(int? AbbId, DateTime? dateStart, DateTime? dateFinish)
        {
            TimeSpan? dt = dateFinish - dateStart;
            var price = from pr in typeAbons
                        where AbbId == pr.ID_typeAb
                        select pr;
            decimal? truePrice = price.ToList()[0].Price;

            return dt.Value.Days * truePrice;
        }


        private void AbonPurchase(int sum)
        {
            var clientCard = from clCard in cards
                             where CurrentSession.client.id_card == clCard.id_card
                             select clCard;
            if (clientCard.FirstOrDefault().balance - sum > 0)
            {
                clientCard.FirstOrDefault().balance -= sum;
                bd_connection.conn.SaveChanges();
            }
            else
            {
                MessageBox.Show("net babla");
            }
        }

        private int GetAbbID(string AbbName)
        {
            var AbbID = from cn in typeAbons
                        where AbbName == cn.Type
                        select cn;
            return AbbID.ToList()[0].ID_typeAb;
        }

        private int GetZallID(string ZalliName)
        {
            var AbbID = from cn in zalss
                        where ZalliName == cn.Type
                        select cn;
            return AbbID.ToList()[0].ID_zal;
        }

        private int GetTrenerID(string TrenerName)
        {
            var AbbID = from cn in treners
                        where TrenerName == cn.Name
                        select cn;
            return AbbID.ToList()[0].ID_trener;
        }


        private void pay_Click(object sender, RoutedEventArgs e)
        {
            AbonPurchase(int.Parse(Summa.Text));
            
        }
    }
}
