namespace Trans2Quik.Core
{
    /// <summary>
    /// Вид сделки
    /// </summary>
    public enum TradeInfoKind : int
    {
        /// <summary>
        /// Неопределен
        /// </summary>
        Undefined = 0,

        /// <summary>
        /// Обычная
        /// </summary>
        Usual = 1,

        /// <summary>
        /// Адресная
        /// </summary>
        Address = 2,

        /// <summary>
        /// Первичное размещение
        /// </summary>
        Primary = 3,

        /// <summary>
        /// Перевод денег / бумаг
        /// </summary>
        Transfer = 4,

        /// <summary>
        /// Адресная сделка первой части РЕПО
        /// </summary>
        FirstPartOfRepo = 5,

        /// <summary>
        /// Расчетная по операции своп
        /// </summary>
        SettlementSwap = 6,

        /// <summary>
        /// Расчетная по внебиржевой операции своп
        /// </summary>
        SettlementOffExchangeSwap = 7,

        /// <summary>
        /// Расчетная сделка бивалютной корзины
        /// </summary>
        SettlementCurrencyBasket = 8,

        /// <summary>
        /// Расчетная внебиржевая сделка бивалютной корзины
        /// </summary>
        SettlementOffExchangeCurrencyBasket = 9
    }
}
