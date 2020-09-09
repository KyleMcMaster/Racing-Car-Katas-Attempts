using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using TDDMicroExercises;
using TDDMicroExercises.Features.TirePressureMonitoringSystem;

namespace TDDMicroExercisesTests.Infrastructure
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        private readonly IRandomNumberGenerator randomNumberGenerator;

        public CustomWebApplicationFactory(IRandomNumberGenerator randomNumberGenerator = null)
        {
            this.randomNumberGenerator = randomNumberGenerator ?? new RandomNumberGenerator();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder
                .UseSolutionRelativeContentRoot("")
                .ConfigureServices(services =>
                {
                    // configure test doubles by replacing services here
                    var descriptor = services.SingleOrDefault(
                        d => d.ServiceType ==
                            typeof(RandomNumberGenerator));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }

                    services.AddScoped((s) => randomNumberGenerator);


                    //services.AddScoped<IMediator, NoOpMediator>();
                });
        }
    }
}
