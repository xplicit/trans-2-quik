namespace Trans2Quik.Core
{
    /// <summary>
    /// Тип стоп-заявки
    /// </summary>
    public enum StopOrderKind : int
    {
        /// <summary>
        /// Стоп-лимит
        /// </summary>
        Simple = 0,

        /// <summary>
        /// С условием по другой бумаге
        /// </summary>
        ConditionPriceByOtherSec = 1,

        /// <summary>
        /// Со связанной заявкой
        /// </summary>
        WithLinkedLimitOrder = 2,
        
        /// <summary>
        /// Тэйк-профит
        /// </summary>
        TakeProfit = 3,

        /// <summary>
        /// Тэйк-профит и стоп-лимит
        /// </summary>
        TakeProfitAndStopLimit = 4,

        /// <summary>
        /// Стоп-лимит по исполнению заявки
        /// </summary>
        ActivatedByOrderSimple = 5,

        /// <summary>
        /// Тэйк-профит по исполнению заявки
        /// </summary>
        ActivatedByOrderTakeProfit = 6,

        /// <summary>
        /// Тэйк-профит и стоп-лимит по исполнению заявки
        /// </summary>
        ActivatedByOrderTakeProfitAndStopLimit = 7
    }
}
