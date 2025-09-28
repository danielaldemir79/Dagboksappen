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
               Design.Red(" Ogiltigt val, försök igen: ");
            }
            Console.WriteLine();
            return helTal;

        }

       
    }
}
