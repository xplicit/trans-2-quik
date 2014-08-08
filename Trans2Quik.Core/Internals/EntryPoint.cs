namespace Trans2Quik.Core.Internals
{
    using System;
    using System.Runtime.InteropServices;

    internal static class EntryPoint
    {
        private const UInt32 CONST_MessageSize = 150;

        internal const string CONST_DllName = "TRANS2QUIK.DLL";

        private const string CONST_Connect = "_TRANS2QUIK_CONNECT@16";
        private const string CONST_Disconnect = "_TRANS2QUIK_DISCONNECT@12";
        private const string CONST_IsDllConnected = "_TRANS2QUIK_IS_DLL_CONNECTED@12";
        private const string CONST_IsQuikConnected = "_TRANS2QUIK_IS_QUIK_CONNECTED@12";
        private const string CONST_SendSyncTransaction = "_TRANS2QUIK_SEND_SYNC_TRANSACTION@36";
        private const string CONST_SendAsyncTransaction = "_TRANS2QUIK_SEND_ASYNC_TRANSACTION@16";
        private const string CONST_SetTransactionsReplyCallback = "_TRANS2QUIK_SET_TRANSACTIONS_REPLY_CALLBACK@16";
        private const string CONST_SetConnectionStatusCallback = "_TRANS2QUIK_SET_CONNECTION_STATUS_CALLBACK@16";
        private const string CONST_SubscribeOrders = "_TRANS2QUIK_SUBSCRIBE_ORDERS@8";
        private const string CONST_UnsubscribeOrders = "_TRANS2QUIK_UNSUBSCRIBE_ORDERS@0";
        private const string CONST_StartOrders = "_TRANS2QUIK_START_ORDERS@4";
        private const string CONST_StartTrades = "_TRANS2QUIK_START_TRADES@4";
        private const string CONST_SubscribeTrades = "_TRANS2QUIK_SUBSCRIBE_TRADES@8";
        private const string CONST_UnsubscribeTrades = "_TRANS2QUIK_UNSUBSCRIBE_TRADES@0";

        public delegate void TransactionReplyCallback(
            Int32 transactionResult,
            Int32 transactionExtendedErrorCode,
            Int32 transactionReplyCode,
            UInt32 transId,
            Double orderNum,
            [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage);

        public delegate void ConnectionStatusCallback(
            Int32 connectionEvent,
            UInt32 extendedErrorCode,
            byte[] infoMessage);

        public delegate void TradeStatusCallback(
            Int32 mode,
            Double number,
            Double orderNumber,
            [MarshalAs(UnmanagedType.LPStr)]string classCode,
            [MarshalAs(UnmanagedType.LPStr)]string secCode,
            Double price,
            Int32 qty,
            Double value,
            Int32 isSell,
            Int32 tradeDescriptor);

        public delegate void OrderStatusCallback(
            Int32 mode,
            Int32 transId,
            Double number,
            [MarshalAs(UnmanagedType.LPStr)]string classCode,
            [MarshalAs(UnmanagedType.LPStr)]string secCode,
            Double price,
            Int32 balance,
            Double value,
            Int32 isSell,
            Int32 status,
            Int32 orderDescriptor);

        public static CallResult Connect(string connectionParamsString)
        {
            return Call(ConnectImpl, connectionParamsString);
        }

        public static CallResult Disconnect()
        {
            return Call(DisconnectImpl);
        }

        public static CallResult IsDllConnected()
        {
            return Call(IsDllConnectedImpl);
        }

        public static CallResult IsQuikConnected()
        {
            return Call(IsQuikConnectedImpl);
        }

        public static CallResult SendAsyncTransaction(string transactionString)
        {
            return Call(SendAsyncTransactionImpl, transactionString);
        }

        public static CallResult SetTransactionReplyCallback(TransactionReplyCallback transactionReplyCallback)
        {
            return Call(SetTransactionReplyCallbackImpl, transactionReplyCallback);
        }

        public static CallResult SetConnectionStatusCallback(ConnectionStatusCallback connectionStatusCallback)
        {
            return Call(SetConnectionStatusCallbackImpl, connectionStatusCallback);
        }

        public static TransactionCallResult SendSyncTransaction(string transactionString)
        {
            var errCode = 0;
            var replyCode = 0;
            var transId = 0;
            var orderNum = 0D;
            var errMessage = new byte[CONST_MessageSize];
            var resMessage = new byte[CONST_MessageSize];

            var res = SendSyncTransactionImpl(
                transactionString,
                ref replyCode,
                ref transId,
                ref orderNum,
                resMessage,
                CONST_MessageSize,
                ref errCode,
                errMessage,
                CONST_MessageSize);

            return new TransactionCallResult(
                new ReturnValue(res),
                errCode,
                TypeConverter.ByteToString(errMessage),
                replyCode,
                transId,
                orderNum,
                TypeConverter.ByteToString(resMessage));
        }

        public static ReturnValue SubscribeOrders(string classCode, string secCode)
        {
            var res = SubscribeOrdersImp(classCode, secCode);
            return new ReturnValue(res);
        }

        public static ReturnValue UnsubscribeOrders()
        {
            var res = UnsubscribeOrdersImp();
            return new ReturnValue(res);
        }

        public static ReturnValue StartOrders(OrderStatusCallback orderStatusCallback)
        {
            var res = StartOrdersImp(orderStatusCallback);
            return new ReturnValue(res);
        }

        public static ReturnValue StartTrades(TradeStatusCallback tradeStatusCallback)
        {
            var res = StartTradesImp(tradeStatusCallback);
            return new ReturnValue(res);
        }

        public static ReturnValue SubscribeTrades(string classCode, string secCode)
        {
            var res = SubscribeTradesImp(classCode, secCode);
            return new ReturnValue(res);
        }

        public static ReturnValue UnsubscribeTrades()
        {
            var res = UnsubscribeTradesImp();
            return new ReturnValue(res);
        }

        [DllImport(CONST_DllName, EntryPoint = CONST_Connect, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 ConnectImpl(string connectionParamsString, ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_Disconnect, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 DisconnectImpl(ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_IsDllConnected, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 IsDllConnectedImpl(ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_IsQuikConnected, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 IsQuikConnectedImpl(ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_SendSyncTransaction, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SendSyncTransactionImpl(
            string transactionString,
            ref Int32 replyCode,
            ref int transId,
            ref double orderNum,
            byte[] resultMessage,
            UInt32 resultMessageSize,
            ref Int32 extendedErrorCode,
            byte[] errorMessage,
            UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_SendAsyncTransaction, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SendAsyncTransactionImpl(
            [MarshalAs(UnmanagedType.LPStr)]string transactionString,
            ref Int32 extendedErrorCode,
            byte[] errorMessage,
            UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_SetTransactionsReplyCallback, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SetTransactionReplyCallbackImpl(
            TransactionReplyCallback transactionReplyCallback,
            ref Int32 extendedErrorCode,
            byte[] errorMessage,
            UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_SetConnectionStatusCallback, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SetConnectionStatusCallbackImpl(
            ConnectionStatusCallback connectionStatusCallback,
            ref Int32 extendedErrorCode,
            byte[] errorMessage,
            UInt32 errorMessageSize);

        [DllImport(CONST_DllName, EntryPoint = CONST_SubscribeOrders, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SubscribeOrdersImp([MarshalAs(UnmanagedType.LPStr)]string classCode, [MarshalAs(UnmanagedType.LPStr)]string secCode);

        [DllImport(CONST_DllName, EntryPoint = CONST_UnsubscribeOrders, CallingConvention = CallingConvention.StdCall)]
        public static extern Int32 UnsubscribeOrdersImp();

        [DllImport(CONST_DllName, EntryPoint = CONST_StartOrders, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 StartOrdersImp(OrderStatusCallback orderStatusCallback);

        [DllImport(CONST_DllName, EntryPoint = CONST_StartTrades, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 StartTradesImp(TradeStatusCallback tradeStatusCallback);

        [DllImport(CONST_DllName, EntryPoint = CONST_SubscribeTrades, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 SubscribeTradesImp([MarshalAs(UnmanagedType.LPStr)]string classCode, [MarshalAs(UnmanagedType.LPStr)]string secCode);

        [DllImport(CONST_DllName, EntryPoint = CONST_UnsubscribeTrades, CallingConvention = CallingConvention.StdCall)]
        private static extern Int32 UnsubscribeTradesImp();

        private delegate Int32 CallDelegate(ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);
        private delegate Int32 CallDelegate<in T>(T parameter, ref Int32 extendedErrorCode, byte[] errorMessage, UInt32 errorMessageSize);
        private static CallResult Call(CallDelegate callDelegate)
        {
            var errCode = 0;
            var message = new byte[CONST_MessageSize];
            var res = callDelegate(ref errCode, message, CONST_MessageSize);
            return new CallResult(new ReturnValue(res), errCode, TypeConverter.ByteToString(message));
        }
        private static CallResult Call<T>(CallDelegate<T> callDelegate, T parameter)
        {
            var errCode = 0;
            var message = new byte[CONST_MessageSize];
            var res = callDelegate(parameter, ref errCode, message, CONST_MessageSize);
            return new CallResult(new ReturnValue(res), errCode, TypeConverter.ByteToString(message));
        }
    }
}
