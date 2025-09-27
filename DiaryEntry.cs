using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dagboksappen
{
    public class DiaryEntry

    {
        public DateTime Date { get; set; }
        public string Text { get; set; }
        public static DateTime EnterDate()
        {
            DateTime date;
            string input;
            Design.Yellow(" Ange datum (ÅÅÅÅ-MM-DD): ");

            while (true)
            {

                input = Console.ReadLine();
                if (DateTime.TryParseExact(input, "yyyy-MM-dd", null, 
                    System.Globalization.DateTimeStyles.None,  out date))
                {
                    return date;
                }

                Design.Red(" Ogiltigt datum, försök igen (ÅÅÅÅ-MM-DD).");


            }
        }
        

        public static string EnterText()
        {
            string text = Console.ReadLine();

            while (string.IsNullOrWhiteSpace(text))
            {
                Design.Red(" Texten får inte vara tom, försök igen: ");
                text = Console.ReadLine();
            }

            return text;
        }


    }
}
