namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Runtime.InteropServices;

    internal static class TradeEntryPoint
    {
        private const string CONST_Account = "_TRANS2QUIK_TRADE_ACCOUNT@4";
        private const string CONST_AccuredInt2 = "_TRANS2QUIK_TRADE_ACCRUED_INT2@4";
        private const string CONST_AccuredInt = "_TRANS2QUIK_TRADE_ACCRUED_INT@4";
        private const string CONST_BlockSecurities = "_TRANS2QUIK_TRADE_BLOCK_SECURITIES@4";
        private const string CONST_BrokerRef = "_TRANS2QUIK_TRADE_BROKERREF@4";
        private const string CONST_ClearingCenterComission = "_TRANS2QUIK_TRADE_CLEARING_CENTER_COMMISSION@4";
        private const string CONST_ClientCode = "_TRANS2QUIK_TRADE_CLIENT_CODE@4";
        private const string CONST_Currency = "_TRANS2QUIK_TRADE_CURRENCY@4";
        private const string CONST_Date = "_TRANS2QUIK_TRADE_DATE@4";
        private const string CONST_DateTime = "_TRANS2QUIK_TRADE_DATE_TIME@8";
        private const string CONST_ExchangeCode = "_TRANS2QUIK_TRADE_EXCHANGE_CODE@4";
        private const string CONST_ExchangeComission = "_TRANS2QUIK_TRADE_EXCHANGE_COMMISSION@4";
        private const string CONST_FileTime = "_TRANS2QUIK_TRADE_FILETIME@4";
        private const string CONST_FirmId = "_TRANS2QUIK_TRADE_FIRMID@4";
        private const string CONST_IsMarginal = "_TRANS2QUIK_TRADE_IS_MARGINAL@4";
        private const string CONST_Kind = "_TRANS2QUIK_TRADE_KIND@4";
        private const string CONST_LowerDiscount = "_TRANS2QUIK_TRADE_LOWER_DISCOUNT@4";
        private const string CONST_PartnerFirmId = "_TRANS2QUIK_TRADE_PARTNER_FIRMID@4";
        private const string CONST_Period = "_TRANS2QUIK_TRADE_PERIOD@4";
        private const string CONST_Price2 = "_TRANS2QUIK_TRADE_PRICE2@4";
        private const string CONST_Repo2Value = "_TRANS2QUIK_TRADE_REPO2_VALUE@4";
        private const string CONST_RepoRate = "_TRANS2QUIK_TRADE_REPO_RATE@4";
        private const string CONST_RepoTerm = "_TRANS2QUIK_TRADE_REPO_TERM@4";
        private const string CONST_RepoValue = "_TRANS2QUIK_TRADE_REPO_VALUE@4";
        private const string CONST_SettleCode = "_TRANS2QUIK_TRADE_SETTLE_CODE@4";
        private const string CONST_SettleCurrency = "_TRANS2QUIK_TRADE_SETTLE_CURRENCY@4";
        private const string CONST_SettleDate = "_TRANS2QUIK_TRADE_SETTLE_DATE@4";
        private const string CONST_StartDiscount = "_TRANS2QUIK_TRADE_START_DISCOUNT@4";
        private const string CONST_StationId = "_TRANS2QUIK_TRADE_STATION_ID@4";
        private const string CONST_Time = "_TRANS2QUIK_TRADE_TIME@4";
        private const string CONST_TradingSystemComission = "_TRANS2QUIK_TRADE_TRADING_SYSTEM_COMMISSION@4";
        private const string CONST_TsComission = "_TRANS2QUIK_TRADE_TS_COMMISSION@4";
        private const string CONST_UpperDiscount = "_TRANS2QUIK_TRADE_UPPER_DISCOUNT@4";
        private const string CONST_UserId = "_TRANS2QUIK_TRADE_USERID@4";
        private const string CONST_Yield = "_TRANS2QUIK_TRADE_YIELD@4";

        public static string Account(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(AccountImpl(tradeDescriptor));
        }

        public static string BrokerRef(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(BrokerRefImpl(tradeDescriptor));
        }

        public static string ClientCode(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(ClientCodeImpl(tradeDescriptor));
        }

        public static string Currency(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(CurrencyImpl(tradeDescriptor));
        }

        public static string ExchangeCode(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(ExchangeCodeImpl(tradeDescriptor));
        }

        public static string FirmId(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(FirmIdImpl(tradeDescriptor));
        }

        public static string PartnerFirmId(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(PartnerFirmIdImpl(tradeDescriptor));
        }

        public static string SettleCode(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(SettleCodeImpl(tradeDescriptor));
        }

        public static string SettleCurrency(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(SettleCurrencyImpl(tradeDescriptor));
        }

        public static string StationId(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(StationIdImpl(tradeDescriptor));
        }

        public static string UserId(Int32 tradeDescriptor)
        {
            return Marshal.PtrToStringAnsi(UserIdImpl(tradeDescriptor));
        }


        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_AccuredInt2, CallingConvention = CallingConvention.StdCall)]
        public static extern double AccuredInt2(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_AccuredInt, CallingConvention = CallingConvention.StdCall)]
        public static extern double AccuredInt(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_BlockSecurities, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 BlockSecurities(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ClearingCenterComission, CallingConvention = CallingConvention.StdCall)]
        public static extern double ClearingCenterComission(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Date, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Date(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_DateTime, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DateTime(Int32 tradeDescriptor, Int32 nTimeType);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ExchangeComission, CallingConvention = CallingConvention.StdCall)]
        public static extern double ExchangeComission(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_FileTime, CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME FileTime(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_IsMarginal, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 IsMarginal(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Kind, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Kind(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_LowerDiscount, CallingConvention = CallingConvention.StdCall)]
        public static extern double LowerDiscount(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Period, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Period(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Price2, CallingConvention = CallingConvention.StdCall)]
        public static extern double Price2(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Repo2Value, CallingConvention = CallingConvention.StdCall)]
        public static extern double Repo2Value(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_RepoRate, CallingConvention = CallingConvention.StdCall)]
        public static extern double RepoRate(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_RepoTerm, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 RepoTerm(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_RepoValue, CallingConvention = CallingConvention.StdCall)]
        public static extern double RepoValue(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_SettleDate, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 SettleDate(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_StartDiscount, CallingConvention = CallingConvention.StdCall)]
        public static extern double StartDiscount(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Time, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Time(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_TradingSystemComission, CallingConvention = CallingConvention.StdCall)]
        public static extern double TradingSystemComission(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_TsComission, CallingConvention = CallingConvention.StdCall)]
        public static extern double TsComission(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_UpperDiscount, CallingConvention = CallingConvention.StdCall)]
        public static extern double UpperDiscount(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Yield, CallingConvention = CallingConvention.StdCall)]
        public static extern double Yield(Int32 tradeDescriptor);


        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Account, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr AccountImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_BrokerRef, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr BrokerRefImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ClientCode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ClientCodeImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Currency, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr CurrencyImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ExchangeCode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ExchangeCodeImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_FirmId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr FirmIdImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_PartnerFirmId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr PartnerFirmIdImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_SettleCode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SettleCodeImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_SettleCurrency, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr SettleCurrencyImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_StationId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr StationIdImpl(Int32 tradeDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_UserId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr UserIdImpl(Int32 tradeDescriptor);
    }
}
