using Xunit;
using System.Collections.Generic;

namespace Assignment1.Tests
{
    public class RegExprTests
    {
        [Fact]
        public void SplitLine_Given_Stream_of_Strings()
        {
            IEnumerable<string> input = new string[] { "skr., abcdefg", "123 abc" };

            IEnumerable<string> output = RegExpr.SplitLine(input);

            Assert.Equal(new[] { "skr", "abcdefg", "123", "abc" }, output);
        }

        [Fact]
        public void Resolution_Given_String_of_Resolutions()
        {
            string input = "1920x1080, 3000x0000, 2000x3000";

            IEnumerable<(int, int)> output = RegExpr.Resolution(input);

            IEnumerable<(int, int)> expectedOutput = new (int, int)[] { (1920, 1080), (3000, 0000), (2000, 3000) };
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void InnerText_given_HTML_string()
        {
            var input = @"<div><p>A <b>regular expression</b>, <b>regex</b> or <b>regexp</b> (sometimes called a <b>rational expression</b>) is, in <a href='/wiki/Theoretical_computer_science' title='Theoretical computer science'>theoretical computer science</a> and <a href='/wiki/Formallanguage' title='Formal language'>formal language</a> theory, a sequence of <a href='/wiki/Character(computing)' title='Character (computing)'>characters</a> that define a <i>search <a href='/wiki/Pattern_matching' title='Pattern matching'>pattern</a></i>. Usually this pattern is then used by <a href='/wiki/String_searchingalgorithm' title='String searching algorithm'>string searching algorithms</a> for 'find' or 'find and replace' operations on <a href='/wiki/String(computer_science)' title='String (computer science)'>strings</a>.</p></div>";

            var expected = new List<string>() { "theoretical computer science", "formal language", "characters", "pattern", "string searching algorithms", "strings" };

            Assert.Equal(expected, RegExpr.InnerText(input, "a"));
        }

        [Fact]
        public void InnerText_given_nested_html()
        {
            var input = @"<div> <p>The phrase <i>regular expressions</i> (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing <u>patterns</u> that matching <em>text</em> need to conform to.</p> </div>";

            var expected = new List<string>() {"The phrase regular expressions (and consequently, regexes) is often used to mean the specific, standard textual syntax for representing patterns that matching text need to conform to."};

            Assert.Equal(expected, RegExpr.InnerText(input, "p"));
        }

    }
}
