using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;

namespace SystemModel.DAO
{
    /// <summary>
    /// Dostarcza metody do wymiany informacji o zdarzeniach w systemie z bazą danych.
    /// </summary>
    public class SensorEventDAO : AbstractDAO<SensorEventTO>
    {
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


    }
}
