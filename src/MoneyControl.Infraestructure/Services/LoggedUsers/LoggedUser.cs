using Microsoft.EntityFrameworkCore;
using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Security.Tokens;
using MoneyControl.Domain.Services.LoggedUsers;
using MoneyControl.Infraestructure.DataAccess;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace MoneyControl.Infraestructure.Services.LoggedUsers
{
    public class LoggedUser(MoneyControlDbContext context, ITokenProvider _tokenProvider) : ILoggedUser
    {

        private readonly MoneyControlDbContext _context = context;

        private readonly ITokenProvider _tokenProvider; 

        public async Task<User> Get()
        {
            var token = _tokenProvider.GetTokenOnRequest();
            var tokenHandler = new JwtSecurityTokenHandler();

            var jwtToken = tokenHandler.ReadJwtToken(token);

            var identifier = jwtToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;

            return await _context.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
        }
    }
}
