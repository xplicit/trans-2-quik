namespace Trans2Quik.Tests
{
    using Core;
    using Core.Entities.Transaction.Order;

    public static class Mother
    {
        public static readonly string CONST_PathToQuik = @"Q:\PSBQuik";
        public static readonly string CONST_Account = "L01+00000F00";
        public static readonly Security SBRF = new Security("TQBR", "SBER");
        public static readonly ProfitCondition STD_ProfitCondition = new ProfitCondition(0.1m, Units.PriceUnits, 0.1m, Units.PriceUnits);
    }
}
