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
        

        public MainWindow()
        {
            InitializeComponent();
            
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await Task.Run(() => WhiteoutSurvival_Bot.Program.Main());
        }


        private void TextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}