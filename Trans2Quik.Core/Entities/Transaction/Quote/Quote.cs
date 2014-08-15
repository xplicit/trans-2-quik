namespace Trans2Quik.Core
{
    public class Quote
    {
        public Direction Direction { get; private set; }
        public int Quantity { get; private set; }
        public decimal Price { get; private set; }
        public Security Security { get; private set; }

        public bool IsByMarket
        {
            get
            {
                return this.Price == decimal.Zero;
            }
        }

        public Quote(Security security, Direction direction, int quantity, decimal price = decimal.Zero)
        {
            this.Security = security;
            this.Direction = direction;
            this.Quantity = quantity;
            this.Price = price;
        }
    }
}
