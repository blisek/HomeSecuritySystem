﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.SystemContext
{
#warning [WZORZEC] Metoda szablonowa.
    public interface SystemContextConstructor
    {
        /// <summary>
        /// Metoda wywoływana jako pierwsza podczas konstruowania kontekstu.
        /// </summary>
        void BeforeInit();

        /// <summary>
        /// Konstruuje i zwraca loggera.
        /// </summary>
        /// <returns></returns>
        SensorsLogger GetSensorsLogger();

        /// <summary>
        /// Konstruuje i zwraca managera sensorów.
        /// </summary>
        /// <returns></returns>
        SensorsManager GetSensorsManager();

        /// <summary>
        /// Konstruuje i zwraca dostawcę providerów.
        /// </summary>
        /// <returns></returns>
        SensorsProvider GetSensorsProvider();

        /// <summary>
        /// Metoda wywoływana jako ostatnia podczas konstruowania kontekstu.
        /// </summary>
        void AfterInit();
    }
}
