using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using WhiteoutSurvival_Bot;


namespace WS_Bot_Frontend
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public GameBot? gameBot;

        public MainWindow()
        {
            InitializeComponent();
            Initialisiere_Backend init = new Initialisiere_Backend();
            ServiceProvider gameBot = init.Init();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ( gameBot != null)
            {
                string a = gameBot.GetConfiguration().BaseDirectory;
                gameBot.GetAdbControl().StartADBConnection();
                MessageBox.Show(a);                
            }
        }
    }
}