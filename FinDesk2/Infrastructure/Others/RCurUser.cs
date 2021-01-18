using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinDesk2.Infrastructure.Others
{
    public class RCurUser
    {
        public static string WLgn()
        {
            string WinLgn = System.Environment.UserName.ToString().ToLower();

            return WinLgn;
        }
    }
}
