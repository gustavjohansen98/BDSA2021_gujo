using System;
using Xunit;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Assignment4.Core;

namespace Assignment4.Entities.Tests
{
    public class TagRepositoryTests : TestDataGenerator
    {
        [Fact]
        public async void Db_available() => Assert.True(await _context.Database.CanConnectAsync());

        [Fact]
        public void TestName()
        {
        //Given
        
        //When
        
        //Then
        }
    }
}
