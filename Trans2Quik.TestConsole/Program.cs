namespace Trans2Quik.TestConsole
{
    using System;
    using System.Threading;
    using Core;

    class Program
    {
        private static string PathToQuik = @"Q:\PSBQuik";
        private static Security Sber = new Security("TQBR", "SBER");
        private static TransactionBuilder TxnBuilder = new TransactionBuilder("L01+00000F00");

        static void Main(string[] args)
        {
            try
            {
                var gateway = new Gateway(PathToQuik);
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

        private static void OrderChanged(object sender, OrderInfoEventArgs e)
        {
            // Process order here
            Console.WriteLine("--> ORDER: {0} {1}", e.OrderInfo, e.OrderInfoDetails);
        }

        private static void TradeChanged(object sender, TradeInfoEventArgs e)
        {
            // Process trade here
            Console.WriteLine("--> TRADE: {0} {1}", e.TradeInfo, e.TradeInfoDetails);
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
                    Buy(gateway);
                }

                if (cki.Key == ConsoleKey.S)
                {
                    Sell(gateway);
                }

            } while (cki.Key != ConsoleKey.Escape);
        }

        private static void Buy(Gateway gtw)
        {
            var txn = TxnBuilder.NewOrder(new OrderTradeParams(Sber, Direction.Buy, 1));
            var res = gtw.SendTransaction(txn.ToString());
            Console.WriteLine("Send Buy transaction... Success={0}", res);
        }

        private static void Sell(Gateway gtw)
        {
            var txn = TxnBuilder.NewOrder(new OrderTradeParams(Sber, Direction.Sell, 1));
            var res = gtw.SendTransaction(txn.ToString());
            Console.WriteLine("Send Sell transaction... Success={0}", res);
        }
    }
}
