namespace Trans2Quik.Core
{
    using System.Text;

    public class OrderInfo
    {
        /// <summary>
        ///  Признак того, идет ли начальное получение заявок или нет
        /// </summary>
        public OrderInfoMode Mode { get; set; }

        /// <summary>
        ///  TransID транзакции, породившей заявку. Имеет значение «0», если заявка не была порождена транзакцией из файла, либо если TransID неизвестен
        /// </summary>
        public int TransId { get; set; }

        /// <summary>
        /// Номер заявки
        /// </summary>
        public double Number { get; set; }

        /// <summary>
        /// Код класса
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        /// Код бумаги
        /// </summary>
        public string SecCode { get; set; }

        /// <summary>
        /// Цена заявки
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Неисполненный остаток заявки
        /// </summary>
        public int Balance { get; set; }

        /// <summary>
        /// Объем заявки
        /// </summary>
        public double Value { get; set; }

        /// <summary>
        ///  Направление заявки: Покупка или Продажа
        /// </summary>
        public Direction Direction { get; set; }

        /// <summary>
        /// Состояние исполнения заявки
        /// </summary>
        public OrderInfoStatus Status { get; set; }

        /// <summary>
        /// Дескриптор заявки
        /// </summary>
        public int OrderDescriptor { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendFormat("Mode={0} ", this.Mode);
            sb.AppendFormat("TransId={0} ", this.TransId);
            sb.AppendFormat("Number={0} ", this.Number);
            sb.AppendFormat("ClassCode={0} ", this.ClassCode);
            sb.AppendFormat("SecCode={0} ", this.SecCode);
            sb.AppendFormat("Price={0} ", this.Price);
            sb.AppendFormat("Balance={0} ", this.Balance);
            sb.AppendFormat("Value={0} ", this.Value);
            sb.AppendFormat("Direction={0} ", this.Direction);
            sb.AppendFormat("Status={0} ", this.Status);
            sb.AppendFormat("OrderDescriptor={0} ", this.OrderDescriptor);
            return sb.ToString().Trim();
        }
    }
}
