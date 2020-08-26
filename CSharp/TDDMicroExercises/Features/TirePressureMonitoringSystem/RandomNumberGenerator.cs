using System;

namespace TDDMicroExercises.Features.TirePressureMonitoringSystem
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        public double? testData = null;

        public RandomNumberGenerator(double? testData = null) => this.testData = testData;

        public double NextDouble()
        {
            if (testData is null)
            {
                var random = new Random();

                return random.NextDouble();
            }

            return testData.GetValueOrDefault();
        }
    }
}
