namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Runtime.InteropServices;

    internal static class OrderEntryPoint
    {
        private const string CONST_Accured = "_TRANS2QUIK_ORDER_ACCRUED_INT@4";
        private const string CONST_ActivationTime = "_TRANS2QUIK_ORDER_ACTIVATION_TIME@4";
        private const string CONST_Date = "_TRANS2QUIK_ORDER_DATE@4";
        private const string CONST_DateTime = "_TRANS2QUIK_ORDER_DATE_TIME@8";
        private const string CONST_Expiry = "_TRANS2QUIK_ORDER_EXPIRY@4";
        private const string CONST_FileTime = "_TRANS2QUIK_ORDER_FILETIME@4";
        private const string CONST_Period = "_TRANS2QUIK_ORDER_PERIOD@4";
        private const string CONST_Qty = "_TRANS2QUIK_ORDER_QTY@4";
        private const string CONST_Time = "_TRANS2QUIK_ORDER_TIME@4";
        private const string CONST_Uid = "_TRANS2QUIK_ORDER_UID@4";
        private const string CONST_UserId = "_TRANS2QUIK_ORDER_USERID@4";
        private const string CONST_VisibleQty = "_TRANS2QUIK_ORDER_VISIBLE_QTY@4";
        private const string CONST_WithdrawFileTime = "_TRANS2QUIK_ORDER_WITHDRAW_FILETIME@4";
        private const string CONST_WithdrawTime = "_TRANS2QUIK_ORDER_WITHDRAW_TIME@4";
        private const string CONST_Yield = "_TRANS2QUIK_ORDER_YIELD@4";
        private const string CONST_Account = "_TRANS2QUIK_ORDER_ACCOUNT@4";
        private const string CONST_BrokerRef = "_TRANS2QUIK_ORDER_BROKERREF@4";
        private const string CONST_ClientCode = "_TRANS2QUIK_ORDER_CLIENT_CODE@4";
        private const string CONST_FirmId = "_TRANS2QUIK_ORDER_FIRMID@4";

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Qty, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Qty(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Date, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Date(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Time, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Time(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_DateTime, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 DateTime(Int32 orderDescriptor, Int32 timeType);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ActivationTime, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 ActivationTime(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_WithdrawTime, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 WithdrawTime(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Expiry, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Expiry(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Accured, CallingConvention = CallingConvention.StdCall)]
        public static extern double AccuredInt(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Yield, CallingConvention = CallingConvention.StdCall)]
        public static extern double Yield(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Uid, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Uid(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_VisibleQty, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 VisibleQty(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Period, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 Period(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_FileTime, CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME FileTime(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_WithdrawFileTime, CallingConvention = CallingConvention.StdCall)]
        public static extern System.Runtime.InteropServices.ComTypes.FILETIME WithdawFileTime(Int32 orderDescriptor);

        public static string UserId(Int32 orderDescriptor)
        {
            return Marshal.PtrToStringAnsi(UserIdImpl(orderDescriptor));
        }
        public static string Account(Int32 orderDescriptor)
        {
            return Marshal.PtrToStringAnsi(AccountImpl(orderDescriptor));
        }
        public static string BrokerRef(Int32 orderDescriptor)
        {
            return Marshal.PtrToStringAnsi(BrokerRefImpl(orderDescriptor));
        }
        public static string ClientCode(Int32 orderDescriptor)
        {
            return Marshal.PtrToStringAnsi(ClientCodeImpl(orderDescriptor));
        }
        public static string FirmId(Int32 orderDescriptor)
        {
            return Marshal.PtrToStringAnsi(FirmIdImpl(orderDescriptor));
        }

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_UserId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr UserIdImpl(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_Account, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr AccountImpl(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_BrokerRef, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr BrokerRefImpl(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_ClientCode, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr ClientCodeImpl(Int32 orderDescriptor);

        [DllImport(EntryPoint.CONST_DllName, EntryPoint = CONST_FirmId, CallingConvention = CallingConvention.StdCall)]
        private static extern IntPtr FirmIdImpl(Int32 orderDescriptor);
    }
}
