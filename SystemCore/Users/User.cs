namespace SystemCore.Users
{
    public class User
    {
        /// <summary>
        /// Id użytkownika w systemie.
        /// </summary>
        public int? Id { get; set; }

        /// <summary>
        /// Nazwa użytkownika w systemie
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// User password.
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Poziom dostępu użytkownika. Nie mylić z PrivilegeId. Jest to wartość pola PrivilegeTO.PrivilegeLevel.
        /// </summary>
        public int PrivilegeLevel { get; set; }

        /// <summary>
        /// Telefon kontaktowy.
        /// </summary>
        public string PhoneNumber { get; set; }
    }
}
