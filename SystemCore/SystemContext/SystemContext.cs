using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Services.SMS;
using SystemCore.SystemActions.SensorEventsHandler;
using SystemCore.SystemActions.SensorEventsHandler.Impl;
using SystemCore.SystemActions.UserManagement;
using SystemCore.SystemActions.UserManagement.Impl;
using SystemCore.SystemActions.ZoneManagement;
using SystemCore.SystemActions.ZoneManagement.Impl;
using SystemCore.Users;
using SystemCore.Exceptions;

namespace SystemCore.SystemContext
{
#warning [WZORZEC] Metoda szablonowa.
    public static class SystemContext
    {
        private static User _user;

        public static User CurrentUser {
            get
            {
                if (_user == null)
                    throw new AccessDeniedException("No user is logged in.");
                return _user;
            }
            private set
            {
                _user = value;
            }
        }

        public static SensorsProvider SensorsProvider { get; private set; }

        public static SensorsManager SensorsManager { get; private set; }

        public static SystemLogger SystemLogger { get; private set; }

        public static SMSService SMSService { get; private set; }

        public static UserManagement UserManagement { get; private set; }

        public static SensorEventsHandler SensorEventsHandler { get; private set; }

        public static void InitSystemContext(SystemContextConstructor systemContextTemplate)
        {
            if (systemContextTemplate == null)
                throw new ArgumentNullException("systemContextTemplate");

            // czynności przed inicjalizacją komponentów
            systemContextTemplate.BeforeInit();

            SystemLogger = systemContextTemplate.GetSensorsLogger();

            SensorsProvider = systemContextTemplate.GetSensorsProvider();

            SensorsManager = systemContextTemplate.GetSensorsManager();

            SMSService = systemContextTemplate.GetSMSService();

            UserManagement = systemContextTemplate.GetUserManagement();

            // czynności po inicjalizacji komponentów
            systemContextTemplate.AfterInit();
        }

        public static void LoginUser(User user, string password)
        {
#error Zrobic
        }

        public static void LogoutUser(User user)
        {

        }

        public static bool IsSomeoneLoggedIn()
        {
            return CurrentUser != null;
        }
    }
}
