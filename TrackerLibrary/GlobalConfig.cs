using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackerLibrary.DataAccess;
using System.Reflection;

namespace TrackerLibrary
{
    public static class GlobalConfig
    {
        public static IDataConnection Connections { get; private set; }
        //public static  List<IDataConnection> Connections { get; private set; } = new List<IDataConnection>();//uncomment this list due to one or mor data sourecs   
        //one id for sql and text config fle PART2
        public static void IntializeConnections(DatabaseType db)/*connectionType)*/
        //uncommnet this public static void (bool database,bool textFiles)*/
        {
          if(db==DatabaseType.Sql)
            {
                SqlConnector sql = new SqlConnector();
                Connections = sql;//unncomment this Connections.Add(sql);
            }
            else if(db==DatabaseType.TextFile)
            {
                TextConnectior text=new TextConnectior();
                Connections = text;//uncomment this Connections.Add(text);

            }
        }
        public static string CnnString(string name)
        {
            //Assembly.Load("System.Configuration.ConfigurationManager");
            return System.Configuration.ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

    }
}
