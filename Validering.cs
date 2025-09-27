using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    internal class Validering
    {
        public static int GetInt()
        {
            int helTal;

            while (!int.TryParse(Console.ReadLine(), out helTal))
            {
                Console.WriteLine("Ogiltigt val, försök igen:");
            }
            
            return helTal;

        }

        public static double GetDouble()
        {
            double tal;

            while (!double.TryParse(Console.ReadLine(), out tal))
            {
                Console.WriteLine("Ogiltigt val, försök igen:");
            }

            return tal;

        }

        public static string GetString()
        {
            string text = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Texten får inte vara tom, försök igen:");
                text = Console.ReadLine();
            }

            return text;
        }

        public static DateOnly GetDateOnly()
        {
            DateOnly datum;
            string input;
            Console.WriteLine("Ange datum (ÅÅÅÅ-MM-DD):");

            while (true)
            {
                input = Console.ReadLine();
                if (DateOnly.TryParseExact(input, "yyyy-MM-dd", out datum))
                {
                    return datum;
                }
                Console.WriteLine("Ogiltigt datum, försök igen (ÅÅÅÅ-MM-DD):");
            }
        }
    }
}
