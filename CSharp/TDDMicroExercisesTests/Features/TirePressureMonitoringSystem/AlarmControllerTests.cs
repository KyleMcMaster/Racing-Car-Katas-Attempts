using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using TDDMicroExercises;
using TDDMicroExercises.Features.TirePressureMonitoringSystem;
using TDDMicroExercisesTests.Infrastructure;
using Xunit;

namespace TDDMicroExercisesTests.Features.TirePressureMonitoringSystem
{
    public class AlarmControllerTests : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient client;

        public AlarmControllerTests(CustomWebApplicationFactory<Startup> factory)
        {
            client = factory.CreateClient();
        }

        [Fact]
        public async Task ReturnsNonNullResponse()
        {
            var response = await client.GetAsync("/alarm");
            response.EnsureSuccessStatusCode();

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AlarmResponse>(stringResponse);

            result.Should().NotBeNull();
        }
    }
}
