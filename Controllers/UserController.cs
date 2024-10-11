using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
using Backend.Context;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _context;

        public UserController(UserDbContext context)
        {
            _context = context;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers([FromServices] GetUsersQueryHandler handler)
        {
            var query = new GetUsersQuery();
            var users = await handler.Handle(query);
            return Ok(users);
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id, [FromServices] GetUserQueryHandler handler)
        {
            var query = new GetUserQuery { Id = id };
            var user = await handler.Handle(query);
            if (user == null) return NotFound();
            return user;
        }

        // PUT: api/User/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUSer(int id, UpdateUserCommand command, [FromServices] UpdateUserCommandHandler handler)
        {
            if (id != command.Id) return BadRequest();
            await handler.Handle(command);
            return NoContent();


        }

        // POST: api/User
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(CreateUserCommand command, [FromServices] CreateUserCommandHandler handler)
        {
            var user = await handler.Handle(command);
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id, [FromServices] DeleteUserCommandHandler handler)
        {
            var command = new DeleteUserCommand { Id = id };
            await handler.Handle(command);
            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

    }
}
