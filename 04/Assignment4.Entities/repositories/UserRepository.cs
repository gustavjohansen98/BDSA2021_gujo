using System.Collections.Generic;
using Assignment4.Core;
using static Assignment4.Core.Response;
using System.Linq;

namespace Assignment4.Entities
{
    public class UserRepository : IUserRepository
    {
        private readonly IKanbanContext _context;

        public UserRepository(IKanbanContext context)
        {
            _context = context;
        }
        public (Response Response, int UserId) Create(UserCreateDTO user)
        {
            if ( _context.Users.FirstOrDefault(a => a.Email == user.Email) != null )
                return (Conflict, -1);

            var _user = new User {
                Name = user.Name,
                Email = user.Email,
            };

            _context.Users.Add(_user);
            _context.SaveChanges();

            return (Created, _user.Id);
        }

        public Response Delete(int userId, bool force = false)
        {
            var user = _context.Users.Find(userId);
            if (user == null) 
                return NotFound;

            var assignedToUser = _context.Tasks.Where(e => e.AssignedTo == user.Id);

            if ((user.Tasks.Any() || assignedToUser.Any()) && !force)
            {
                return Conflict;
            } 
            else if ((user.Tasks.Any() || assignedToUser.Any()) && force)
            {
                // manual cascade deletion of foreign key is neccessary, since the foreign key is nullable
                // had it not been nullable, ef core would have done it automatically :
                // https://docs.microsoft.com/en-us/ef/core/saving/cascade-delete
                _context.Users.Remove(user);
                assignedToUser.AsEnumerable().ToList().ForEach(e => e.AssignedTo = null);
                _context.SaveChanges();
                return Deleted;
            } 
            else if (!assignedToUser.Any())
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return Deleted;
            }

            return BadRequest;
        }

        public UserDTO Read(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null) return null;

            var dto = new UserDTO(
                user.Id,
                user.Name,
                user.Email
            );

            return dto;
        }

        public IReadOnlyCollection<UserDTO> ReadAll()
        {
            if (!_context.Users.Any()) return null;
            return _context.Users.Select(x => new UserDTO(x.Id, x.Name, x.Email)).ToList().AsReadOnly();
        }

        public Response Update(UserUpdateDTO user)
        {
            var _user = _context.Users.Find(user.Id);
            if (_user == null)
                return NotFound;

            _user.Email = user.Email;
            _user.Name = user.Name;

            _context.SaveChanges();
            return Updated;
        }
    }
}