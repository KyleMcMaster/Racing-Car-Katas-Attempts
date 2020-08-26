namespace TDDMicroExercises.Features.TirePressureMonitoringSystem
{
    public class Sensor : ISensor
    {
        private readonly IRandomNumberGenerator random;
        const double Offset = 16;

        public Sensor(IRandomNumberGenerator random) => this.random = random;

        public double PopNextPressurePsiValue()
        {
            double pressureTelemetryValue = 6 * random.NextDouble() * random.NextDouble();

            return Offset + pressureTelemetryValue;
        }
    }
}
