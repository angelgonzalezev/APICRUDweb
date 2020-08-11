using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace DAL
{
    class Connection
    {
        public static string getConnectionString()
        {
            //Nos devuelve un objeto de tipo ConnectionStringSettings
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings["ClientesConnection"];
            return setting.ConnectionString;
        }

        public string getConnectionStringByName(string connectionStringName)
        {
            //Nos devuelve un objeto de tipo ConnectionStringSettings
            ConnectionStringSettings setting = ConfigurationManager.ConnectionStrings[connectionStringName];
            return setting.ConnectionString;
        }
    }
}