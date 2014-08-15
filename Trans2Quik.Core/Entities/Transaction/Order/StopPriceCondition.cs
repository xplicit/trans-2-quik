namespace Trans2Quik.Core
{
    /// <summary>
    /// Условие стоп цены
    /// </summary>
    public enum StopPriceCondition : int
    {
        /// <summary>
        /// "&lt;="
        /// </summary>
        LessOrEqual = 0,

        /// <summary>
        /// "&gt;="
        /// </summary>
        GreatherOrEqual = 1
    }
}