using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;   //檢查格式

namespace IdentityID_checker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter your Identity ID (First letter must be uppercase) : ");
            String ID = Console.ReadLine();
            if (IDisValid(ID))
            {
                Console.WriteLine("The ID is valid.");
            }
            else
            {
                Console.WriteLine("The ID is invalid.");
            }

            Console.ReadKey();
        }

        static int AlphabetToNumber(char charID)
        {
            string alphabet = "ABCDEFGHJKLMNPQRSTUVWXYZIO";
            int number = alphabet.IndexOf(charID) + 10;
            return number;
        }

        static int CharNumToIntNum(char charID)
        {
            string charNum = "0123456789";
            int intNum = charNum.IndexOf(charID);
            return intNum; 
        }

        static bool IDisValid(String ID)
        {
            String forbat = "^[A-Z][1-2][0-9]{8}$";
            Regex rg = new Regex(forbat);   //規則運算式
            if (!rg.IsMatch(ID))
            {
                Console.WriteLine("Incorrect forbat.");
                return false;
            }

            char[] charID = ID.ToCharArray();
            int[] magnification = { 1, 9, 8, 7, 6, 5, 4, 3, 2, 1, 1 };
            int total = 0;

            for(int i=0 ; i<charID.Length ; i++)
            {
                if (i == 0)
                {
                    total += (AlphabetToNumber(charID[i])) / 10 * magnification[i];
                    total += (AlphabetToNumber(charID[i])) % 10 * magnification[i + 1];
                }
                else
                {
                    total += CharNumToIntNum(charID[i]) * magnification[i+1];
                }
            }

            return total % 10 == 0;
        }
    }

    
}
