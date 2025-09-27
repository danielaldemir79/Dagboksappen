using System.ComponentModel.DataAnnotations;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dagboksappen
{
    internal class Program
    {

        static void Main(string[] args)
        {

            Dictionary<DateOnly, string> myDiary = new Dictionary<DateOnly, string>();
            DiaryEntry diaryEntry = new DiaryEntry();

            Console.WriteLine("Välkommen till din dagbok\n");


            while (true)
            {

                Console.WriteLine("Dagboksappen!");
                Console.WriteLine("1. Skriv ny anteckning");
                Console.WriteLine("2. Lista alla anteckningar");
                Console.WriteLine("3. Uppdatera anteckningar");
                Console.WriteLine("4. Ta bort Anteckningar");
                Console.WriteLine("5. Spara till fil.");
                Console.WriteLine("6. Läs från fil.");
                Console.WriteLine("7. Avsluta");
                Console.Write("Välj ett alternativ (1-7): ");

                int choice = Validering.GetInt();

                if (choice == 7)
                {
                    break;
                }

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Skriv ny anteckning");
                        break;
                    case 2:
                        Console.WriteLine("Lista alla anteckningar");
                        break;
                    case 3:
                        Console.WriteLine("Uppdatera anteckningar");
                        break;
                    case 4:
                        Console.WriteLine("Ta bort Anteckningar");
                        break;
                    case 5:
                        Console.WriteLine("Spara till fil.");
                        break;
                    case 6:
                        Console.WriteLine("Läs från fil.");
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, försök igen.");
                        break;
                }


            }



        }

      

    }

}
