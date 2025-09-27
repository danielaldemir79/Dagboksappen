using Dagboksappen;
using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dagboksappen
{
    
    internal class Program
    {

        static void Main(string[] args)
        {          
            FileManager.LoadFromFile();

            Console.WriteLine("Välkommen till din dagbok\n");


            while (true)
            {

                ShowMenu();

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
                        FileManager.SaveToFile();
                        break;
                    case 7:
                        FileManager.LoadFromFile();
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }


            }

        }

        public static void ShowMenu()
        {
            Console.WriteLine("Välj ett alternativ:");
            Console.WriteLine("1. Lägg till anteckning");
            Console.WriteLine("2. Radera anteckning");
            Console.WriteLine("3. Sök anteckningar på datum");
            Console.WriteLine("4. Uppdatera anteckning");
            Console.WriteLine("5. Lista alla anteckningar");
            Console.WriteLine("6. Spara till fil");
            Console.WriteLine("7. Läs från fil");
            Console.WriteLine("8. Avsluta");

        }

    }


}

       



         

            
