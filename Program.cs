using Dagboksappen;
using System.ComponentModel.DataAnnotations;
using System.Net.WebSockets;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dagboksappen
{
    
    internal class Program
    {

        static void Main(string[] args)
        {          
            FileManager.LoadFromFile();

            while (true)
            {

                ShowMenu();

                Design.Yellow(" Ditt val: ");
                int choice = Validering.GetInt();


                if (choice == 8)
                {
                    break;
                }

                switch (choice)
                {
                    case 1:
                        DiaryTools.AddNote();
                        break;

                    case 2:
                        DiaryTools.RemoveNote();
                        break;
                    case 3:
                        DiaryTools.SearchDate();
                        break;
                    case 4:
                        DiaryTools.UpdateNote();
                        break;
                    case 5:
                        DiaryTools.ListNotes();
                        break;
                    case 6:
                        FileManager.LoadFromFile();
                        break;
                    case 7:
                        FileManager.SaveToFile();
                        break;
                    default:
                        Console.Clear();
                        Design.Red("\nOgiltigt val, försök igen.\n\n");
                        break;
                }


            }

        }

        public static void ShowMenu()
        {
            Design.Yellow("╔═══════════════════════╗\n");
            Design.Yellow("║                       ║\n");
            Design.Yellow("║       DIN DAGBOK      ║\n");
            Design.Yellow("║                       ║\n");
            Design.Yellow("╚═══════════════════════╝\n");

            Design.Yellow(" Välj ett alternativ:\n");
            Design.Green(" 1. Lägg till anteckning\n");
            Design.Red(" 2. Ta bort anteckning\n");
            Console.WriteLine(" 3. Sök anteckning på datum");
            Console.WriteLine(" 4. Uppdatera anteckning");
            Console.WriteLine(" 5. Lista alla anteckningar");
            Console.WriteLine(" 6. Läs från fil");
            Design.Green(" 7. Spara till fil\n");
            Design.Red(" 8. Avsluta\n");

        }

    }


}

       



         

            
