namespace Trans2Quik.Tests
{
    using Core;
    using Core.Entities.Transaction.Order;

    public static class Mother
    {
        public static readonly string CONST_PathToQuik = @"C:\Quik";
        public static readonly string CONST_Account = "LXX+XXXXXXXXX";
        public static readonly Security SBRF = new Security("TQBR", "SBER");
        public static readonly ProfitCondition STD_ProfitCondition = new ProfitCondition(0.1m, Units.PriceUnits, 0.1m, Units.PriceUnits);
    }
}
