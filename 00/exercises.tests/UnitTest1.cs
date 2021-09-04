using System;
using Xunit;
using System.IO;

namespace exercises.tests
{
    public class UnitTest1
    {
        [Fact]
        public void Main_prints_hello_world()
        {
			
		}

        [Theory]
        [InlineData(400)]
        [InlineData(1600)]
		[InlineData(2000)]
		[InlineData(4)]
		[InlineData(8)]
		[InlineData(0)]
        public void Given_year_returns_true(int year)
        {
			var result = Program.IsLeapYear(year);

			Assert.True(result);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(3)]
		[InlineData(2010)]
		[InlineData(9)]
		[InlineData(100)]
		[InlineData(200)]
        public void Given_year_returns_false(int year)
        {
			var result = Program.IsLeapYear(year);

			Assert.False(result);
        }
    }
}
