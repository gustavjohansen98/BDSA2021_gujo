using System;
using Assignment4.Core;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Assignment4.Entities.Tests
{
    public class TaskRepositoryTests : TestDataGenerator
    {
        [Fact]
        public async void Db_available() => Assert.True(await _context.Database.CanConnectAsync());

        [Fact]
        public void Find_gustav()
        {
            Seed(_context);

            var user = _context.Users.Find(3);
            Assert.Equal("Gustav Johansen", user.Name);
        }

        [Fact]
        public void Find_paolo()
        {
            Seed(_context);

            var user = _context.Users.Find(2);
            Assert.Equal("Paolo Tell", user.Name);
        }
    }
}
