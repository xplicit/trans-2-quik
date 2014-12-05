namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Globalization;
    using System.Runtime.InteropServices.ComTypes;

    internal static class TypeConverter
    {
        public static readonly string CONST_AmountFormat = "F";

        public static OrderInfoStatus GetStatus(int statusCode)
        {
            switch (statusCode)
            {
                case (int)OrderInfoStatus.Active:
                    return OrderInfoStatus.Active;
                case (int)OrderInfoStatus.Withdrawn:
                    return OrderInfoStatus.Withdrawn;
                default:
                    return OrderInfoStatus.Completed;
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

        public static string AmountToString(decimal amount, int decimalPoints = 2, bool round = false)
        {
            var rounded = round ? RoundedAmount(amount, decimalPoints) : amount;
            var res = rounded.ToString(CONST_AmountFormat+decimalPoints, CultureInfo.InvariantCulture);
            return string.IsNullOrEmpty(res) ? "0" : res;
        }

        public static decimal RoundedAmount(decimal amount, int decimalPoints)
        {
            return Math.Round(amount, decimalPoints, MidpointRounding.AwayFromZero);
        }
    }
}
