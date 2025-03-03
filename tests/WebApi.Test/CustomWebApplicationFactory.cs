using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoneyControl.Infraestructure.DataAccess;

namespace WebApi.Test
{
    public  class CustomWebApplicationFactory : WebApplicationFactory<Main>
    {

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {

                    var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();
                    services.AddDbContext<MoneyControlDbContext>(config =>
                    {
                        config.UseInMemoryDatabase("InMemoryDbTest");
                        config.UseInternalServiceProvider(provider);
                    });
                });
        }

    }
}
