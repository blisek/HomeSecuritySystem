using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Enums;
using SystemCore.Sensors.SensorEventMappers;

namespace SystemCore.Sensors
{
    public static class SensorEventMapperFactory
    {
        private static readonly Dictionary<SensorType, SensorEventMapper> _mappers = new Dictionary<SensorType, SensorEventMapper>()
        {
            { SensorType.MOVE_SENSOR, new MoveSensorEventMapper() }
        };

        public static SensorEventMapper GetMapper(SensorType type)
        {
            if (type == SensorType.UNKNOWN)
                return null;

            SensorEventMapper sem = null;
            _mappers.TryGetValue(type, out sem);
            return sem;
        }
    }
}
