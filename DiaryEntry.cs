using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    public class DiaryEntry

    {
        public static DateOnly EnterDate()
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
        

        public static string EnterText()
        {
            string text = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Texten får inte vara tom, försök igen:");
                text = Console.ReadLine();
            }

            return text;
        }
    }
}
