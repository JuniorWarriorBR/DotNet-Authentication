using jobRegister.Models.UserModel;
using jobRegister.Repositories.UserRepository;
using jobRegister.Services.JwtBearerService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace jobRegister.Controllers
{
    [ApiController]
    [Route("user")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] User model, [FromServices] IUserRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            repository.Create(model);

            return Ok();
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLogin model, [FromServices] IUserRepository repository)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            User User = repository.Read(model.Email, model.Password);

            if (User == null)
                return Unauthorized();

            var token = TokenService.GenerateToken(User);
            User.Password = "";

            return Ok(new
            {
                User = User,
                token = token
            });
        }
    }
}
