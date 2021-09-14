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
        input = new int[][]{new int[]{1, 2, 3}, new int[] {4, 5, 6}, new int[]{7, 8, 9}};

        IEnumerable<int> output = Iterators.Flatten(input);
        
        
        IEnumerable<int> expectedOutput = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9};
        Assert.Equal(expectedOutput, output);
        }
    }
}
