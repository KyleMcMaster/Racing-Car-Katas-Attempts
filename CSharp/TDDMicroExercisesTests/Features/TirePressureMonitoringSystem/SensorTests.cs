using FluentAssertions;
using TDDMicroExercises.Features.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercisesTests.Features.TirePressureMonitoringSystem
{
    public class SensorTests
    {
        [Fact]
        public void Sensor_Pop_Produces_Value_Greater_Than_Sixteen()
        {
            var random = new RandomNumberGenerator();
            var sensor = new Sensor(random);

            var result = sensor.PopNextPressurePsiValue();

            result.Should().BeGreaterThan(16);
        }

        [Fact]
        public void Sensor_Pop_Produces_Value_Less_Than_TwentyTwo()
        {
            var random = new RandomNumberGenerator();
            var sensor = new Sensor(random);

            var result = sensor.PopNextPressurePsiValue();

            result.Should().BeLessThan(22);
        }

        [Fact]
        public void Sensor_Pop_Produces_Equal_To_Sixteen()
        {
            var random = new RandomNumberGenerator(0.0);
            var sensor = new Sensor(random);

            var result = sensor.PopNextPressurePsiValue();

            result.Should().Be(16);
        }

        [Fact]
        public void Sensor_Pop_Produces_Equal_To_TwentyTwo()
        {
            var random = new RandomNumberGenerator(1);
            var sensor = new Sensor(random);

            var result = sensor.PopNextPressurePsiValue();

            result.Should().Be(22);
        }
    }
}
