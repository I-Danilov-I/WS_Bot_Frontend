using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace WS_Bot_Frontend
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var bot = WhiteoutSurvival_Bot.Program.botControl;
            var a = bot.Logging.OnLogMessage;
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            // Beispieltext für den Matrix-Stil Effekt
            string textToDisplay = "Hallo Welt! Dies ist eine Matrix-inspirierte Nachricht.\n";

            await AppendTextLikeTypewriter(textToDisplay);

            // Sicherstellen, dass die `Program.Main()` Methode geeignet für asynchrone Aufrufe gestaltet ist
            await Task.Run(() => WhiteoutSurvival_Bot.Program.Main());
        }

        public async Task AppendTextLikeTypewriter(string text)
        {
            foreach (char c in text)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    Run run = new Run(c.ToString()) { Foreground = System.Windows.Media.Brushes.LimeGreen };
                    Paragraph paragraph = logRichTextBox.Document.Blocks.FirstBlock as Paragraph ?? new Paragraph();
                    if (paragraph.Parent == null)
                        logRichTextBox.Document.Blocks.Add(paragraph);
                    paragraph.Inlines.Add(run);
                    logRichTextBox.ScrollToEnd();
                });
                await Task.Delay(50); // Verzögerung zwischen den Zeichen für den Typewriter-Effekt
            }
        }

        private void logRichTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            // Diese Methode könnte für weitere Funktionen implementiert werden, falls benötigt.
        }
    }
}
