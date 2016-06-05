using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemCore.Devices.Alarm
{
    public interface AlarmSystem
    {
        void TurnOnAlarm(int beepLengthInMs, int beepIntervalsInMs);

        bool IsAlarmOn();

        void TurnOffAlarm();
    }
}
