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
                    
                    await AppendTextLikeTypewriter("Lager ausgauer wird abgeholt...");
                    botControl.LagerOnlineBelohnung.AusdauerAbholen();
                    botControl.Stability.CheckStability();
              
                    // Lager belohnung Geschenk
                    botControl.LagerOnlineBelohnung.GeschnekAbholen();
                    botControl.Stability.CheckStability();

                    // Geheimdienst
                    botControl.Stability.CheckStability();
                    botControl.Geheimdienst.StartProcess();

                    // Allianz Kisten
                    botControl.Stability.CheckStability();
                    botControl.Allianz.KistenAbholen();
         
                    // Allianz Technologie BEitrag
                    botControl.Stability.CheckStability();
                    botControl.Allianz.TechnologieBeitrag(5);
                    botControl.Stability.CheckStability();
             
                    // Allianz Hilfe geben
                    botControl.Allianz.Hilfe();
                    botControl.Stability.CheckStability();

                    // Allianz Autobeitritt 
                    botControl.Allianz.AutobeitritAktivieren();
                    botControl.Stability.CheckStability();

                    // Arena
                    botControl.Arena.GoToArena();
                    botControl.Stability.CheckStability();             

                    // Lebensbaum       
                    botControl.LebensBaum.BaumBelohnungAbholen();
                    botControl.Stability.CheckStability();
      
                    // LAebensbaun von Freunden       
                    botControl.LebensBaum.EssensVonFreundenAbholen();
                    botControl.Stability.CheckStability();
       
                    // Truppen Training          
                    botControl.TruppenTraining.TrainiereLatenzTreger(500);
                    botControl.Stability.CheckStability();  
                    botControl.TruppenTraining.TrainiereInfaterie(500);
                    botControl.Stability.CheckStability();
                    botControl.TruppenTraining.TrainiereSniper(500);
                    botControl.Stability.CheckStability();                

                    // Erkundung Abholen und Kampf         
                    botControl.Erkundung.StartProcess();
                    botControl.Stability.CheckStability();        

                    // VIp Kiste abholen              
                    botControl.VIP.KistenAbholen();
                    botControl.Stability.CheckStability();
                 
                    // Eilauftrag         
                    botControl.GuvenourBefehl.EilauftragAbholen();
                    botControl.Stability.CheckStability();            

                    // Fetlichkeitsauftrag             
                    botControl.GuvenourBefehl.FestlichkeitenAbholen();
                    botControl.Stability.CheckStability();
               
                    // HElden Rekurt         
                    botControl.Helden.HeldenRekrutieren();
                    botControl.Stability.CheckStability();
              
                    // PolarTerror
                    //stopwatch.Restart();
                    //botControl.Jagt.PolarTerrorStarten(6);
                    //botControl.Stability.CheckStability();
                    //Time();

                    // BEtienjagt
                    botControl.Jagt.BestienJagtStarten(25);
                    botControl.Stability.CheckStability();
             
                    // Arena
                    botControl.Arena.GoToArena();
                    botControl.Stability.CheckStability();
                
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
