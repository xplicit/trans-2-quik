namespace Trans2Quik.Core
{
    using System;

    public class TransactionEventArgs : EventArgs
    {
        public  TransactionCallResult TransactionResult { get; private set; }

        public TransactionEventArgs(TransactionCallResult transactionResult)
        {
            this.TransactionResult = transactionResult;
        }
    }
}
