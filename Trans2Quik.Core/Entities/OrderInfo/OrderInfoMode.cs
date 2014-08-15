namespace Trans2Quik.Core
{
    /// <summary>
    /// Признак того, идет ли начальное получение заявок или нет
    /// </summary>
    public enum OrderInfoMode : int
    {
        /// <summary>
        /// Новая заявка
        /// </summary>
        NewOrder = 0,

        /// <summary>
        /// Идет начальное получение заявок
        /// </summary>
        InitialFetch = 1,

        /// <summary>
        /// Получена последняя заявка из начальной рассылки
        /// </summary>
        EndInitialFetch = 2
    }
}
