using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS
{
    /// <summary>
    /// Interfejs do wysyłania wiadomości SMS.
    /// </summary>
#warning [WZORZEC] Proxy - z wyglądu zwykła klasa, w założeniu w implementacji łączy się z zewnętrznym serwerem, bramką smsową, ukrywając przed użytkownikiem ten fakt.
    public interface SMSService
    {
        SMSMessage NewMessage();

        bool SendMessage(SMSMessage message);
    }
}
