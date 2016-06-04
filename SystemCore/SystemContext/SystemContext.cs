using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.SystemContext
{
#warning [WZORZEC] Metoda szablonowa.
    public static class SystemContext
    {
        public static SensorsProvider SensorsProvider { get; private set; }

        public static SensorsManager SensorsManager { get; private set; }

        public static SensorsLogger SensorsLogger { get; private set; }

        public static void InitSystemContext(SystemContextConstructor systemContextTemplate)
        {
            if (systemContextTemplate == null)
                throw new ArgumentNullException("systemContextTemplate");

            // czynności przed inicjalizacją komponentów
            systemContextTemplate.BeforeInit();

            SensorsLogger = systemContextTemplate.GetSensorsLogger();

            SensorsProvider = systemContextTemplate.GetSensorsProvider();

            SensorsManager = systemContextTemplate.GetSensorsManager();

            // czynności po inicjalizacji komponentów
            systemContextTemplate.AfterInit();
        }
    }
}
