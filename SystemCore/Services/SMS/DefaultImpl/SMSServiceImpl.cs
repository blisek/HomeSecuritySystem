using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS.DefaultImpl
{
    public class SMSServiceImpl : SMSService
    {
        /// <summary>
        /// Tworzy nową wiadomość do wysłania.
        /// </summary>
        /// <returns></returns>
        public SMSMessage NewMessage()
        {
            return new SMSMessageImpl();
        }

        public bool SendMessage(SMSMessage message)
        {
            // Wysylanie wiadomosci

            if (message == null)
                throw new ArgumentNullException("message");

            return true;
        }
    }
}
