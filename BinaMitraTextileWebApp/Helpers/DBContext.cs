using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp
{
    public class DBContext : DbContext
    {
        private const int TimeoutDefault = 30;

        public DBContext() { this.Database.Connection.ConnectionString = Helper.ConnectionString; }
        public DBContext(int timeoutSeconds) : this() { ((IObjectContextAdapter)this).ObjectContext.CommandTimeout = timeoutSeconds; }

        /******************************************************************************************************************************************************/

        public DbSet<ActivityLogsModel> ActivityLogs { get; set; }
        public DbSet<UnitsModel> Units { get; set; }
        public DbSet<UserAccountRolesModel> UserAccountRoles { get; set; }

        /******************************************************************************************************************************************************/

    }
}