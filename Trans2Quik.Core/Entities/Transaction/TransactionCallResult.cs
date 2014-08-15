namespace Trans2Quik.Core
{
    using System.Text;

    public class TransactionCallResult : CallResult
    {
        public int ReplyCode { get; set; }
        public long TransactionId { get; set; }
        public double OrderNumber { get; set; }
        public string ResultMessage { get; set; }

        public TransactionCallResult(
            ReturnValue result,
            int errorCode,
            string errorMessage,
            int replyCode,
            long transactionId,
            double orderNumber,
            string resultMessage)
            : base(result, errorCode, errorMessage)
        {
            this.ReplyCode = replyCode;
            this.TransactionId = transactionId;
            this.OrderNumber = orderNumber;
            this.ResultMessage = resultMessage;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendFormat("\nReplyCode={0}; TransactionId={1}; OrderNumber={2}; ResultMessage={3};",
                this.ReplyCode,
                this.TransactionId,
                this.OrderNumber,
                this.ResultMessage);

            return sb.ToString().Trim();
        }
    }
}
