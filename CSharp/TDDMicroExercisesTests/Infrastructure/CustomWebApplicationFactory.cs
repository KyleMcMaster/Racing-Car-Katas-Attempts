using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using TDDMicroExercises;

namespace TDDMicroExercisesTests.Infrastructure
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseSolutionRelativeContentRoot("")
                .ConfigureServices(services =>
                {
                    // configure test doubles by replacing services here

                    //services.AddScoped<IMediator, NoOpMediator>();
                });
        }
    }
}
