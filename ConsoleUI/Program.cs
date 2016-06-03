using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemModel.TO;
using SystemModel.DAO;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var privilege in PrivilegeDAO.GetInstance().GetAll())
            {
                WritePrivilege(privilege);
            }

            WritePrivilege(PrivilegeDAO.GetInstance().GetById(2));
        }

        private static void WritePrivilege(PrivilegeTO privilege)
        {
            Console.WriteLine("Id: {0}", privilege.PrivilegeId);
            Console.WriteLine("Name: {0}", privilege.PrivilegeName);
            Console.WriteLine("Description: {0}", privilege.PrivilegeDesc);
            Console.WriteLine("Level: {0}", privilege.PrivilegeLevel);
        }
    }
}
