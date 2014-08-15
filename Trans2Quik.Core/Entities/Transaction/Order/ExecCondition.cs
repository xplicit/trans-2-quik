namespace Trans2Quik.Core
{
    /// <summary>
    /// Условие исполнения заявки.
    /// </summary>
    public enum ExecCondition : int
    {
        /// <summary>
        /// Поставить в очередь
        /// </summary>
        PutInQueue = 0,

        /// <summary>
        /// Немедленно или отклонить
        /// </summary>
        FillOrKill = 1,

        /// <summary>
        /// Снять остаток
        /// </summary>
        KillBalance = 2
    }
}
