namespace Trans2Quik.Core
{
    using System;
    using System.Runtime.InteropServices;
    using Internals;

    internal class ConnectionListener
    {
        private readonly EntryPoint.ConnectionStatusCallback connectionCallback;

        public string PathToQuik { get; private set; }
        public CallResult LastResult { get; private set; }
        public bool IsConnected
        {
            get
            {
                return this.IsQuikConnected && this.IsDllConnected;
            }
        }

        public event EventHandler ConnectionStatusChanged;

        public ConnectionListener(string pathToQuik)
        {
            this.PathToQuik = pathToQuik;
            this.connectionCallback = new EntryPoint.ConnectionStatusCallback(this.ConnectionStatusCallback);
            GCHandle.Alloc(this.connectionCallback);
        }

        public bool Connect()
        {
            var isCallbakOk = this.SetupConnectionCallback();
            this.LastResult = EntryPoint.Connect(this.PathToQuik);
            return this.LastResult.ReturnValue.IsSuccess && isCallbakOk;
        }
        public bool Disconnect()
        {
            // TODO: Check if connected.
            this.LastResult = EntryPoint.Disconnect();
            return this.LastResult.ReturnValue.IsSuccess;
        }

        internal bool IsQuikConnected
        {
            get
            {
                var res = EntryPoint.IsQuikConnected();
                return res.ReturnValue.IsQuikConnected;
            }
        }
        internal bool IsDllConnected
        {
            get
            {
                var res = EntryPoint.IsDllConnected();
                return res.ReturnValue.IsDllConnected;
            }
        }

        private void ConnectionStatusCallback(Int32 connectionEvent, UInt32 extendedErrorCode, byte[] infoMessage)
        {
            this.OnConnectionStatusChanged(EventArgs.Empty);
        }

        protected virtual void OnConnectionStatusChanged(EventArgs args)
        {
            var tmp = this.ConnectionStatusChanged;

            if (tmp != null)
            {
                tmp(this, args);
            }
        }

        private bool SetupConnectionCallback()
        {
            var res = EntryPoint.SetConnectionStatusCallback(this.connectionCallback);
            return res.ReturnValue.IsSuccess;
        }
    }
}
