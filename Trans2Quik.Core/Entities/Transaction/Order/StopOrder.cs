namespace Trans2Quik.Core
{
    using System;
    using System.Text;
    using Entities.Transaction.Order;
    using Internals;

    public class StopOrder : Order
    {
        /// <summary>
        /// Стоп-цена за единицу инструмента
        /// </summary>
        public decimal? StopPrice { get; set; }

        /// <summary>
        /// Тип стоп-заявки
        /// </summary>
        public StopOrderKind? OrderKind { get; set; }

        /// <summary>
        /// Класс инструмента условия
        /// </summary>
        public string StopPriceClassCode { get; set; }

        /// <summary>
        /// Код инструмента условия
        /// </summary>
        public string StopPriceSecCode { get; set; }
        
        /// <summary>
        /// Направление предельного изменения стоп-цены
        /// </summary>
        public StopPriceCondition? StopPriceCondition { get; set; }

        /// <summary>
        /// Цена связанной лимитированной заявки
        /// </summary>
        public decimal? LinkedOrderPrice { get; set; }

        /// <summary>
        /// Цена условия стоп-лимит для заявки типа StopOrderKind.TakeProfitAndStopLimit
        /// </summary>
        public decimal? StopPrice2 { get; set; }

        /// <summary>
        /// Срок действия стоп-заявки
        /// </summary>
        public ExpiryDate ExpiryDate { get; set; }

        /// <summary>
        /// Признак исполнения заявки по рыночной цене при наступлении условия "стоп-лимит"
        /// </summary>
        public bool? MarketStopLimit { get; set; }

        /// <summary>
        /// Признак исполнения заявки по рыночной цене при наступлении условаия "тэйк-профит"
        /// </summary>
        public bool? MarketTakeProfit { get; set; }

        /// <summary>
        /// Признак действия заявки типа "Тэйк профит и стоп-лимит" в течение определенного интервала времени
        /// </summary>
        public bool? IsActiveInTime { get; set; }

        /// <summary>
        /// Время начала действия заявки типа "Тэйк профит и стоп-лимит"
        /// </summary>
        public DateTime? ActiveFromTime { get; set; }

        /// <summary>
        /// Время окончания действия заявки типа "Тэйк профит и стоп-лимит"
        /// </summary>
        public DateTime? ActiveToTime { get; set; }

        /// <summary>
        /// Величина отступа от максимума (минимума) цены последней сделки.
        /// </summary>
        public decimal? Offset { get; set; }

        /// <summary>
        /// Единицы измерения отступа
        /// </summary>
        public Units? OffsetUnits { get; set; }

        /// <summary>
        /// Величина защитного спрэда
        /// </summary>
        public decimal? Spread { get; set; }

        /// <summary>
        /// Единицы измерения защитного спрэда
        /// </summary>
        public Units? SpreadUnits { get; set; }

        /// <summary>
        /// Регистрационный номер заявки-условия
        /// </summary>
        public string BaseOrderKey { get; set; }

        /// <summary>
        /// Признак использования в качестве объема заявки "по исполнению" исполненного количества бумаг заявки-условия.
        /// </summary>
        public bool? UseBaseOrderBalance { get; set; }
        
        /// <summary>
        /// Признак активации заявки "по исполнению" при частичном исполнении заявки-условия.
        /// </summary>
        public bool? ActivateIfBaseOrderPartlyFilled { get; set; }

        
        public StopOrder(int transactionId, string account, StopOrderKind kind) : base(transactionId, account, "NEW_STOP_ORDER")
        {
            this.OrderKind = kind;
        }

        internal StopOrder SetStopOrderTradeParams(StopOrderTradeParams stopOrderTradeParams)
        {
            if (stopOrderTradeParams == null)
            {
                return this;
            }

            this.SetOrderTradeParams(stopOrderTradeParams.OrderTradeParams);
            this.StopPrice = stopOrderTradeParams.StopPrice;
            this.ExpiryDate = stopOrderTradeParams.ExpiryDate;
            this.StopPrice2 = stopOrderTradeParams.StopPrice2;

            this.SetActiveTime(stopOrderTradeParams.ActiveTime);
            this.SetProfitCondition(stopOrderTradeParams.ProfitCondition);

            return this;
        }

        internal StopOrder SetProfitCondition(ProfitCondition condition)
        {
            if (condition == null)
            {
                return this;
            }

            this.Offset = condition.Offset;
            this.OffsetUnits = condition.OffsetUnits;
            this.Spread = condition.Spread;
            this.SpreadUnits = condition.SpreadUnits;
            this.MarketStopLimit = condition.MarketStopLimit;
            this.MarketTakeProfit = condition.MarketTakeProfit;

            return this;
        }

        internal StopOrder SetActiveTime(ActiveTime activeTime)
        {
            if (activeTime == null)
            {
                return this;
            }

            this.IsActiveInTime = true;
            this.ActiveFromTime = activeTime.From;
            this.ActiveToTime = activeTime.To;

            return this;
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString() + " ");

            sb.AppendKey("STOPPRICE", this.StopPrice);
            sb.AppendKey("STOP_ORDER_KIND", this.OrderKind);
            sb.AppendKey("STOPPRICE_CLASSCODE", this.StopPriceClassCode);
            sb.AppendKey("STOPPRICE_SECCODE", this.StopPriceSecCode);
            sb.AppendKey("STOPPRICE_CONDITION", this.StopPriceCondition);
            sb.AppendKey("LINKED_ORDER_PRICE", this.LinkedOrderPrice);
            sb.AppendKey("EXPIRY_DATE", this.ExpiryDate);
            sb.AppendKey("STOPPRICE2", this.StopPrice2);
            sb.AppendKey("MARKET_STOP_LIMIT", this.MarketStopLimit);
            sb.AppendKey("MARKET_TAKE_PROFIT", this.MarketTakeProfit);
            sb.AppendKey("IS_ACTIVE_IN_TIME", this.IsActiveInTime);
            sb.AppendKey("ACTIVE_FROM_TIME", this.ActiveFromTime);
            sb.AppendKey("ACTIVE_TO_TIME", this.ActiveToTime);
            sb.AppendKey("OFFSET", this.Offset);
            sb.AppendKey("OFFSET_UNITS", this.OffsetUnits);
            sb.AppendKey("SPREAD", this.Spread);
            sb.AppendKey("SPREAD_UNITS", this.SpreadUnits);
            sb.AppendKey("BASE_ORDER_KEY", this.BaseOrderKey);
            sb.AppendKey("USE_BASE_ORDER_BALANCE", this.UseBaseOrderBalance);
            sb.AppendKey("ACTIVATE_IF_BASE_ORDER_PARTLY_FILLED", this.ActivateIfBaseOrderPartlyFilled);

            return sb.ToString().Trim();
        }
    }
}
