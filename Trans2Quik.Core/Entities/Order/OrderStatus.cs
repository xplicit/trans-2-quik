namespace Trans2Quik.Core
{
    /// <summary>
    /// Состояние исполнения заявки
    /// </summary>
    public enum OrderStatus
    {
        /// <summary>
        /// Заявка исполнена
        /// </summary>
        Completed = 0,

        /// <summary>
        /// Активная заявка
        /// </summary>
        Active = 1,

        /// <summary>
        /// Заявка снята
        /// </summary>
        Withdrawn = 2
    }
}
