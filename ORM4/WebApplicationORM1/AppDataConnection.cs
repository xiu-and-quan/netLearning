using LinqToDB.Configuration;
using LinqToDB.Data;

namespace WebApplicationORM1
{
    public class AppDataConnection : DataConnection
    {
        public AppDataConnection(LinqToDBConnectionOptions<AppDataConnection> options)
            : base(options)
        {

        }
    }
}
