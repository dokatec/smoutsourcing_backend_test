using Backend.Data;
using Backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;  // Adiciona o namespace para IConfiguration

namespace ApiAuthPostgres.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthDbContext _context;
        private readonly IConfiguration _configuration;  // Injeta o IConfiguration

        public AuthController(AuthDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;  // Inicializa o IConfiguration
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(Register registerUser)
        {
            if (await _context.AuthUsers.AnyAsync(u => u.Email == registerUser.Email))
            {
                return BadRequest("Username is already taken.");
            }

            var user = new AuthUser
            {

                Email = registerUser.Email,
                PasswordHash = HashPassword(registerUser.Password)
            };

            _context.AuthUsers.Add(user);
            await _context.SaveChangesAsync();

            return Ok("User registered successfully!");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(Login loginUser)
        {
            var user = await _context.AuthUsers.SingleOrDefaultAsync(u => u.Email == loginUser.Email);

            if (user == null || !VerifyPassword(loginUser.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials.");
            }

            // Gera o JWT
            var token = GenerateJwtToken(user);
            return Ok(new { token });
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        private bool VerifyPassword(string password, string passwordHash)
        {
            var hash = HashPassword(password);
            return hash == passwordHash;
        }

        private string GenerateJwtToken(AuthUser user)  // Use AuthUser no lugar de User
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var credentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            if (secretKey.KeySize < 256)
                throw new ArgumentException("A chave secreta precisa ter pelo menos 256 bits (32 caracteres).");

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryMinutes"])),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
