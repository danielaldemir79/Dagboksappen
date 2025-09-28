using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dagboksappen
{
    internal class DiaryTools
    {

        public static Dictionary<DateTime, DiaryEntry> myDiary = new Dictionary<DateTime, DiaryEntry>();
        //public DiaryEntry diaryEntry = new DiaryEntry();


        public static void AddNote()
        {
            Console.Clear();
            Design.Green("╔══════════════════════════════╗\n");
            Design.Green("║                              ║\n"); 
            Design.Green("║     LÄGG TILL ANTECKNING     ║\n");
            Design.Green("║                              ║\n");
            Design.Green("╚══════════════════════════════╝\n\n");

            DateTime date = DiaryEntry.EnterDate();

            if (myDiary.ContainsKey(date))                                                  //Kontrollerar om det angivna datumet redan finns som en nyckel i myDiary-dictionaryn. Avbryter med felmeddelande om så är fallet.
            {
                Console.Clear();
                Design.Red("\n Det finns redan en anteckning för detta datum\n\n");
                return;
            }

            Design.Yellow(" Skriv din anteckning: ");
            string text = DiaryEntry.EnterText();

            myDiary[date] = new DiaryEntry { Date = date, Text = text };                    //Lägger till en ny anteckning i myDiary-dictionaryn med det angivna datumet som nyckel och en ny instans av DiaryEntry som värde.
            Console.Clear();
            Design.Green(" Anteckningen har lagts till.\n\n");
        }

        
        public static void RemoveNote()
        {

            Console.Clear();
            Design.Red("╔══════════════════════════════╗\n");
            Design.Red("║                              ║\n");
            Design.Red("║      TA BORT ANTECKNING      ║\n");
            Design.Red("║                              ║\n");
            Design.Red("╚══════════════════════════════╝\n\n");
            
            ViewAllNotes();

            Design.Red(" \n Vilken anteckning vill du ta bort?\n");
            DateTime date = DiaryEntry.EnterDate();
           

            if (!myDiary.ContainsKey(date))                                                 //Kontrollerar om det angivna datumet inte finns som en nyckel i myDiary-dictionaryn. Avbryter med felmeddelande om så är fallet.
            {
                Console.Clear();
                Design.Red("\n Det finns ingen anteckning för detta datum\n\n");
                return;
            }
           
            myDiary.Remove(date);                                                           //Tar bort anteckningen som motsvarar det angivna datumet från myDiary-dictionaryn.

            Console.Clear();
            Design.Green("Anteckningen har tagits bort.\n");

        }

       
        public static void ListNotes()
        {
            Console.Clear();

            Design.Yellow("╔═══════════════════════════════╗\n");
            Design.Yellow("║                               ║\n");
            Design.Yellow("║   DIN LISTA AV ANTECKNINGAR   ║\n");
            Design.Yellow("║                               ║\n");
            Design.Yellow("╚═══════════════════════════════╝\n\n");

            ViewAllNotes();

            Design.ClearScreen();
        }

        public static void ViewAllNotes()
        {
            if (myDiary.Count == 0)                                             //Kontrollerar om myDiary-dictionaryn är tom och skriver ut ett meddelande om så är fallet.
            {
                Design.Red(" Det finns inga anteckningar att visa.\n");
                return;
            }
            var sortedDiary = myDiary.OrderBy(entry => entry.Key);             //Sorterar myDiary-dictionaryn efter nycklarna (datum) i stigande ordning och lagrar resultatet i sortedDiary.

            Design.Green(" Alla anteckningar\n");
            Design.Yellow(" Sorterad efter datum.\n\n");

            foreach (var entry in sortedDiary)                                 //Loopar genom varje post i sortedDiary och skriver ut datumet och den formaterade texten för varje anteckning.
            {
                Design.Yellow($" {entry.Key:yyyy-MM-dd}");
                Console.WriteLine(TextFormat(entry.Value.Text, 50));
            }
        }

        public static void UpdateNote()
        {
            Console.Clear();

            Design.Yellow("╔════════════════════════════════╗\n");
            Design.Yellow("║                                ║\n");
            Design.Yellow("║    UPPDATERA DIN ANTECKNING    ║\n");
            Design.Yellow("║                                ║\n");
            Design.Yellow("╚════════════════════════════════╝\n\n");

            ViewAllNotes();
            
            Design.Green("\n\n Vilken anteckning vill du uppdatera?\n");
            DateTime date = DiaryEntry.EnterDate();                                     //Anropar metoden EnterDate från DiaryEntry-klassen för att få ett datum från användaren.
            if (!myDiary.ContainsKey(date))                                             //Kontrollerar om det angivna datumet inte finns som en nyckel i myDiary-dictionaryn. Avbryter med felmeddelande om så är fallet.
            {
                Console.Clear();
                Design.Red(" Det finns ingen anteckning för detta datum\n");
                return;
            }

            Design.Yellow (" Skriv din nya anteckning:");
            string text = DiaryEntry.EnterText();

            myDiary[date].Text = text;                                                  //Uppdaterar texten för den anteckning som motsvarar det angivna datumet med den nya texten som användaren har angett.
            Console.Clear();
            Design.Green(" Anteckningen har uppdaterats.\n");
        }

        public static void SearchDate()
        {
            Console.Clear();
            Design.Yellow("╔════════════════════════════════╗\n");
            Design.Yellow("║                                ║\n");
            Design.Yellow("║     SÖK EFTER EN ANTECKNING    ║\n");
            Design.Yellow("║                                ║\n");
            Design.Yellow("╚════════════════════════════════╝\n\n");
            
            Design.Green(" Vilket datum vill du söka efter?\n\n");
            DateTime date = DiaryEntry.EnterDate();

            if (myDiary.TryGetValue(date, out DiaryEntry entry))                    //Försöker hämta värdet (anteckningen) från myDiary-dictionaryn baserat på det angivna datumet.
            {
                Design.Yellow($"\n {date:yyyy-MM-dd} ");                            //Om anteckningen finns, skrivs datumet ut i formatet ÅÅÅÅ-MM-DD.  
                Console.WriteLine(TextFormat(entry.Text, 50));                      //Den formaterade texten för anteckningen skrivs också ut med en maxlängd på 50 tecken per rad.
            }
            else
            {
                Design.Red("\n Det finns ingen anteckning för detta datum\n");

            }

            Design.ClearScreen();
        }

        public static string TextFormat(string text, int maxLineLength)  
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            var words = text.Split(' ');                                        //Denna array används för att dela upp texten i ord baserat på mellanslag.   
            var lines = new List<string>();                                     //Denna lista används för att lagra de formaterade raderna av text.
            string currentLine = "";                                            //Denna sträng används för att bygga upp den aktuella raden av text.
            Console.WriteLine();
            foreach (var word in words)                                         //Denna loop itererar genom varje ord i words-arrayen.
            {
                if ((currentLine.Length + word.Length + 1) > maxLineLength)     //Om längden på currentLine plus längden på det aktuella ordet plus ett mellanslag överstiger maxLineLength
                {
                    lines.Add(" " + currentLine.TrimEnd());                     //Läggs currentLine till i lines-listan efter att eventuella avslutande mellanslag har tagits bort.
                    currentLine = "";                                           //currentLine återställs till en tom sträng för att börja bygga en ny rad.
                }
                currentLine += word + " ";                                      //Det aktuella ordet läggs till i currentLine tillsammans med ett mellanslag.
            }
            if (currentLine.Length > 0)                                         //Efter loopen, om currentLine inte är tom
                lines.Add(" " + currentLine.TrimEnd() + "\n");                  //Läggs den sista raden till i lines-listan efter att eventuella avslutande mellanslag har tagits bort.

            return string.Join(Environment.NewLine, lines);                     //Slutligen returneras en enda sträng som består av alla rader i lines-listan, separerade med radbrytningar.
        }
    }
}
