using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemCore.Users;
using SystemCore.Exceptions;

namespace SystemCore.SystemActions
{
    public interface UserManagement
    {
        IEnumerable<User> GetRegisteredUsers();

        /// <summary>
        /// Metoda używana do rejestrowania nowego użytkownika w systemie.
        /// 
        /// Użytkownik może zostać zarejestrowany tylko wtedy gdy przydzielony
        /// mu poziom uprawnień jest co najwyżej o 1 niższy od użytkownika, który
        /// go rejestruje.
        /// </summary>
        /// <exception cref="AccessDeniedException">Gdy użytkownik, który rejestruje nowego użytkownika nie ma wystarczających uprawnień, bądź gdy nowy użytkownik ma wyższy/równy poziom uprawnień co użytkownik, który go rejestruje.</exception>
        /// <param name="registratingUser">Użytkownik, który rejestruje nowego użytkownika.</param>
        /// <param name="registeredUser">Nowy użytkownik, który jest rejestrowany.</param>
        void RegisterUser(User registratingUser, User registeredUser);

        void RemoveUser(User performingUser, User userToRemove);

        void DegradeUser(User performingUser, User userToDegrade, int newPrivilegeLevel);

        void PromoteUser(User performingUser, User userToPromote, int newPrivilegeLevel);
    }
}
