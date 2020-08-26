using FluentAssertions;
using TDDMicroExercises.Features.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercisesTests.Features.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        [Fact]
        public void Constructor_Ininitialized_AlarmOn_To_False()
        {
            Alarm alarm = new Alarm(new Sensor(new RandomNumberGenerator()));
            Assert.False(alarm.AlarmOn);
        }

        [Fact]
        public void Psi_Value_Of_Sixteen_Triggers_The_Alarm()
        {
            Alarm alarm = new Alarm(new Sensor(new RandomNumberGenerator(0)));

            alarm.Check();

            alarm.AlarmOn.Should().BeTrue();
        }

        [Fact]
        public void Psi_Value_Of_TwentyTwo_Triggers_The_Alarm()
        {
            Alarm alarm = new Alarm(new Sensor(new RandomNumberGenerator(1)));

            alarm.Check();

            alarm.AlarmOn.Should().BeTrue();
        }

        [Fact]
        public void Psi_Value_Within_Valid_Range_Does_Not_Trigger_The_Alarm()
        {
            Alarm alarm = new Alarm(new Sensor(new RandomNumberGenerator(0.5)));

            alarm.Check();

            alarm.AlarmOn.Should().BeFalse();
        }
    }
}