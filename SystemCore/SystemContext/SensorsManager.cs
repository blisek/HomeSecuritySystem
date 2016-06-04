using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;

namespace SystemCore.SystemContext
{
    /// <summary>
    /// Moduł zarządzający zarejestrowanymi czujnikami.
    /// </summary>
    public abstract class SensorsManager
    {
        /// <summary>
        /// Dodaje do zarządcy nowy czujnik.
        /// </summary>
        /// <param name="sensor"></param>
        public abstract void AddSensor(SensorInfo sensor);

        /// <summary>
        /// Dodaje do zarządcy kilka czujników
        /// </summary>
        /// <param name="sensors"></param>
        #warning [WZORZEC] Metoda szablonowa
        public virtual void AddSensors(IEnumerable<SensorInfo> sensors)
        {
            if (sensors == null)
                throw new ArgumentNullException("sensors");
            foreach (var sensor in sensors)
                AddSensor(sensor);
        }

        
    }
}
