using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopTeacherTools;
using System.Reflection;
using System.Net;

namespace DTTPresent
{
    class cls_info : cls_page
    {
        private static readonly cls_info instance = new cls_info();
        public static cls_info Instance { get { return instance; } }

        private Version version;
        private DateTime buildDateTime;

        private cls_info()
        {
            version = Assembly.GetEntryAssembly().GetName().Version;
            buildDateTime = new DateTime(2000, 1, 1).Add(new TimeSpan(
            TimeSpan.TicksPerDay * version.Build + // days since 1 January 2000
            TimeSpan.TicksPerSecond * 2 * version.Revision));
        }

        public string infoURL { get { return "http://www.niallbarr.me.uk/dtt/presenter/info.php?ver=" + WebUtility.UrlEncode(version.ToString()); } }
    }
}
