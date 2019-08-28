using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RoleBasedBasicAuthenticationWebApi.Models
{
    public class UserValidate
    {
        public static bool Login(string username, string password)
        {
            UserBL userBL = new UserBL();
            var UserList = userBL.GetUsers();
            return UserList.Any(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            user.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
        }

        public static User GetUserDetails(string username, string password)
        {
            UserBL userbl = new UserBL();
            return userbl.GetUsers().FirstOrDefault(user => user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase) &&
            user.Password.Equals(password, StringComparison.OrdinalIgnoreCase));
        }
    }
}