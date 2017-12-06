using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NTechAdviser
{
    public class ApplicationContext
    {
        private static volatile ApplicationContext instance;
        private static object syncRoot = new Object();

        private ApplicationContext() { }

        public static ApplicationContext Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new ApplicationContext();
                    }
                }

                return instance;
            }
        }

        public static List<string> AvoidableColumnsForAccountsSearch { get; set; }
        public static List<string> AvoidableColumnsForCreDebSearch { get; set; }
        public static List<string> AvoidableColumnsForStocksSearch { get; set; }

        public static string UserName { get; set; }
        public static int UserType { get; set; }
        public static bool CanContinue { get; set; }
        public static bool IsLoggedIn { get; set; }
        public static string AdminKeyForUpdate { get; set; }
        public static List<string> ProjectNames { get; set; }
        public static List<string> ParticularDetails { get; set; }
        public static bool PrintContentGenerated { get; set; }
    }
}
