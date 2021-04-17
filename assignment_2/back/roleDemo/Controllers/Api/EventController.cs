using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using roleDemo.Data;
using roleDemo.Models;
using roleDemo.Repositories;
using roleDemo.ViewModels;
using System.Threading.Tasks;

namespace roleDemo.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly EventRepo _eventRepo;
        private readonly AttendeeRepo _attendeeRepo;

        public EventController(UserManager<ApplicationUser> userManager,
            ApplicationDbContext context,
            ILogger<EventRepo> logger)
        {
            _userManager = userManager;
            _eventRepo = new EventRepo(context, logger);
            _attendeeRepo = new AttendeeRepo(context, logger);
        }

        [HttpGet]
        public IActionResult All()
        {
            return new ObjectResult(new { events = _eventRepo.GetAll() });
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult Details(int id)
        {
            var e = _eventRepo.FindOne(id);
            if (e == null) return StatusCode(410);

            var users = _attendeeRepo.FindAllUsersByEvent(e);
            return new ObjectResult(new { e,  users });
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var success = _eventRepo.Delete(id);
            return success ? StatusCode(200) : StatusCode(404);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Admin")]
        public IActionResult Create([FromBody] EventVM eventVM)
        {
            if (ModelState.IsValid)
            {
                var success = _eventRepo.Create(eventVM);
                return success ? StatusCode(201) : StatusCode(422);
            }
            return StatusCode(400);
        }

        [HttpPost]
        [Route("{id}/attend")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> Attend(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var e = _eventRepo.FindOne(id);
            if (e == null) return StatusCode(410);

            var success = _attendeeRepo.Create(e, user);
            return success ? StatusCode(201) : StatusCode(422);
        }

        [HttpDelete]
        [Route("{id}/attend")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> DelAttend(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            var e = _eventRepo.FindOne(id);
            if (e == null) return StatusCode(410);

            var success = _attendeeRepo.Delete(e, user);
            return success ? StatusCode(201) : StatusCode(422);
        }

        [HttpGet]
        [Route("mine")]
        [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        public async Task<IActionResult> MyEvents(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            return new ObjectResult(new { events = _attendeeRepo.FindAllEventsByUser(user) });
        }
    }
}
