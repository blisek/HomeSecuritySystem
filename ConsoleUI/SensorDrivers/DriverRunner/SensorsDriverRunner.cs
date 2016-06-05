using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SystemCore.Sensors.SensorEvents;
using SystemCore.Sensors.SensorEvents.SpecificSensorEvents;

namespace ConsoleUI.SensorDrivers.DriverRunner
{
    public static class SensorsDriverRunner
    {
        public static void RunMoveSensorDriver(MoveSensorDriver moveSensorDriver)
        {
            Task.Run(() =>
            {
                Thread.Sleep(6000);
                while (true)
                {
                    moveSensorDriver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON);
                    var ev = new MoveSensorEvent
                    {
                        Severity = EventSeverity.WARNING,
                        EventType = SystemCore.Sensors.EventType.MOVE_SENSOR,
                        EventDescription = "Move occurred.",
                        Angle = 91.25f,
                        Distance = 13.73f
                    };
                    moveSensorDriver.EventCallback(ev);
                    moveSensorDriver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON_HOLD);
                    Thread.Sleep(6000);
                    Console.WriteLine("MoveSensor activated");
                }
            });
        }

        public static void RunSomeDriver(SomeDriver driver)
        {
            Task.Run(() =>
            {
                Thread.Sleep(6000);
                while (true)
                {
                    driver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON);
                    var ev = new Event
                    {
                        Severity = EventSeverity.INFO,
                        EventType = SystemCore.Sensors.EventType.UNKNOWN,
                        EventDescription = "Normal state update."
                    };
                    driver.EventCallback(ev);
                    driver.ChangeState(SystemCore.Sensors.Drivers.SensorState.ON_HOLD);
                    Thread.Sleep(6000);
                    Console.WriteLine("SomeSensor activated");
                }
            });
        }
    }
}
