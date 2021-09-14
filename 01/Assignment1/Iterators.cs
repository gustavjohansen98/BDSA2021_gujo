using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            // cleanest solution using Linq
            return items.SelectMany(item => item);
            
            // alternative method with yield implicit implemented and looping over the outer stream
            /* foreach(var outer in items)
                foreach(T item in outer)   
                    yield return item;
            */
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            return items.Where(predicate.Invoke);
        }

        public static bool Even(int i) 
        {
            return i % 2 == 0;
        }

        // let's try with the LeapYear function from assignment 00 as well
        public static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && (year % 100 != 0 || year % 400 == 0);
        }

        public static void Main(string[] args)
        {
            Predicate<int> even = Even;
            Predicate<int> isLeapYear = IsLeapYear;
        }
    }
}
