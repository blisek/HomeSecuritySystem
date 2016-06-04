using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemCore.Sensors.SensorEvents
{
    public interface SensorEventMapper
    {
        SensorEvent Map(SensorEventTO eventTO);

        SensorEventTO Map(SensorEvent sensorEvent);

        IEnumerable<SensorEvent> Map(IEnumerable<SensorEventTO> eventTOs);

        IEnumerable<SensorEventTO> Map(IEnumerable<SensorEvent> sensorEvents);
    }
}
