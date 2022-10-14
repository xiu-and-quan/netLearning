using LinqToDB.Configuration;
using LinqToDB.Data;

namespace MyWebApplicationLinq2Db
{

    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDBConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}
