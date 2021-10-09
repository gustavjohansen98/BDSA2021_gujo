using System;
using Assignment4.Core;
using Xunit;
using static Assignment4.Core.Response;

namespace Assignment4.Entities.Tests
{
    public class TagRepositoryTests : TestDataGenerator
    {
        // ITagRepository _repo;

        // TagRepositoryTests()
        // {
        //     _repo = new TagRepository(_context);
        // }

        [Fact]
        public void TestName()
        {
            var _repo = new TagRepository(_context);
            Seed(_context);
            var response = _repo.Delete(2);

            Assert.Equal(Conflict, response);
        }
    }
}
