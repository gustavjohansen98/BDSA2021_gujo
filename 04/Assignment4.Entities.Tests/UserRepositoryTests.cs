using System;
using Assignment4.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Assignment4.Entities.Tests
{
    public class UserRepositoryTests : TestDataGenerator
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
