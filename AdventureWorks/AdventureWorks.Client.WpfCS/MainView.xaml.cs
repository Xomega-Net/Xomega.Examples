using System.Windows;

namespace AdventureWorks.Client.WpfCS
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public static void Start()
        {
            MainView main = new MainView();
            Application.Current.MainWindow = main;
            main.Show();
        }

        public MainView()
        {
            InitializeComponent();
        }
    }
}
