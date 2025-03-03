using MoneyControl.Domain.Security.Tokens;

namespace MoneyControl.Api.Token
{
    public class HttpContextTokenValue(IHttpContextAccessor _acessor) : ITokenProvider
    {

        private readonly IHttpContextAccessor _acessor; 

      public string GetTokenOnRequest()
        {
            var token = _acessor.HttpContext!.Request.Headers.Authorization.ToString();
            return token.Replace("Bearer ", "").Trim();
            
        }
    }
}
