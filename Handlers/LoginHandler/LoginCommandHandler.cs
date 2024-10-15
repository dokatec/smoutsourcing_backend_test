using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Backend.Data;
using Backend.Commands.LoginCommand;
using Backend.Models;

public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginUser>
{
    private readonly LoginDbContext _context;

    public LoginCommandHandler(LoginDbContext context)
    {
        _context = context;
    }

    public async Task<LoginUser> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        var user = await _context.UserLogin
            .SingleOrDefaultAsync(u => u.Email == request.Email && u.Senha == request.Senha, cancellationToken);

        if (user == null)
        {
            return null;
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes("YourSecretKeyHere");
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        var tokenString = tokenHandler.WriteToken(token);

        return new LoginUser { Token = tokenString };
    }
}
