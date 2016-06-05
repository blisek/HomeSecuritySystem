using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Exceptions;
using SystemCore.Attributes;
using SystemCore.Helpers;

namespace SystemCore.SystemActions.ZoneManagement.Impl
{
    public class ZoneManagementImpl : ZoneManagement
    {
        private HashSet<uint> _disabledZones;

        public ZoneManagementImpl()
        {
            _disabledZones = new HashSet<uint>();
        }

        [MinimumPrivilegeLevel(PrivilegeHelper.DefaultPrivileges.Admin)]
        public bool AssignZoneToSensor(SensorInfo sensorInfo, uint zone)
        {
            if (sensorInfo == null)
                return false;
            sensorInfo.Zone = zone;
            return true;
        }

        [MinimumPrivilegeLevel(PrivilegeHelper.DefaultPrivileges.Admin)]
        public bool AssignZoneToSensor(string sensorId, uint zone)
        {
            SensorInfo sensorInfo = SystemContext.SystemContext.SensorsManager.GetSensor(sensorId);
            return (sensorInfo != null) ? AssignZoneToSensor(sensorInfo, zone) : false;
        }

        [MinimumPrivilegeLevel(PrivilegeHelper.DefaultPrivileges.User)]
        public void DisableZone(uint zone)
        {
            _disabledZones.Add(zone);
        }

        [MinimumPrivilegeLevel(PrivilegeHelper.DefaultPrivileges.User)]
        public void EnableZone(uint zone)
        {
            _disabledZones.Remove(zone);
        }

        public IEnumerable<SensorInfo> GetAllDisabledSensors()
        {
            return SystemContext.SystemContext.SensorsManager.GetAllSensors().Where(IsSensorDisabled);
        }

        public IEnumerable<IGrouping<uint, SensorInfo>> GetAllSensorsGroupedByZone()
        {
            return SystemContext.SystemContext.SensorsManager.GetAllSensors().GroupBy(sensorInfo => sensorInfo.Zone);
        }

        public IReadOnlyList<SensorInfo> GetAllSensorsInZone(uint zone)
        {
            return SystemContext.SystemContext.SensorsManager.GetAllSensors().Where(si => si.Zone == zone).ToList();
        }

        public uint GetSensorZone(SensorInfo sensorInfo)
        {
            if (sensorInfo == null)
                throw new SensorMissingException("sensorInfo");

            return sensorInfo.Zone;
        }

        public uint GetSensorZone(string sensorId)
        {
            var sensorInfo = SystemContext.SystemContext.SensorsManager.GetSensor(sensorId);
            if (sensorInfo == null)
                throw new SensorMissingException("sensorId", sensorId);
            return sensorInfo.Zone;
        }

        public bool IsSensorDisabled(SensorInfo sensor)
        {
            return (sensor == null) ? false : _disabledZones.Contains(sensor.Zone);
        }

        public bool IsSensorDisabled(string sensorId)
        {
            var sensorInfo = SystemContext.SystemContext.SensorsManager.GetSensor(sensorId);
            return (sensorInfo == null) ? false : _disabledZones.Contains(sensorInfo.Zone);
        }

        public bool IsZoneDisabled(uint zone)
        {
            return _disabledZones.Contains(zone);
        }

    }
}
