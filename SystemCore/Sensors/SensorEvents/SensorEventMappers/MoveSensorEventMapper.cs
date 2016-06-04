using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemCore.Sensors.SensorEvents.SpecificSensorEvents;

namespace SystemCore.Sensors.SensorEvents.SensorEventMappers
{
    public class MoveSensorEventMapper : SensorEventMapper
    {
        public SensorEvent map(SensorEventTO eventTO)
        {
            float distance = .0f;
            float.TryParse(eventTO.EventPar1, out distance);
            int angle = eventTO.EventPar3;

            return new MoveSensorEvent
            {
                Id = eventTO.EventId,
                SensorId = eventTO.EventSource,
                EventDescription = eventTO.EventDescription,
                EventDate = eventTO.EventDate,
                Distance = distance,
                Angle = angle,
                SensorType = SensorType.MOVE_SENSOR
            };
        }

        public IEnumerable<SensorEvent> map(IEnumerable<SensorEventTO> eventTOs)
        {
            return null;
        }
    }
}
