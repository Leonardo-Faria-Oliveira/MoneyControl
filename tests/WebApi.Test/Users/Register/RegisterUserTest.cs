using CommonTestUtilities.Requests;
using Microsoft.AspNetCore.Mvc.Testing;
using MoneyControl.Communication.Requests;
using System.Net;
using System.Net.Http.Json;

namespace WebApi.Test.Users.Register
{
    public class RegisterUserTest : IClassFixture<CustomWebApplicationFactory>
    {
        private readonly HttpClient _httpClient;

        public RegisterUserTest(CustomWebApplicationFactory webApplicationFactory)
        {
            _httpClient = webApplicationFactory.CreateClient();
        }

        [Fact]
        public async Task Success()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var result = await _httpClient.PostAsJsonAsync("/api/User", request);
            Assert.Equal(HttpStatusCode.Created, result.StatusCode);
        }

        [Theory]
        [InlineData(null, null, null)]
        [InlineData("", "email@example.com", "Password123!")]
        [InlineData("Name", "", "Password123!")]
        [InlineData("Name", "email@example.com", "")]
        [InlineData("Name", "invalid-email", "Password123!")]
        [InlineData("Name", "email@example.com", "short")]
        public async Task BadRequest(string name, string email, string password)
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;
            request.Email = email;
            request.Password = password;
            var result = await _httpClient.PostAsJsonAsync("/api/User", request);
            Assert.Equal(HttpStatusCode.BadRequest, result.StatusCode);
        }

       
    }
}
