using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasicAuthenticationWebApi.Models
{
    public class UserBL
    {
        public List<User> GetUsers()
        {
            List<User> userList = new List<User>();
            userList.Add(new User()
            {
                ID = 101,
                UserName = "MaleUser",
                Password = "123456"
            });

            userList.Add(new User()
            {
                ID = 101,
                UserName="FemaleUser",
                Password="abcdef"
            });
            return userList;
        }
    }
}