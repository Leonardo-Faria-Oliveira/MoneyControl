using MoneyControl.Domain.Entities;
using MoneyControl.Domain.Security.Tokens;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonTestUtilities.Repositories
{
    public class JwtTokenGeneratorBuilder
    {

        public static IAccessTokenGenerator Build()
        {
            var mock = new Mock<IAccessTokenGenerator>();

            mock.Setup(accessTokenGenerator => accessTokenGenerator.Generate(It.IsAny<User>())).Returns("eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJPbmxpbmUgSldUIEJ1aWxkZXIiLCJpYXQiOjE3NDEwMjIxMTcsImV4cCI6MTc3MjU1ODExNywiYXVkIjoid3d3LmV4YW1wbGUuY29tIiwic3ViIjoianJvY2tldEBleGFtcGxlLmNvbSIsIkdpdmVuTmFtZSI6IkpvaG5ueSIsIlN1cm5hbWUiOiJSb2NrZXQiLCJFbWFpbCI6Impyb2NrZXRAZXhhbXBsZS5jb20iLCJSb2xlIjpbIk1hbmFnZXIiLCJQcm9qZWN0IEFkbWluaXN0cmF0b3IiXX0.TDRnnZmW2lGkEVsqLUUS6hDBKE6B0MKAh-XgBAU7xvc");

            return mock.Object;
        }

    }
}
