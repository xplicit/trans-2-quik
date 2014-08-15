namespace Trans2Quik.Core
{
    using System;

    public class ActiveTime
    {
        public DateTime From { get; private set; }
        public DateTime To { get; private set; }

        public ActiveTime(DateTime from, DateTime to)
        {
            this.From = from;
            this.To = to;
        }
    }
}