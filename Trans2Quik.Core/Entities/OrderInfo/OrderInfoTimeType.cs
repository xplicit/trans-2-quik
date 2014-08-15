namespace Trans2Quik.Core
{
    public enum OrderInfoTimeType : int
    {
        /// <summary>
        /// Дата выставления заявки в формате YYYYMMDD
        /// </summary>
        QuikDate = 0,

        /// <summary>
        /// Время выставления заявки в формате HHMMSS
        /// </summary>
        QuikTime = 1,

        /// <summary>
        /// Микросекунды времени выставления заявки, целое число от 0 до 999999
        /// </summary>
        MicroSec = 2,

        /// <summary>
        /// Дата снятия заявки в формате YYYYMMDD 
        /// </summary>
        WithdrawQuikDate = 3,

        /// <summary>
        /// Время снятия заявки в формате HHMMSS
        /// </summary>
        WithdrawQuikTime = 4,

        /// <summary>
        /// Микросекунды времени снятия заявки, целое число от 0 до 999999
        /// </summary>
        WithdrawMicroSec = 5
    }
}
