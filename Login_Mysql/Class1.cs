using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Login_Mysql
{
    class Class1
    {
        public string dbconnect()
        {
            string con = "Server=192.168.0.53;port=3306;Database=test_db;Uid=root;Pwd=1111;";
            return con;
        }
    }
}
