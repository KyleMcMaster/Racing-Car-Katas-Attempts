using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace TDDMicroExercises.Features.TirePressureMonitoringSystem
{
    [ApiController]
    [Route("[controller]")]
    public class AlarmController : ControllerBase
    {
        private readonly ILogger<AlarmController> logger;
        private readonly ISensor sensor;

        public AlarmController(ILogger<AlarmController> logger, ISensor sensor)
        {
            this.logger = logger;
            this.sensor = sensor;
        }

        [HttpGet()]
        [SwaggerOperation(
            Summary = "Gets an alarm's state",
            Description = "Check an alarm and return whether the sensor for that alarm triggered the alarm itself",
            OperationId = "Alarm.Get",
            Tags = new[] { "Alarm" })
        ]
        public AlarmResponse Get()
        {
            var alarm = new Alarm(sensor);

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
