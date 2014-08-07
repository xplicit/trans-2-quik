namespace Trans2Quik.Core.Internals
{
    using System;

    internal static class ExecHelper
    {
        public static void Do(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                ex.ThrowIfCritical();
            }
        }

        public static bool IsCritical(this Exception ex)
        {
            return
                    ex is OutOfMemoryException
                    || ex is AppDomainUnloadedException
                    || ex is BadImageFormatException
                    || ex is CannotUnloadAppDomainException
                    || ex is InvalidProgramException
                    || ex is System.Threading.ThreadAbortException;
        }

        public static void ThrowIfCritical(this Exception ex)
        {
            if (IsCritical(ex))
            {
                throw ex;
            }
        }
    }
}
