using System;
using Xunit;
using Assignment4.Core;
using static Assignment4.Core.Response;
using System.Linq;

namespace Assignment4.Entities.Tests
{
    public class UserRepositoryTests : TestDataGenerator
    {

        [Fact]
        public void Given_CreateUserDTO_With_Existing_Email_returns_Conflict()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var newUser = new UserCreateDTO {
                Email = "gujo@itu.dk",
                Name = "Doesn't matter",
            };

            var responseTuple = _repo.Create(newUser);

            Assert.Equal((Conflict, -1), responseTuple);
        }

        [Fact]
        public void Given_CreateUserDTO_With_NonExisting_Email_returns_Created()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var newUser = new UserCreateDTO {
                Email = "test@test.com",
                Name = "test",
            };

            var responseTuple = _repo.Create(newUser);

            var user = _context.Users.FirstOrDefault(x => x.Name == newUser.Name);

            Assert.Equal((Created, 4), responseTuple);
            Assert.Equal(user.Name, newUser.Name);
        }

        [Fact]
        public void Given_user_in_use_delete_with_force_returns_deleted()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var response = _repo.Delete(3, true);

            Assert.Equal(Deleted, response);
            Assert.Null(_context.Tasks.Find(1).AssignedTo);
            Assert.Null(_context.Tasks.Find(2).AssignedTo);
        }

        [Fact]
        public void Given_user_in_use_delete_no_force_returns_conflict()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var response = _repo.Delete(3);

            Assert.Equal(Conflict, response);
            Assert.NotNull(_context.Tasks.Find(1).AssignedTo);
            Assert.NotNull(_context.Tasks.Find(2).AssignedTo);
        }

    }
}
