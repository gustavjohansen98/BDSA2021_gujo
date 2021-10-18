using System;
using System.Collections.Generic;
using System.Linq;
using Assignment4.Core;
using static Assignment4.Core.Response;

namespace Assignment4.Entities
{
    public class TaskRepository : ITaskRepository
    {
        private readonly IKanbanContext _context;

        #nullable enable
        Func<User?, string?> pipe = (x) => x is null ? null : x.Name;
        #nullable disable

        public TaskRepository(IKanbanContext context)
        {
            _context = context;
        }
        public (Response Response, int TaskId) Create(TaskCreateDTO task)
        {
            if (task.AssignedToId != null && _context.Users.Find(task.AssignedToId) is null)
                return (BadRequest, -1);

            List<Tag> final = null;

            if (task.Tags != null && task.Tags.Any())
            {
                var stringTags = task.Tags.Distinct().ToList();
                List<Tag> existingTags = new List<Tag>();

                // maaah, prob would have been better with a join 
                stringTags.ForEach(st => {
                    var ex = _context.Tags.FirstOrDefault(e => e.Name.ToLower() == st.ToLower());
                    if (ex is not null) 
                    {
                        existingTags.Add(ex);
                        stringTags.Remove(st);    
                    } 
                });

                var transformed = stringTags.Select( st => new Tag { Name = st } ).ToList();
                _context.Tags.AddRange(transformed);
                _context.SaveChanges();

                final = transformed.Union(existingTags).ToList();
            }


            var _task = new Task {
                Title = task.Title,
                AssignedTo = task.AssignedToId,
                Description = task.Description,
                State = State.New,
                Tags = final ?? null,
            };

            _context.Tasks.Add(_task);
            _context.SaveChanges();
            return (Created, _task.Id);

        }

        public IReadOnlyCollection<TaskDTO> ReadAll()
        {
            if (!_context.Tasks.Any())
                return null;
            
            return _context.Tasks.Select(t => new TaskDTO
                    (
                        t.Id,
                        t.Title,
                        pipe(_context.Users.Find(t.AssignedTo)),
                        t.Tags.Select(t => t.Name).AsEnumerable().ToList().AsReadOnly(),
                        t.State
                    )
                    ).ToList().AsReadOnly();
        }




        public IReadOnlyCollection<TaskDTO> ReadAllRemoved()
        {
            return ReadAll().Where(t =>  t.State == State.Removed).ToList().AsReadOnly();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByTag(string tag)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByUser(int userId)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyCollection<TaskDTO> ReadAllByState(State state)
        {
            throw new NotImplementedException();
        }

        public TaskDetailsDTO Read(int taskId)
        {
            throw new NotImplementedException();
        }


        public Response Update(TaskUpdateDTO task)
        {
            throw new NotImplementedException();
        }

        public Response Delete(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
