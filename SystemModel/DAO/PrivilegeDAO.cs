using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using Dapper;

namespace SystemModel.DAO
{
    public static class PrivilegeDAO
    {
        private const string _SELECT_ALL = "select * from privileges;";
        //private const string _SELECT_BY_ID = "select * from privileges where PrivilegeId = @privilegeId";

        private static List<PrivilegeTO> _cachedPrivileges;

        /// <summary>
        /// Zwraca wszystkie poziomy dostępu i cache'uje je do późniejszego użytku.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<PrivilegeTO> GetAll()
        {
            if (_cachedPrivileges == null)
            {
                using (var connection = SQLiteDBConnection.GetInstance().GetConnection())
                {
                    _cachedPrivileges = connection.Query<PrivilegeTO>(_SELECT_ALL).ToList();
                }
            }

            return _cachedPrivileges;
        }

        /// <summary>
        /// Zwraca PrivilegeTO o danym id lub null jeśli obiekt o takowym id nie istnieje. 
        /// </summary>
        /// <param name="id">Id > 0, identyfikujące PriviligeTO.</param>
        /// <returns>Odpowiedni PrivilegeTO, bądź null.</returns>
        public static PrivilegeTO GetById(int id)
        {
            return GetAll().Where(p => p.PrivilegeId == id).SingleOrDefault();
        }


    }
}
