using Microsoft.AspNetCore.Mvc;
using MediatR;
using Backend.Commands;
using Backend.Queries;
using Backend.Data;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly UserDbContext _context;


        public UserController(IMediator mediator, UserDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserCommand command)
        {
            var user = await _mediator.Send(command);
            return Ok(new { user.Id, user.Name, user.Email });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));
            return Ok(user);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUserById(int id, UpdateUserCommand command)
        {
            if (id != command.UserId)
            {
                return BadRequest("User ID mismatch");
            }
            var user = await _mediator.Send(command);
            if (!user)
            {
                return NotFound();
            }

            return Ok("Usuario Atualizado com sucesso!");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserById(int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand());
            return Ok(user);
        }


    }
}
