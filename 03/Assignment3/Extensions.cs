using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BDSA2020.Assignment03
{
    public static class Extensions
    {
        public static IEnumerable<T> Flatten<T>(this IEnumerable<IEnumerable<T>> collection) => collection.SelectMany(item => item);
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate) => collection.Where( i => predicate.Invoke(i));
        public static IEnumerable<int> GetNumbers_Exercise1(this IEnumerable<int> collection) => collection.Where( number => (number % 7 == 0) && (number > 42));
        public static IEnumerable<int> GetLeapYears(this IEnumerable<int> collection) => collection.Where( year => (year % 4 == 0) && (year % 100 != 0 || year % 400 == 0));
        public static bool IsSecure(this Uri uri) => uri.Scheme == Uri.UriSchemeHttps;
        public static int WordCount(this string str) => new Regex(@"[a-zA-Z]+").Matches(str).Count; 
    }
}
