namespace Trans2Quik.Core.Internals
{
    using System.Text;
    using Entities;

    internal static class ExtensionHelper
    {
        public static void AppendKey(this StringBuilder sb, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                sb.AppendFormat("{0}={1}; ", key, value);
            }
        }
        public static void AppendKey(this StringBuilder sb, string key, decimal? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat("{0}={1}; ", key, TypeConverter.AmountToString(value.Value));
        }

        public static void AppendKey(this StringBuilder sb, string key, int? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat("{0}={1}; ", key, value.Value);
        }

        public static void AppendKey(this StringBuilder sb, string key, bool? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat("{0}={1}; ", key, value.Value ? "YES" : "NO");
        }

        public static void AppendKey(this StringBuilder sb, string key, Direction? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            switch (value.Value)
            {
                case Direction.Buy:
                    sb.AppendFormat("{0}={1}; ", key, "B");
                    return;
                case Direction.Sell:
                    sb.AppendFormat("{0}={1}; ", key, "S");
                    return;
            };
        }
        public static void AppendKey(this StringBuilder sb, string key, ExecCondition? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            switch (value.Value)
            {
                case ExecCondition.PutInQueue:
                    sb.AppendFormat("{0}={1}; ", key, "PUT_IN_QUEUE");
                    return;
                case ExecCondition.FillOrKill:
                    sb.AppendFormat("{0}={1}; ", key, "FILL_OR_KILL");
                    return;
                case ExecCondition.KillBalance:
                    sb.AppendFormat("{0}={1}; ", key, "KILL_BALANCE");
                    return;
            };
        }

        public static void AppendOrderType(this StringBuilder sb, string key, bool? isLimitOrder)
        {
            if (!isLimitOrder.HasValue)
            {
                return;
            }

            var symbol = isLimitOrder.Value ? "L" : "M";
            sb.AppendFormat("{0}={1}; ", key, symbol);
        }
    }
}
