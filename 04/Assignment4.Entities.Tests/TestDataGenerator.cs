using System;
using System.Collections.Generic;
using Assignment4.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using static Assignment4.Core.State;

namespace Assignment4.Entities.Tests
{
    [Xunit.Collection("Sequential")]
    public abstract class TestDataGenerator : IDisposable
    {
        private const string _connectionString = "DataSource=:memory";
        private readonly SqliteConnection _connection;
        protected readonly KanbanContext _context;

        protected TestDataGenerator()
        {
            _connection = new SqliteConnection(_connectionString);
            _connection.Open();

            var options = new DbContextOptionsBuilder<KanbanContext>()
                              .UseSqlite(_connection)
                              .Options;

            _context = new KanbanContext(options);
            _context.Database.EnsureCreated();

            // Seed(_context);
        }

        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
            _connection.Close();
        }

        protected void Seed(DbContext context)
        {
            var users = new[] {
                new User { Id = 1, Name = "Rasmus Lystrøm", Email = "rasmus@itu.dk"},
                new User { Id = 2, Name = "Paolo Tell", Email = "paolo@itu.dk"},
                new User { Id = 3, Name = "Gustav Johansen", Email = "gujo@itu.dk"},
            };

            var tags = new[] {
                new Tag { Id = 1, Name = "task is urgent", Tasks = new List<Task>()},
                new Tag { Id = 2, Name = "task can wait", Tasks = new List<Task>()},
            };

            var tasks = new[] {
                new Task { Id = 1, Title = "Complete assignment 4", Description = "Due date is this friday", State = Active,},
                new Task { Id = 2, Title = "Hand in assignment 4", State = New,},
            };

            context.AddRange(users);
            context.AddRange(tasks);
            context.AddRange(tags);

            context.SaveChanges();

        }

    }
}