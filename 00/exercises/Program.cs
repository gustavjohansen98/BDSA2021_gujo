using System;

namespace exercises
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input a year to see if it is a leap year ...\nType exit to terminate the program. \n");

            while (true)
            {
                var input = Console.ReadLine();
                int year;

                if (Int32.TryParse(input, out year))
                {
                    if (year < 1582)
                    {
                        Console.WriteLine("We only accept years from 1582 .. try again \n");
                    }
                    else
                    {
                        string output = IsLeapYear(year) ? "Yay" : "Nay";
                        Console.WriteLine(output + "\nTry another year ... \n");
                    }
                }
                else if (input.ToString().Trim() == "exit")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Gibberish! \nTry another value \n");
                }
            }
        }

        /*
        Every year that is exactly divisible by four is a leap year, 
        except for years that are exactly divisible by 100, 
        but these centurial years are leap years if they are exactly divisible by 400. 
        For example, the years 1700, 1800, and 1900 are not leap years, but the years 1600 and 2000 are.
        */
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }
    }
}
