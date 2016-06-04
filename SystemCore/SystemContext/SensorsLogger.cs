using SystemCore.Sensors.SensorEvents;

namespace SystemCore.SystemContext
{
    /// <summary>
    /// Loguje zdarzenia w systemie.
    /// </summary>
    public interface SensorsLogger
    {
        void Log(SensorEvent sensorEvent);
    }
}
