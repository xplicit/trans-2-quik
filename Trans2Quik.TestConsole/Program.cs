namespace Trans2Quik.TestConsole
{
    using System;
    using System.Threading;
    using Core;

    class Program
    {
        public static readonly string PathToQuik = @"C:\PSBQuik";

        static void Main(string[] args)
        {
            try
            {
                var gateway = new TransactionGateway(PathToQuik);
                gateway.OrderChanged += OrderChanged;
                gateway.TradeChanged += TradeChanged;
                gateway.Start();

                Console.WriteLine("\nPress a Esc to quit...");

                DoWhileEscNotPressed(() =>
                {
                    // check connection
                    if (!gateway.IsConnected)
                    {
                        Console.WriteLine("Could not connect to the quik...");
                    }

                    Thread.Sleep(3000); // Loop until input is entered.
                });

                gateway.Stop();
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION: {0}\n{1}", ex.Message, ex.StackTrace);
                Console.ReadLine();
            }
        }

        private static void OrderChanged(object sender, OrderEventArgs e)
        {
            // Process order here
            Console.WriteLine("--> ORDER: {0} {1}", e.Order, e.OrderDetails);
        }

        private static void TradeChanged(object sender, TradeEventArgs e)
        {
            // Process trade here
            Console.WriteLine("--> TRADE: {0} {1}", e.Trade, e.TradeDetails);
        }

        private static void DoWhileEscNotPressed(Action action)
        {
            var cki = new ConsoleKeyInfo();
            do
            {
                while (Console.KeyAvailable == false)
                {
                    action();
                }

                cki = Console.ReadKey(true);

            } while (cki.Key != ConsoleKey.Escape);
        }
    }
}
