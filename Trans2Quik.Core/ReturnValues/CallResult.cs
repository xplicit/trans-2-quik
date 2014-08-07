namespace Trans2Quik.Core
{
    using System.Text;

    public class CallResult
    {
        public int ErrorCode { get; private set; }
        public ReturnValue ReturnValue { get; private set; }
        public string ErrorMessage { get; private set; }

        public CallResult(ReturnValue returnValue, int errorCode, string errorMessage)
        {
            this.ReturnValue = returnValue;
            this.ErrorCode = errorCode;
            this.ErrorMessage = errorMessage;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("ReturnValue={0}; ErrorCode={1}; Message={2};", this.ReturnValue, this.ErrorCode, this.ErrorMessage);
            return sb.ToString().Trim();
        }
    }
}
