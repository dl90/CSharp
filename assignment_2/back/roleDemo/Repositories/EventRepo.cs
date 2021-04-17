using Microsoft.Extensions.Logging;
using roleDemo.Data;
using roleDemo.ViewModels;
using System;
using System.Linq;

namespace roleDemo.Repositories
{
    public class EventRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventRepo> _logger;

        public EventRepo(ApplicationDbContext context, ILogger<EventRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Models.Event FindOne(int id)
        {
            return _context.Events.FirstOrDefault(e => e.Id == id);
        }

        public IQueryable<Models.Event> GetAll()
        {
            return _context.Events.OrderByDescending(e => e.DateTime);
        }

        public bool Create(EventVM eventVM)
        {
            try
            {
                _context.Add(new Models.Event
                {
                    Name = eventVM.Name,
                    DateTime = eventVM.DateTime,
                    Description = eventVM.Description
                });
                var c = _context.SaveChanges();
                return c > 0;
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now}: {e.Message}");
                return false;
            }
        }

        public bool Delete(int id)
        {
            var ev = FindOne(id);
            if (ev == null) return false;

            try
            {
                _context.Remove(ev);
                var c = _context.SaveChanges();
                return c > 0;
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now}: {e.Message}");
                return false;
            }
        }
    }
}
