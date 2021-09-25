using System;
using Xunit;
using System.Collections.Generic;
using BDSA2020.Assignment03;

namespace BDSA2020.Assignment03.Tests
{
    public class ExtensionsTests
    {
        [Fact]
        public void Given_Nested_Collection_Return_One_Collection_With_Flatten_Extenstion()
        {
            IEnumerable<IEnumerable<int>> input;
            input = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };

            IEnumerable<int> output = input.Flatten();

            IEnumerable<int> expectedOutput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Filter_with_leapYear_extension()
        {
            var input = new int[]{0, -1, 3, 2010, 2000, 400, 4, 1600, 200};

            var output = input.GetLeapYears();
            var expectedOutput = new int[]{0, 2000, 400, 4, 1600};

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Get_numbers_with_GetNumbers_Extension()
        {
            var input = new int[]{7, 14, 21, 28, 35, 42, 49, 56, 63, 70, 71, 77};
        
            var output = input.GetNumbers_Exercise1();
        
            Assert.Equal(new int[]{49, 56, 63, 70, 77}, output);
        }

        [Theory]
        [InlineData("ftp://test.com/", false)]
        [InlineData("http://test.com/", false)]
        [InlineData("https://test.com/", true)]
        public void Given_Uri_return_true_if_secure(string uri, bool expected)
        {
            Uri input = new Uri(uri);

            bool output = input.IsSecure();

            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData("here are some words", 4)]
        [InlineData("here are some more words", 5)]
        [InlineData("here are some words 0 4 ; #", 4)]
        [InlineData("1241';[{..,", 0)]
        [InlineData("aslkakslfha aksdj", 2)]
        public void Given_string_return_word_count_with_WordCount_extension(string str, int expectedCount)
        {
            int actualCount = str.WordCount();

            Assert.Equal(expectedCount, actualCount);
        }
    }
}
