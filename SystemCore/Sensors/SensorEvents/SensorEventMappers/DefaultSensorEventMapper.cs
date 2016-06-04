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
        public SensorEventTO Map(SensorEvent sensorEvent)
        {
            return new SensorEventTO
            {
                EventId = sensorEvent.Id,
                EventSource = sensorEvent.SensorId,
                EventDescription = sensorEvent.EventDescription,
                EventDate = sensorEvent.EventDate,
                Severity = (int)sensorEvent.Severity,
                SourceType = sensorEvent.SensorType.ToString()
            };
        }

        public IEnumerable<SensorEventTO> Map(IEnumerable<SensorEvent> sensorEvents)
        {
            if (sensorEvents == null)
                throw new ArgumentNullException("sensorEvents");

            foreach (var sensorEvent in sensorEvents)
                yield return Map(sensorEvent);
        }

        public IEnumerable<SensorEvent> Map(IEnumerable<SensorEventTO> eventTOs)
        {
            foreach (var to in eventTOs)
                yield return Map(to);
        }

        public SensorEvent Map(SensorEventTO eventTO)
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
