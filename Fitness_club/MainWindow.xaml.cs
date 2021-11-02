using System.Windows;

namespace Fitness_club
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Enter.NavigationService.Navigate(new login_form());
        }
    }
}
