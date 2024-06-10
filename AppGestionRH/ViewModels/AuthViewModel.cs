using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppGestionRH.ViewModels
{
    public static class AuthViewModel
    {
        private static Dictionary<string, (string Password, int Attempts, DateTime? LockoutEndTime)> users
            = new Dictionary<string, (string, int, DateTime?)>
        {
            { "admin", ("password", 0, null) } // Example user
        };

        public static bool Authenticate(string username, string password)
        {
            if (users.ContainsKey(username))
            {
                var user = users[username];

                if (user.LockoutEndTime.HasValue && user.LockoutEndTime.Value > DateTime.Now)
                {
                    return false;
                }

                if (user.Password == password)
                {
                    users[username] = (user.Password, 0, null); // Reset attempts on success
                    return true;
                }
                else
                {
                    user.Attempts++;
                    if (user.Attempts >= 3)
                    {
                        users[username] = (user.Password, user.Attempts, DateTime.Now.AddMinutes(30));
                    }
                    else
                    {
                        users[username] = (user.Password, user.Attempts, null);
                    }
                }
            }
            return false;
        }

        public static bool IsLockedOut()
        {
            foreach (var user in users.Values)
            {
                if (user.LockoutEndTime.HasValue && user.LockoutEndTime.Value > DateTime.Now)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
