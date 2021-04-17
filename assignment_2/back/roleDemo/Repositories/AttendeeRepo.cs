using Microsoft.Extensions.Logging;
using roleDemo.Data;
using roleDemo.Models;
using roleDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace roleDemo.Repositories
{
    public class AttendeeRepo
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<EventRepo> _logger;

        public AttendeeRepo(ApplicationDbContext context, ILogger<EventRepo> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Attendee FindOne(Models.Event userEvent, ApplicationUser user)
        {
            return _context.Attendees.FirstOrDefault(attendee => attendee.Event == userEvent && attendee.User == user);
        }

        public IEnumerable<UserVM> FindAllUsersByEvent(Models.Event userEvent)
        {
            try
            {
                return _context.Attendees.Join(_context.Users,
                            attendee => attendee.UserId,
                            user => user.Id,
                            (attendee, user) => new { attendee, user })
                            .Where(result => result.attendee.Event == userEvent)
                            .Select(result => new UserVM
                            {
                                UserName = result.user.UserName,
                                FirstName = result.user.FirstName,
                                LastName = result.user.LastName
                            }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now}: {e.Message}");
                return null;
            }
        }

        public IEnumerable<EventVM> FindAllEventsByUser(ApplicationUser user)
        {
            try
            {
                return _context.Attendees.Join(_context.Events,
                            attendee => attendee.EventId,
                            userEvent => userEvent.Id,
                            (attendee, userEvent) => new { attendee, userEvent })
                            .Where(result => result.attendee.User == user)
                            .Select(result => new EventVM
                            {
                                Id = result.userEvent.Id,
                                Name = result.userEvent.Name,
                                DateTime = result.userEvent.DateTime,
                                Description = result.userEvent.Description
                            }).ToList();
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now}: {e.Message}");
                return null;
            }
        }

        public bool Create(Models.Event userEvent, ApplicationUser user)
        {
            try
            {
                _context.Add(new Attendee { Event = userEvent, User = user });
                var c = _context.SaveChanges();
                return c > 0;
            }
            catch (Exception e)
            {
                _logger.LogError($"{DateTime.Now}: {e.Message}");
                return false;
            }
        }

        public bool Delete(Models.Event userEvent, ApplicationUser user)
        {
            var attendee = FindOne(userEvent, user);
            if (attendee == null) return false;

            try
            {
                _context.Remove(attendee);
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
