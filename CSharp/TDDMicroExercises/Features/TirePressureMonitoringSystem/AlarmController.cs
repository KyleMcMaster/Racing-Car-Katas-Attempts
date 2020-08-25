using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace TDDMicroExercises.Features.TirePressureMonitoringSystem
{
    [ApiController]
    [Route("[controller]")]
    public class AlarmController : ControllerBase
    {
        private readonly ILogger<AlarmController> logger;

        public AlarmController(ILogger<AlarmController> logger) => this.logger = logger;

        [HttpGet()]
        public AlarmResponse Get()
        {
            var alarm = new Alarm();

            alarm.Check();

            return new AlarmResponse
            {
                IsAlarmOn = alarm.AlarmOn
            };
        }
    }

    public class AlarmResponse
    {
        public bool IsAlarmOn { get; set; }
    }
}
