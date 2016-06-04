using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Services.SMS
{
    public interface SMSService
    {
        SMSMessage NewMessage();

        bool SendMessage(SMSMessage message);
    }
}
