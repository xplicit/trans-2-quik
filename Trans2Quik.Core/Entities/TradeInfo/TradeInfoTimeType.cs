namespace Trans2Quik.Core
{
    public enum TradeInfoTimeType : int
    {
        /// <summary>
        /// Дата заключения сделки в формате YYYYMMDD
        /// </summary>
        QuikDate = 0,

        /// <summary>
        /// Время заключения сделки в формате HHMMSS
        /// </summary>
        QuikTime = 1,

        /// <summary>
        /// Микросекунды времени заключения сделки, целое число от 0 до 999999
        /// </summary>
        MicroSec = 2
    }
}
