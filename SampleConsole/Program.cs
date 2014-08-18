namespace SampleConsole
{
    using System;
    using Trans2Quik.Core;

    class Program
    {
        static void Main(string[] args)
        {
            var gateway = new Gateway(@"C:\Quik", "LXX+XXXXXXXXX");
            gateway.NewTransaction += OnNewTransaction;
            gateway.Start();

            // Buy 1 lot "SBER" by market
            gateway.SendOrder("TQBR", "SBER", Direction.Buy, 1);

            Console.ReadLine();
        }

        private static void OnNewTransaction(object sender, TransactionEventArgs e)
        {
            Console.WriteLine("Result: {0}", e.TransactionResult);
        }
    }
}
