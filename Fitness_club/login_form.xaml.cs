using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для login_form.xaml
    /// </summary>
    public partial class login_form : Page
    {
        public static ObservableCollection<Client> clientss { get; set; }
        public login_form()
        {
            InitializeComponent();
        }

        private void Autor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Registration());
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            clientss = new ObservableCollection<Client>(bd_connection.conn.Client.ToList());
            var nothing = clientss.Where(a => a.Login == Email.Text && a.password == Password.Password).FirstOrDefault();
            if (nothing != null)
            {
                CurrentSession.client = nothing;
                NavigationService.Navigate(new Kabinet());
            }
            else
            {
                MessageBox.Show("Error", "440", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
