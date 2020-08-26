namespace TDDMicroExercises.Features.TirePressureMonitoringSystem
{
    public class Alarm
    {
        private long alarmCount = 0;
        private bool alarmOn;
        private const double LowPressureThreshold = 17;
        private const double HighPressureThreshold = 21;
        private readonly ISensor sensor;

        public Alarm(ISensor sensor)
        {
            alarmOn = false;
            this.sensor = sensor;
        }

        public void Check()
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue();

            if (psiPressureValue < LowPressureThreshold || HighPressureThreshold < psiPressureValue)
            {
                alarmOn = true;
                alarmCount += 1;
            }
        }

        public bool AlarmOn => alarmOn;
    }
}
