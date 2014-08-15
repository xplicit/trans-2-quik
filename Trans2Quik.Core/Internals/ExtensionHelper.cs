namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Text;

    internal static class ExtensionHelper
    {
        private const string CONST_Format = "{0}={1}; ";

        public static void AppendKey(this StringBuilder sb, string key, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                sb.AppendFormat(CONST_Format, key, value);
            }
        }
        public static void AppendKey(this StringBuilder sb, string key, decimal? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, TypeConverter.AmountToString(value.Value));
        }

        public static void AppendKey(this StringBuilder sb, string key, int? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, value.Value);
        }

        public static void AppendKey(this StringBuilder sb, string key, bool? value)
        {
            if (!value.HasValue)
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, value.Value ? "YES" : "NO");
        }

        public static void AppendKey(this StringBuilder sb, string key, Direction? direction)
        {
            if (!direction.HasValue)
            {
                return;
            }

            switch (direction.Value)
            {
                case Direction.Buy:
                    sb.AppendFormat(CONST_Format, key, "B");
                    return;
                case Direction.Sell:
                    sb.AppendFormat(CONST_Format, key, "S");
                    return;
            };
        }
        public static void AppendKey(this StringBuilder sb, string key, ExecCondition? condition)
        {
            if (!condition.HasValue)
            {
                return;
            }

            switch (condition.Value)
            {
                case ExecCondition.PutInQueue:
                    sb.AppendFormat(CONST_Format, key, "PUT_IN_QUEUE");
                    return;
                case ExecCondition.FillOrKill:
                    sb.AppendFormat(CONST_Format, key, "FILL_OR_KILL");
                    return;
                case ExecCondition.KillBalance:
                    sb.AppendFormat(CONST_Format, key, "KILL_BALANCE");
                    return;
            };
        }

        public static void AppendKey(this StringBuilder sb, string key, StopOrderKind? orderKind)
        {
            if (!orderKind.HasValue)
            {
                return;
            }

            var orderKindString = string.Empty;
            switch (orderKind.Value)
            {
                case StopOrderKind.Simple:
                    orderKindString = "SIMPLE_STOP_ORDER";
                    break;
                case StopOrderKind.ConditionPriceByOtherSec:
                    orderKindString = "CONDITION_PRICE_BY_OTHER_SEC";
                    break;
                case StopOrderKind.WithLinkedLimitOrder:
                    orderKindString = "WITH_LINKED_LIMIT_ORDER";
                    break;
                case StopOrderKind.TakeProfit:
                    orderKindString = "TAKE_PROFIT_STOP_ORDER";
                    break;
                case StopOrderKind.TakeProfitAndStopLimit:
                    orderKindString = "TAKE_PROFIT_AND_STOP_LIMIT_ORDER";
                    break;
                case StopOrderKind.ActivatedByOrderSimple:
                    orderKindString = "ACTIVATED_BY_ORDER_SIMPLE_STOP_ORDER";
                    break;
                case StopOrderKind.ActivatedByOrderTakeProfit:
                    orderKindString = "ACTIVATED_BY_ORDER_TAKE_PROFIT_STOP_ORDER";
                    break;
                case StopOrderKind.ActivatedByOrderTakeProfitAndStopLimit:
                    orderKindString = "ACTIVATED_BY_ORDER_TAKE_PROFIT_AND_STOP_LIMIT_ORDER";
                    break;
            };

            if (string.IsNullOrEmpty(orderKindString))
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, orderKindString);
        }

        public static void AppendKey(this StringBuilder sb, string key, StopPriceCondition? priceCondition)
        {
            if (!priceCondition.HasValue)
            {
                return;
            }

            switch (priceCondition.Value)
            {
                case StopPriceCondition.LessOrEqual:
                    sb.AppendFormat(CONST_Format, key, "<=");
                    return;
                case StopPriceCondition.GreatherOrEqual:
                    sb.AppendFormat(CONST_Format, key, ">=");
                    return;
            };
        }

        public static void AppendKey(this StringBuilder sb, string key, Units? units)
        {
            if (!units.HasValue)
            {
                return;
            }

            switch (units.Value)
            {
                case Units.Percents:
                    sb.AppendFormat(CONST_Format, key, "PERCENTS");
                    return;
                case Units.PriceUnits:
                    sb.AppendFormat(CONST_Format, key, "PRICE_UNITS");
                    return;
            };
        }
        
        public static void AppendKey(this StringBuilder sb, string key, DateTime? time)
        {
            if (!time.HasValue)
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, time.Value.ToString("hhmmss"));
        }

        public static void AppendOrderType(this StringBuilder sb, string key, bool? isLimitOrder)
        {
            if (!isLimitOrder.HasValue)
            {
                return;
            }

            var symbol = isLimitOrder.Value ? "L" : "M";
            sb.AppendFormat(CONST_Format, key, symbol);
        }

        public static void AppendKey(this StringBuilder sb, string key, ExpiryDate expDate)
        {
            if (expDate == null)
            {
                return;
            }

            sb.AppendFormat(CONST_Format, key, expDate);
        }
    }
}
