using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemCore.Structs;
using SystemCore.Sensors;

namespace SystemCore.Sensors.SensorEventMappers
{
    public class MoveSensorEventMapper : SensorEventMapper
    {
        public SensorEvent map(SensorEventTO eventTO)
        {
#error DOkonczyc
            return null;
        }

        public IEnumerable<SensorEvent> map(IEnumerable<SensorEventTO> eventTOs)
        {
            return null;
        }
    }
}
