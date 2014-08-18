namespace Trans2Quik.Core
{
    using System;
    using System.Runtime.InteropServices;
    using Internals;

    public class TransactionManager
    {
        private readonly EntryPoint.TransactionReplyCallback transactionReplyCallback;

        private CallResult LastResult { get; set; }
        private bool AsyncMode { get; set; }

        public event EventHandler<TransactionEventArgs> TransactionAsyncReply;

        public TransactionManager(bool asyncMode = false)
        {
            this.AsyncMode = asyncMode;

            if (this.AsyncMode)
            {
                this.transactionReplyCallback = new EntryPoint.TransactionReplyCallback(this.TransactionReplyCallback);
                GCHandle.Alloc(this.transactionReplyCallback);
                EntryPoint.SetTransactionReplyCallback(this.transactionReplyCallback);
            }
        }

        public TransactionCallResult SendSyncTransaction(string transactionString)
        {
            if (this.AsyncMode)
            {
                throw new InvalidOperationException("Cannot send Sync transaction in Async mode.");
            }

            return EntryPoint.SendSyncTransaction(transactionString);
        }

        public bool SendAsyncTransaction(string transactionString)
        {
            if (!this.AsyncMode)
            {
                throw new InvalidOperationException("Cannot send Async transaction in sync mode.");
            }

            this.LastResult = EntryPoint.SendAsyncTransaction(transactionString);
            return this.LastResult.ReturnValue.IsSuccess;
        }

        private void TransactionReplyCallback(
                Int32 transactionResult,
                Int32 transactionExtendedErrorCode,
                Int32 transactionReplyCode,
                UInt32 transId,
                Double orderNum,
                [MarshalAs(UnmanagedType.LPStr)] string transactionReplyMessage)
        {
            var res = new TransactionCallResult(
                new ReturnValue(transactionResult),
                transactionExtendedErrorCode,
                string.Empty,
                transactionReplyCode,
                transId,
                orderNum,
                transactionReplyMessage);

            this.OnTransactionReply(new TransactionEventArgs(res));
        }

        protected virtual void OnTransactionReply(TransactionEventArgs args)
        {
            var tmp = this.TransactionAsyncReply;

            if (tmp != null)
            {
                tmp(this, args);
            }
        }
    }
}
