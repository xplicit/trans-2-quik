namespace Trans2Quik.TestConsole
{
    using System;
    using System.Threading;
    using Core;

    class Program
    {
        public static readonly string PathToQuik = @"C:\PSBQuik";

        private static long TxnNumber = 65465984;
        private static string TxnTemplate = @"ACCOUNT=L01+00000F00; TYPE=M; TRANS_ID={0}; CLASSCODE=TQBR; SECCODE=SBER; ACTION=NEW_ORDER; OPERATION={1}; PRICE=0; QUANTITY=1;";

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
            var txn = string.Format(TxnTemplate, TxnNumber++, "B");
            var res = gtw.SendTransaction(txn);
            Console.WriteLine("Send Buy transaction... Success={0}", res);
        }

        private static void Sell(Gateway gtw)
        {
            var txn = string.Format(TxnTemplate, TxnNumber++, "S");
            var res = gtw.SendTransaction(txn);
            Console.WriteLine("Send Sell transaction... Success={0}", res);
        }
    }
}
