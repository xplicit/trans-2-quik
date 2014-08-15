namespace Trans2Quik.Core
{
    /// <summary>
    /// Период, когда была совершена сделка
    /// </summary>    
    public enum TradeInfoPeriod : int
    {
        /// <summary>
        /// Открытие
        /// </summary>
        Open = 0,

        /// <summary>
        /// Нормальный
        /// </summary>
        Normal = 1,

        /// <summary>
        /// Закрытие
        /// </summary>
        Close = 2
    }
}
