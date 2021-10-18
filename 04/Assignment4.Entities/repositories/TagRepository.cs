using System.Collections.Generic;
using System.Linq;
using Assignment4.Core;
using static Assignment4.Core.Response;

namespace Assignment4.Entities
{
    public class TagRepository : ITagRepository
    {
        private readonly IKanbanContext _context;

        public TagRepository(IKanbanContext context)
        {
            _context = context;
        }
        public (Response Response, int TagId) Create(TagCreateDTO tag)
        {
            if (_context.Tags.FirstOrDefault(e => e.Name == tag.Name) != null)
                return (Conflict, -1);

            var _tag = new Tag {
                Name = tag.Name,
            };

            _context.Tags.Add(_tag);
            _context.SaveChanges();
            return (Created, _tag.Id);
        }

        public Response Delete(int tagId, bool force = false)
        {
            var tag = _context.Tags.Find(tagId);
            if (tag == null)
                return NotFound;

            bool hasSome = tag.Tasks != null && tag.Tasks.Any(); 

            if (hasSome && !force)
            {
                return Conflict;
            }
            else if (hasSome && force)
            {
                // cascade deletion
                _context.Tasks.Where(e => e.Tags.Contains(tag))
                              .AsEnumerable().ToList()
                              .ForEach(e => e.Tags.Remove(tag));
                _context.Tags.Remove(tag);
                _context.SaveChanges();
                return Deleted;
            }

            _context.Tags.Remove(tag);
            _context.SaveChanges();
            return Deleted;
        }

        public TagDTO Read(int tagId)
        {
            var tag = _context.Tags.Find(tagId);
            if (tag == null)
                return null;
            
            return new TagDTO(tag.Id, tag.Name);
        }

        public IReadOnlyCollection<TagDTO> ReadAll()
        {
            return _context.Tags.Select(t => new TagDTO(t.Id, t.Name)).AsEnumerable().ToList().AsReadOnly();
        }

        public Response Update(TagUpdateDTO tag)
        {
            var _tag = _context.Tags.Find(tag.Id);
            if (_tag == null)
                return NotFound;

            _tag.Name = tag.Name;
            _context.SaveChanges();
            return Updated;
        }
    }
}