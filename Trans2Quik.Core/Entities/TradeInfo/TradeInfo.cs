namespace Trans2Quik.Core
{
    using System.Text;

    public class TradeInfo
    {
        /// <summary>
        /// Признак того, идет ли начальное получение сделок или нет
        /// </summary>
        public TradeInfoMode Mode { get; set; }

        /// <summary>
        /// Номер сделки
        /// </summary>
        public double Number { get; set; }

        /// <summary>
        /// Номер заявки, породившей сделку
        /// </summary>
        public double OrderNumber { get; set; }

        /// <summary>
        /// Код класса
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        ///  Код бумаги
        /// </summary>
        public string SecCode { get; set; }

        /// <summary>
        /// Цена сделки
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        ///  Количество сделки
        /// </summary>
        public int Qty { get; set; }

        /// <summary>
        ///  Направление сделки: Покупка или Продажа
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Объем сделки
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        /// Дескриптор сделки
        /// </summary>
        public int TradeDescriptor { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Mode={0} ", this.Mode);
            sb.AppendFormat("Number={0} ", this.Number);
            sb.AppendFormat("OrderNumber={0} ", this.OrderNumber);
            sb.AppendFormat("ClassCode={0} ", this.ClassCode);
            sb.AppendFormat("SecCode={0} ", this.SecCode);
            sb.AppendFormat("Price={0} ", this.Price);
            sb.AppendFormat("Qty={0} ", this.Qty);
            sb.AppendFormat("Value={0} ", this.Value);
            sb.AppendFormat("Direction={0} ", this.Direction);
            sb.AppendFormat("TradeDescriptor={0} ", this.TradeDescriptor);

            return sb.ToString().Trim();
        }
    }
}
