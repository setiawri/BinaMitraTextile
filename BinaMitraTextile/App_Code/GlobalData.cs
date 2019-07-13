using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;

namespace BinaMitraTextile
{
    public static class GlobalData
    {
        public static bool ConnectionTestCompleted = false;
        public static bool ConnectToLiveDB = false;
        public static bool ConnectToLiveDBLocal = false;

        public static string TemporarySelectedGridviewValue;

        private static bool QuitApplication { get; set; } = false;
        public static DataTable TemporarySaleTables { get; set; } = new DataTable();
        public static UserAccount UserAccount { get; set; }
    }
}
