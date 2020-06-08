using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otdelenie.Logic
{
    public static class User
    {
        public static string Login { get; set; }
        public static string Password { get; set; }
        public static string RoleID { get; set; }
        public static string ID { get; set; }

        public static void Clear()
        {
            Login = "";
            Password = "";
            RoleID = "";
            ID = "";
        }
    }
}
