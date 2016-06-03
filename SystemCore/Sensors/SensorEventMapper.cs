using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Structs;
using SystemModel.TO;

namespace SystemCore.Sensors
{
    public interface SensorEventMapper
    {
        SensorEvent map(SensorEventTO eventTO);

        IEnumerable<SensorEvent> map(IEnumerable<SensorEventTO> eventTOs);
    }
}
