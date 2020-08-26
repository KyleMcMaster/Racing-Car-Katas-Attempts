using FluentAssertions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using TDDMicroExercises;
using TDDMicroExercises.Features.TirePressureMonitoringSystem;
using TDDMicroExercisesTests.Infrastructure;
using Xunit;

namespace TDDMicroExercisesTests.Features.TirePressureMonitoringSystem
{
    public class AlarmControllerTests
    {
        [Fact]
        public async Task Returns_IsAlarmOn_True_When_Low_Psi()
        {
            var factory = new CustomWebApplicationFactory<Startup>(new RandomNumberGenerator(0));

            var client = factory.CreateClient();

            var response = await client.GetAsync("/alarm");
            response.EnsureSuccessStatusCode();

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AlarmResponse>(stringResponse);

            result.IsAlarmOn.Should().BeTrue();
        }

        [Fact]
        public async Task Returns_IsAlarmOn_True_When_High_Psi()
        {
            var factory = new CustomWebApplicationFactory<Startup>(new RandomNumberGenerator(1));

            var client = factory.CreateClient();

            var response = await client.GetAsync("/alarm");
            response.EnsureSuccessStatusCode();

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AlarmResponse>(stringResponse);

            result.IsAlarmOn.Should().BeTrue();
        }

        [Fact]
        public async Task Returns_IsAlarmOn_False_When_Psi_Within_Range()
        {
            var factory = new CustomWebApplicationFactory<Startup>(new RandomNumberGenerator(0.5));

            var client = factory.CreateClient();

            var response = await client.GetAsync("/alarm");
            response.EnsureSuccessStatusCode();

            string stringResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<AlarmResponse>(stringResponse);

            result.IsAlarmOn.Should().BeFalse();
        }
    }
}
