using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    internal class DiaryTools
    {

        public static Dictionary<DateTime, string> myDiary = new Dictionary<DateTime, string>();
        public DiaryEntry diaryEntry = new DiaryEntry();


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
            myDiary[date] = text;
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

            Design.Red(" Vilken anteckning vill du ta bort?\n");
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

            if (myDiary.Count == 0)
            {
                Console.WriteLine(" Inga anteckningar att visa.");
                return;
            }
            
            foreach (var entry in myDiary)
            {
                Console.WriteLine($" {entry.Key:yyyy-MM-dd}: {entry.Value}");
            }

            Design.ClearScreen();
        }

        public static void UpdateNote()
        {
            DateTime date = DiaryEntry.EnterDate();
            if (!myDiary.ContainsKey(date))
            {
                Console.WriteLine("Det finns ingen anteckning för detta datum");
                return;
            }

            Console.WriteLine("Skriv din nya anteckning:");
            string text = DiaryEntry.EnterText();

            myDiary[date] = text;
            Console.WriteLine("Anteckningen har uppdaterats.");
        }

        public static void SearchDate()
        {
            DateTime date = DiaryEntry.EnterDate();

            if (myDiary.TryGetValue(date, out string text))
            {
                Console.WriteLine($"{date:yyyy-MM-dd}: {text}");
            }
            else
            {
                Console.WriteLine("Det finns ingen anteckning för detta datum");

            }
        }
    }
}
