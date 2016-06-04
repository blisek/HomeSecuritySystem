using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.SystemContext.Default
{
    /// <summary>
    /// Domyślny
    /// </summary>
    public abstract class DefaultSystemContextConstructor : SystemContextConstructor
    {
        public abstract void AfterInit();
        public abstract void BeforeInit();

        public SensorsLogger GetSensorsLogger()
        {
            return new DefaultDBSensorsLogger();
        }

        public SensorsManager GetSensorsManager()
        {
            return new DefaultSensorsManager();
        }

        public abstract SensorsProvider GetSensorsProvider();
    }
}
