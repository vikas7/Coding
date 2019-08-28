using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWebApi.Models
{
    public class UserValidate
    {
        public static bool Login(string userName, string password)
        {
            UserBL userBL = new UserBL();
            var userList = userBL.GetUsers();
            return userList.Any(user => user.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase) 
            && user.Password == password);
        }
    }
}