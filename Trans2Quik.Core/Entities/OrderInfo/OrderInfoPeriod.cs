namespace Trans2Quik.Core.Entities.Order
{
    /// <summary>
    /// Период, когда была выставлена заявка
    /// </summary>
    public enum OrderInfoPeriod : int
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
