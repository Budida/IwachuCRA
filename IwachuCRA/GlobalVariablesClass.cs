using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IwachuCRA
{
   public static class GlobalVariablesClass
    {
        public static DateTime referenceDate = new DateTime(1970, 1, 1);
        public static string
            username = "",
            council_code    = "",
            region_code     = "",
            email           = "",
            fullname        = "",
            council_name    = "",
            daddress        = "",
            dfax            = "",
            dphone          = "",
            demail          = "",
            dedname         ="",
            bank_account    ="",
            level           = "";
        public static double makazi_percent = 0,
           biashara_percent = 0,
           bmakazi_percent = 0,
           riba_percent = 0,
           limbikizo_percent = 0,
           limbikizo_mwezi = 0,
           riba_month = 0;
        public static string    riba_tumika    = "";
        public static int       userid;
        public static string    system_ip      = "";
        public static string    system_db      = "";
        public static string    db_user        = "";
        public static string    db_pass        = "";
        public static string connString         = "";
    }
}
