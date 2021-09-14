using System;
using System.Collections.Generic;

namespace Assignment1
{
    public static class Iterators
    {
        public static IEnumerable<T> Flatten<T>(IEnumerable<IEnumerable<T>> items)
        {
            throw new NotImplementedException();
        }

        public static IEnumerable<T> Filter<T>(IEnumerable<T> items, Predicate<T> predicate)
        {
            throw new NotImplementedException();
        }

        public static bool Even(int i) 
        {
            return i % 2 == 0;
        }

        public static void Main(string[] args)
        {
            Predicate<int> even = Even;
        }
    }
}
