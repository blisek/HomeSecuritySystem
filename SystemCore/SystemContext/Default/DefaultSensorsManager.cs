using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Sensors.SensorEvents;
using SystemCore.Sensors.Drivers;
using SystemCore.Mappers;

namespace SystemCore.SystemContext.Default
{
    public class DefaultSensorsManager : SensorsManager
    {
        private readonly Dictionary<string, SensorInfo> _sensors;
        private const string MSG_STATE_CHANGES = "State of [{0}] changed to {1}";

        public DefaultSensorsManager()
        {
            _sensors = new Dictionary<string, SensorInfo>();
        }

        public void AddSensor(SensorInfo sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException("sensor");

            var sensorDriver = sensor.Driver;
            Action<Event> driverEventCallback = delegate (Event se) { OnEventOccured(sensor.SensorId, se); };
            Action<SensorState> driverStateCallback = delegate (SensorState ss) { OnStateChanged(sensor.SensorId, ss); };
            sensorDriver.EventCallback = driverEventCallback;
            sensorDriver.StateChangedCallback = driverStateCallback;
            _sensors[sensor.SensorId] = sensor;
        }

        public void AddSensors(IEnumerable<SensorInfo> sensors)
        {
            foreach (var sensor in sensors)
                AddSensor(sensor);
        }

        public IEnumerable<SensorInfo> GetAllSensors()
        {
            return _sensors.Values;
        }

        public SensorInfo GetSensor(string sensorId)
        {
            return _sensors.Values.Where(s => s.SensorId == sensorId).FirstOrDefault();
        }

        private void OnEventOccured(string sensorId, Event sensorEvent)
        {
            if (sensorEvent.SensorId == null)
                sensorEvent.SensorId = sensorId;
            SystemContext.SensorsLogger.Log(sensorEvent);
        }

        private void OnStateChanged(string sensorId, SensorState sensorState)
        {
            var sensorEvent = new Event { SensorId = sensorId, Severity = EventSeverity.INFO };
            sensorEvent.EventDescription = string.Format(MSG_STATE_CHANGES, sensorId, sensorState);
            sensorEvent.EventType = EventType.UNKNOWN;
            SystemContext.SensorsLogger.Log(sensorEvent);
        }
    }
}
