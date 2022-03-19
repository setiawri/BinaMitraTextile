using System.Data.Entity;
using BinaMitraTextileWebApp.Models;

namespace BinaMitraTextileWebApp
{
    public class DBContext : DbContext
    {
        public DBContext() { this.Database.Connection.ConnectionString = Helper.ConnectionString; }

        /******************************************************************************************************************************************************/

        public DbSet<ActivityLogsModel> ActivityLogs { get; set; }

        /******************************************************************************************************************************************************/

    }
}