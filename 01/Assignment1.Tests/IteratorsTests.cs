using Xunit;
using System.Collections.Generic;
using System;

namespace Assignment1.Tests
{
    public class IteratorsTests
    {
        [Fact]
        public void Flatten_Given_123456789_returns_123456789()
        {
            IEnumerable<IEnumerable<int>> input;
            input = new int[][] { new int[] { 1, 2, 3 }, new int[] { 4, 5, 6 }, new int[] { 7, 8, 9 } };

            IEnumerable<int> output = Iterators.Flatten(input);


            IEnumerable<int> expectedOutput = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Filter_with_even_predicate()
        {
            var numbers = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};

            var output = Iterators.Filter(numbers, Iterators.Even);
            var expectedOutput = new int[]{2, 4, 6, 8};

            Assert.Equal(expectedOutput, output);
        }

        [Fact]
        public void Filter_with_leapYear_function()
        {
        var input = new int[]{0, -1, 3, 2010, 2000, 400, 4, 1600, 200};
        
        var output = Iterators.Filter(input, Iterators.IsLeapYear);
        var expectedOutput = new int[]{0, 2000, 400, 4, 1600};
        
        Assert.Equal(expectedOutput, output);
        }
    }
}
