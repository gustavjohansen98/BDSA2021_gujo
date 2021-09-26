using System;
using Xunit;
using System.IO;
using System.Text;

namespace BDSA2020.Assignment03.Tests
{
    public class DelegatesTests
    {

        // Delegates 
        Action<string> Reverse = str => 
        {
            var cArray = str.ToCharArray();
            Array.Reverse(cArray);
            Console.WriteLine(new string(cArray));
        };

        Func<decimal, decimal, decimal> Product = (x, y) => x * y;

        Func<string, int, bool> StringIntEqual = (str, number) => number == int.Parse(str); 



        [Fact]
        public void print_reversed_string_given_string()
        {
            var writer = new StringWriter();
            Console.SetOut(writer);
            Reverse("Hej med dig");

            string output = writer.GetStringBuilder().ToString().Trim();

            string expected = "gid dem jeH";
            Assert.Equal(expected, output);
        }

        [Fact]
        public void Given_decimals_return_the_product()
        {
            decimal two = 2.0M;
            decimal four = 4.0M;
        
            decimal product = Product(two, four);
        
            Assert.Equal(8.0M, product);
        }

        [Fact]
        public void Compare_int_and_string_with_StringIntEqual()
        {
            string str = "   0042";
            int number = 42;
        
            bool actual = StringIntEqual(str, number);
        
            Assert.True(actual);
        }
    }
}
