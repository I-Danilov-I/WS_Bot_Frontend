using System.Windows;
using System.Windows.Documents;
using WhiteoutSurvival_Bot;


namespace WS_Bot_Frontend
{
    public partial class MainWindow : Window
    {
        public static ServicesInitializer botControl = WhiteoutSurvival_Bot.Program.botControl;
    
       
        public MainWindow()
        {
            InitializeComponent();
            botControl = WhiteoutSurvival_Bot.Program.botControl;
        }


        public async Task Run()
        {

            while (true)
            {
                await AppendTextLikeTypewriter("Truppen werden geheilt...");
                botControl.Stability.CheckStability();
                botControl.TruppenHeilen.Heilen();
                await AppendTextLikeTypewriter("Truppenheilung abgeschlossen");

                await AppendTextLikeTypewriter("Lager Ausdauer wird abgeholt...");
                botControl.LagerOnlineBelohnung.AusdauerAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Lager Ausdauer erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Lager Geschenk wird abgeholt...");
                botControl.LagerOnlineBelohnung.GeschnekAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Lager Geschenk erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Geheimdienst wird ausgeführt...");
                botControl.Stability.CheckStability();
                botControl.Geheimdienst.StartProcess();
                await AppendTextLikeTypewriter("Geheimdienst erfolgreich abgeschlossen");

                await AppendTextLikeTypewriter("Allianz Kisten werden abgeholt...");
                botControl.Allianz.KistenAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Allianz Kisten erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Allianz Technologie Beitrag...");
                botControl.Allianz.TechnologieBeitrag(5);
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Allianz Technologie Beitrag erfolgreich abgeschlossen");

                await AppendTextLikeTypewriter("Allianz Hilfe wird gegeben...");
                botControl.Allianz.Hilfe();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Allianz Hilfe erfolgreich gegeben");

                await AppendTextLikeTypewriter("Allianz Autobeitritt wird aktiviert...");
                botControl.Allianz.AutobeitritAktivieren();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Allianz Autobeitritt erfolgreich aktiviert");

                await AppendTextLikeTypewriter("Arena wird betreten...");
                botControl.Arena.GoToArena();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Arena erfolgreich betreten");

                await AppendTextLikeTypewriter("Lebensbaum Belohnung wird abgeholt...");
                botControl.LebensBaum.BaumBelohnungAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Lebensbaum Belohnung erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Lebensbaum von Freunden wird abgeholt...");
                botControl.LebensBaum.EssensVonFreundenAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Lebensbaum von Freunden erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Truppen Training wird durchgeführt...");
                await AppendTextLikeTypewriter("Latten-Träger werden ausgebildet...");
                botControl.TruppenTraining.TrainiereLatenzTreger(500);
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Latten-Träger erfolgreich ausgebildet");

                await AppendTextLikeTypewriter("Infanterie wird ausgebildet...");
                botControl.TruppenTraining.TrainiereInfaterie(500);
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Infanterie erfolgreich ausgebildet");

                await AppendTextLikeTypewriter("Scharfschützen werden ausgebildet...");
                botControl.TruppenTraining.TrainiereSniper(500);
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Scharfschützen erfolgreich ausgebildet");
                await AppendTextLikeTypewriter("Truppen Training erfolgreich abgeschlossen");


                await AppendTextLikeTypewriter("Erkundung wird durchgeführt...");
                botControl.Erkundung.StartProcess();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Erkundung erfolgreich abgeschlossen");

                await AppendTextLikeTypewriter("VIP Kiste wird abgeholt...");
                botControl.VIP.KistenAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("VIP Kiste erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Eilauftrag wird abgeholt...");
                botControl.GuvenourBefehl.EilauftragAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Eilauftrag erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Festlichkeiten werden abgeholt...");
                botControl.GuvenourBefehl.FestlichkeitenAbholen();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Festlichkeiten erfolgreich abgeholt");

                await AppendTextLikeTypewriter("Helden werden rekrutiert...");
                botControl.Helden.HeldenRekrutieren();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Helden erfolgreich rekrutiert");

                await AppendTextLikeTypewriter("Bestienjagd wird gestartet...");
                botControl.Jagt.BestienJagtStarten(25);
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Bestienjagd erfolgreich abgeschlossen");

                await AppendTextLikeTypewriter("Arena wird erneut betreten...");
                botControl.Arena.GoToArena();
                botControl.Stability.CheckStability();
                await AppendTextLikeTypewriter("Arena erfolgreich erneut betreten");
            }
        }









        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            await AppendTextLikeTypewriter("Whiteout Survival Bot starting...");
            await Run();
        }

        public async Task AppendTextLikeTypewriter(string text)
        {
            await Dispatcher.InvokeAsync(() =>
            {
                // Neuen Paragraph für die neue Zeile erstellen
                Paragraph paragraph = new Paragraph();
                logRichTextBox.Document.Blocks.Add(paragraph);
            });

            foreach (char c in text)
            {
                await Dispatcher.InvokeAsync(() =>
                {
                    Run run = new Run(c.ToString()) { Foreground = System.Windows.Media.Brushes.LimeGreen };
                   
                    // Füge das Zeichen zum letzten Paragraph hinzu
                    Paragraph paragraph = logRichTextBox.Document.Blocks.LastBlock as Paragraph ?? new Paragraph();
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
