using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.Sensors.SensorEvents.SensorEventMappers
{
    public class DefaultSensorEventMapper : SensorEventMapper
    {
        public IEnumerable<SensorEvent> map(IEnumerable<SensorEventTO> eventTOs)
        {
            foreach (var to in eventTOs)
                yield return map(to);
        }

        public SensorEvent map(SensorEventTO eventTO)
        {
            return new SensorEvent
            {
                Id = eventTO.EventId,
                SensorId = eventTO.EventSource,
                EventDate = eventTO.EventDate,
                EventDescription = eventTO.EventDescription,
                Severity = (EventSeverity)eventTO.Severity,
                SensorType = SensorType.UNKNOWN
            };
        }
    }
}
