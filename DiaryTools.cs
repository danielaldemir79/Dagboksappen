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

            if (myDiary.ContainsKey(date))
            {
                Console.Clear();
                Design.Red("\n Det finns redan en anteckning för detta datum\n\n");
                return;
            }

            Design.Yellow(" Skriv din anteckning: ");
            string text = DiaryEntry.EnterText();

            myDiary[date] = new DiaryEntry { Date = date, Text = text };
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
           

            if (!myDiary.ContainsKey(date))
            {
                Console.Clear();
                Design.Red("\n Det finns ingen anteckning för detta datum\n\n");
                return;
            }
           
            myDiary.Remove(date);

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
            if (myDiary.Count == 0)
            {
                Design.Red(" Det finns inga anteckningar att visa.\n");
                return;
            }
            var sortedDiary = myDiary.OrderBy(entry => entry.Key);

            Design.Green(" Alla anteckningar\n");
            Design.Yellow(" Sorterad efter datum.\n\n");

            foreach (var entry in sortedDiary)
            {
                Design.Yellow($" {entry.Key:yyyy-MM-dd}");
                Console.WriteLine($" {entry.Value.Text}");
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
            DateTime date = DiaryEntry.EnterDate();
            if (!myDiary.ContainsKey(date))
            {
                Console.Clear();
                Design.Red(" Det finns ingen anteckning för detta datum\n");
                return;
            }

            Design.Yellow (" Skriv din nya anteckning:");
            string text = DiaryEntry.EnterText();

            myDiary[date].Text = text;
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

            if (myDiary.TryGetValue(date, out DiaryEntry entry))
            {
                Design.Yellow($"\n {date:yyyy-MM-dd} ");
                Console.WriteLine($": {entry.Text}");
            }
            else
            {
                Design.Red("\n Det finns ingen anteckning för detta datum\n");

            }

            Design.ClearScreen();
        }
    }
}
