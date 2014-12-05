namespace Trans2Quik.Core
{
    public class OrderTradeParams
    {
        public Security Security { get; private set; }
        public Direction Direction { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }

        public bool IsLimited
        {
            get
            {
                return this.Price != decimal.Zero;
            }
        }

        public OrderTradeParams(Security security, Direction direction, int quantity, decimal price = decimal.Zero)
        {
            this.Security = security;
            this.Direction = direction;
            this.Quantity = quantity;
            this.Price = price;
        }
        public OrderTradeParams(string classCode, string secCode, int secPoints, Direction direction, int quantity, decimal price = decimal.Zero)
            : this(new Security(classCode, secCode, secPoints), direction, quantity, price)
        {
        }
    }
}
