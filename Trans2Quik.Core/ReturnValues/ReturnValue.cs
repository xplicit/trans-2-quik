namespace Trans2Quik.Core
{
    public class ReturnValue
    {
        private const int CONST_Success = 0;
        private const int CONST_Failed = 1;
        private const int CONST_QuikTerminalNotFound = 2;
        private const int CONST_DllVersionNotSupported = 3;
        private const int CONST_AlreadyConnectedToQuik = 4;
        private const int CONST_WrongSyntax = 5;
        private const int CONST_QuikNotConnected = 6;
        private const int CONST_DllNotConnected = 7;
        private const int CONST_QuikConnected = 8;
        private const int CONST_QuikDisconnected = 9;
        private const int CONST_DllConnected = 10;
        private const int CONST_DllDisconnected = 11;
        private const int CONST_MemoryAllocationError = 12;
        private const int CONST_WrongConnectionHandle = 13;
        private const int CONST_WrongInputParams = 14;

        public int Code { get; private set; }

        public string Message
        {
            get
            {
                return ResultToString(this.Code);
            }
        }

        public bool IsSuccess
        {
            get
            {
                return this.Code == CONST_Success;
            }
        }

        public bool IsQuikConnected
        {
            get
            {
                return this.Code == CONST_QuikConnected;
            }
        }

        public bool IsDllConnected
        {
            get
            {
                return this.Code == CONST_DllConnected;
            }
        }

        public ReturnValue(int code)
        {
            this.Code = code;
        }

        public override string ToString()
        {
            return string.Format("{0} - {1} ", this.Code, ResultToString(this.Code));
        }

        public static string ResultToString(int result)
        {
            switch (result)
            {
                case CONST_Success:
                    return Resources.Success;
                case CONST_Failed:
                    return Resources.Failed;
                case CONST_QuikTerminalNotFound:
                    return Resources.QuikTerminalNotFound;
                case CONST_DllVersionNotSupported:
                    return Resources.DllVersionNotSupported;
                case CONST_AlreadyConnectedToQuik:
                    return Resources.AlreadyConnectedToQuik;
                case CONST_WrongSyntax:
                    return Resources.WrongSyntax;
                case CONST_QuikNotConnected:
                    return Resources.QuikNotConnected;
                case CONST_DllNotConnected:
                    return Resources.DllNotConnected;
                case CONST_QuikConnected:
                    return Resources.QuikConnected;
                case CONST_QuikDisconnected:
                    return Resources.QuikDisconnected;
                case CONST_DllConnected:
                    return Resources.DllConnected;
                case CONST_DllDisconnected:
                    return Resources.DllDisconnected;
                case CONST_MemoryAllocationError:
                    return Resources.MemoryAllocationError;
                case CONST_WrongConnectionHandle:
                    return Resources.WrongConnectionHandle;
                case CONST_WrongInputParams:
                    return Resources.WrongInputParams;
                default:
                    return Resources.UnknownValue;
            }
        }
    }
}
