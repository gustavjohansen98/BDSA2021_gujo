using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Assignment1
{
    public static class RegExpr
    {
        public static IEnumerable<string> SplitLine(IEnumerable<string> lines)
        {
            var pattern = @"(([A-Za-z0-9]+))";
            var regex = new Regex(pattern);
            
            foreach(string s in lines)
                foreach(var word in regex.Matches(s))
                    yield return word.ToString();
        }

        public static IEnumerable<(int width, int height)> Resolution(string resolutions)
        {
            var pattern = @"((?<width>([0-9]*))x(?<height>([0-9]*)))";
            var matchCollection = Regex.Matches(resolutions, pattern);

            foreach (Match match in matchCollection)
            {
                Int32.TryParse(match.Groups["width"].Value, out int width);
                Int32.TryParse(match.Groups["height"].Value, out int height);
                yield return (width, height);
            }
        }

        public static IEnumerable<string> InnerText(string html, string tag)
        {
            Regex pattern = new Regex($@"\<{tag}.*?\>(.*?)\<\/{tag}\>");

            foreach (Match match in pattern.Matches(html))
            {
                yield return Regex.Replace(match.Groups[1].ToString(), "</*.*?>", String.Empty);
            }
        }
    }
}
