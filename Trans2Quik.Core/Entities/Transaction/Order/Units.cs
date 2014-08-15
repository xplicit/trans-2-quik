namespace Trans2Quik.Core
{
    /// <summary>
    /// Единицы измерения отступа и защитного спрэда
    /// </summary>
    public enum Units : int
    {
        /// <summary>
        /// В процентах (шаг изменения - одна сотая процента)
        /// </summary>
        Percents = 0,

        /// <summary>
        /// В параметрах цены (шаг изменения равен шагу цены по инструменту)
        /// </summary>
        PriceUnits = 1
    }
}
