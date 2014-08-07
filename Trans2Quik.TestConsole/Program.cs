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
                var server = new Gateway(PathToQuik);
                server.OrderChanged += OrderChanged;
                server.TradeChanged += TradeChanged;

                server.Start();

                var res = server.Subscribe("", "");  // all securities 
                Console.WriteLine("Subscribed={0}", res);

                Console.WriteLine("\nPress a Esc to quit...");

                DoWhileEscNotPressed(() =>
                {
                    // check connection
                    if (!server.IsConnected)
                    {
                        Console.WriteLine("Connecting to the quik...");
                        // try to restart
                        server.Start();
                    }

                    Thread.Sleep(3000); // Loop until input is entered.
                });

                server.Stop();
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
