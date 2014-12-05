namespace Trans2Quik.TestConsole
{
    using System;
    using System.Threading;
    using Core;

    class Program
    {
        static readonly Security ticker = new Security ("SPBFUT", "RIZ4", 0);

        static void Main(string[] args)
        {
            try
            {

                var gateway = new Gateway(@"C:\Quik", "SPBFUTXXXXX");
                gateway.OrderChanged += OrderChanged;
                gateway.TradeChanged += TradeChanged;
                gateway.NewTransaction += NewTransaction;  
                gateway.Start();

                Console.WriteLine("\nPress a Esc to quit...");

                DoWhileEscNotPressed(gateway, () =>
                {
                    // check connection
                    if (!gateway.IsConnected)
                    {
                        Console.WriteLine("Could not connect to the quik...");
                    }

                    Thread.Sleep(1000); // Loop until input is entered.
                });

                gateway.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: {0}\n{1}", ex.Message, ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void OrderChanged(object sender, OrderInfoEventArgs e)
        {
            // Process order here
            Console.WriteLine("--> ORDER: {0}", e.OrderInfo);
        }

        private static void TradeChanged(object sender, TradeInfoEventArgs e)
        {
            // Process trade here
            Console.WriteLine("--> TRADE: {0}", e.TradeInfo);
        }

        private static void NewTransaction(object sender, TransactionEventArgs e)
        {
            Console.WriteLine("--> NEW TRANSACTION: {0}", e.TransactionResult);
        }

        private static void DoWhileEscNotPressed(Gateway gateway, Action action)
        {
            var cki = new ConsoleKeyInfo();
            do
            {
                while (Console.KeyAvailable == false)
                {
                    action();
                }

                cki = Console.ReadKey(true);

                if (cki.Key == ConsoleKey.B)
                {
                    // Buy
                    gateway.SendOrder(ticker, Direction.Buy, 1, 93270);
                }

                if (cki.Key == ConsoleKey.S)
                {
                    // Sell
                    gateway.SendOrder(ticker, Direction.Sell, 1, 94500);
                }

            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
