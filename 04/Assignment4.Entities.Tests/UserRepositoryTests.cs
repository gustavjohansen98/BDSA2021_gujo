using System;
using Xunit;
using Assignment4.Core;
using static Assignment4.Core.Response;
using System.Linq;
using System.Collections.Generic;

namespace Assignment4.Entities.Tests
{
    public class UserRepositoryTests : TestDataGenerator
    {

        [Fact]
        public void Given_CreateUserDTO_With_Existing_Email_returns_Conflict()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var newUser = new UserCreateDTO
            {
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

            var newUser = new UserCreateDTO
            {
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
            Assert.Null(_repo.Read(3));
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

        [Fact]
        public void Given_read_2_returns_paolo_tell_as_UserDTO()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var dto = _repo.Read(2);

            Assert.Equal((2, "Paolo Tell", "paolo@itu.dk"), (dto.Id, dto.Name, dto.Email));
        }

        [Fact]
        public void Given_read_0_returns_null()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var dto = _repo.Read(0);

            Assert.Null(dto);
        }

        [Fact]
        public void ReadAll_return_ReadOnly_Collection()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var list = _repo.ReadAll();

            var expected = new List<UserDTO>();
            expected.Add(new UserDTO(1, "Rasmus Lystrøm", "rasmus@itu.dk"));
            expected.Add(new UserDTO(2, "Paolo Tell", "paolo@itu.dk"));
            expected.Add(new UserDTO(3, "Gustav Johansen", "gujo@itu.dk"));

            Assert.Equal(expected.AsReadOnly(), list);
        }

        [Fact]
        public void ReadAll_without_seed_returns_null()
        {
            var _repo = new UserRepository(_context);
            Assert.Null(_repo.ReadAll());
        }

        [Fact]
        public void Update_returns_updated_and_new_name_is_inserted_to_enitity_in_context()
        {
            var _repo = new UserRepository(_context);
            Seed(_context);

            var dto = new UserUpdateDTO {
                Id = 3,
                Name = "test",
                Email = "gujo@itu.dk"
            };

            var respone = _repo.Update(dto);

            Assert.Equal(Updated, respone);
            Assert.Equal("test", _repo.Read(3).Name);
        }

    }
}
