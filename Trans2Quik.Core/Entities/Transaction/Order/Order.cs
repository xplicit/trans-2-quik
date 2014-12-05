namespace Trans2Quik.Core
{
    using System.Text;
    using Internals;

    public class Order
    {
        /// <summary>
        /// Уникальный идентификационный номер заявки
        /// </summary>
        public int TransactionId { get; set; }

        /// <summary>
        /// Вид транзакции
        /// </summary>
        public string Action { get; set; }

        /// <summary>
        /// Код класса
        /// </summary>
        public string ClassCode { get; set; }

        /// <summary>
        /// Код инструмента
        /// </summary>
        public string SecCode { get; set; }

        /// <summary>
        /// Количество знаков после запятой цены инструмента
        /// </summary>
        public int SecPoints { get; set; }
        
        /// <summary>
        /// Номер счета трейдера
        /// </summary>
        public string Account { get; set; }
        
        /// <summary>
        /// Код клиента
        /// </summary>
        public string ClientCode { get; set; }

        /// <summary>
        /// Идентификатор участника торгов (код фирмы)
        /// </summary>
        public string FirmId { get; set; }

        /// <summary>
        /// Количество лотов в заявке
        /// </summary>
        public int? Quantity { get; set; }

        /// <summary>
        /// Цена за единицу инструмента
        /// </summary>
        public decimal? Price { get; set; }

        /// <summary>
        /// Направление заявки - продать/купить
        /// </summary>
        public Direction? Operation { get; set; }

        /// <summary>
        /// Тип заявки
        /// </summary>
        public bool? IsLimitOrder { get; set; }

        /// <summary>
        /// Является ли заявка заявкой Маркет Мейкера
        /// </summary>
        public bool? IsMarketMaker { get; set; }

        /// <summary>
        /// Условие исполнения заявки
        /// </summary>
        public ExecCondition? ExecutionCondition { get; set; }

        /// <summary>
        /// Номер заявки, снимаемой с тороговой системы
        /// </summary>
        public string OrderKey { get; set; }

        /// <summary>
        /// Номер стоп-заявки, снимаемой с торговой системы
        /// </summary>
        public string StopOrderKey { get; set; }

        public Order(int transactionId, string account, string action)
        {
            this.TransactionId = transactionId;
            this.Account = account;
            this.Action = action;
        }

        internal Order SetOrderTradeParams(OrderTradeParams orderTradeParams)
        {
            if (orderTradeParams == null)
            {
                return this;
            }

            this.Operation = orderTradeParams.Direction;
            this.Price = orderTradeParams.Price;
            this.Quantity = orderTradeParams.Quantity;
            this.IsLimitOrder = orderTradeParams.IsLimited;

            this.SetSecurity(orderTradeParams.Security);

            return this;
        }

        internal Order SetSecurity(Security security)
        {
            if (security == null)
            {
                return this;
            }

            this.ClassCode = security.ClassCode;
            this.SecCode = security.SecCode;

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendKey("TRANS_ID", this.TransactionId);
            sb.AppendKey("ACTION", this.Action);
            sb.AppendKey("CLASSCODE", this.ClassCode);
            sb.AppendKey("SECCODE", this.SecCode);
            sb.AppendKey("ACCOUNT", this.Account);
            sb.AppendKey("CLIENT_CODE", this.ClientCode);
            sb.AppendKey("FIRM_ID", this.FirmId);
            sb.AppendKey("QUANTITY", this.Quantity);
            sb.AppendKey("PRICE", this.Price, this.SecPoints);
            sb.AppendKey("OPERATION", this.Operation);
            sb.AppendOrderType("TYPE", this.IsLimitOrder);
            sb.AppendKey("MARKET_MAKER_ORDER", this.IsMarketMaker);
            sb.AppendKey("EXECUTION_CONDITION", this.ExecutionCondition);
            sb.AppendKey("ORDER_KEY", this.OrderKey);
            sb.AppendKey("STOP_ORDER_KEY", this.StopOrderKey);

            return sb.ToString().Trim();
        }
    }
}
