using TDDMicroExercises.Features.TirePressureMonitoringSystem;
using Xunit;

namespace TDDMicroExercisesTests.Features.TirePressureMonitoringSystem
{
    public class AlarmTests
    {
        [Fact]
        public void Foo()
        {
            Alarm alarm = new Alarm();
            Assert.False(alarm.AlarmOn);
        }
    }
}