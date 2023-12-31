using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace User_Register_Login_Dotnet.Models
{
    public class UserModel
    {
           public int ID { get; set; }
        public int MyProperty { get; set; }

        public string Emailid { get; set; }

        public string Password { get; set; }

        public string Name { get; set; }
    }
}