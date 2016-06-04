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

        public static void InitSystemContext(SystemContextTemplate systemContextTemplate)
        {

        }
    }
}
