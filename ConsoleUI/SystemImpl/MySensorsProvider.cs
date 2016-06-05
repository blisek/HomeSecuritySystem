using ConsoleUI.SensorDrivers;
using ConsoleUI.SensorDrivers.DriverRunner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.SystemContext;

namespace ConsoleUI.SystemImpl
{
    class MySensorsProvider : SensorsProvider
    {
        public IEnumerable<SensorInfo> FindAllSensors(object discriminator)
        {
            var sensor1 = new SensorInfo { SensorId = "move_sensor_1", Zone = 1, Driver = new MoveSensorDriver() };
            var sensor2 = new SensorInfo { SensorId = "some_sensor_2", Zone = 2, Driver = new SomeDriver() };

            SensorsDriverRunner.RunMoveSensorDriver(sensor1.Driver as MoveSensorDriver);
            SensorsDriverRunner.RunSomeDriver(sensor2.Driver as SomeDriver);

            return new List<SensorInfo> { sensor1, sensor2 };
        }
    }
}
