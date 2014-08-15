namespace Trans2Quik.Core
{
    /// <summary>
    /// Признак того, идет ли начальное получение сделок или нет
    /// </summary>
    public enum TradeInfoMode : int
    {
        /// <summary>
        /// Новая сделка
        /// </summary>
        NewTrade = 0,

        /// <summary>
        /// Идет начальное получение сделок
        /// </summary>
        InitialFetch = 1,

        /// <summary>
        /// Получена последняя сделка из начальной рассылки
        /// </summary>
        EndInitialFetch = 2
    }
}
