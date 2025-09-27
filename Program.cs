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
            DiaryTools diaryTools = new DiaryTools();

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
                        diaryTools.AddNote();
                        break;

                    case 2:
                        Console.WriteLine("Lista alla anteckningar");
                        break;
                    case 3:
                        Console.WriteLine("Sök anteckningar på datum");
                        break;
                    case 4:
                        Console.WriteLine("Uppdatera anteckningar");
                        break;
                    case 5:
                        diaryTools.RemoveNote();
                        break;
                    case 6:
                        Console.WriteLine("Spara till fil.");
                        break;
                    case 7:
                        Console.WriteLine("Läs från fil.");
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
            Console.WriteLine("1. Skriv ny anteckning");
            Console.WriteLine("2. Lista alla anteckningar");
            Console.WriteLine("3. Sök anteckningar på datum");
            Console.WriteLine("4. Uppdatera anteckning");
            Console.WriteLine("5. Ta bort anteckning");
            Console.WriteLine("6. Spara till fil");
            Console.WriteLine("7. Läs från fil");
            Console.WriteLine("8. Avsluta");

        }

    }


}

       



         

            
