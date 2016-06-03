using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    public static class SystemUserDAO
    {
        private const string _SELECT_ALL = "select * from users";

        /// <summary>
        /// Zwraca wszystkich użytkowników w postaci iteratora.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<SystemUserTO> GetAll()
        {
            using(var connection = SQLiteDBConnection.GetInstance().GetConnection())
            {
                return connection.Query<SystemUserTO>(_SELECT_ALL);
            }
        }
    }
}
