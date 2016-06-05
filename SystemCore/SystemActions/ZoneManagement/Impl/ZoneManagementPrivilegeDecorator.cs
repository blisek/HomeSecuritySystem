using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Sensors;
using SystemCore.Helpers;

namespace SystemCore.SystemActions.ZoneManagement.Impl
{
    public class ZoneManagementPrivilegeDecorator : ZoneManagement
    {
        private readonly ZoneManagement _zoneManagement;

        public ZoneManagementPrivilegeDecorator(ZoneManagement zoneManagement)
        {
            if (zoneManagement == null)
                throw new ArgumentNullException("zoneManagement");

            _zoneManagement = zoneManagement;
        }

        public bool AssignZoneToSensor(SensorInfo sensorInfo, uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<SensorInfo, uint, bool>)_zoneManagement.AssignZoneToSensor).Method);
            return _zoneManagement.AssignZoneToSensor(sensorInfo, zone);
        }

        public bool AssignZoneToSensor(string sensorId, uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Func<string, uint, bool>)_zoneManagement.AssignZoneToSensor).Method);
            return _zoneManagement.AssignZoneToSensor(sensorId, zone);
        }

        public void DisableZone(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<uint>)_zoneManagement.DisableZone).Method);
            _zoneManagement.DisableZone(zone);
        }

        public void EnableZone(uint zone)
        {
            PrivilegeHelper.CheckUserPrivilegeForMethod(((Action<uint>)_zoneManagement.EnableZone).Method);
            _zoneManagement.EnableZone(zone);
        }

        public IEnumerable<SensorInfo> GetAllDisabledSensors()
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.GetAllDisabledSensors();
        }

        public IEnumerable<IGrouping<uint, SensorInfo>> GetAllSensorsGroupedByZone()
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.GetAllSensorsGroupedByZone();
        }

        public IReadOnlyList<SensorInfo> GetAllSensorsInZone(uint zone)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.GetAllSensorsInZone(zone);
        }

        public uint GetSensorZone(SensorInfo sensorInfo)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.GetSensorZone(sensorInfo);
        }

        public uint GetSensorZone(string sensorId)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.GetSensorZone(sensorId);
        }

        public bool IsSensorDisabled(SensorInfo sensor)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.IsSensorDisabled(sensor);
        }

        public bool IsSensorDisabled(string sensorId)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.IsSensorDisabled(sensorId);
        }

        public bool IsZoneDisabled(uint zone)
        {
#warning TODO: Dodać sprawdzanie uprawnień jak w innych.
            return _zoneManagement.IsZoneDisabled(zone);
        }
    }
}
