﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialReader.Class.Function
{
    public static class LogFunction
    {

        public static DateTime ConvertDatetime(int _unix)
        {
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(_unix).ToLocalTime();
            return dtDateTime;
        }

        public static int ConvertToUnixTime()
        {
            int unixTimestamp = (Int32)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            return unixTimestamp;

        }

    }
}
    