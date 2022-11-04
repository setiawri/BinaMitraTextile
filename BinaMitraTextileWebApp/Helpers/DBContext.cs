using System.Data.Entity;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp
{
    public class DBContext : DbContext
    {
        public DBContext() { this.Database.Connection.ConnectionString = Helper.ConnectionString; }

        /******************************************************************************************************************************************************/

        public DbSet<ActivityLogsModel> ActivityLogs { get; set; }
        public DbSet<UnitsModel> Units { get; set; }
        public DbSet<UserAccountRolesModel> UserAccountRoles { get; set; }

        /******************************************************************************************************************************************************/

    }
}