namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Runtime.InteropServices.ComTypes;

    internal static class TypeConverter
    {
        public static OrderStatus GetStatus(int statusCode)
        {
            switch (statusCode)
            {
                case (int)OrderStatus.Active:
                    return OrderStatus.Active;
                case (int)OrderStatus.Withdrawn:
                    return OrderStatus.Withdrawn;
                default:
                    return OrderStatus.Completed;
            }
        }

        public static Direction GetDirection(int directionCode)
        {
            switch (directionCode)
            {
                case (int)Direction.Buy:
                    return Direction.Buy;
                default:
                    return Direction.Sell;
            }
        }

        public static DateTime GetDateTime(FILETIME filetime)
        {
            long high = filetime.dwHighDateTime;
            long ft = high << 32 + filetime.dwLowDateTime;
            return DateTime.FromFileTime(ft);
        }

        public static bool GetBool(int value)
        {
            return value != 0;
        }

        public static string ByteToString(byte[] str)
        {
            int count = 0;
            for (int i = 0; i < str.Length; ++i)
            {
                if (0 == str[i])
                {
                    count = i;
                    break;
                }
            }

            return System.Text.Encoding.Default.GetString(str, 0, count);
        }
    }
}
