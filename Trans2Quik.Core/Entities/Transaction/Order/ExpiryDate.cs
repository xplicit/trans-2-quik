namespace Trans2Quik.Core
{
    using System;

    public class ExpiryDate
    {
        public static readonly ExpiryDate GTC = new ExpiryDate(true);
        public static readonly ExpiryDate TODAY = new ExpiryDate();

        public bool GoodTillCanceled { get; private set; }
        public DateTime? Date { get; private set; }

        private ExpiryDate(DateTime? date, bool goodTillCanceled)
        {
            this.Date = date;
            this.GoodTillCanceled = goodTillCanceled;
        }
 
        public ExpiryDate(DateTime? date) : this(date, false)
        {
        }

        public ExpiryDate(bool goodTillCanceled) : this(null, goodTillCanceled)
        {
        }
        
        public ExpiryDate() : this(null)
        {
        }

        public override string ToString()
        {
            if (this.GoodTillCanceled)
            {
                return "GTC";
            }

            if (!this.Date.HasValue)
            {
                return "TODAY";
            }

            return this.Date.Value.ToString("yyyyMMdd");
        }
    }
}