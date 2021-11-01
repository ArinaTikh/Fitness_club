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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
        public Abonement()
        {
            InitializeComponent();
            FillCmBoxes();
             typeAbons = new ObservableCollection<TypeAbon>(bd_connection.conn.TypeAbon.ToList());
            zalss = new ObservableCollection<Zal>(bd_connection.conn.Zal.ToList());
            treners = new ObservableCollection<Trener>(bd_connection.conn.Trener.ToList());
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
            var n = new Abon();
            n.secName = Asecname.Text;
            MessageBox.Show(Abb.SelectedItem.ToString());
            n.ID_typeAb = GetAbbID(Abb.SelectedItem.ToString());
            n.name = Aname.Text;
            n.ID_zal = GetZallID(Zali.SelectedItem.ToString());
            n.ID_trener = GetTrenerID(trenrk.SelectedItem.ToString());
            n.Count_trens = int.Parse(much.Text);
            n.Date_start = start.SelectedDate;
            n.Date_finish = fin.SelectedDate;
            n.Price = GetAbonPrice(n.ID_typeAb, n.Date_start, n.Date_finish);
            bd_connection.conn.Abon.Add(n);
            bd_connection.conn.SaveChanges();
            MessageBox.Show("Вы преобрели абонемент!");
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
