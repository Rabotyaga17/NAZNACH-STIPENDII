using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otdelenie
{
    public static class ConnectionStr
    {
        public static string Get { get; } = "Data Source=GEGCBR\\SQLEXPRESS04;Initial Catalog=NAZNACHENIE STIPENDII;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        
        //public static string Get { get; } = "Data Source=DESKTOP-O70G8S5;Initial Catalog=Help;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

    }
}
