using System;

namespace JGEmulator
{
    public static class Utils
    {
        public static string GetTimestamp()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
    }
}
