using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    /// <summary>
    /// Dostarcza metody do wymiany informacji o zdarzeniach w systemie z bazą danych.
    /// </summary>
    public class SensorEventDAO : AbstractDAO<SensorEventTO>
    {
        private const string QUERY_INSERT_SENSOR_EVENT =
            "INSERT INTO sensor_events(EventSource, SourceType, EventDescription, EventDate, Severity, EventPar1, EventPar2, EventPar3, EventPar4) VALUES " +
            "(@EventSource, @SourceType, @EventDescription, @EventDate, @Severity, @EventPar1, @EventPar2, @EventPar3, @EventPar4); SELECT last_insert_rowid()";

        private static volatile SensorEventDAO _instance;
        private static object _mutex = new object();

        public static SensorEventDAO GetInstance()
        {
            if(_instance == null)
            {
                lock(_mutex)
                {
                    if (_instance == null)
                        _instance = new SensorEventDAO();
                }
            }

            return _instance;
        }


        private SensorEventDAO() : base("sensor_events") { }

        public SensorEventTO insert(SensorEventTO sensor)
        {
            if (sensor == null)
                throw new ArgumentNullException("sensor");

            using(var connection = GetConnection())
            {
                sensor.EventId = connection.Query<int>(QUERY_INSERT_SENSOR_EVENT, sensor).First();
            }

            return sensor;
        }

    }
}
