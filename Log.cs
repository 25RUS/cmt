using System;
using System.IO;

namespace CMT
{
    public static class Log
    {
        public static void Write(string logMsg)
        {    
            File.AppendAllText($"{CMT.SysInit.rdn}/cmt_log.txt", $"{DateTime.Now.ToString()} {logMsg}\n");
        }

    }
}