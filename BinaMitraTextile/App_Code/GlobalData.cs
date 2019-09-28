using System;
using LIBUtil;

using System.Data;

namespace BinaMitraTextile
{
    public static class GlobalData
    {
        public static Guid AppGuid = new Guid(((System.Runtime.InteropServices.GuidAttribute)System.Reflection.Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(System.Runtime.InteropServices.GuidAttribute), false).GetValue(0)).Value.ToString());

        public static bool ConnectionTestCompleted = false;
        public static bool ConnectAsServer = false;
        public static bool ConnectToDevDB = false;
        public static bool ConnectToLiveDB = false;
        public static bool ConnectToLocalLiveDB = false;
        public static string LiveConnectionPort;

        public static string TemporarySelectedGridviewValue;

        private static bool QuitApplication { get; set; } = false;
        public static DataTable TemporarySaleTables { get; set; } = new DataTable();
        public static UserAccount UserAccount { get; set; }
    }
}
